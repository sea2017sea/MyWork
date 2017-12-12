using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Point.com.Model.Base;

namespace Point.com.Model
{
    public class M_AddAppReq : M_BaseModel
    {
        //手机号码
        public string Mobile { get; set; }

        //APP的名称
        public List<string> AppName { get; set; }
    }

    public class M_QueryCategoryRes
    {
        //分类集合
        public List<M_CategoryEntity> Entities { get; set; }
    }

    public class M_CategoryEntity
    {
        //分类ID
        public int CateId { get; set; }
        //分类名称
        public string CateName { get; set; }
        //分类图标
        public string CatePic { get; set; }
    }

    public class M_QueryAccountRecordReq
    {
        //会员ID
        public int UserId { get; set; }
    }

    public class M_QueryAccountRecordRes
    {
        //账户流水记录
        public List<M_AccountRecordEntity> Entities { get; set; }
    }

    public class M_AccountRecordEntity
    {
        public string TranName { get; set; }                     //交易类型名称
        public int TranType { get; set; }                        //交易类型  1 回答问题（参与互动）    2 邀请好友（分享好友）  4 转出积分  8 转入积分 16 现金提现 32 兑换商品(兑换抵扣劵)
        public string PicUrl { get; set; }                       //图标地址
        public int PlusReduce { get; set; }                      //交易获取或者使用 1增加 2 使用（减）
        
        public decimal TranNum { get; set; }                     //交易金额
        public string StrTranNum { get; set; }                   //交易金额

        public int IsPushIn { get; set; }                       //站内是否推送，红点展示，0 为推送 1 推送  2推送失败
        //public int IsPushOut { get; set; }                      //站外是否推送，红点展示，0 为推送 1 推送  2推送失败

        public Nullable<System.DateTime> RowCeateDate { get; set; }    //交易时间
        public string StrRowCeateDate { get; set; }                    //交易时间
    }

    public class M_AddAccountRecordReq
    {
        //交易类型  1 回答问题（参与互动）    2 邀请好友（分享好友）  4 购买积分  8 出售积分 16 现金提现
        public int TranType { get; set; }
        public int UserId { get; set; }         //会员ID
        public decimal TranNum { get; set; }    //交易的抵佣金金额
        public string InRemarks { get; set; }   //内部备注，如：来源于哪里，关键ID等信息
    }

    //public class M_AddRechargeReq
    //{
    //    public int UserId { get; set; }                     //会员ID
    //    public int ShopSysNo { get; set; }                  //店铺ID
    //    public int GoodsSysNo { get; set; }                 //商品ID
    //    public string PaymentNumber { get; set; }           //充值金额
    //    public decimal RechargeAmount { get; set; }         //第三方平台充值的唯一交易流水号
    //}

    //public class M_AddRechargeRes
    //{
    //    public int RechargeSysNo { get; set; }   //充值成功的ID，兑换抵扣劵余额不足时需要此ID
    //}

    public class M_ScoreTurnReq
    {
        public int UserId { get; set; }                     //会员ID
        public decimal ScoreTurn { get; set; }              //转让的积分
    }

    public class M_CreatePaymentReq
    {
        public int UserId { get; set; }                  //会员ID
        public int GoodsSysNo { get; set; }              //商品ID
        public decimal RechargeAmount { get; set; }      //充值的金额 单位：元
    }

    public class M_CreatePaymentRes
    {
        public int OrderNo { get; set; }                //订单号
        public string ApiParam { get; set; }            //支付请求参数
        //public M_OrderEntity OrderEntity { get; set; }     //订单信息
    }

    public class M_OrderEntity
    {
        public int UserId { get; set; }                           //会员ID
        public int OrderNo { get; set; }                          //订单号
        public int GoodsSysNo { get; set; }                       //店铺商品ID 对应 T_ShopGoods 表的 sysno
        public string GoodsName { get; set; }                     //商品名称
        public decimal RechargeAmount { get; set; }               //充值金额，订单金额
        public string StrRechargeAmount { get; set; }             //充值金额，订单金额
    }

    public class M_UpdatePayStateReq
    {
        public int UserId { get; set; }                           //会员ID
        public int OrderNo { get; set; }                          //订单号
        public decimal RechargeAmount { get; set; }               //充值金额，订单金额
        public string PaymentNumber { get; set; }                 //支付流水，第三方的
        public DateTime? PayTime { get; set; }                    //支付时间
        public int PayState { get; set; }                         //支付状态 ，0 未支付 1 支付中 2 支付成功
    }
}
