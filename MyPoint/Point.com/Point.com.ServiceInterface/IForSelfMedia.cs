using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Point.com.Model;
using Point.com.Model.Base;

namespace Point.com.ServiceInterface
{
    public interface IForSelfMedia
    {
        /// <summary>
        /// 根据文章ID查询文章信息,用于从首页点击进入阅读文章页面，根据返回数据前端判断是否可以直接阅读或者需要遮罩付费
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Ptcp<M_QueryArticleByIdRes> QueryArticleById(M_QueryArticleByIdReq req);

        /// <summary>
        /// 根据文章ID查询文章信息 h5专门使用 不需要付费可直接阅读
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Ptcp<M_QueryArticleReadByIdRes> QueryArticleReadById(M_QueryArticleReadByIdReq req);

        /// <summary>
        /// 查询作者下面所有的文章信息
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Ptcp<M_QueryAuthorArticleRes> QueryAuthorArticle(M_QueryAuthorArticleReq req);

        /// <summary>
        /// 我的关注列表
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Ptcp<M_QueryMyFollowRes> QueryMyFollow(M_QueryMyFollowReq req);

        /// <summary>
        /// 关注/取消关注
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Ptcp<string> SetFollow(M_SetFollowReq req);

        /// <summary>
        /// 付费阅读
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Ptcp<string> PayRead(M_PayReadReq req);

        /// <summary>
        /// 获取首页的红点数量
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Ptcp<M_QueryHomePageRedDotRes> QueryHomePageRedDot(M_QueryHomePageRedDotReq req);

        /// <summary>
        /// 自媒体文章分析保存手机号码信息，用于注册处理数据
        /// </summary>
        /// <param name="mobile"></param>
        /// <param name="authorSysNo"></param>
        /// <param name="articleSysNo"></param>
        /// <returns></returns>
        Ptcp<string> AddSelfMediaSaveRecord(string mobile, int authorSysNo, int articleSysNo);
    }
}
