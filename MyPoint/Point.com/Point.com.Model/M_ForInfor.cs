using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Point.com.Model.Base;

namespace Point.com.Model
{
    public class M_QueryHomePageReq
    {
        public int UserId { get; set; } //会员ID，如果已经注册并且登录，则必须传递，如果存在会员ID则会影响到返回的数据

        //资讯类型  1 30岁以上男  2 30岁以下男  4 30岁以上女   8 30岁以下女
        public int InfoType { get; set; }

        public int PageIndex { get; set; } //第几页
        public int PageSize { get; set; } //每页大小
    }

    public class M_QueryHomePageRes
    {
        //首页的数据集合
        public List<M_HomePageData> PageDatas { get; set; }

        //总的数据条数
        public int Total { get; set; }
    }

    public class M_QueryShareTitleRes
    {
        public M_HomePageData PageData { get; set; }
    }

    public class M_HomePageData
    {
        public int SysNo { get; set; }               //主键，自增长
        public int DataType { get; set; }            //信息类型  1 咨询、新闻   2 导购咨询(店铺)   4广告咨询（答题 ） 8 自媒体文章
        public string StrInforType { get; set; }     //推送类型 0 所有  1 30岁以上男  2 30岁以下男  4 30岁以上女   8 30岁以下女，格式：[1],[2],[3]
        public string InforName { get; set; }        //信息标题 DataType=8时是 文章标题
        public string InforRemark { get; set; }      //信息的备注信息，自己填写，如：区域    DataType=8时是 文章副标题
        public string InforDesc { get; set; }         //信息描述   DataType=8时是文章的作者
        public string LogoIcon{ get; set; }          //logo图标，店铺的logo
        public string HeadPic { get; set; }           //头图(左右、横排都是这个头图)   DataType=8时是文章的图片
        public string CoverPic{ get; set; }          //封面图片
        public string ShopPic { get; set; }          //店铺列表图片地址
        public string PushPic { get; set; }          //推送页面图片地址
        public string VideoUrl{ get; set; }          //视频地址
        public int? CateId { get; set; }              //店铺的分类ID，只有 InforType 为 2 时，必填
        public int ShowMode { get; set; }            //展示方式  0 横排展示（店铺） 1 横排展示（广告，答题）  2 左右展示
        public int? ShopSysNo { get; set; }            //店铺的ID，只有 InforType 为 4 时，必填，对应当前表 InforType = 2 时
        public string InforSource{ get; set; }       //来源
        public string LinkUrl{ get; set; }           //跳转链接地址
        public int IntSort{ get; set; }              //排序，数值越大越靠前     

        public DateTime SourceDateTime { get; set; }    //来源时间  DataType=8时是文章的时间
        public string StrSourceDateTime { get; set; }  //来源时间   DataType=8时是文章的时间
    }

    public class M_QueryFavoritesReq
    {
        public int UserId { get; set; }      //会员ID
        public int PageIndex { get; set; }   //第几页
        public int PageSize { get; set; }    //每页大小
    }

    public class M_QueryFavoritesRes
    {
        public List<M_HomePageData> PageDatas { get; set; }   //数据集合
        public int Total { get; set; }          //总的数据条数
    }

    public class M_QueryAccountRecommendReq
    {
        public int UserId { get; set; }      //会员ID
        public int PageIndex { get; set; }   //第几页
        public int PageSize { get; set; }    //每页大小
    }

    public class M_QueryAccountRecommendRes
    {
        public List<M_HomePageData> PageDatas { get; set; }   //数据集合
        public int Total { get; set; }                        //总的数据条数
    }

    public class M_QueryNoReadInfoRes
    {
        public int ScoreCount { get; set; }     //兑换消息未读取数量   大于0表示存在未读取的消息
        public int AccountCount { get; set; }    //个人账户未读取消息数量  大于0表示存在未读取的消息
    }

    public class M_QueryShopReq
    {
        public int CateId { get; set; }       //分类ID，为 0 查询全部
        public int PageIndex { get; set; }   //第几页
        public int PageSize { get; set; }    //每页大小
     }

    public class M_QueryShopRes
    {
        public List<M_ShopInfo> ShopInfos { get; set; }
        public int Total { get; set; }          //总的数据条数
    }

    public class M_QueryShopInfoRes
    {
        public M_ShopInfo ShopInfo { get; set; }        //店铺信息
    }

    public class M_QueryShopGoodsReq
    {
        public int ShopId { get; set; }               //店铺ID
        public string GoodsLabelOne { get; set; }     //商品标签   如：是否新品 0 不是  1 是
        public string GoodsLabelTwo { get; set; }     //商品标签   如：是否新品 0 不是  1 是
        
