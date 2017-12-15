using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Point.com.Logging;
using Point.com.Model;
using Point.com.Model.Base;
using Point.com.ServiceInterface;
using Point.com.ServiceModel;

namespace Point.com.Facade
{
    public class ForInforService : BaseService<IForInfor>
    {
        /// <summary>
        /// 获取首页的数据 1个小时的缓存
        /// 如果是题目类型，则需要去掉当前会员已经回答过的题了
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public QueryHomePageRes Any(QueryHomePageReq req)
        {
            var res = new QueryHomePageRes();

            try
            {
                var m_req = Mapper.Map<QueryHomePageReq, M_QueryHomePageReq>(req);
                var ptcp = ServiceImpl.QueryHomePage(m_req);
                if (ptcp.DoFlag == PtcpState.Success)
                {
                    res.DoFlag = (int)PtcpState.Success;
                }
                res.DoResult = ptcp.DoResult;

                if (ptcp.ReturnValue.IsNotNull() && ptcp.ReturnValue.PageDatas.IsHasRow())
                {
                    res.Total = ptcp.ReturnValue.Total;
                    res.PageDatas = Mapper.MapperGeneric<M_HomePageData, HomePageData>(ptcp.ReturnValue.PageDatas).ToList();
                }
            }
            catch (Exception ex)
            {
                res.DoResult = "系统繁忙，请稍后再试";
            }

            return res;
        }

        /// <summary>
        /// 根据分类ID查询店铺列表信息
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public QueryShopRes Any(QueryShopReq req)
        {
            var res = new QueryShopRes();

            try
            {
                var m_req = Mapper.Map<QueryShopReq, M_QueryShopReq>(req);
                var ptcp = ServiceImpl.QueryShop(m_req);
                if (ptcp.DoFlag == PtcpState.Success)
                {
                    res.DoFlag = (int)PtcpState.Success;
                }
                res.DoResult = ptcp.DoResult;

                if (ptcp.ReturnValue.IsNotNull() && ptcp.ReturnValue.ShopInfos.IsHasRow())
                {
                    res.Total = ptcp.ReturnValue.Total;
                    res.ShopInfos = Mapper.MapperGeneric<M_ShopInfo, ShopInfo>(ptcp.ReturnValue.ShopInfos).ToList();
                }
            }
            catch (Exception ex)
            {
                res.DoResult = "系统繁忙，请稍后再试";
            }

            return res;
        }

        /// <summary>
        /// 根据店铺ID查询店铺信息
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public QueryShopInfoRes Any(QueryShopInfoReq req)
        {
            var res = new QueryShopInfoRes();

            try
            {
                var ptcp = ServiceImpl.QueryShopInfo(req.ShopId);
                if (ptcp.DoFlag == PtcpState.Success)
                {
                    res.DoFlag = (int)PtcpState.Success;
                }
                res.DoResult = ptcp.DoResult;

                if (ptcp.ReturnValue.IsNotNull() && ptcp.ReturnValue.ShopInfo.IsNotNull())
                {
                    res.ShopInfo = Mapper.Map<M_ShopInfo, ShopInfo>(ptcp.ReturnValue.ShopInfo);
                }
            }
            catch (Exception ex)
            {
                res.DoResult = "系统繁忙，请稍后再试";
            }

            return res;
        }

        /// <summary>
        /// 根据店铺ID，获取店铺下面所有的商品信息
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public QueryShopGoodsRes Any(QueryShopGoodsReq req)
        {
            var res = new QueryShopGoodsRes();

            try
            {
                var m_req = Mapper.Map<QueryShopGoodsReq, M_QueryShopGoodsReq>(req);
                var ptcp = ServiceImpl.QueryShopGoods(m_req);
                if (ptcp.DoFlag == PtcpState.Success)
                {
                    res.DoFlag = (int)PtcpState.Success;
                }
                res.DoResult = ptcp.DoResult;

                if (ptcp.ReturnValue.IsNotNull() && ptcp.ReturnValue.GoodsEntities.IsNotNull())
                {
                    res.Total = ptcp.ReturnValue.Total;
                    res.GoodsEntities = Mapper.MapperGeneric<M_ShopGoodsEntity, ShopGoodsEntity>(ptcp.ReturnValue.GoodsEntities).ToList();
                }
            }
            catch (Exception ex)
            {
                res.DoResult = "系统繁忙，请稍后再试";
            }

            return res;
        }

