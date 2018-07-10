using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Point.com.Model.VersionTwo
{
    #region 获取首页的数据

    public class M_QueryIndexDataPageReq
    {
        public int UserId { get; set; }          //会员ID 必须
        
        public int PageIndex { get; set; }       //第几页 默认 1 必须 
        public int PageSize { get; set; }        //每页大小 默认 10 必须
    }

    public class M_QueryIndexDataPageRes
    {
        //总的数据条数
        public int Total { get; set; }

        //首页的数据集合
        public List<M_IndexPageData> PageDatas { get; set; }
    }

    #endregion

    #region 根据广告ID获取广告商品信息

    public class M_QueryAdvGoodsByIdReq
    {
        public int UserId { get; set; }          //会员ID 必须

        public int AdvSysNo { get; set; }        //广告ID，热卖类型ID

        public int PageIndex { get; set; }       //第几页 默认 1 必须 
        public int PageSize { get; set; }        //每页大小 默认 10 必须
    }

    public class M_QueryAdvGoodsByIdRes
    {
        public int Total { get; set; }                  //总的数据条数

        public string Portrait { get; set; }            //头像图片地址
        public string NickName { get; set; }            //昵称

        public List<M_AdvGoodsModel> AdvGoodsModels { get; set; }    //广告商品集合
    }

    #endregion

    #region 领取红包

    public class M_ReceiveRedRes
    {
        public string Title { get; set; }            //标题
        public int SurplusCount { get; set; }        //红包剩余数量
        public decimal ReceiveAmount { get; set; }   //领取金额，单位：元
    }

    #endregion 

    #region 查询邀请好友（用于首页点击 DataType = 2 时的明细页面）

    public class M_QueryInvitingFriendsRes
    {
        public M_InvitingFriendsModel InvitingFriends { get; set; }    //邀请好友实体

    }

    #endregion

    #region 领取优惠劵

    public class M_ReceiveCouponRes
    {
        /// <summary>
        /// 领取类型（当 DataType = 2 时有效）
        /// 1 站内补贴现金红包（CouponMoney 此时必须有值）
        /// 2 站外链接地址,此时会去 T_ReceiveConfigure 表找对应的记录
        /// </summary>
        public int ReceiveType { get; set; }

        public decimal CouponMoney { get; set; }        //成功领取的优惠券 ReceiveType = 1 并且  IsReceive = true 并且 CouponMoney > 0 可用 

        public string ReceiveUrl { get; set; }          //领取的地址 ReceiveType = 2 并且 IsReceive = true 有外链的URL地址
    }

    #endregion

    #region 根据分类ID查询商品信息

    public class M_QueryCateGoodsReq
    {
        public int CateId { get; set; }          //分类ID
        public int PageIndex { get; set; }       //第几页 默认 1 必须 
        public int PageSize { get; set; }        //每页大小 默认 10 必须
    }

    public class M_QueryCateGoodsRes
    {
        public int Total { get; set; }          //总的数据条数
        public string CateName { get; set; }    //分类名称

        public List<M_AdvGoodsModel> GoodsModels { get; set; }   //分类商品集合
    }

    #endregion

    #region

    #endregion


    public class M_IndexPageData
    {
        public int SysNo { get; set; }                   //主键，自增长，唯一标识
        public int DataType { get; set; }               //数据类型   1 广告（参与互动，领取红包）   2 推广(邀请好友，立享钜惠)
        public string CoverPicUrl { get; set; }         //封面图片

        public string ShopName { get; set; }            //店铺名称         当 DataType = 2 时，有店铺名称
        public string LogoPicUrl { get; set; }          //店铺logo图片     当 DataType = 2 时，有店铺logo
        public int SetInvitationNum { get; set; }       //需要邀请的人数   当 DataType = 2 时，需要有邀请的人数
        
        /// <summary>
        /// 领取类型（当 DataType = 2 时有效）  1 站内补贴现金红包（CouponMoney 此时必须有值）   2 站外链接地址,此时会去 T_ReceiveConfigure 表找对应的记录
        /// </summary>
        public int ReceiveType { get; set; }            

        public decimal CouponMoney { get; set; }        //优惠券金额       当 DataType = 2 时，需要优惠券金额

        public string Title { get; set; }              //标题
        public string DescOne { get; set; }            //描述1
        public string DescTwo { get; set; }            //描述2
        public decimal MarketPrice { get; set; }       //市场价格
        public decimal PromotionPrice { get; set; }    //促销价格
        public int IntSort { get; set; }               //排序，数值越大越靠前

        /// <summary>
        /// DataType 为 1 广告（参与互动，领取红包） 并且已经参加过互动，会拉取当前广告下面所有的商品
        /// </summary>
        public List<M_AdvGoodsModel> AdvGoodsModels { get; set; }
    }

    public class M_AdvGoodsModel
    {
        public int SysNo { get; set; }                      //主键，自增长 唯一标识，商品ID
        public int AdvSysNo { get; set; }                   //广告ID 对应 B_InforConfigure 表的 SysNo 字段
        public int CateId { get; set; }                     //商品所属分类ID
        public string GoodsName { get; set; }               //商品名称
        public string GoodsPic { get; set; }                //商品图片地址
        public string GoodsDetailedLink { get; set; }       //商品明细连接地址，点击商品图片的地址 如果有值则说明可以点击商品，到这个链接去
        public string GoodsExcLink { get; set; }            //商品兑换链接地址，点击兑换按钮的地址 如果有值则说明可以点击商品，到这个链接去
        public decimal MarketPrice { get; set; }            //市场价格
        public decimal PromotionPrice { get; set; }         //促销价格
        public decimal DeductibleMoney { get; set; }        //抵扣金额

        public int SalesVolume { get; set; }                //销量 对应 B_InforConfigure 表的 DataType = 3 热卖推荐的销售数量

        public decimal CashBonus { get; set; }              //现金红包 客户参与之后发给客户的红包金额 0 不给红包
        public int CashBonusNum { get; set; }               //现金红包的总数量
    }
    
    public class M_InvitingFriendsModel
    {
        public string Portrait { get; set; }            //头像图片地址

        public string NickName { get; set; }            //昵称

        public string ShopName { get; set; }            //店铺名称

        public string LogoPicUrl { get; set; }          //店铺logo

        public int SetInvitationNum { get; set; }       //需要邀请的人数
        
        public bool IsReceive { get; set; }             //是否可以领取  true 可以  false 不可以

        public decimal MarketPrice { get; set; }       //市场价格

        public decimal PromotionPrice { get; set; }    //促销价格

        public decimal CouponMoney { get; set; }        //优惠券金额
        
        public List<string> InvitationMembers { get; set; }  //邀请的会员头像集合
    }
}
