using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Point.com.Model;
using Point.com.Model.Base;
using Point.com.ServiceInterface;
using Point.com.ServiceModel;

namespace Point.com.Facade
{
    /// <summary>
    /// 自媒体
    /// </summary>
    public class ForSelfMediaService : BaseService<IForSelfMedia>
    {
        /// <summary>
        /// 根据文章ID查询文章信息,用于从首页点击进入阅读文章页面，根据返回数据前端判断是否可以直接阅读或者需要遮罩付费
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public QueryArticleByIdRes Any(QueryArticleByIdReq req)
        {
            var res = new QueryArticleByIdRes();

            try
            {
                var m_req = Mapper.Map<QueryArticleByIdReq, M_QueryArticleByIdReq>(req);
                var ptcp = ServiceImpl.QueryArticleById(m_req);
                if (ptcp.DoFlag == PtcpState.Success)
                {
                    res.DoFlag = (int)PtcpState.Success;
                }
                res.DoResult = ptcp.DoResult;

                if (ptcp.ReturnValue.IsNotNull() && ptcp.ReturnValue.ArticleEntity.IsNotNull() && ptcp.ReturnValue.AuthorEntity.IsNotNull())
                {
                    res.ArticleEntity = Mapper.Map<M_ArticleEntity, ArticleEntity>(ptcp.ReturnValue.ArticleEntity);
                    res.AuthorEntity = Mapper.Map<M_AuthorEntity, AuthorEntity>(ptcp.ReturnValue.AuthorEntity);
                }
            }
            catch (Exception ex)
            {
                res.DoResult = "系统繁忙，请稍后再试";
            }

            return res;
        }

        /// <summary>
        /// 根据文章ID查询文章信息 h5专门使用 不需要付费可直接阅读
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public QueryArticleReadByIdRes Any(QueryArticleReadByIdReq req)
        {
            var res = new QueryArticleReadByIdRes();

            try
            {
                var m_req = Mapper.Map<QueryArticleReadByIdReq, M_QueryArticleReadByIdReq>(req);
                var ptcp = ServiceImpl.QueryArticleReadById(m_req);
                if (ptcp.DoFlag == PtcpState.Success)
                {
                    res.DoFlag = (int)PtcpState.Success;
                }
                res.DoResult = ptcp.DoResult;

                if (ptcp.ReturnValue.IsNotNull() && ptcp.ReturnValue.ArticleEntity.IsNotNull() && ptcp.ReturnValue.AuthorEntity.IsNotNull())
                {
                    res.ArticleEntity = Mapper.Map<M_ArticleEntity, ArticleEntity>(ptcp.ReturnValue.ArticleEntity);
                    res.AuthorEntity = Mapper.Map<M_AuthorEntity, AuthorEntity>(ptcp.ReturnValue.AuthorEntity);
                }
            }
            catch (Exception ex)
            {
                res.DoResult = "系统繁忙，请稍后再试";
            }

            return res;
        }

        /// <summary>
        /// 查询作者下面所有的文章信息
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public QueryAuthorArticleRes Any(QueryAuthorArticleReq req)
        {
            var res = new QueryAuthorArticleRes();

            try
            {
                var m_req = Mapper.Map<QueryAuthorArticleReq, M_QueryAuthorArticleReq>(req);
                var ptcp = ServiceImpl.QueryAuthorArticle(m_req);
                if (ptcp.DoFlag == PtcpState.Success)
                {
                    res.DoFlag = (int)PtcpState.Success;
                }
                res.DoResult = ptcp.DoResult;

                if (ptcp.ReturnValue.IsNotNull() && ptcp.ReturnValue.ArticleEntities.IsNotNull() && ptcp.ReturnValue.AuthorEntity.IsNotNull())
                {
                    res.ArticleEntities = Mapper.MapperGeneric<M_ArticleEntity, ArticleEntity>(ptcp.ReturnValue.ArticleEntities).ToList();
                    res.AuthorEntity = Mapper.Map<M_AuthorEntity, AuthorEntity>(ptcp.ReturnValue.AuthorEntity);
                    res.Total = ptcp.ReturnValue.Total;
                }
            }
            catch (Exception ex)
            {
                res.DoResult = "系统繁忙，请稍后再试";
            }

            return res;
        }

        /// <summary>
        /// 我的关注列表
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public QueryMyFollowRes Any(QueryMyFollowReq req)
        {
            var res = new QueryMyFollowRes();

            try
            {
                var m_req = Mapper.Map<QueryMyFollowReq, M_QueryMyFollowReq>(req);
                var ptcp = ServiceImpl.QueryMyFollow(m_req);
                if (ptcp.DoFlag == PtcpState.Success)
                {
                    res.DoFlag = (int)PtcpState.Success;
                }
                res.DoResult = ptcp.DoResult;

                if (ptcp.ReturnValue.IsNotNull() && ptcp.ReturnValue.AuthorEntities.IsNotNull() && ptcp.ReturnValue.AuthorEntities.IsHasRow())
                {
                    res.AuthorEntities = Mapper.MapperGeneric<M_AuthorEntity, AuthorEntity>(ptcp.ReturnValue.AuthorEntities).ToList();
                }
            }
            catch (Exception ex)
            {
                res.DoResult = "系统繁忙，请稍后再试";
            }

            return res;
        }

        /// <summary>
        /// 关注/取消关注
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public SetFollowRes Any(SetFollowReq req)
        {
            var res = new SetFollowRes();

            try
            {
                var m_req = Mapper.Map<SetFollowReq, M_SetFollowReq>(req);
                var ptcp = ServiceImpl.SetFollow(m_req);
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
        /// 付费阅读
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public PayReadRes Any(PayReadReq req)
        {
            var res = new PayReadRes();

            try
            {
                var m_req = Mapper.Map<PayReadReq, M_PayReadReq>(req);
                var ptcp = ServiceImpl.PayRead(m_req);
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
        /// 获取首页的红点数量
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public QueryHomePageRedDotRes Any(QueryHomePageRedDotReq req)
        {
            var res = new QueryHomePageRedDotRes();

            try
            {
                var m_req = Mapper.Map<QueryHomePageRedDotReq, M_QueryHomePageRedDotReq>(req);
                var ptcp = ServiceImpl.QueryHomePageRedDot(m_req);
                if (ptcp.DoFlag == PtcpState.Success)
                {
                    res.DoFlag = (int)PtcpState.Success;
                }
                res.DoResult = ptcp.DoResult;

                if (ptcp.ReturnValue.IsNotNull())
                {
                    res.RedCount = ptcp.ReturnValue.RedCount;
                }
            }
            catch (Exception ex)
            {
                res.DoResult = "系统繁忙，请稍后再试";
            }

            return res;
        }

        /// <summary>
        /// 自媒体文章分析保存手机号码信息，用于注册处理数据
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public AddSelfMediaSaveRecordRes Any(AddSelfMediaSaveRecordReq req)
        {
            var res = new AddSelfMediaSaveRecordRes();

            try
            {
                var ptcp = ServiceImpl.AddSelfMediaSaveRecord(req.Mobile,req.AuthorSysNo,req.ArticleSysNo);
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
    }
}