        /// <summary>
        /// 根据广告(答题)咨询ID获取所有的题目信息
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public QuerySubjectRes Any(QuerySubjectReq req)
        {
            var res = new QuerySubjectRes();

            try
            {
                var ptcp = ServiceImpl.QuerySubject(req.UserId,req.InforSysNo);
                if (ptcp.DoFlag == PtcpState.Success)
                {
                    res.DoFlag = (int)PtcpState.Success;
                }
                res.DoResult = ptcp.DoResult;

                if (ptcp.ReturnValue.IsNotNull() && ptcp.ReturnValue.SubjectEntities.IsNotNull())
                {
                    res.IsAnswer = ptcp.ReturnValue.IsAnswer;
                    res.SubjectEntities = Mapper.MapperGeneric<M_SubjectEntity, SubjectEntity>(ptcp.ReturnValue.SubjectEntities).ToList();
                }
            }
            catch (Exception ex)
            {
                res.DoResult = "系统繁忙，请稍后再试";
            }

            return res;
        }

        /// <summary>
        /// 根据广告(答题)咨询ID获取所有的题目信息
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public QueryShareSubjectRes Any(QueryShareSubjectReq req)
        {
            var res = new QueryShareSubjectRes();

            try
            {
                var ptcp = ServiceImpl.QueryShareSubject(req.Moblie, req.InforSysNo);
                if (ptcp.DoFlag == PtcpState.Success)
                {
                    res.DoFlag = (int)PtcpState.Success;
                }
                res.DoResult = ptcp.DoResult;

                if (ptcp.ReturnValue.IsNotNull() && ptcp.ReturnValue.SubjectEntities.IsNotNull())
                {
                    res.IsAnswer = ptcp.ReturnValue.IsAnswer;
                    res.SubjectEntities = Mapper.MapperGeneric<M_SubjectEntity, SubjectEntity>(ptcp.ReturnValue.SubjectEntities).ToList();
                }
            }
            catch (Exception ex)
            {
                res.DoResult = "系统繁忙，请稍后再试";
            }

            return res;
        }

        /// <summary>
        /// 答题推荐商品
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public QuerySubjectRecommendRes Any(QuerySubjectRecommendReq req)
        {
            var res = new QuerySubjectRecommendRes();

            try
            {
                var ptcp = ServiceImpl.QuerySubjectRecommend(req.RootSubSysNo,req.AnsSysNo);
                if (ptcp.DoFlag == PtcpState.Success)
                {
                    res.DoFlag = (int)PtcpState.Success;
                }
                res.DoResult = ptcp.DoResult;

                if (ptcp.ReturnValue.IsNotNull() && ptcp.ReturnValue.GoodsEntities.IsNotNull())
                {
                    res.GoodsEntities = Mapper.MapperGeneric<M_ShopGoodsEntity, ShopGoodsEntity>(ptcp.ReturnValue.GoodsEntities).ToList();
                }
            }
            catch (Exception ex)
            {
                res.DoResult = "系统繁忙，请稍后再试";
            }

            return res;
        }

        /// <summary>
        /// 获取参与答题的会员记录(头像、数量)
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public SubjectParticipateRes Any(SubjectParticipateReq req)
        {
            var res = new SubjectParticipateRes();

            try
            {
                var ptcp = ServiceImpl.SubjectParticipate(req.InforSysNo);
                if (ptcp.DoFlag == PtcpState.Success)
                {
                    res.DoFlag = (int)PtcpState.Success;
                }
                res.DoResult = ptcp.DoResult;

                if (ptcp.ReturnValue.IsNotNull() && ptcp.ReturnValue.Participates.IsNotNull())
                {
                    res.ParticipateCount = ptcp.ReturnValue.ParticipateCount;
                    res.Participates = Mapper.MapperGeneric<M_ParticipateRecord, ParticipateRecord>(ptcp.ReturnValue.Participates).ToList();
                }
            }
            catch (Exception ex)
            {
                res.DoResult = "系统繁忙，请稍后再试";
            }

            return res;
        }

