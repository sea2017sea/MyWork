using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Point.com.Common;
using Point.com.Model;
using Point.com.Model.Base;
using Point.com.ServiceInterface;

namespace Point.com.ServiceImplement
{
    /// <summary>
    /// 自媒体
    /// </summary>
    public class ForSelfMediaImpl : BaseService, IForSelfMedia
    {
        private static ForBaseImpl fb = new ForBaseImpl();
        private static MemberDepImpl mem = new MemberDepImpl();

        /// <summary>
        /// 根据文章ID查询文章信息,用于从首页点击进入阅读文章页面，根据返回数据前端判断是否可以直接阅读或者需要遮罩付费
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public Ptcp<M_QueryArticleByIdRes> QueryArticleById(M_QueryArticleByIdReq req)
        {
            var ptcp = new Ptcp<M_QueryArticleByIdRes>();

            if (req.IsNull())
            {
                ptcp.DoResult = "非法请求";
                return ptcp;
            }

            if (req.ArticleSysNo <= 0)
            {
                ptcp.DoResult = "文章ID错误";
                return ptcp;
            }

            //获取当前文章信息
            var artciclInfo = DbSession.MLT.T_SelfMediaArticleRepository.QueryBy(new T_SelfMediaArticle()
            {
                SysNo = req.ArticleSysNo,
                IsEnable = true
            }).FirstOrDefault();

            if (artciclInfo.IsNull() || artciclInfo.SysNo <= 0)
            {
                ptcp.DoResult = "未能获取到信息";
                return ptcp;
            }

            //获取当前作者信息
            var authorInfo = DbSession.MLT.T_SelfMediaAuthorRepository.QueryBy(new T_SelfMediaAuthor()
            {
                SysNo = artciclInfo.AuthorSysNo,
                IsEnable = true
            }).FirstOrDefault();

            if (authorInfo.IsNull() || authorInfo.SysNo <= 0)
            {
                ptcp.DoResult = "未能获取到作者信息";
                return ptcp;
            }

            int payCount = 0;
            if (req.UserId > 0)
            {
                var payDbCount = DbSession.MLT.T_SelfMediaPayRecordRepository.QueryCountBy(new T_SelfMediaPayRecord()
                {
                    UserId = req.UserId,
                    ArticleSysNo = artciclInfo.SysNo,
                    AuthorSysNo = authorInfo.SysNo,
                    IsEnable = true
                });

                payCount = Converter.ParseInt(payDbCount, 0);
            }

            var artciclCount = DbSession.MLT.T_SelfMediaArticleRepository.QueryCountBy(new T_SelfMediaArticle()
            {
                AuthorSysNo = authorInfo.SysNo,
                IsHot = true,
                IsEnable = true
            });

            M_ArticleEntity articleEntity = new M_ArticleEntity();

            if (payCount > 0)
            {
                articleEntity.IsRead = true;
            }

            articleEntity.ReadScore = artciclInfo.ReadScore.GetValueOrDefault();
            articleEntity.SysNo = artciclInfo.SysNo.GetValueOrDefault();
            articleEntity.Title = artciclInfo.Title;
            articleEntity.HeadPic = artciclInfo.HeadPic;
            articleEntity.Subtitle = artciclInfo.Subtitle;
            articleEntity.Content = artciclInfo.Content;
            //articleEntity.StartDateTime = artciclInfo.StartDateTime.GetValueOrDefault();
            //articleEntity.EndDateTime = artciclInfo.EndDateTime.GetValueOrDefault();
            articleEntity.SortId = artciclInfo.SortId.GetValueOrDefault();
            articleEntity.RowCeateDate = artciclInfo.RowCeateDate.GetValueOrDefault();
            articleEntity.StrRowCeateDate = articleEntity.RowCeateDate.ToString("yyyy-MM-dd");

            M_AuthorEntity author = new M_AuthorEntity();
            author.AuthorSysNo = authorInfo.SysNo.GetValueOrDefault();
            author.AuthorName = authorInfo.AuthorName;
            author.Portrait = authorInfo.Portrait;
            author.Describe = authorInfo.Describe;
            author.HotArticleCount = Converter.ParseInt(artciclCount, 0);

            ptcp.ReturnValue = new M_QueryArticleByIdRes();
            ptcp.ReturnValue.ArticleEntity = articleEntity;
            ptcp.ReturnValue.AuthorEntity = author;
            ptcp.DoFlag = PtcpState.Success;

            return ptcp;
        }

