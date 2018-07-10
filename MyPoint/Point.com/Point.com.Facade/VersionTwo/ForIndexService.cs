using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Point.com.Model.Base;
using Point.com.Model.VersionTwo;
using Point.com.ServiceInterface.VersionTwo;
using Point.com.ServiceModel.VersionTwo;

namespace Point.com.Facade.VersionTwo
{
    /// <summary>
    /// 首页的数据
    /// </summary>
    public class ForIndexService : BaseService<IForIndex>
    {
        /// <summary>
        /// 获取首页的数据
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public QueryIndexDataPageRes Any(QueryIndexDataPageReq req)
        {
            var res = new QueryIndexDataPageRes();

            try
            {
                var m_req = Mapper.Map<QueryIndexDataPageReq, M_QueryIndexDataPageReq>(req);
                var ptcp = ServiceImpl.QueryIndexDataPage(m_req);
                if (ptcp.DoFlag == PtcpState.Success)
                {
                    res.DoFlag = (int)PtcpState.Success;
                }
                res.DoResult = ptcp.DoResult;

                if (ptcp.ReturnValue.IsNotNull() && ptcp.ReturnValue.PageDatas.IsHasRow())
                {
                    res.Total = ptcp.ReturnValue.Total;
                    res.PageDatas = Mapper.MapperGeneric<M_IndexPageData, IndexPageData>(ptcp.ReturnValue.PageDatas).ToList();
                }
            }
            catch (Exception ex)
            {
                res.DoResult = "系统繁忙，请稍后再试";
            }

            return res;
        }

        /// <summary>
        /// 获取首页的红点(APP logo 上面的红点)
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public QueryIndexRedDotRes Any(QueryIndexRedDotReq req)
        {
            var res = new QueryIndexRedDotRes();

            try
            {
                var ptcp = ServiceImpl.QueryIndexRedDot(req.UserId);
                if (ptcp.DoFlag == PtcpState.Success)
                {
                    res.DoFlag = (int)PtcpState.Success;
                }
                res.DoResult = ptcp.DoResult;
                if (ptcp.DoFlag == PtcpState.Success)
                {
                    res.RedDotCount = ptcp.ReturnValue;
                }
            }
            catch (Exception ex)
            {
                res.DoResult = "系统繁忙，请稍后再试";
            }

            return res;
        }

        /// <summary>
        /// 根据广告ID获取广告商品信息
        /// 根据热卖ID获取热卖商品信息
        ///
        /// (首页是广告类型、热卖推荐时，点击调用的服务，两种类型用这一个服务)
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public QueryAdvGoodsByIdRes Any(QueryAdvGoodsByIdReq req)
        {
            var res = new QueryAdvGoodsByIdRes();

            try
            {
                var m_req = Mapper.Map<QueryAdvGoodsByIdReq, M_QueryAdvGoodsByIdReq>(req);
                var ptcp = ServiceImpl.QueryAdvGoodsById(m_req);
                if (ptcp.DoFlag == PtcpState.Success)
                {
                    res.DoFlag = (int)PtcpState.Success;
                }
                res.DoResult = ptcp.DoResult;

                if (ptcp.ReturnValue.IsNotNull() && ptcp.ReturnValue.AdvGoodsModels.IsHasRow())
                {
                    res.Total = ptcp.ReturnValue.Total;
                    res.Portrait = ptcp.ReturnValue.Portrait;
                    res.NickName = ptcp.ReturnValue.NickName;
                    res.AdvGoodsModels = Mapper.MapperGeneric<M_AdvGoodsModel, AdvGoodsModel>(ptcp.ReturnValue.AdvGoodsModels).ToList();
                }
            }
            catch (Exception ex)
            {
                res.DoResult = "系统繁忙，请稍后再试";
            }

            return res;
        }

        /// <summary>
        /// 广告互动领取现金红包
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public ReceiveRedRes Any(ReceiveRedReq req)
        {
            var res = new ReceiveRedRes();

            try
            {
                var ptcp = ServiceImpl.ReceiveRed(req.UserId, req.GoodsId);
                if (ptcp.DoFlag == PtcpState.Success)
                {
                    res.DoFlag = (int)PtcpState.Success;
                }
                res.DoResult = ptcp.DoResult;

                if (ptcp.ReturnValue.IsNotNull())
                {
                    res.Title = ptcp.ReturnValue.Title;
                    res.ReceiveAmount = ptcp.ReturnValue.ReceiveAmount;
                    res.SurplusCount = ptcp.ReturnValue.SurplusCount;
                }
            }
            catch (Exception ex)
            {
                res.DoResult = "系统繁忙，请稍后再试";
            }

            return res;
        }

        /// <summary>
        /// 查询邀请好友（用于首页点击 DataType = 2 时的明细页面）
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public QueryInvitingFriendsRes Any(QueryInvitingFriendsReq req)
        {
            var res = new QueryInvitingFriendsRes();

            try
            {
                var ptcp = ServiceImpl.QueryInvitingFriends(req.UserId,req.RecSysNo);
                if (ptcp.DoFlag == PtcpState.Success)
                {
                    res.DoFlag = (int)PtcpState.Success;
                }
                res.DoResult = ptcp.DoResult;

                if (ptcp.ReturnValue.IsNotNull())
                {
                    res.InvitingFriends = Mapper.Map<M_InvitingFriendsModel, InvitingFriendsModel>(ptcp.ReturnValue.InvitingFriends);
                }
            }
            catch (Exception ex)
            {
                res.DoResult = "系统繁忙，请稍后再试";
            }

            return res;
        }

        /// <summary>
        /// 领取优惠劵
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public ReceiveCouponRes Any(ReceiveCouponReq req)
        {
            var res = new ReceiveCouponRes();

            try
            {
                var ptcp = ServiceImpl.ReceiveCoupon(req.UserId, req.RecSysNo);
                if (ptcp.DoFlag == PtcpState.Success)
                {
                    res.DoFlag = (int)PtcpState.Success;
                }
                res.DoResult = ptcp.DoResult;

                if (ptcp.ReturnValue.IsNotNull())
                {
                    res.CouponMoney = ptcp.ReturnValue.CouponMoney;
                    res.ReceiveType = ptcp.ReturnValue.ReceiveType;
                    res.ReceiveUrl = ptcp.ReturnValue.ReceiveUrl;
                }
            }
            catch (Exception ex)
            {
                res.DoResult = "系统繁忙，请稍后再试";
            }

            return res;
        }
    }
}
