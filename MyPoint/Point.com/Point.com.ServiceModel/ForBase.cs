using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Point.com.ServiceModel.Base;

namespace Point.com.ServiceModel
{
    public class LocalCacheAllReq
    {
    }

    public class LocalCacheAllRes : BaseResponse
    {

    }

    public class AddAppReq:BaseModel
    {
        //手机号码
        public string Mobile { get; set; }

        //APP的名称
        public List<string> AppName { get; set; }
    }

    public class AddAppRes : BaseResponse
    {

    }

    public class AppImgUploadReq : BaseModel
    {
        //上传图片的类型   0 默认  1 上传头像  2 上传商品图片 
        public int UploadType { get; set; }

    }

    public class AppImgUploadRes : BaseResponse
    {
        //图片链接(绝对路径)
        public string ImgUrl { get; set; }
    }

    public class QueryCategoryReq
    {
    }

    public class QueryCategoryRes : BaseResponse
    {
        //分类集合
        public List<CategoryEntity> Entities { get; set; }
    }

    public class CategoryEntity
    {
        public int CateId { get; set; }           //分类ID
        public string CateName { get; set; }      //分类名称
        public string CateDescOne { get; set; }   //分类描述1
        public string CateDescTwo { get; set; }   //分类描述2
        public string CatePic { get; set; }       //分类图标
    }

    public class QueryAccountRecordReq
    {
        //会员ID
        public int UserId { get; set; }
    }

    public class QueryAccountRecordRes : BaseResponse
    {
        //账户流水记录
        public List<AccountRecordEntity> Entities { get; set; }
    }

    public class AccountRecordEntity
    {
        public string TranName { get; set; }                     //交易类型名称
        public int TranType { get; set; }                        //交易类型  1 回答问题（参与互动）    2 邀请好友（分享好友）  4 转出积分  8 转入积分 16 现金提现 32 兑换商品(兑换抵用劵)
        public string PicUrl { get; set; }                       //图标地址
        public int PlusReduce { get; set; }                      //交易获取或者使用 1增加 2 使用（减）

        public decimal TranNum { get; set; }                     //交易金额
        public string StrTranNum { get; set; }                   //交易金额

        public int IsPushIn { get; set; }                       //站内是否推送，红点展示，0 为推送 1 推送  2推送失败

        public Nullable<System.DateTime> RowCeateDate { get; set; }    //交易时间
        public string StrRowCeateDate { get; set; }                    //交易时间
    }

    public class AddAccountRecordReq
    {
        //交易类型  1 回答问题（参与互动）    2 邀请好友（分享好友）  4 购买积分  8 出售积分 16 现金提现
        public int TranType { get; set; }
        public int UserId { get; set; }         //会员ID
        public decimal TranNum { get; set; }    //交易的抵佣金金额
    }

    public class AddAccountRecordRes : BaseResponse
    {

    }

    public class AddRechargeReq
    {
        public int UserId { get; set; }                     //会员ID
        public int ShopSysNo { get; set; }                  //店铺ID
        public int GoodsSysNo { get; set; }                 //商品ID
        public string PaymentNumber { get; set; }           //充值金额
        public decimal RechargeAmount { get; set; }         //第三方平台充值的唯一交易流水号
    }

    public class AddRechargeRes : BaseResponse
    {
        public int RechargeSysNo { get; set; }   //充值成功的ID，兑换抵用劵余额不足时需要此ID
    }

    public class ScoreTurnReq
    {
        public int UserId { get; set; }                     //会员ID
        public decimal ScoreTurn { get; set; }              //转让的积分
    }

    public class ScoreTurnRes : BaseResponse
    {

    }

    public class MemberWithdrawalsReq
    {
        public int UserId { get; set; }                     //会员ID
    }

    public class MemberWithdrawalsRes : BaseResponse
    {

    }

    public class MemberWithdrawalsTwoReq
    {
        public int UserId { get; set; }                     //会员ID
        public decimal Amount { get; set; }                 //提现金额 是经过 Score / 100 换算之后的金额
    }

    public class MemberWithdrawalsTwoRes : BaseResponse
    {

    }

    public class CreatePaymentReq
    {
        public int UserId { get; set; }                  //会员ID
        public int GoodsSysNo { get; set; }              //商品ID
        public decimal RechargeAmount { get; set; }      //充值的金额 单位：元
    }

    public class CreatePaymentRes : BaseResponse
    {
        public int OrderNo { get; set; }                //订单号
        public string ApiParam { get; set; }            //支付请求参数
        //public OrderEntity OrderEntity { get; set; }     //订单信息
    }

    public class OrderEntity
    {
        public int UserId { get; set; }                           //会员ID
        public int OrderNo { get; set; }                          //订单号
        public int GoodsSysNo { get; set; }                       //店铺商品ID 对应 T_ShopGoods 表的 sysno
        public string GoodsName { get; set; }                     //商品名称
        public decimal RechargeAmount { get; set; }               //充值金额，订单金额
        public string StrRechargeAmount { get; set; }             //充值金额，订单金额
    }

    public class UpdatePayStateReq
    {
        public int UserId { get; set; }                           //会员ID
        public int OrderNo { get; set; }                          //订单号
        public decimal RechargeAmount { get; set; }               //充值金额，订单金额
        public string PaymentNumber { get; set; }                 //支付流水，第三方的
        public DateTime? PayTime { get; set; }                    //支付时间
        public int PayState { get; set; }                         //支付状态 ，0 未支付 1 支付中 2 支付成功
    }

    public class UpdatePayStateRes : BaseResponse
    {

    }

    public class QueryPayStateReq
    {
        public int UserId { get; set; }                           //会员ID
        public int OrderNo { get; set; }                          //订单号
    }

    public class QueryPayStateRes : BaseResponse
    {

    }

    public class AddJiGuangPushReq
    {
        public int UserId { get; set; }                           //会员ID
        public string JiGuangSysNo { get; set; }                  //极光用户的唯一标识
        public int SourceTypeSysNo { get; set; }                  //来源渠道 1 安卓  2 IOS
    }

    public class AddJiGuangPushRes : BaseResponse
    {

    }
}