        /// <summary>
        /// 根据文章ID查询文章信息 h5专门使用 不需要付费可直接阅读
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public Ptcp<M_QueryArticleReadByIdRes> QueryArticleReadById(M_QueryArticleReadByIdReq req)
        {
            var ptcp = new Ptcp<M_QueryArticleReadByIdRes>();

            if (req.IsNull())
            {
                ptcp.DoResult = "非法请求";
                return ptcp;
            }

            if (req.ArticleSysNo <= 0)
            {
                ptcp.DoResult = "文章ID错误";
                return ptcp;
            }

            //获取当前文章信息
            var artciclInfo = DbSession.MLT.T_SelfMediaArticleRepository.QueryBy(new T_SelfMediaArticle()
            {
                SysNo = req.ArticleSysNo,
                IsEnable = true
            }).FirstOrDefault();

            if (artciclInfo.IsNull() || artciclInfo.SysNo <= 0)
            {
                ptcp.DoResult = "未能获取到信息";
                return ptcp;
            }

            //获取当前作者信息
            var authorInfo = DbSession.MLT.T_SelfMediaAuthorRepository.QueryBy(new T_SelfMediaAuthor()
            {
                SysNo = artciclInfo.AuthorSysNo,
                IsEnable = true
            }).FirstOrDefault();

            if (authorInfo.IsNull() || authorInfo.SysNo <= 0)
            {
                ptcp.DoResult = "未能获取到作者信息";
                return ptcp;
            }

            var artciclCount = DbSession.MLT.T_SelfMediaArticleRepository.QueryCountBy(new T_SelfMediaArticle()
            {
                AuthorSysNo = authorInfo.SysNo,
                IsHot = true,
                IsEnable = true
            });


            M_ArticleEntity articleEntity = new M_ArticleEntity();

            articleEntity.IsRead = true;         //分析出去的文章 通过h5可直接阅读，不需要付费
            articleEntity.ReadScore = artciclInfo.ReadScore.GetValueOrDefault();
            articleEntity.SysNo = artciclInfo.SysNo.GetValueOrDefault();
            articleEntity.Title = artciclInfo.Title;
            articleEntity.HeadPic = artciclInfo.HeadPic;
            articleEntity.Subtitle = artciclInfo.Subtitle;
            articleEntity.Content = artciclInfo.Content;
            //articleEntity.StartDateTime = artciclInfo.StartDateTime.GetValueOrDefault();
            //articleEntity.EndDateTime = artciclInfo.EndDateTime.GetValueOrDefault();
            articleEntity.SortId = artciclInfo.SortId.GetValueOrDefault();
            articleEntity.RowCeateDate = artciclInfo.RowCeateDate.GetValueOrDefault();
            articleEntity.StrRowCeateDate = articleEntity.RowCeateDate.ToString("yyyy-MM-dd");

            M_AuthorEntity author = new M_AuthorEntity();
            author.AuthorSysNo = authorInfo.SysNo.GetValueOrDefault();
            author.AuthorName = authorInfo.AuthorName;
            author.Portrait = authorInfo.Portrait;
            author.Describe = authorInfo.Describe;
            author.HotArticleCount = Converter.ParseInt(artciclCount, 0);

            ptcp.ReturnValue = new M_QueryArticleReadByIdRes();
            ptcp.ReturnValue.ArticleEntity = articleEntity;
            ptcp.ReturnValue.AuthorEntity = author;
            ptcp.DoFlag = PtcpState.Success;

            return ptcp;
        }