        /// <summary>
        /// 保存答案，获得奖励金
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public AddAnswerRecordRes Any(AddAnswerRecordReq req)
        {
            var res = new AddAnswerRecordRes();


            try
            {
                M_AddAnswerRecordrReq m_req = new M_AddAnswerRecordrReq();
                if (req.IsNotNull())
                {
                    m_req.UserId = req.UserId;

                    if (!string.IsNullOrEmpty(req.Parameter))
                    {
                        List<M_AnswerRecordEntity> answerRecord =
                            SerializerCollection.JsonSerializer.Deserialize<List<M_AnswerRecordEntity>>(req.Parameter);
                        m_req.RecordEntities = answerRecord;
                    }
                }

                var ptcp = ServiceImpl.AddAnswerRecord(m_req);
                if (ptcp.DoFlag == PtcpState.Success)
                {
                    res.DoFlag = (int)PtcpState.Success;
                }
                res.DoResult = ptcp.DoResult;

                if (ptcp.ReturnValue.IsNotNull())
                {
                    res.AnswerMoney = ptcp.ReturnValue.AnswerMoney;
                    res.StrAnswerMoney = ptcp.ReturnValue.StrAnswerMoney;
                }
            }
            catch (Exception ex)
            {
                res.DoResult = "系统繁忙，请稍后再试";
            }

            return res;
        }

        /// <summary>
        /// h5 分享会员不存在 保存答案，获得奖励金
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public AddShareAnswerRecordRes Any(AddShareAnswerRecordReq req)
        {
            var res = new AddShareAnswerRecordRes();

            try
            {
                M_AddShareAnswerRecordReq m_req = new M_AddShareAnswerRecordReq();
                if (req.IsNotNull())
                {
                    m_req.Mobile = req.Mobile;

                    if (!string.IsNullOrEmpty(req.Parameter))
                    {
                        List<M_AnswerRecordEntity> answerRecord =
                            SerializerCollection.JsonSerializer.Deserialize<List<M_AnswerRecordEntity>>(req.Parameter);
                        m_req.RecordEntities = answerRecord;
                    }
                }

                var ptcp = ServiceImpl.AddShareAnswerRecord(m_req);
                if (ptcp.DoFlag == PtcpState.Success)
                {
                    res.DoFlag = (int)PtcpState.Success;
                }
                res.DoResult = ptcp.DoResult;

                if (ptcp.ReturnValue.IsNotNull())
                {
                    res.AnswerMoney = ptcp.ReturnValue.AnswerMoney;
                    res.StrAnswerMoney = ptcp.ReturnValue.StrAnswerMoney;
                }
            }
            catch (Exception ex)
            {
                res.DoResult = "系统繁忙，请稍后再试";
            }

            return res;
        }

        /// <summary>
        /// 兑换抵用劵
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public ExcCouponRes Any(ExcCouponReq req)
        {
            var res = new ExcCouponRes();

            try
            {
                var m_req = Mapper.Map<ExcCouponReq, M_ExcCouponReq>(req);
                var ptcp = ServiceImpl.ExcCoupon(m_req);
                if (ptcp.DoFlag == PtcpState.Success)
                {
                    res.DoFlag = (int)PtcpState.Success;
                }
                res.DoResult = ptcp.DoResult;

                if (ptcp.ReturnValue.IsNotNull() && ptcp.ReturnValue.ExcCoupon.IsNotNull())
                {
                    res.ExcCoupon = Mapper.Map<M_ExcCouponInfo, ExcCouponInfo>(ptcp.ReturnValue.ExcCoupon);
                }
            }
            catch (Exception ex)
            {
                res.DoResult = "系统繁忙，请稍后再试";
            }

            return res;
        }

