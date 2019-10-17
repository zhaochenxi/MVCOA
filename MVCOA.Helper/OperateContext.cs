using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCOA.Helper
{
    public class OperateContext
    {
        public static IBLL.IBLLSession BLLSession = DI.SpringHelper.GetObject<IBLL.IBLLSession>("BLLSession");

        #region 根据用户id查询用户权限
        /// <summary>
        /// 根据用户id查询用户权限
        /// </summary>
        /// <param name="usrId"></param>
        public static List<MODEL.Ou_Permission> GetUserPermission(int usrId)
        {
            //----------用户角色对应的权限
            //用户id 获取对应 角色Id
            List<int> listRoleId = BLLSession.IOu_UserRoleBLL.GetListBy(ur => ur.urUId == usrId).Select(ur => ur.urRId).ToList();
            //角色Id 获取对应 权限Id
            List<int> listPerIds = BLLSession.IOu_RolePermissionBLL.GetListBy(rp => listRoleId.Contains(rp.rpRId)).Select(rp => rp.rpPId).ToList();
            //权限Id 获取对应 权限数据
            List<MODEL.Ou_Permission> listPermission = BLLSession.IOu_PermissionBLL.GetListBy(p => listPerIds.Contains(p.pid)).ToList();

            //----------用户特权权限
            //用户id 获取对应 vip权限id
            List<int> vipPerIds = BLLSession.IOu_UserVipPermissionBLL.GetListBy(vip => vip.vipUserId == usrId).Select(vip => vip.vipPermission).ToList();
            //vip权限id 获取对应 权限数据
            List<MODEL.Ou_Permission> listPermission2 = BLLSession.IOu_PermissionBLL.GetListBy(p => vipPerIds.Contains(p.pid)).ToList();

            //将两个权限集合合并
            listPermission2.ForEach(p =>
            {
                listPermission.Add(p);
            });

            return listPermission;
        } 
        #endregion
    }
}