        /// <summary>
        /// 查询作者下面所有的文章信息
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public Ptcp<M_QueryAuthorArticleRes> QueryAuthorArticle(M_QueryAuthorArticleReq req)
        {
            var ptcp = new Ptcp<M_QueryAuthorArticleRes>();

            if (req.IsNull())
            {
                ptcp.DoResult = "非法请求";
                return ptcp;
            }

            if (req.AuthorSysNo <= 0)
            {
                ptcp.DoResult = "作者ID错误";
                return ptcp;
            }

            if (req.PageIndex <= 0 || req.PageIndex > 10000)
            {
                req.PageIndex = 1;
            }

            if (req.PageSize <= 0 || req.PageSize > 100)
            {
                req.PageSize = 10;
            }

            //获取当前作者信息
            var authorInfo = DbSession.MLT.T_SelfMediaAuthorRepository.QueryBy(new T_SelfMediaAuthor()
            {
                SysNo = req.AuthorSysNo,
                IsEnable = true
            }).FirstOrDefault();

            if (authorInfo.IsNull() || authorInfo.SysNo <= 0)
            {
                ptcp.DoResult = "未能获取到作者信息";
                return ptcp;
            }

            //获取作者文章信息
            var artciclListCount = DbSession.MLT.T_SelfMediaArticleRepository.QueryCountBy(new T_SelfMediaArticle()
            {
                AuthorSysNo = req.AuthorSysNo,
                IsEnable = true
            });
            var artciclList = DbSession.MLT.T_SelfMediaArticleRepository.QueryPageBy(req.PageIndex, req.PageSize, new T_SelfMediaArticle()
            {
                AuthorSysNo = req.AuthorSysNo,
                IsEnable = true
            }, " ORDER BY SysNo DESC").ToList();

            int follow = 0;
            if (req.UserId > 0)
            {
                //是否关注
                var followDb = DbSession.MLT.T_SelfMediaFollowRecordRepository.QueryCountBy(new T_SelfMediaFollowRecord()
                {
                    UserId = req.UserId,
                    AuthorSysNo = req.AuthorSysNo,
                    IsFollow = true,
                    IsEnable = true
                });

                follow = Converter.ParseInt(followDb, 0);
            }

            M_AuthorEntity author = new M_AuthorEntity();
            author.AuthorSysNo = authorInfo.SysNo.GetValueOrDefault();
            author.AuthorName = authorInfo.AuthorName;
            author.Portrait = authorInfo.Portrait;
            author.Describe = authorInfo.Describe;

            if (follow > 0)
            {
                author.IsFollow = true;
            }

            List<M_ArticleEntity> articleEntities = new List<M_ArticleEntity>();
            if (artciclList.IsNotNull() && artciclList.IsHasRow())
            {
                foreach (var art in artciclList)
                {
                    M_ArticleEntity articleEntity = new M_ArticleEntity();

                    articleEntity.ReadScore = art.ReadScore.GetValueOrDefault();
                    articleEntity.SysNo = art.SysNo.GetValueOrDefault();
                    articleEntity.HeadPic = art.HeadPic;
                    articleEntity.Title = art.Title;
                    articleEntity.Subtitle = art.Subtitle;
                    articleEntity.Content = art.Content;
                    articleEntity.SortId = art.SortId.GetValueOrDefault();
                    articleEntity.RowCeateDate = art.RowCeateDate.GetValueOrDefault();
                    articleEntity.StrRowCeateDate = articleEntity.RowCeateDate.ToString("yyyy-MM-dd");

                    articleEntities.Add(articleEntity);
                }
            }

            ptcp.ReturnValue = new M_QueryAuthorArticleRes();
            ptcp.ReturnValue.ArticleEntities = articleEntities;
            ptcp.ReturnValue.AuthorEntity = author;
            ptcp.ReturnValue.Total = Converter.ParseInt(artciclListCount, 0);
            ptcp.DoFlag = PtcpState.Success;

            return ptcp;
        }

