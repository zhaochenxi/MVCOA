using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using MVCOA.Helper;

namespace MVCOA.Login.Admin
{
    /// <summary>
    /// 系统管理
    /// </summary>
    public class SysController : Controller
    {
        #region 1.0 权限列表 视图 +Permission()
        [HttpGet]
        /// <summary>
        /// 权限列表 视图
        /// </summary>
        /// <returns></returns>
        public ActionResult Permission()
        {
            return View();
        }
        #endregion

        #region 1.1 权限列表 数据 +Permission()
        [HttpPost]
        /// <summary>
        /// 权限列表 视图
        /// </summary>
        /// <returns></returns>
        public ActionResult GetPermData()
        {
            //获取页容量
            int pageSize = int.Parse(Request.Form["rows"]);
            //获取请求页码
            int pageIndex = int.Parse(Request.Form["page"]);

            //1 查询数据
            //var list = OperateContext.Current.BLLSession.IOu_PermissionBLL.GetListBy(p => p.pIsDel == false).Select(p => p.ToPOCO());
            //查询分页数据
            var list = OperateContext.Current.BLLSession.IOu_PermissionBLL.GetPagedList(pageIndex,pageSize,p => p.pIsDel == false,p => p.pid).Select(p => p.ToPOCO());
            int rowCount = OperateContext.Current.BLLSession.IOu_PermissionBLL.GetListBy(p => p.pIsDel == false).Count();
            //2 生成规定格式的 json字符串发回 给 异步对象
            MODEL.EasyUIModel.DataGridModel dgModel = new MODEL.EasyUIModel.DataGridModel()
            {
                total = list.Count(),
                rows = list,
                footer = null
            };
            return Json(dgModel);
        }
        #endregion

        #region 1.2 加载 权限修改 窗体html +EditPermission()
        [HttpGet]
        /// <summary>
        /// 1.2 加载 权限修改 窗体html
        /// </summary>
        /// <returns></returns>
        public ActionResult EditPermission(int id)
        {
            //根据id查询要修改的权限
            var model = OperateContext.Current.BLLSession.IOu_PermissionBLL.GetListBy(p => p.pid == id).FirstOrDefault().ToViewModel();

            SetDropDonwList();

            //将 权限对象 传给 视图 的 Model属性
            return PartialView(model);
        }
        #endregion

        #region 1.2 权限修改 +EditPermission(MODEL.ViewModel.Permission model)
        [HttpPost]
        /// <summary>
        /// 1.2 权限修改
        /// </summary>
        /// <returns></returns>
        public ActionResult EditPermission(MODEL.Ou_Permission model)
        {
            int res = OperateContext.Current.BLLSession.IOu_PermissionBLL.Modify(model, "pName", "pAreaName", "pControllerName", "pActionName", "pFormMethod", "pOperationType", "pOrder", "pIsShow", "pRemark");

            if (res > 0)
                return Redirect("/admin/sys/Permission?ok");
            else
                return Redirect("/admin/sys/Permission?err");
        }
        #endregion

        #region 1.3 新增权限 +AddPermission()
        [HttpPost]
        /// <summary>
        /// 新增权限
        /// </summary>
        /// <returns></returns>
        public ActionResult AddPermission(MODEL.Ou_Permission model)
        {
            model.pIsDel = false;
            model.pAddTime = DateTime.Now;

            int res = OperateContext.Current.BLLSession.IOu_PermissionBLL.Add(model);

            if (res > 0)
                return Redirect("/admin/sys/Permission?ok");
            else
                return Redirect("/admin/sys/Permission?err");
        }
        #endregion

        /// <summary>
        /// 显示 新增权限 表单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AddPermission()
        {
            SetDropDonwList();
            return PartialView("EditPermission");
        }


        //------------------------------------------
        /// <summary>
        /// 设置新增和修改通用的下拉框数据
        /// </summary>
        void SetDropDonwList()
        {
            //准备请求方式下拉框数据
            ViewBag.httpMethodList = new List<SelectListItem>() {
             new SelectListItem(){ Text="Get",Value="1"},
             new SelectListItem(){ Text="Post",Value="2"},
             new SelectListItem(){ Text="Both",Value="3"}
            };

            /*
             0-无操作 1-easyui连接 2-打开新窗体
             */
            ViewBag.operationList = new List<SelectListItem>() {
             new SelectListItem(){ Text="无操作",Value="0"},
             new SelectListItem(){ Text="easyui连接",Value="1"},
             new SelectListItem(){ Text="打开新窗体",Value="2"}
            };
        }
    }
}
