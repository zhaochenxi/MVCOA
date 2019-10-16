using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLA
{
    public partial class Ou_UserInfo : IBLL.IOu_UserInfoBLL
    {
        public MODEL.Ou_UserInfo Login(string strName, string strPwd)
        {
            //根据登录名查询Ou_UserInfo
            MODEL.Ou_UserInfo usr = base.GetListBy(u => u.uLoginName == strName).Select(u => u.ToPOCO()).First();
            //判断是否登陆成功
            if (usr != null && usr.uPwd == Common.DataHelper.MD5(strPwd))
            {
                return usr;
            }
            return null;

        }
    }
}
