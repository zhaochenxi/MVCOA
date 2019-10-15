using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    /// <summary>
    /// 数据层的仓储接口,里面包含所有的数据层接口
    /// </summary>
    public partial interface IDBSession
    {
        int SaveChanges();
    }
}
