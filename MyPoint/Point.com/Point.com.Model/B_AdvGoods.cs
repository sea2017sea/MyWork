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
    			public partial class B_AdvGoods:ModelBase
    {
        public Nullable<int> SysNo { get; set; }
        public Nullable<int> AdvSysNo { get; set; }
        public Nullable<int> CateId { get; set; }
        public string GoodsName { get; set; }
        public string GoodsPic { get; set; }
        public string GoodsDetailedLink { get; set; }
        public string GoodsExcLink { get; set; }
        public Nullable<decimal> MarketPrice { get; set; }
        public Nullable<decimal> PromotionPrice { get; set; }
        public Nullable<decimal> DeductibleMoney { get; set; }
        public Nullable<decimal> CashBonus { get; set; }
        public Nullable<int> CashBonusNum { get; set; }
        public Nullable<int> IntSort { get; set; }
        public Nullable<System.DateTime> RowCeateDate { get; set; }
        public Nullable<System.DateTime> ModifyTime { get; set; }
        public Nullable<bool> IsEnable { get; set; }
    }
}