        /// <summary>
        /// 我的关注列表
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public Ptcp<M_QueryMyFollowRes> QueryMyFollow(M_QueryMyFollowReq req)
        {
            var ptcp = new Ptcp<M_QueryMyFollowRes>();

            if (req.IsNull())
            {
                ptcp.DoResult = "非法请求";
                return ptcp;
            }

            if (req.UserId <= 0)
            {
                ptcp.DoResult = "会员ID错误";
                return ptcp;
            }

            //取出我的关注
            var myFollows = DbSession.MLT.T_SelfMediaFollowRecordRepository.QueryBy(new T_SelfMediaFollowRecord()
            {
                UserId = req.UserId,
                IsFollow = true,
                IsEnable = true
            }, " ORDER BY SysNo DESC").ToList();

            if (myFollows.IsNull() || !myFollows.IsHasRow())
            {
                ptcp.DoResult = "没有关注信息";
                return ptcp;
            }

            //取出作者
            List<int> authIdList = myFollows.Select(c => c.AuthorSysNo.GetValueOrDefault()).ToList();
            string strAuthor = string.Join(",", authIdList);

            string sqlArt = string.Format(@"SELECT * FROM T_SelfMediaArticle WHERE AuthorSysNo IN ({0}) AND IsEnable = 1", strAuthor);
            string sqlPay = string.Format(@"SELECT * FROM T_SelfMediaPayRecord WHERE UserId = {0} AND IsEnable = 1 ", req.UserId);
            string sqlAuthor = string.Format(@"SELECT * FROM T_SelfMediaAuthor WHERE SysNo IN ({0}) AND IsEnable = 1", strAuthor);

            var artList = DbSession.MLT.ExecuteSql<T_SelfMediaArticle>(sqlArt).ToList();
            var authorList = DbSession.MLT.ExecuteSql<T_SelfMediaAuthor>(sqlAuthor).ToList();
            if (artList.IsNull() || !artList.IsHasRow() || authorList.IsNull() || !authorList.IsHasRow())
            {
                ptcp.DoResult = "没有关注信息";
                return ptcp;
            }

            var payList = DbSession.MLT.ExecuteSql<T_SelfMediaPayRecord>(sqlPay).ToList();

            List<M_AuthorEntity> authorEntities = new List<M_AuthorEntity>();
            foreach (var myf in myFollows)
            {
                M_AuthorEntity author = new M_AuthorEntity();
                author.IsFollow = true;

                var authorInfo = authorList.Where(c => c.SysNo == myf.AuthorSysNo).FirstOrDefault();
                if (authorInfo.IsNotNull() && authorInfo.SysNo > 0)
                {
                    #region

                    author.AuthorSysNo = authorInfo.SysNo.GetValueOrDefault();
                    author.AuthorName = authorInfo.AuthorName;
                    author.Portrait = authorInfo.Portrait;
                    author.Describe = authorInfo.Describe;

                    //取出当前作者的文章
                    var nowAuthorArts = artList.Where(c => c.AuthorSysNo == author.AuthorSysNo).ToList();
                    //取出当前会员已读取当前作者的文章
                    if (payList.IsNotNull() && payList.IsHasRow())
                    {
                        #region

                        var payActs = payList.Where(c => c.UserId == req.UserId && c.AuthorSysNo == author.AuthorSysNo).ToList();
                        if (payActs.IsNotNull() && payActs.IsHasRow())
                        {
                            int allCount = nowAuthorArts.Count;
                            int readCount = payActs.Count;
                            int notCount = allCount - readCount;
                            if (notCount <= 0)
                            {
                                author.NotReadCount = 0;
                                author.StrNotReadCount = "0";
                            }
                            else
                            {
                                author.NotReadCount = notCount;
                                if (notCount > 9)
                                {
                                    author.StrNotReadCount = "9+";
                                }
                                else
                                {
                                    author.StrNotReadCount = notCount.ToString();
                                }
                            }
                        }
                        else
                        {
                            author.NotReadCount = 0;
                            author.StrNotReadCount = "0";
                        }

                        #endregion
                    }
                    else
                    {
                        if (nowAuthorArts.IsNotNull() && nowAuthorArts.IsHasRow())
                        {
                            author.NotReadCount = nowAuthorArts.Count;
                            if (nowAuthorArts.Count > 9)
                            {
                                author.StrNotReadCount = "9+";
                            }
                            else
                            {
                                author.StrNotReadCount = nowAuthorArts.Count.ToString();
                            }
                        }
                        else
                        {
                            author.NotReadCount = 0;
                            author.StrNotReadCount = "0";
                        }
                    }

                    //取出最新一个的文章标题
                    if (nowAuthorArts.IsNotNull() && nowAuthorArts.IsHasRow())
                    {
                        author.Title = nowAuthorArts.OrderByDescending(c => c.SysNo).FirstOrDefault().Title;
                    }

                    authorEntities.Add(author);

                    #endregion
                }
            }

            ptcp.ReturnValue = new M_QueryMyFollowRes();
            ptcp.ReturnValue.AuthorEntities = authorEntities;
            ptcp.DoFlag = PtcpState.Success;

            return ptcp;
        }

