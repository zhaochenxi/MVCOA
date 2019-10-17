using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVCOA.Login.Admin
{
    /// <summary>
    /// 管理员登陆等相关业务
    /// </summary>
    public class AdminController : Controller
    {
        #region 1.0 管理员登陆页面 + ActionResult Login()
        /// <summary>
        /// 1.0 管理员登陆页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        #endregion


        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
            MODEL.FormatModel.AjaxMsgModel ajaxM = new MODEL.FormatModel.AjaxMsgModel()
            {
                Statu = "err",
                Msg = "登陆失败"
            };

            //获取数据
            string strName = form["txtName"];
            string strPwd = form["txtPwd"];
            //验证
            //通过操作上下位获取用户业务接口对象，调用里面的登陆方法！
            MODEL.Ou_UserInfo usr = Helper.OperateContext.BLLSession.IOu_UserInfoBLL.Login(strName, strPwd);
            
            if ( usr != null)
            {
                //保存用户数据到session里
                Session["ainfo"] = usr;

                //用cookie记住登陆数据
                if (!string.IsNullOrEmpty(form["isAllway"]))
                {
                    //将用户id加密成字符串
                    string strCookieValue = Common.SecurityHelper.EncryptUserInfo(usr.uId.ToString());
                    //创建Cookie
                    HttpCookie cookie = new HttpCookie("ainfo", strCookieValue);
                    cookie.Expires = DateTime.Now.AddDays(1);
                    cookie.Path = "/admin/";
                    Response.Cookies.Add(cookie);

                }
                //查询当前用户权限，并将权限存入Session
                List<MODEL.Ou_Permission> listPers = Helper.OperateContext.GetUserPermission(usr.uId);
                Session["uPermission"] = listPers;

                ajaxM.Statu = "ok";
                ajaxM.Msg = "登陆成功";
                ajaxM.BackUrl = "/admin/admin/index";
            }
            
            return Json(ajaxM);
        }

        [HttpGet]
        public ActionResult Index()
        { return View(); }

    }
}
