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
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="advSysNo"></param>
        /// <returns></returns>
        Ptcp<M_QueryAdvGoodsByIdRes> QueryAdvGoodsById(int userid, int advSysNo);

        /// <summary>
        /// 领取红包
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="goodsId"></param>
        /// <returns></returns>
        Ptcp<M_ReceiveRedRes> ReceiveRed(int userid, int goodsId);
    }
}