        /// <summary>
        /// 关注/取消关注
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public Ptcp<string> SetFollow(M_SetFollowReq req)
        {
            var ptcp = new Ptcp<string>();

            if (req.IsNull())
            {
                ptcp.DoResult = "非法请求";
                return ptcp;
            }

            if (req.AuthorSysNo <= 0)
            {
                ptcp.DoResult = "作者ID错误";
                return ptcp;
            }

            if (req.UserId <= 0)
            {
                ptcp.DoResult = "会员ID错误";
                return ptcp;
            }

            DateTime dtNow = DateTime.Now;
            if (req.IsFollow)
            {
                //取消原来的关注
                DbSession.MLT.T_SelfMediaFollowRecordRepository.Update(new T_SelfMediaFollowRecord()
                {
                    IsFollow = false,
                    ModifyTime = dtNow
                }, new T_SelfMediaFollowRecord()
                {
                    UserId = req.UserId,
                    AuthorSysNo = req.AuthorSysNo,
                    IsFollow = true,
                    IsEnable = true
                });
                DbSession.MLT.SaveChange();

                //去除这个作者的文章信息，将这些作者的文章信息记录到已读红点表，用于首页显示红点的判断
                var articleList = DbSession.MLT.T_SelfMediaArticleRepository.QueryBy(new T_SelfMediaArticle()
                    {
                        AuthorSysNo = req.AuthorSysNo,
                        IsEnable = true
                    }).ToList();

                if (articleList.IsNotNull() && articleList.IsHasRow())
                {
                    //获取红点记录
                    var redList = DbSession.MLT.T_SelfMediaRedDotRecordRepository.QueryBy(new T_SelfMediaRedDotRecord()
                        {
                            UserId = req.UserId,
                            AuthorSysNo = req.AuthorSysNo,
                            IsEnable = true
                        }).ToList();


                    if (redList.IsNotNull() && redList.IsHasRow())
                    {
                        foreach (var art in articleList)
                        {
                            if (!redList.Any(c => c.ArticleSysNo.GetValueOrDefault() == art.SysNo.GetValueOrDefault()))
                            {
                                DbSession.MLT.T_SelfMediaRedDotRecordRepository.Add(new T_SelfMediaRedDotRecord()
                                {
                                    UserId = req.UserId,
                                    AuthorSysNo = req.AuthorSysNo,
                                    ArticleSysNo = art.SysNo,
                                    RowCeateDate = dtNow,
                                    ModifyTime = dtNow,
                                    IsEnable = true
                                });
                            }
                        }
                    }
                    else
                    {
                        foreach (var art in articleList)
                        {
                            DbSession.MLT.T_SelfMediaRedDotRecordRepository.Add(new T_SelfMediaRedDotRecord()
                            {
                                UserId = req.UserId,
                                AuthorSysNo = req.AuthorSysNo,
                                ArticleSysNo = art.SysNo,
                                RowCeateDate = dtNow,
                                ModifyTime = dtNow,
                                IsEnable = true
                            });
                        }
                    }
                }


                //关注
                DbSession.MLT.T_SelfMediaFollowRecordRepository.Add(new T_SelfMediaFollowRecord()
                {
                    UserId = req.UserId,
                    AuthorSysNo = req.AuthorSysNo,
                    IsFollow = true,
                    RowCeateDate = dtNow,
                    ModifyTime = dtNow,
                    IsEnable = true
                });
            }
            else
            {
                //取消关注
                DbSession.MLT.T_SelfMediaFollowRecordRepository.Update(new T_SelfMediaFollowRecord()
                {
                    IsFollow = false,
                    ModifyTime = dtNow
                }, new T_SelfMediaFollowRecord()
                {
                    UserId = req.UserId,
                    AuthorSysNo = req.AuthorSysNo,
                    IsFollow = true,
                    IsEnable = true
                });
            }

            DbSession.MLT.SaveChange();

            ptcp.DoFlag = PtcpState.Success;
            ptcp.DoResult = "操作成功";

            return ptcp;
        }

