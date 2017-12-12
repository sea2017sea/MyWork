using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Point.com.Model
{
    public class M_GetWxPayRequestDataReq
    {
        public int UserId { get; set; }                           //会员ID
        public int OrderNo { get; set; }                          //订单号
        public decimal RechargeAmount { get; set; }               //充值金额，订单金额 元
        public string GoodsName { get; set; }                     //商品名称
    }
}
