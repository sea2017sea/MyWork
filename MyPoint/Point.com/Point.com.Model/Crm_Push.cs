//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Point.com.Model
{
    using System;
    using System.Collections.Generic;
    
    [Serializable]
    			public partial class Crm_Push:ModelBase
    {
        public Nullable<int> SysNo { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> PushType { get; set; }
        public string GoodsPic { get; set; }
        public string GoodsName { get; set; }
        public Nullable<int> PushCount { get; set; }
        public Nullable<int> ClickCount { get; set; }
        public string Remark { get; set; }
        public Nullable<System.DateTime> RowCeateDate { get; set; }
        public Nullable<System.DateTime> ModifyTime { get; set; }
        public Nullable<bool> IsEnable { get; set; }
    }
}
