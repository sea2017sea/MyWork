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
    			public partial class T_SelfMediaSaveRecord:ModelBase
    {
        public Nullable<int> SysNo { get; set; }
        public string Mobile { get; set; }
        public Nullable<int> AuthorSysNo { get; set; }
        public Nullable<int> ArticleSysNo { get; set; }
        public Nullable<decimal> TranNum { get; set; }
        public Nullable<int> IsTransfer { get; set; }
        public Nullable<System.DateTime> RowCeateDate { get; set; }
        public Nullable<System.DateTime> ModifyTime { get; set; }
        public Nullable<bool> IsEnable { get; set; }
    }
}