        public int PageIndex { get; set; }            //第几页
        public int PageSize { get; set; }             //每页大小
    }                                               

    public class M_QueryShopGoodsRes
    {
        public List<M_ShopGoodsEntity> GoodsEntities { get; set; }    //店铺商品集合
        public int Total { get; set; }          //总的数据条数
    }

    public class M_QuerySubjectRecommendRes
    {
        public List<M_ShopGoodsEntity> GoodsEntities { get; set; }    //商品集合
    }

    public class M_ShopGoodsEntity
    {
        public int SysNo { get; set; }                      //主键，自增长，唯一
        public int ShopSysNo { get; set; }                  //店铺ID，对应 T_InforConfigure 表sysno
        public string GoodsName { get; set; }               //商品名称
        public string GoodsPic { get; set; }                //商品图片地址
        public string GoodsOutLink { get; set; }            //商品链接地址 如果有值则说明可以点击商品，到这个链接去
        public decimal MarketPrice { get; set; }            //市场价格，门店价格
        public string StrMarketPrice { get; set; }          //市场价格，门店价格

        public string GoodsLabelOne { get; set; }               //商品标签   如：是否新品 0 不是  1 是
        public string GoodsLabelTwo { get; set; }               //商品标签   如：是否新品 0 不是  1 是
        
        public int ExcCouponSysNo { get; set; }             //兑换抵用劵ID，获取到抵用抵用的金额，对应 T_CouponInfo 表的SysNo
        public decimal ExcAmount { get; set; }              //抵用金额
        public string StrExcAmount { get; set; }            //抵用金额
        public int CouponCount { get; set; }                //抵用劵数量
        public int UseCouponCount { get; set; }             //抵用劵使用数量
        public int OverCouponCount { get; set; }            //抵用劵剩余数量

        public M_ExcCouponInfo ExcCoupon { get; set; }      //抵用劵详细信息
    }

    public class M_ShopInfo
    {
        public int SysNo { get; set; }               //主键，自增长
        public string ShopName { get; set; }        //店铺名称
        public string ShopRemark { get; set; }      //店铺的备注信息，自己填写，如：区域
        public string ShopDesc { get; set; }         //店铺描述、说明
        public string LogoIcon { get; set; }          //logo图标，店铺的logo
        public string HeadPic { get; set; }           //头图(左右、横排都是这个头图)
        public string CoverPic { get; set; }          //封面图片
        public string ShopPic { get; set; }          //店铺列表图片地址
        public string PushPic { get; set; }          //推送页面图片地址
        public string VideoUrl { get; set; }          //视频地址
        public int CateId { get; set; }              //店铺的分类ID，只有 InforType 为 2 时，必填
        public string InforSource { get; set; }       //来源
        public string LinkUrl { get; set; }           //跳转链接地址
        public int IntSort { get; set; }              //排序，数值越大越靠前     

        public DateTime SourceDateTime { get; set; }    //来源时间
        public string StrSourceDateTime { get; set; }  //来源时间

        public decimal HighMoney { get; set; }         //最高抵用金额
        public string StrHighMoney { get; set; }         //最高抵用金额
        public int LimitCount { get; set; }             //活动限额
        public int SurplusCount { get; set; }           //剩余数量

        public string GoodsLabelOne { get; set; }               //商品标签   如：是否新品 0 不是  1 是
        public string GoodsLabelTwo { get; set; }               //商品标签   如：是否新品 0 不是  1 是
        public int GoodsLabelOneCount { get; set; }             //商品标签1商品数量
        public int GoodsLabelTwoCount { get; set; }             //商品标签2数量
    }

    public class M_QuerySubjectRes
    {
        public int IsAnswer { get; set; }                       //是否已经回答过了，0 未回答  1 已回答
        public List<M_SubjectEntity> SubjectEntities { get; set; }       //题目
    }

    public class M_QueryShareSubjectRes
    {
        public int IsAnswer { get; set; }                       //是否已经回答过了，0 未回答  1 已回答
        public List<M_SubjectEntity> SubjectEntities { get; set; }       //题目
    }

    public class M_SubjectEntity
    {
        public int SysNo { get; set; }                          //题目ID
        public int InforSysNo { get; set; }                     //信息ID，当 InforSysNo > 0 时说明是广告的一级题目；InforSysNo = 0时，说明是由题目答案引发的题目
        public string ProblemNameUrl { get; set; }              //题目，一个图片地址
        public decimal AnswerMoney { get; set; }                //答题金额
        public string StrAnswerMoney { get; set; }              //答题金额

