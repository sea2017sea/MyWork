using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Point.com.Model.Base;
using Point.com.Model.VersionTwo;

namespace Point.com.ServiceInterface.VersionTwo
{
    /// <summary>
    /// 首页的数据
    /// </summary>
    public interface IForIndex
    {
        /// <summary>
        /// 首页的数据
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Ptcp<M_QueryIndexDataPageRes> QueryIndexDataPage(M_QueryIndexDataPageReq req);

        /// <summary>
        /// 获取首页的红点(APP logo 上面的红点)
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        Ptcp<int> QueryIndexRedDot(int userid);

        /// <summary>
        /// 根据广告ID获取广告商品信息
        /// 根据热卖ID获取热卖商品信息
        ///
        /// (首页是广告类型、热卖推荐时，点击调用的服务，两种类型用这一个服务)
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Ptcp<M_QueryAdvGoodsByIdRes> QueryAdvGoodsById(M_QueryAdvGoodsByIdReq req);

        /// <summary>
        /// 领取红包
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="goodsId"></param>
        /// <returns></returns>
        Ptcp<M_ReceiveRedRes> ReceiveRed(int userid, int goodsId);

        /// <summary>
        /// 查询邀请好友（用于首页点击 DataType = 2 时的明细页面）
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="recSysNo">B_InforConfigure 表 DataType = 2 时的 SysNo</param>
        /// <returns></returns>
        Ptcp<M_QueryInvitingFriendsRes> QueryInvitingFriends(int userid, int recSysNo);

        /// <summary>
        /// 领取优惠劵
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="recSysNo"></param>
        /// <returns></returns>
        Ptcp<M_ReceiveCouponRes> ReceiveCoupon(int userid, int recSysNo);

        /// <summary>
        /// 根据分类ID查询商品信息
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Ptcp<M_QueryCateGoodsRes> QueryCateGoods(M_QueryCateGoodsReq req);
    }
}
