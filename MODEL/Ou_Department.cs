//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace MODEL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ou_Department
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ou_Department()
        {
            this.Ou_Role = new HashSet<Ou_Role>();
            this.Ou_UserInfo = new HashSet<Ou_UserInfo>();
        }
    
        public int depId { get; set; }
        public int depPid { get; set; }
        public string depName { get; set; }
        public string depRemark { get; set; }
        public bool depIsDel { get; set; }
        public System.DateTime depAddTime { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ou_Role> Ou_Role { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ou_UserInfo> Ou_UserInfo { get; set; }
    }
}