        public List<M_AnswerEntity> AnswerEntities { get; set; }    //答案
    }

    public class M_AnswerEntity
    {
        public int SysNo { get; set; }                      //答案ID
        public int SubSysNo { get; set; }                   //题目ID
        public int ChildrenSubSysNo { get; set; }           //当前答案关联的题目ID
        public string AnswerNameUrl { get; set; }           //答案，一个图片地址
    }

    public class M_AddAnswerRecordrReq
    {
        public int UserId { get; set; }      //会员ID

        public List<M_AnswerRecordEntity> RecordEntities { get; set; }    //回答问题的记录
    }

    public class M_AddShareAnswerRecordReq
    {
        public string Mobile { get; set; }      //手机号码，必须

        public int ShareUserId { get; set; }    //分享人的会员ID，必须

        public List<M_AnswerRecordEntity> RecordEntities { get; set; }    //回答问题的记录
    }

    public class M_AddShareAnswerRecordRes
    {
        public decimal AnswerMoney { get; set; }                //答题金额
        public string StrAnswerMoney { get; set; }              //答题金额
    }

    public class M_AddAnswerRecordRes
    {
        public decimal AnswerMoney { get; set; }                //答题金额
        public string StrAnswerMoney { get; set; }              //答题金额
    }

    public class M_AnswerRecordEntity
    {
        public int SubSysNo { get; set; }    //题目ID
        public int AnsSysNo { get; set; }    //答案ID
    }

    public class M_ExcCouponReq
    {
        public int UserId { get; set; }      //会员ID
        public int GoodsId { get; set; }     //兑换的商品ID

        public int OrderNo { get; set; }     //充值的ID，订单号，当账户抵佣金不足时必须要进行充值
    }

    public class M_ExcCouponRes
    {
        public M_ExcCouponInfo ExcCoupon { get; set; }   //兑换成功返回的信息
    }

    public class M_QueryCouponInfoReq
    {
        public int ExcCouponSysNo { get; set; }      //抵用劵ID
    }

    public class M_QueryCouponInfoRes
    {
        public M_ExcCouponInfo ExcCoupon { get; set; }   //抵用劵信息
    }

    public class M_ExcCouponInfo
    {
        public string ShopName { get; set; }           //店铺名称
        public string ShopRemark { get; set; }         //店铺备注
        public string ShopDesc { get; set; }           //信息的备注信息，自己填写，如：区域
        public string LogoIcon { get; set; }           //店铺logo
        public string HeadPic { get; set; }            //头图(左右、横排都是这个头图)
        public string CoverPic { get; set; }           //封面图片、背景图片
        public string ShopPic { get; set; }          //店铺列表图片地址
        public string PushPic { get; set; }          //推送页面图片地址

        public string GoodsName { get; set; }            //商品名称
        public string GoodsPic { get; set; }             //商品图片
        public decimal ExcAmount { get; set; }           //抵用金额
        public string StrExcAmount { get; set; }         //抵用金额

        public string StrIsEffective { get; set; }       //有效，无效

        public int CouponType { get; set; }              //抵用金的类型   1 链接  2 二维码、条形码  4 公码  8 私码
        public string CouponValue { get; set; }             //抵用金的值，可能是链接地址、二维码或者条形码图片地址、码

        public string UseRule { get; set; }              //使用规则
        public string RuleContent { get; set; }          //规则内容
    }

    public class M_CheckFavoritesRes
    {
        public int CheckRes { get; set; }            //0 没有收藏   1 已经收藏过了
    }

    public class M_QueryMyCouponReq
    {
        public int UserId { get; set; }      //会员ID
        public int PageIndex { get; set; }            //第几页
        public int PageSize { get; set; }             //每页大小
    }

    public class M_QueryMyCouponRes
    {
        public int Total { get; set; }          //总的数据条数
        public List<M_ExcCouponInfo> ExcCoupons { get; set; }    //抵用劵列表
    }

    public class M_SubjectParticipateRes
    {
        public string ParticipateCount { get; set; }                   //参数总数，如：+1568  超过1000，显示为：+1.5K，只显示最新的6个会员
        public List<M_ParticipateRecord> Participates { get; set; }    //参与记录
    }

    public class M_ParticipateRecord
    {
        public int UserId { get; set; }              //会员ID
        public string Portrait { get; set; }         //会员头像地址 
        public string NickName { get; set; }         //会员昵称
    }
}
