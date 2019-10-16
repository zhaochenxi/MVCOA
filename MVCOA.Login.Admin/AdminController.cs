using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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



    }
}