        /// <summary>
        /// 付费阅读
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public Ptcp<string> PayRead(M_PayReadReq req)
        {
            var ptcp = new Ptcp<string>();

            if (req.IsNull())
            {
                ptcp.DoResult = "非法请求";
                return ptcp;
            }

            if (req.UserId <= 0)
            {
                ptcp.DoResult = "会员ID错误";
                return ptcp;
            }

            if (req.ArticleSysNo <= 0)
            {
                ptcp.DoResult = "文章ID错误";
                return ptcp;
            }

            var payRecord = DbSession.MLT.T_SelfMediaPayRecordRepository.QueryBy(new T_SelfMediaPayRecord()
            {
                UserId = req.UserId,
                ArticleSysNo = req.ArticleSysNo,
                IsEnable = true
            }).FirstOrDefault();

            if (payRecord.IsNotNull() && payRecord.SysNo.GetValueOrDefault() > 0)
            {
                ptcp.DoResult = "已经付过费了，请直接阅读";
                ptcp.DoFlag = PtcpState.Success;
                return ptcp;
            }

            //获取文章付费阅读的积分、低佣金
            var article = DbSession.MLT.T_SelfMediaArticleRepository.QueryBy(new T_SelfMediaArticle()
            {
                SysNo = req.ArticleSysNo,
                IsEnable = true
            }).FirstOrDefault();

            if (article.IsNull() || article.SysNo <= 0)
            {
                ptcp.DoResult = "当前文章不存在或者已下架";
                return ptcp;
            }

            //获取会员的积分
            var member = DbSession.MLT.T_MemberRepository.QueryBy(new T_Member()
            {
                SysNo = req.UserId
            }).FirstOrDefault();

            if (member.IsNull() || member.SysNo <= 0)
            {
                ptcp.DoResult = "未能获取到会员信息";
                return ptcp;
            }

            if (member.Score < article.ReadScore)
            {
                //ptcp.DoResult = string.Format("抵用金不足，账户抵用金{0}元，阅读当前文章需要{1}元抵用金", member.Score, article.ReadScore);
                //ptcp.DoResult = "抵用金不足";
                ptcp.DoResult = "参与互动获取更多奖励金";
                return ptcp;
            }

            //插入付费记录
            DbSession.MLT.T_SelfMediaPayRecordRepository.Add(new T_SelfMediaPayRecord()
            {
                UserId = req.UserId,
                AuthorSysNo = article.AuthorSysNo,
                ArticleSysNo = article.SysNo.GetValueOrDefault(),
                PayScore = article.ReadScore,
                RowCeateDate = DateTime.Now,
                IsEnable = true
            });

            //扣减账户低佣金
            //账号新增流水，插入抵用金
            fb.AddAccountRecord(new M_AddAccountRecordReq()
            {
                TranType = (int)Enums.TranType.ReadArticle,
                UserId = req.UserId,
                TranNum = Convert.ToDecimal(article.ReadScore)
            });

            DbSession.MLT.SaveChange();
            ptcp.DoFlag = PtcpState.Success;
            ptcp.DoResult = "付费成功";

            return ptcp;
        }

