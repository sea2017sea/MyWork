using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Point.com.Common
{
    public class Enums
    {
        public static readonly int CashProportion = 100;              //充值比例  1元人民币 = 100抵扣劵
        public static readonly int TiXianProportion = 100;            //提现比例   100抵扣劵 = 1元人民币
        public static readonly string ScoreName = "抵用金";
        public static readonly string Rmb = "元";

        /// <summary>
        /// 来源渠道
        /// </summary>
        public enum SourceTypeSysNo
        {
            [Description("没有填写")]
            Default = 0,
            [Description("安卓")]
            AndroIdApp = 1,
            [Description("IOS")]
            IosApp = 2
        }

        /// <summary>
        /// 操作日志类型
        /// </summary>
        public enum OperationLog
        {
            Login = 1,                  //登录
            InforClick = 2,             //资讯点击
            ShopClick = 4,              //商品点击
            DuiHuanClick = 8            //兑换点击
        }

        /// <summary>
        /// 性别
        /// </summary>
        public enum Sex
        {
            secrecy = 0,     //保密
            men = 1,         //男
            women = 2,       //女
        }

        /// <summary>
        /// 短信类型
        /// </summary>
        public enum SmsType
        {
            Reg = 1,                //注册
            Login = 2,              //登录
            PwdBack = 4,            //密码找回
        }

        /// <summary>
        /// 短信验证码状态
        /// </summary>
        public enum SmsStatus
        {
            No = 0,                //未验证
            OK = 1,              //已验证
            Fail = 2,            //验证失败
        }

        /// <summary>
        /// 会员查询
        /// </summary>
        public enum SelectCustomer
        {
            UserId = 1,           //根据会员ID查询
            Mobile = 2           //根据手机号码查询
        }

        /// <summary>
        /// 上传图片的类型
        /// </summary>
        public enum UploadType
        {
            Def = 0,      //默认
            Head = 1,     //头像
            goods = 2       //商品
        }

        /// <summary>
        /// 资讯类型
        /// </summary>
        public enum InforType
        {
            Man30Up = 1,                //30岁以上男
            Man30Lower = 2,             //30岁以下男
            Woman30Up = 4,              //30岁以上女
            Woman30Lower = 8,            //30岁以下女
            NotBirthday = 100            //没有填写生日的类型
        }

        /// <summary>
        /// 数据类型
        /// </summary>
        public enum DataType
        {
            News = 1,         //咨询、新闻
            Shop = 2,         //导购、店铺
            Adv = 4,          //广告、答题
        }

        /// <summary>
        /// 账号交易类型、流水类型
        /// </summary>
        public enum TranType
        {
            Partic = 1,          //参与互动
            Share = 2,           //邀请好友，分享好友
            PurchaseScore = 4,   //转出抵用金
            Sell = 8,            //转入抵用金
            TiXian = 16,         //提现
            ExcGoods = 32,       //兑换商品(兑换抵用劵)
            ReadArticle = 64,    //阅读文章，扣减低佣金
            SaveSelfMedia = 128,    //自媒体分享，注册手机号码，获取低佣金
            Share_New = 70,      //新版参与互动  
            RecCoupon = 71,      //新版领取优惠劵-现金红包  
        }

        /// <summary>
        /// 抵用劵类型
        /// </summary>
        public enum CouponType
        {
            Url = 1,                 //链接地址
            CodeUrl = 2,             //二维码、条形码的链接地址
            PubCode = 4,             //公码
            PriCode = 8              //私码
        }

        /// <summary>
        /// 积分转让处理状态
        /// </summary>
        public enum TurnState
        {
            Untreated = 0,             //未处理
            InProcess = 1,             //处理中
            Complete = 2,              //处理完成
        }

        /// <summary>
        /// 提现处理状态
        /// </summary>
        public enum WithdrawalsState
        {
            Untreated = 0,             //未处理
            InProcess = 1,             //处理中
            Complete = 2,              //处理完成
        }

        /// <summary>
        /// 支付状态
        /// </summary>
        public enum PayState
        {
            NoPay = 0,             //未支付
            PayIng = 1,             //支付中
            Complete = 2,           //支付完成
        }

        /// <summary>
        /// 抵用劵状态  0 有效  1 无效  2 已使用
        /// </summary>
        public enum CouponState
        {
            Ok = 0,          //有效
            No = 1,          //无效
            Use = 2,         //已使用
        }
    }
}
