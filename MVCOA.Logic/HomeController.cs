using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MVCOA.Logic
{
    public class HomeController:Controller
    {
        /// <summary>
        /// 测试方法，读取所有的权限数据
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            List<MODEL.Ou_Permission> list = Helper.OperateContext.BLLSession.IOu_PermissionBLL.GetListBy(t => t.pIsDel == false);
            return View(list);
        }
    }
}