        /// <summary>
        /// 获取首页的红点数量
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public Ptcp<M_QueryHomePageRedDotRes> QueryHomePageRedDot(M_QueryHomePageRedDotReq req)
        {
            var ptcp = new Ptcp<M_QueryHomePageRedDotRes>();

            if (req.IsNull())
            {
                ptcp.DoResult = "非法请求";
                return ptcp;
            }

            if (req.UserId <= 0)
            {
                ptcp.ReturnValue = new M_QueryHomePageRedDotRes();
                ptcp.ReturnValue.RedCount = 0;
                ptcp.DoFlag = PtcpState.Success;
                ptcp.DoResult = "查询成功";
                return ptcp;
            }

            //获取关注列表
            var folloList = DbSession.MLT.T_SelfMediaFollowRecordRepository.QueryBy(new T_SelfMediaFollowRecord() {
                UserId = req.UserId,
                IsFollow = true,
                IsEnable = true
            }).ToList();

            if (folloList.IsNull() || !folloList.IsHasRow())
            {
                ptcp.ReturnValue = new M_QueryHomePageRedDotRes();
                ptcp.ReturnValue.RedCount = 0;
                ptcp.DoFlag = PtcpState.Success;
                ptcp.DoResult = "查询成功";
                return ptcp;
            }

            List<int> authorSysNos = folloList.Select(c => c.AuthorSysNo.GetValueOrDefault()).Distinct().ToList();
            string strAuthorSysNos = string.Join(",",authorSysNos);

            string sqlAuthor = string.Format("SELECT * FROM dbo.T_SelfMediaArticle WHERE AuthorSysNo IN ({0}) AND IsEnable = 1", strAuthorSysNos);
            var articleInfoList = DbSession.MLT.ExecuteSql<T_SelfMediaArticle>(sqlAuthor).ToList();
            if (articleInfoList.IsNull() || !articleInfoList.IsHasRow())
            {
                ptcp.ReturnValue = new M_QueryHomePageRedDotRes();
                ptcp.ReturnValue.RedCount = 0;
                ptcp.DoFlag = PtcpState.Success;
                ptcp.DoResult = "查询成功";
                return ptcp;
            }

            DateTime dtNow = DateTime.Now;
            //取的读取记录
            string sqlRead = string.Format("SELECT * FROM dbo.T_SelfMediaRedDotRecord WHERE UserId = {0} AND AuthorSysNo IN ({1}) AND IsEnable = 1", req.UserId, strAuthorSysNos);
            var readList = DbSession.MLT.ExecuteSql<T_SelfMediaRedDotRecord>(sqlRead).ToList();
            if (readList.IsNull() || !readList.IsHasRow())
            {
                foreach (var art in articleInfoList)
                {
                    //添加记录
                    DbSession.MLT.T_SelfMediaRedDotRecordRepository.Add(new T_SelfMediaRedDotRecord()
                    {
                        UserId = req.UserId,
                        AuthorSysNo = art.AuthorSysNo,
                        ArticleSysNo = art.SysNo,
                        RowCeateDate = dtNow,
                        ModifyTime = dtNow,
                        IsEnable = true
                    });
                }
                DbSession.MLT.SaveChange();

                ptcp.ReturnValue = new M_QueryHomePageRedDotRes();
                ptcp.ReturnValue.RedCount = articleInfoList.Count;
                ptcp.DoFlag = PtcpState.Success;
                ptcp.DoResult = "查询成功";
                return ptcp;
            }

            int redCount = articleInfoList.Count - readList.Count;
            if (redCount < 0)
            {
                redCount = 0;
            }

            foreach (var art in articleInfoList)
            {
                if (!readList.Any(c => c.UserId == req.UserId && c.AuthorSysNo == art.AuthorSysNo &&
                                       c.ArticleSysNo == art.SysNo))
                {
                    //添加记录
                    DbSession.MLT.T_SelfMediaRedDotRecordRepository.Add(new T_SelfMediaRedDotRecord()
                    {
                        UserId = req.UserId,
                        AuthorSysNo = art.AuthorSysNo,
                        ArticleSysNo = art.SysNo,
                        RowCeateDate = dtNow,
                        ModifyTime = dtNow,
                        IsEnable = true
                    });
                }
            }
            DbSession.MLT.SaveChange();


            ptcp.ReturnValue = new M_QueryHomePageRedDotRes();
            ptcp.ReturnValue.RedCount = redCount;
            ptcp.DoFlag = PtcpState.Success;
            ptcp.DoResult = "查询成功";

            return ptcp;
        }

