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
    
    public partial class WF_BillFlowNode
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WF_BillFlowNode()
        {
            this.WF_BillFlowNodeRemark = new HashSet<WF_BillFlowNodeRemark>();
        }
    
        public int BillFlowNodeID { get; set; }
        public Nullable<int> WorkFlowNodeID { get; set; }
        public Nullable<int> NodeStateID { get; set; }
        public Nullable<int> WorkFlowID { get; set; }
        public Nullable<int> BillID { get; set; }
    
        public virtual WF_WorkFlowNode WF_WorkFlowNode { get; set; }
        public virtual WF_NodeState WF_NodeState { get; set; }
        public virtual WF_WorkFlow WF_WorkFlow { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WF_BillFlowNodeRemark> WF_BillFlowNodeRemark { get; set; }
    }
}