        /// <summary>
        ///  根据抵用劵ID获取抵用劵信息、店铺名称、图标
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public QueryCouponInfoRes Any(QueryCouponInfoReq req)
        {
            var res = new QueryCouponInfoRes();

            try
            {
                var m_req = Mapper.Map<QueryCouponInfoReq, M_QueryCouponInfoReq>(req);
                var ptcp = ServiceImpl.QueryCouponInfo(m_req);
                if (ptcp.DoFlag == PtcpState.Success)
                {
                    res.DoFlag = (int)PtcpState.Success;
                }
                res.DoResult = ptcp.DoResult;

                if (ptcp.ReturnValue.IsNotNull() && ptcp.ReturnValue.ExcCoupon.IsNotNull())
                {
                    res.ExcCoupon = Mapper.Map<M_ExcCouponInfo, ExcCouponInfo>(ptcp.ReturnValue.ExcCoupon);
                }
            }
            catch (Exception ex)
            {
                res.DoResult = "系统繁忙，请稍后再试";
            }

            return res;
        }

        /// <summary>
        /// 我的抵用劵列表
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public QueryMyCouponRes Any(QueryMyCouponReq req)
        {
            var res = new QueryMyCouponRes();

            try
            {
                var m_req = Mapper.Map<QueryMyCouponReq, M_QueryMyCouponReq>(req);
                var ptcp = ServiceImpl.QueryMyCoupon(m_req);
                if (ptcp.DoFlag == PtcpState.Success)
                {
                    res.DoFlag = (int)PtcpState.Success;
                }
                res.DoResult = ptcp.DoResult;

                if (ptcp.ReturnValue.IsNotNull() && ptcp.ReturnValue.ExcCoupons.IsNotNull())
                {
                    res.Total = ptcp.ReturnValue.Total;
                    res.ExcCoupons = Mapper.MapperGeneric<M_ExcCouponInfo, ExcCouponInfo>(ptcp.ReturnValue.ExcCoupons).ToList();
                }
            }
            catch (Exception ex)
            {
                res.DoResult = "系统繁忙，请稍后再试";
            }

            return res;
        }

        /// <summary>
        /// 检查是否已经收藏了
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public CheckFavoritesRes Any(CheckFavoritesReq req)
        {
            var res = new CheckFavoritesRes();
            try
            {
                var ptcp = ServiceImpl.CheckFavorites(req.UserId, req.DataType, req.InforSysNo);
                if (ptcp.DoFlag == PtcpState.Success)
                {
                    res.DoFlag = (int)PtcpState.Success;
                }


                if (ptcp.ReturnValue.IsNotNull())
                {
                    res.CheckRes = ptcp.ReturnValue.CheckRes;
                }
                res.DoResult = ptcp.DoResult;
            }
            catch (Exception ex)
            {
                res.DoResult = "系统繁忙，请稍后再试";
                res.DoFlag = -8;
            }

            return res;
        }

        /// <summary>
        /// 收藏
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public AddFavoritesRes Any(AddFavoritesReq req)
        {
            var res = new AddFavoritesRes();

            try
            {
                var ptcp = ServiceImpl.AddFavorites(req.UserId,req.DataType,req.InforSysNo);
                if (ptcp.DoFlag == PtcpState.Success)
                {
                    res.DoFlag = (int) PtcpState.Success;
                }
                res.DoResult = ptcp.DoResult;
            }
            catch (Exception ex)
            {
                res.DoResult = "系统繁忙，请稍后再试";
            }

            return res;
        }

        /// <summary>
        /// 获取我的收藏
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public QueryFavoritesRes Any(QueryFavoritesReq req)
        {
            var res = new QueryFavoritesRes();

            try
            {
                var m_req = Mapper.Map<QueryFavoritesReq, M_QueryFavoritesReq>(req);
                var ptcp = ServiceImpl.QueryFavorites(m_req);
                if (ptcp.DoFlag == PtcpState.Success)
                {
                    res.DoFlag = (int)PtcpState.Success;
                }
                res.DoResult = ptcp.DoResult;

                if (ptcp.ReturnValue.IsNotNull() && ptcp.ReturnValue.PageDatas.IsHasRow())
                {
                    res.Total = ptcp.ReturnValue.Total;
                    res.PageDatas = Mapper.MapperGeneric<M_HomePageData, HomePageData>(ptcp.ReturnValue.PageDatas).ToList();
                }
            }
            catch (Exception ex)
            {
                res.DoResult = "系统繁忙，请稍后再试";
            }

            return res;
        }

