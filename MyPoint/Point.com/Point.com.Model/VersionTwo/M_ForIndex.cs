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

    public class M_QueryAdvGoodsByIdRes
    {
        public string Portrait { get; set; }            //头像图片地址
        public string NickName { get; set; }            //昵称

        public List<M_AdvGoodsModel> AdvGoodsModels { get; set; }    //广告商品集合
    }

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
        public decimal CashBonus { get; set; }              //现金红包 客户参与之后发给客户的红包金额 0 不给红包
        public int CashBonusNum { get; set; }               //现金红包的总数量
    }
}
