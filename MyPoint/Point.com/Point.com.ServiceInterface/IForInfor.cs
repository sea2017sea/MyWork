using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Point.com.Model;
using Point.com.Model.Base;

namespace Point.com.ServiceInterface
{
    public interface IForInfor
    {
        /// <summary>
        /// 获取首页的数据 1个小时的缓存
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Ptcp<M_QueryHomePageRes> QueryHomePage(M_QueryHomePageReq req);

        /// <summary>
        /// 根据分类ID查询店铺列表信息
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Ptcp<M_QueryShopRes> QueryShop(M_QueryShopReq req);

        /// <summary>
        /// 根据店铺ID查询店铺信息
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Ptcp<M_QueryShopInfoRes> QueryShopInfo(int shopId);

        /// <summary>
        /// 根据店铺ID，获取店铺下面所有的商品信息
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Ptcp<M_QueryShopGoodsRes> QueryShopGoods(M_QueryShopGoodsReq req);

        /// <summary>
        /// 根据广告(答题)咨询ID获取所有的题目信息
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="inforSysNo"></param>
        /// <returns></returns>
        Ptcp<M_QuerySubjectRes> QuerySubject(int userId, int inforSysNo);

        /// <summary>
        /// 分享 没有注册会员时 根据广告(答题)咨询ID获取所有的题目信息
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="inforSysNo"></param>
        /// <returns></returns>
        Ptcp<M_QueryShareSubjectRes> QueryShareSubject(string moblie, int inforSysNo);

        /// <summary>
        /// 答题推荐商品
        /// </summary>
        /// <param name="rootSubSysNo">根题，第一道题的ID</param>
        /// <param name="ansSysNo"></param>
        /// <returns></returns>
        Ptcp<M_QuerySubjectRecommendRes> QuerySubjectRecommend(int rootSubSysNo, int ansSysNo);

        /// <summary>
        /// 获取参与答题的会员记录(头像、数量)
        /// </summary>
        /// <param name="inforSysNo"></param>
        /// <returns></returns>
        Ptcp<M_SubjectParticipateRes> SubjectParticipate(int inforSysNo);

        /// <summary>
        /// 保存答案，获得奖励金
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Ptcp<M_AddAnswerRecordRes> AddAnswerRecord(M_AddAnswerRecordrReq req);

        /// <summary>
        /// h5 分享会员不存在 保存答案，获得奖励金
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Ptcp<M_AddShareAnswerRecordRes> AddShareAnswerRecord(M_AddShareAnswerRecordReq req);

        /// <summary>
        /// 兑换抵用劵
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Ptcp<M_ExcCouponRes> ExcCoupon(M_ExcCouponReq req);

        /// <summary>
        /// 根据抵用劵ID获取抵用劵信息、店铺名称、图标
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Ptcp<M_QueryCouponInfoRes> QueryCouponInfo(M_QueryCouponInfoReq req);

        /// <summary>
        /// 我的抵用劵列表
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Ptcp<M_QueryMyCouponRes> QueryMyCoupon(M_QueryMyCouponReq req);

        /// <summary>
        /// 检查是否已经收藏了
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="dataType">咨讯类型 只能是资讯才能收藏</param>
        /// <param name="InforSysNo">咨讯ID</param>
        /// <returns></returns>
        Ptcp<M_CheckFavoritesRes> CheckFavorites(int userid, int dataType, int InforSysNo);

        /// <summary>
        /// 收藏
        /// </summary>
        /// <param name="userid">会员ID</param>
        /// <param name="dataType">咨讯类型 只能是资讯才能收藏</param>
        /// <param name="InforSysNo">咨讯ID</param>
        /// <returns></returns>
        Ptcp<string> AddFavorites(int userid, int dataType, int InforSysNo);

        /// <summary>
        /// 获取我的收藏
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Ptcp<M_QueryFavoritesRes> QueryFavorites(M_QueryFavoritesReq req);

        /// <summary>
        /// 取消我的收藏
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="sysNo"></param>
        /// <returns></returns>
        Ptcp<string> CancelFavorites(int userid, int sysNo);

        /// <summary>
        /// 查询账户中心推荐数据
        /// PS：调用本服务之后，前端需要自行处理掉对应页面上面的红点，后端服务会修改标识
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Ptcp<M_QueryAccountRecommendRes> QueryAccountRecommend(M_QueryAccountRecommendReq req);

        /// <summary>
        /// 更新会员中心数据为已读状态，一次性全部更新掉所有的未读消息
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        Ptcp<string> UpdateAccountRecordPush(int userid);

        /// <summary>
        /// 获取兑换或个人账户中心未读取消息数量
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        Ptcp<M_QueryNoReadInfoRes> QueryNoReadInfo(int userid);

        /// <summary>
        /// 根据ID查询分享的标题
        /// </summary>
        /// <param name="sysno"></param>
        /// <returns></returns>
        Ptcp<string> QueryShareTitle(int sysno);
    }
}