        /// <summary>
        /// 取消收藏
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public CancelFavoritesRes Any(CancelFavoritesReq req)
        {
            var res = new CancelFavoritesRes();

            try
            {
                var ptcp = ServiceImpl.CancelFavorites(req.UserId,req.SysNo);
                if (ptcp.DoFlag == PtcpState.Success)
                {
                    res.DoFlag = (int)PtcpState.Success;
                }
                res.DoResult = ptcp.DoResult;
            }
            catch (Exception ex)
            {
                res.DoResult = "系统繁忙，请稍后再试";
            }

            return res;
        }

        /// <summary>
        /// 查询账户中心推荐数据 
        /// PS：调用本服务之后，前端需要自行处理掉对应页面上面的红点，后端服务会修改标识
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public QueryAccountRecommendRes Any(QueryAccountRecommendReq req)
        {
            var res = new QueryAccountRecommendRes();

            try
            {
                var m_req = Mapper.Map<QueryAccountRecommendReq, M_QueryAccountRecommendReq>(req);
                var ptcp = ServiceImpl.QueryAccountRecommend(m_req);
                if (ptcp.DoFlag == PtcpState.Success)
                {
                    res.DoFlag = (int)PtcpState.Success;
                }
                res.DoResult = ptcp.DoResult;

                if (ptcp.ReturnValue.IsNotNull() && ptcp.ReturnValue.PageDatas.IsHasRow())
                {
                    res.Total = ptcp.ReturnValue.Total;
                    res.PageDatas = Mapper.MapperGeneric<M_HomePageData, HomePageData>(ptcp.ReturnValue.PageDatas).ToList();
                }
            }
            catch (Exception ex)
            {
                res.DoResult = "系统繁忙，请稍后再试";
            }

            return res;
        }

        /// <summary>
        /// 更新会员中心数据为已读状态，一次性全部更新掉所有的未读消息
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public UpdateAccountRecordPushRes Any(UpdateAccountRecordPushReq req)
        {
            var res = new UpdateAccountRecordPushRes();

            try
            {
                var ptcp = ServiceImpl.UpdateAccountRecordPush(req.UserId);
                if (ptcp.DoFlag == PtcpState.Success)
                {
                    res.DoFlag = (int)PtcpState.Success;
                }
                res.DoResult = ptcp.DoResult;
            }
            catch (Exception ex)
            {
                res.DoResult = "系统繁忙，请稍后再试";
            }

            return res;
        }

        /// <summary>
        /// 获取兑换或个人账户中心未读取消息数量
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public QueryNoReadInfoRes Any(QueryNoReadInfoReq req)
        {
            var res = new QueryNoReadInfoRes();

            try
            {
                var ptcp = ServiceImpl.QueryNoReadInfo(req.UserId);
                if (ptcp.DoFlag == PtcpState.Success)
                {
                    res.DoFlag = (int)PtcpState.Success;
                }
                res.DoResult = ptcp.DoResult;

                if (ptcp.ReturnValue.IsNotNull())
                {
                    res.AccountCount = ptcp.ReturnValue.AccountCount;
                    res.ScoreCount = ptcp.ReturnValue.ScoreCount;
                }
            }
            catch (Exception ex)
            {
                res.DoResult = "系统繁忙，请稍后再试";
            }

            return res;
        }

        /// <summary>
        /// 根据ID查询分享的标题
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public QueryShareTitleRes Any(QueryShareTitleReq req)
        {
            var res = new QueryShareTitleRes();

            try
            {
                var ptcp = ServiceImpl.QueryShareTitle(req.SysNo);
                if (ptcp.DoFlag == PtcpState.Success)
                {
                    res.DoFlag = (int)PtcpState.Success;
                }
                res.DoResult = ptcp.DoResult;
            }
            catch (Exception ex)
            {
            }

            return res;
        }
    }
}
