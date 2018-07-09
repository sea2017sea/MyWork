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
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public QueryAdvGoodsByIdRes Any(QueryAdvGoodsByIdReq req)
        {
            var res = new QueryAdvGoodsByIdRes();

            try
            {
                var ptcp = ServiceImpl.QueryAdvGoodsById(req.UserId,req.AdvSysNo);
                if (ptcp.DoFlag == PtcpState.Success)
                {
                    res.DoFlag = (int)PtcpState.Success;
                }
                res.DoResult = ptcp.DoResult;

                if (ptcp.ReturnValue.IsNotNull() && ptcp.ReturnValue.AdvGoodsModels.IsHasRow())
                {
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

    }
}