        /// <summary>
        /// 自媒体文章分享保存手机号码信息，用于注册处理数据
        /// </summary>
        /// <param name="mobile"></param>
        /// <param name="authorSysNo"></param>
        /// <param name="articleSysNo"></param>
        /// <returns></returns>
        public Ptcp<string> AddSelfMediaSaveRecord(string mobile, int authorSysNo, int articleSysNo)
        {
            var ptcp = new Ptcp<string>();

            if (string.IsNullOrEmpty(mobile))
            {
                ptcp.DoResult = "手机号码不能为空";
                return ptcp;
            }

            if (mobile.Length != 11)
            {
                ptcp.DoResult = "手机号码格式不正确";
                return ptcp;
            }

            //Regex regex = new Regex(RegexExt.mobileRegex);
            //if (!regex.IsMatch(mobile))
            if (mobile.Length != 11)
            {
                ptcp.DoResult = "手机号码格式不正确";
                return ptcp;
            }

            if (authorSysNo <= 0)
            {
                ptcp.DoResult = "作者ID不能为空";
                return ptcp;
            }

            if (articleSysNo <= 0)
            {
                ptcp.DoResult = "文章ID不能为空";
                return ptcp;
            }

            DateTime dtNow = DateTime.Now;
            //判断当前手机号码是否已经注册过了
            var memInfo = mem.QueryMemberInfoByMobile(mobile);
            if (memInfo.DoFlag == PtcpState.Success)
            {
                //会员已经存在 直接关注
                int userid = Converter.ParseInt(memInfo.DoResult, 0);

                //自动关注作者
                ForSelfMediaImpl forSelf = new ForSelfMediaImpl();
                forSelf.SetFollow(new M_SetFollowReq()
                {
                    UserId = userid,
                    AuthorSysNo = authorSysNo,
                    IsFollow = true
                });
            }
            else
            {
                //新用户，等注册的时候处理
                DbSession.MLT.T_SelfMediaSaveRecordRepository.Add(new T_SelfMediaSaveRecord()
                {
                    Mobile = mobile,
                    AuthorSysNo = authorSysNo,
                    ArticleSysNo = articleSysNo,
                    IsTransfer = 0,
                    RowCeateDate = dtNow,
                    ModifyTime = dtNow,
                    IsEnable = true
                });
                DbSession.MLT.SaveChange();
            }

            ptcp.DoFlag = PtcpState.Success;
            ptcp.DoResult = "保存成功";
            return ptcp;
        }
    }
}
