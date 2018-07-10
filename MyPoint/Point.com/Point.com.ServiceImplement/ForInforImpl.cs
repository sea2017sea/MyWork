using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Point.com.Common;
using Point.com.Logging;
using Point.com.Model;
using Point.com.Model.Base;
using Point.com.ServiceInterface;

namespace Point.com.ServiceImplement
{
    public class ForInforImpl : BaseService, IForInfor
    {
        public List<M_SubjectEntity> subjectEntities = null;
        private static ForBaseImpl fb = new ForBaseImpl();
        private static MemberDepImpl mem = new MemberDepImpl();
        
        /// <summary>
        /// 获取首页的数据
        /// 如果是题目类型，则需要去掉当前会员已经回答过的题了
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public Ptcp<M_QueryHomePageRes> QueryHomePage(M_QueryHomePageReq req)
        {
            var ptcp = new Ptcp<M_QueryHomePageRes>();

            if (req.IsNull())
            {
                ptcp.DoResult = "请求数据非法";
                return ptcp;
            }

            if (req.UserId > 0)
            {
                var memberInfo = DbSession.MLT.T_MemberRepository.QueryBy(new T_Member()
                {
                    SysNo = req.UserId
                }).FirstOrDefault();

                if (memberInfo.IsNotNull() && memberInfo.SysNo > 0)
                {
                    req.InfoType = memberInfo.InforType.GetValueOrDefault();
                }
            }

            string jsonParam = JsonConvert.SerializeObject(req);
            Logger.Write(LoggerLevel.Error, "QueryHomePage_in", "", jsonParam, "");

            if (req.InfoType <= 0)
            {
                ptcp.DoResult = "咨询类型不能为空";
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

            List<T_InforConfigure> sortList = new List<T_InforConfigure>();

            string sql = string.Format(@"SELECT * FROM T_InforConfigure WHERE (StrInforType LIKE '%(0)%' OR StrInforType LIKE '%({0})%') AND IsShowIndex = 1 AND IsEnable = 1 ORDER BY IntSort DESC", req.InfoType);
            var orgAllDatas = DbSession.MLT.ExecuteSql<T_InforConfigure>(sql).ToList();

            if (orgAllDatas.IsNotNull() && orgAllDatas.IsHasRow())
            {
                sortList.AddRange(orgAllDatas);
            }

            //获取自媒体数据
            string sqlArt = string.Format(@"SELECT * FROM T_SelfMediaArticle WHERE (StrInforType LIKE '%(0)%' OR StrInforType LIKE '%({0})%') AND IsShowIndex = 1 AND IsEnable = 1 ORDER BY SortId DESC", req.InfoType);
            var articleList = DbSession.MLT.ExecuteSql<T_SelfMediaArticle>(sqlArt).ToList();
            
            if (articleList.IsNotNull() && articleList.IsHasRow())
            {
                //将 T_SelfMediaArticle 转换为 T_InforConfigure
                var auths = AllAuthorInfo();
                foreach (var sel in articleList)
                {
                    var infoArt = TableTInforConfigure(sel, auths);
                    if (infoArt.IsNotNull())
                    {
                        sortList.Add(infoArt);
                    }
                }
            }

            if (sortList.IsNull() || !sortList.IsHasRow())
            {
                ptcp.DoResult = "没有内容";
                return ptcp;
            }

            sortList = sortList.OrderByDescending(c => c.IntSort).ToList();
            var pageList = sortList.Skip(req.PageSize * (req.PageIndex - 1)).Take(req.PageSize).ToList();


            ptcp.ReturnValue = new M_QueryHomePageRes();

            var pl = Mapper.MapperGeneric<T_InforConfigure, M_HomePageData>(pageList).ToList();

            foreach (var m in pl)
            {
                m.StrSourceDateTime = m.SourceDateTime.ToString();
            }

            ptcp.ReturnValue.PageDatas = pl;
            
            //string dataParm = JsonConvert.SerializeObject(pl);
            //Logger.Write(LoggerLevel.Error, "QueryHomePage_Data", jsonParam, dataParm, "");

            ptcp.ReturnValue.Total = sortList.Count;
            ptcp.DoFlag = PtcpState.Success;
            ptcp.DoResult = "查询成功";
            return ptcp;
        }

        /// <summary>
        /// 获取首页的数据
        /// 如果是题目类型，则需要去掉当前会员已经回答过的题了
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public Ptcp<M_QueryHomePageRes> QueryHomePageTwo(M_QueryHomePageReq req)
        {
            var ptcp = new Ptcp<M_QueryHomePageRes>();

            if (req.IsNull())
            {
                ptcp.DoResult = "请求数据非法";
                return ptcp;
            }

            if (req.UserId > 0)
            {
                var memberInfo = DbSession.MLT.T_MemberRepository.QueryBy(new T_Member()
                {
                    SysNo = req.UserId
                }).FirstOrDefault();

                if (memberInfo.IsNotNull() && memberInfo.SysNo > 0)
                {
                    req.InfoType = memberInfo.InforType.GetValueOrDefault();
                }
            }

            string jsonParam = JsonConvert.SerializeObject(req);
            Logger.Write(LoggerLevel.Error, "QueryHomePage_in", "", jsonParam, "");

            if (req.InfoType <= 0)
            {
                ptcp.DoResult = "咨询类型不能为空";
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

            List<T_InforConfigure> sortList = new List<T_InforConfigure>();
            var cacheAll = string.Format("{0}.QueryHomePage.{1}.{2}", GetType().Name, req.InfoType,req.UserId);

            //sortList = CacheClientSession.LocalCacheClient.Get<List<T_InforConfigure>>(cacheAll);

            if (req.PageIndex == 1 || sortList.IsNull() || !sortList.IsHasRow())
            {
                sortList = new List<T_InforConfigure>();

                string sql = string.Format(@"SELECT * FROM T_InforConfigure WHERE (StrInforType LIKE '%(0)%' OR StrInforType LIKE '%({0})%') AND IsShowIndex = 1 AND IsEnable = 1 ORDER BY IntSort DESC",req.InfoType);
                List<T_InforConfigure> orgAllDatas = DbSession.MLT.ExecuteSql<T_InforConfigure>(sql).ToList();
                if (orgAllDatas.IsNull() || !orgAllDatas.IsHasRow())
                {
                    ptcp.DoResult = "没有数据";
                    return ptcp;
                }

                #region

                //如果存在会员ID，则获取当前会员已经答过的题目
                List<T_InforConfigure> orgNotSubs = new List<T_InforConfigure>();
                //已经回答过的题目集合
                List<T_InforConfigure> orgSubs = new List<T_InforConfigure>();
                if (req.UserId > 0)
                {
                    string sqlSub = string.Format(@"SELECT * FROM T_Subject sb INNER JOIN T_AnswerRecord sr ON sr.SubSysNo = sb.SysNo WHERE sr.UserId = {0} AND sb.InforSysNo > 0 AND sb.IsEnable = 1 AND sr.IsEnable = 1",req.UserId);

                    var subDatas = DbSession.MLT.ExecuteSql<T_Subject>(sqlSub).ToList();
                    if (subDatas.IsNotNull() && subDatas.IsHasRow())
                    {
                        //存在答题记录，则在总的信息源中，排除这些已经答过题的
                        foreach (var fc in orgAllDatas)
                        {
                            //调整逻辑，已经答过的继续显示
                            if (!subDatas.Any(c => c.InforSysNo == fc.SysNo))
                            {
                                orgNotSubs.Add(fc);
                            }
                            else
                            {
                                if (fc.DataType == (int) Enums.DataType.Adv)
                                {
                                    orgSubs.Add(fc);
                                }
                            }
                        }
                    }
                    else
                    {
                        //没有已答题的数据
                        orgNotSubs.AddRange(orgAllDatas);
                    }
                }
                else
                {
                    //当前会员未登录
                    orgNotSubs.AddRange(orgAllDatas);
                }

                //获取自媒体数据
                string sqlArt = string.Format(@"SELECT * FROM T_SelfMediaArticle WHERE (StrInforType LIKE '%(0)%' OR StrInforType LIKE '%({0})%') AND IsShowIndex = 1 AND IsEnable = 1 ORDER BY SortId DESC", req.InfoType);
                var articleList = DbSession.MLT.ExecuteSql<T_SelfMediaArticle>(sqlArt).ToList();
                List<T_InforConfigure> infoArtList = null;
                if (articleList.IsNotNull() && articleList.IsHasRow())
                {
                    //将 T_SelfMediaArticle 转换为 T_InforConfigure
                    infoArtList = new List<T_InforConfigure>();
                    var auths = AllAuthorInfo();
                    foreach (var sel in articleList)
                    {
                        var infoArt = TableTInforConfigure(sel,auths);
                        if (infoArt.IsNotNull())
                        {
                            infoArtList.Add(infoArt);
                        }
                    }
                }

                #endregion

                #region 排序处理

                var newsList =
                    orgNotSubs.Where(c => c.DataType == (int) Enums.DataType.News)
                              .OrderByDescending(c => c.IntSort)
                              .ToList();
                var shopList =
                    orgNotSubs.Where(c => c.DataType == (int) Enums.DataType.Shop)
                              .OrderByDescending(c => c.IntSort)
                              .ToList();
                var advList =
                    orgNotSubs.Where(c => c.DataType == (int) Enums.DataType.Adv)
                              .OrderByDescending(c => c.IntSort)
                              .ToList();

                if (orgSubs.IsNotNull() && orgSubs.IsHasRow())
                {
                    if (advList.IsNotNull())
                    {
                        advList.AddRange(orgSubs);
                    }
                    else
                    {
                        advList = new List<T_InforConfigure>();
                        advList.AddRange(orgSubs);
                    }
                }

                int newsCount = 0;
                int shopCount = 0;
                int devCount = 0;
                int artCount = 0;

                if (newsList.IsNotNull() && newsList.IsHasRow())
                {
                    newsCount = newsList.Count;
                }

                if (shopList.IsNotNull() && shopList.IsHasRow())
                {
                    shopCount = shopList.Count;
                }

                if (advList.IsNotNull() && advList.IsHasRow())
                {
                    devCount = advList.Count;
                }

                if (infoArtList.IsNotNull() && infoArtList.IsHasRow())
                {
                    artCount = infoArtList.Count;
                }

                int forIndex = newsCount;
                if (forIndex < shopCount)
                {
                    forIndex = shopCount;
                }

                if (forIndex < devCount)
                {
                    forIndex = devCount;
                }

                if (forIndex < artCount)
                {
                    forIndex = artCount;
                }

                int newsIndex = 0;
                int shopIndex = 0;
                int devIndex = 0;
                int artIndex = 0;

                #region 新逻辑  展示顺序 数量可配置

                //1新闻  2店铺  3答题  4文章
                int one = Configurator.One;
                int two = Configurator.Two;
                int three = Configurator.Three;
                int frour = Configurator.Frour;

                int oneCount = Configurator.OneCount;
                int twoCount = Configurator.TwoCount;
                int threeCount = Configurator.ThreeCount;
                int frourCount = Configurator.FrourCount;

                for (int i = 0; i < forIndex; i++)
                {
                    #region 展示第一位

                    switch (one)
                    {
                        case 1:

                            #region 新闻

                            if (oneCount > 0 && newsCount > newsIndex)
                            {
                                for (int j = 0; j < oneCount; j++)
                                {
                                    if (newsCount > newsIndex)
                                    {
                                        sortList.Add(newsList[newsIndex]);
                                        newsIndex = newsIndex + 1;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }

                            #endregion

                            break;
                        case 2:

                            #region 店铺

                            if (twoCount > 0 && shopCount > shopIndex)
                            {
                                for (int j = 0; j < twoCount; j++)
                                {
                                    if (shopCount > shopIndex)
                                    {
                                        sortList.Add(shopList[shopIndex]);
                                        shopIndex = shopIndex + 1;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }

                            #endregion

                            break;
                        case 3:

                            #region 答题

                            if (threeCount > 0 && devCount > devIndex)
                            {
                                for (int j = 0; j < threeCount; j++)
                                {
                                    if (devCount > devIndex)
                                    {
                                        sortList.Add(advList[devIndex]);
                                        devIndex = devIndex + 1;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }

                            #endregion

                            break;
                        case 4:

                            #region 答题

                            if (frourCount > 0 && artCount > artIndex)
                            {
                                for (int j = 0; j < frourCount; j++)
                                {
                                    if (artCount > artIndex)
                                    {
                                        sortList.Add(infoArtList[artIndex]);
                                        artIndex = artIndex + 1;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }

                            #endregion

                            break;
                    }

                    #endregion

                    #region 展示第二位

                    switch (two)
                    {
                        case 1:

                            #region 新闻

                            if (oneCount > 0 && newsCount > newsIndex)
                            {
                                for (int j = 0; j < oneCount; j++)
                                {
                                    if (newsCount > newsIndex)
                                    {
                                        sortList.Add(newsList[newsIndex]);
                                        newsIndex = newsIndex + 1;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }

                            #endregion

                            break;
                        case 2:

                            #region 店铺

                            if (twoCount > 0 && shopCount > shopIndex)
                            {
                                for (int j = 0; j < twoCount; j++)
                                {
                                    if (shopCount > shopIndex)
                                    {
                                        sortList.Add(shopList[shopIndex]);
                                        shopIndex = shopIndex + 1;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }

                            #endregion

                            break;
                        case 3:

                            #region 答题

                            if (threeCount > 0 && devCount > devIndex)
                            {
                                for (int j = 0; j < threeCount; j++)
                                {
                                    if (devCount > devIndex)
                                    {
                                        sortList.Add(advList[devIndex]);
                                        devIndex = devIndex + 1;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }

                            #endregion

                            break;
                        case 4:

                            #region 答题

                            if (frourCount > 0 && artCount > artIndex)
                            {
                                for (int j = 0; j < frourCount; j++)
                                {
                                    if (artCount > artIndex)
                                    {
                                        sortList.Add(infoArtList[artIndex]);
                                        artIndex = artIndex + 1;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }

                            #endregion

                            break;
                    }

                    #endregion

                    #region 展示第三位

                    switch (three)
                    {
                        case 1:

                            #region 新闻

                            if (oneCount > 0 && newsCount > newsIndex)
                            {
                                for (int j = 0; j < oneCount; j++)
                                {
                                    if (newsCount > newsIndex)
                                    {
                                        sortList.Add(newsList[newsIndex]);
                                        newsIndex = newsIndex + 1;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }

                            #endregion

                            break;
                        case 2:

                            #region 店铺

                            if (twoCount > 0 && shopCount > shopIndex)
                            {
                                for (int j = 0; j < twoCount; j++)
                                {
                                    if (shopCount > shopIndex)
                                    {
                                        sortList.Add(shopList[shopIndex]);
                                        shopIndex = shopIndex + 1;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }

                            #endregion

                            break;
                        case 3:

                            #region 答题

                            if (threeCount > 0 && devCount > devIndex)
                            {
                                for (int j = 0; j < threeCount; j++)
                                {
                                    if (devCount > devIndex)
                                    {
                                        sortList.Add(advList[devIndex]);
                                        devIndex = devIndex + 1;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }

                            #endregion

                            break;
                        case 4:

                            #region 答题

                            if (frourCount > 0 && artCount > artIndex)
                            {
                                for (int j = 0; j < frourCount; j++)
                                {
                                    if (artCount > artIndex)
                                    {
                                        sortList.Add(infoArtList[artIndex]);
                                        artIndex = artIndex + 1;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }

                            #endregion

                            break;
                    }

                    #endregion

                    #region 展示第四位

                    switch (frour)
                    {
                        case 1:

                            #region 新闻

                            if (oneCount > 0 && newsCount > newsIndex)
                            {
                                for (int j = 0; j < oneCount; j++)
                                {
                                    if (newsCount > newsIndex)
                                    {
                                        sortList.Add(newsList[newsIndex]);
                                        newsIndex = newsIndex + 1;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }

                            #endregion

                            break;
                        case 2:

                            #region 店铺

                            if (twoCount > 0 && shopCount > shopIndex)
                            {
                                for (int j = 0; j < twoCount; j++)
                                {
                                    if (shopCount > shopIndex)
                                    {
                                        sortList.Add(shopList[shopIndex]);
                                        shopIndex = shopIndex + 1;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }

                            #endregion

                            break;
                        case 3:

                            #region 答题

                            if (threeCount > 0 && devCount > devIndex)
                            {
                                for (int j = 0; j < threeCount; j++)
                                {
                                    if (devCount > devIndex)
                                    {
                                        sortList.Add(advList[devIndex]);
                                        devIndex = devIndex + 1;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }

                            #endregion

                            break;
                        case 4:

                            #region 答题

                            if (frourCount > 0 && artCount > artIndex)
                            {
                                for (int j = 0; j < frourCount; j++)
                                {
                                    if (artCount > artIndex)
                                    {
                                        sortList.Add(infoArtList[artIndex]);
                                        artIndex = artIndex + 1;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }

                            #endregion

                            break;
                    }

                    #endregion
                }

                #endregion 

                #region 老的代码  不要了

                //if (newsList.IsNotNull() && newsList.IsHasRow())
                //{
                //    #region

                //    int fiveNewsIndex = 0;
                //    foreach (var newL in newsList)
                //    {
                //        if (fiveNewsIndex < 5)
                //        {
                //            sortList.Add(newL);
                //            fiveNewsIndex = fiveNewsIndex + 1;
                //        }
                //        else
                //        {
                //            if (advList.IsNotNull() && advList.IsHasRow())
                //            {
                //                if (advList.Count > devIndex)
                //                {
                //                    sortList.Add(advList[devIndex]);
                //                    devIndex = devIndex + 1;
                //                }
                //            }

                //            if (shopList.IsNotNull() && shopList.IsHasRow())
                //            {
                //                if (shopList.Count > shopIndex)
                //                {
                //                    sortList.Add(shopList[shopIndex]);
                //                    shopIndex = shopIndex + 1;
                //                }
                //            }

                //            fiveNewsIndex = 0;
                //        }

                //        newsIndex = newsIndex + 1;
                //        if (newsIndex >= newsList.Count)
                //        {
                //            #region

                //            for (int i = 0; i < forIndex; i++)
                //            {
                //                if (advList.IsNotNull() && advList.IsHasRow())
                //                {
                //                    if (advList.Count > devIndex)
                //                    {
                //                        sortList.Add(advList[devIndex]);
                //                        devIndex = devIndex + 1;
                //                    }
                //                }

                //                if (shopList.IsNotNull() && shopList.IsHasRow())
                //                {
                //                    if (shopList.Count > shopIndex)
                //                    {
                //                        sortList.Add(shopList[shopIndex]);
                //                        shopIndex = shopIndex + 1;
                //                    }
                //                }
                //            }

                //            #endregion
                //        }
                //    }

                //    #endregion
                //}
                //else
                //{
                //    #region

                //    for (int i = 0; i < forIndex; i++)
                //    {
                //        if (advList.IsNotNull() && advList.IsHasRow())
                //        {
                //            if (advList.Count > devIndex)
                //            {
                //                sortList.Add(advList[devIndex]);
                //                devIndex = devIndex + 1;
                //            }
                //        }

                //        if (shopList.IsNotNull() && shopList.IsHasRow())
                //        {
                //            if (shopList.Count > shopIndex)
                //            {
                //                sortList.Add(shopList[shopIndex]);
                //                shopIndex = shopIndex + 1;
                //            }
                //        }
                //    }

                //    #endregion
                //}

                #endregion

                #endregion

                //写入缓存
                //CacheClientSession.LocalCacheClient.Set(cacheAll, sortList, new TimeSpan(0,10,0));
            }

            if (sortList.IsNull() || !sortList.IsHasRow())
            {
                ptcp.DoResult = "没有数据";
                return ptcp;
            }
            
            List<T_InforConfigure> sortSelectList = new List<T_InforConfigure>();
            foreach (var sl in sortList)
            {
                if (!sortSelectList.Any(c => c.SysNo == sl.SysNo && c.DataType == sl.DataType))
                {
                    sortSelectList.Add(sl);
                }
            }

            var pageList = sortSelectList.Skip(req.PageSize * (req.PageIndex - 1)).Take(req.PageSize).ToList();

            ptcp.ReturnValue = new M_QueryHomePageRes();

            var pl = Mapper.MapperGeneric<T_InforConfigure, M_HomePageData>(pageList).ToList();

            foreach (var m in pl)
            {
                m.StrSourceDateTime = m.SourceDateTime.ToString();
            }

            ptcp.ReturnValue.PageDatas = pl;

            ptcp.ReturnValue.Total = sortList.Count;
            ptcp.DoFlag = PtcpState.Success;
            ptcp.DoResult = "查询成功";
            return ptcp;
        }

        /// <summary>
        /// 根据分类ID查询店铺列表信息
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public Ptcp<M_QueryShopRes> QueryShop(M_QueryShopReq req)
        {
            var ptcp = new Ptcp<M_QueryShopRes>();

            if (req.IsNull())
            {
                ptcp.DoResult = "请求数据非法";
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

            string jsonParam = JsonConvert.SerializeObject(req);
            Logger.Write(LoggerLevel.Error, "QueryShop_in", "", jsonParam, "");

            var cacheKey = string.Format("{0}.QueryShop.{1}.{2}", GetType().Name, req.CateId,req.PageIndex);
            var allDatas = CacheClientSession.LocalCacheClient.Get(cacheKey, () =>
                {
                    #region 组装查询SQL语句

                    string sql = "";
                    string sqlCount = "";
                    if (req.CateId <= 0)
                    {
                        sql =
                            string.Format(@"SELECT TOP {0} * FROM (SELECT ROW_NUMBER() OVER (ORDER BY IntSort DESC) AS RowNumber,* FROM T_InforConfigure WHERE DataType = 2 AND IsEnable = 1) as A  
                         WHERE RowNumber > {0}*({1}-1) ORDER BY A.IntSort DESC", req.PageSize, req.PageIndex);

                        sqlCount =
                            string.Format(@"SELECT COUNT(0) FROM T_InforConfigure WHERE DataType = 2 AND IsEnable = 1");
                    }
                    else
                    {
                        sql =
                            string.Format(@"SELECT TOP {0} * FROM (SELECT ROW_NUMBER() OVER (ORDER BY IntSort DESC) AS RowNumber,* FROM T_InforConfigure WHERE DataType = 2 AND CateId = {1} AND IsEnable = 1) as A  
                         WHERE RowNumber > {0}*({2}-1) ORDER BY A.IntSort DESC", req.PageSize, req.CateId, req.PageIndex);

                        sqlCount =
                            string.Format(
                                @"SELECT COUNT(0) FROM T_InforConfigure WHERE DataType = 2 AND CateId = {0} AND IsEnable = 1",
                                req.CateId);
                    }

                    #endregion

                    var records = DbSession.MLT.ExecuteSql<T_InforConfigure>(sql).ToList();
                    if (records.IsNotNull() && records.IsHasRow())
                    {
                        //根据店铺信息拉取店铺商品信息
                        List<int> shopIds = records.Select(c => c.SysNo.GetValueOrDefault()).ToList();
                        string strShopIds = string.Join(",", shopIds);

                        string sqlShopGoods = string.Format(@"SELECT * FROM T_ShopGoods WHERE ShopSysNo IN ({0}) AND IsEnable = 1",strShopIds);
                        var shopGoodsInfos = DbSession.MLT.ExecuteSql<T_ShopGoods>(sqlShopGoods).ToList();

                        //根据商品信息拉取抵用抵用的信息
                        string sqlCoupons = string.Format(@"SELECT * FROM T_CouponInfo WHERE ShopSysNo IN ({0}) AND IsEnable = 1", strShopIds);
                        var couponInfos = DbSession.MLT.ExecuteSql<T_CouponInfo>(sqlCoupons).ToList();

                        #region 组装数据

                        List<M_ShopInfo> mShopInfos = new List<M_ShopInfo>();
                        foreach (var shop in records)
                        {
                            M_ShopInfo shopInfo = new M_ShopInfo();
                            shopInfo.SysNo = shop.SysNo.GetValueOrDefault();
                            shopInfo.ShopName = shop.InforName;
                            shopInfo.ShopDesc = shop.InforDesc;
                            shopInfo.ShopRemark = shop.InforRemark;
                            shopInfo.LogoIcon = shop.LogoIcon;
                            shopInfo.HeadPic = shop.HeadPic;
                            shopInfo.CoverPic = shop.CoverPic;
                            shopInfo.ShopPic = shop.ShopPic;
                            shopInfo.PushPic = shop.PushPic;
                            shopInfo.VideoUrl = shop.VideoUrl;
                            shopInfo.CateId = shop.CateId.GetValueOrDefault();
                            shopInfo.InforSource = shop.InforSource;
                            shopInfo.LinkUrl = shop.LinkUrl;

                            if (shop.SourceDateTime != null)
                            {
                                shopInfo.SourceDateTime = Convert.ToDateTime(shop.SourceDateTime);
                                shopInfo.StrSourceDateTime = shop.SourceDateTime.ToString();
                            }

                            #region 处理最高抵佣金、活动限制数量、剩余数量

                            shopInfo.HighMoney = 0;
                            shopInfo.StrHighMoney = shopInfo.HighMoney.ToString();
                            //最高抵佣金
                            if (couponInfos.IsNotNull() && couponInfos.IsHasRow())
                            {
                                var shopCouponInfos = couponInfos.Where(c => c.ShopSysNo == shopInfo.SysNo).ToList();
                                if (shopCouponInfos.IsNotNull() && shopCouponInfos.IsHasRow())
                                {
                                    shopInfo.HighMoney = Convert.ToDecimal(shopCouponInfos.Max(c => c.ExcAmount));
                                    shopInfo.StrHighMoney = shopInfo.HighMoney.ToString();
                                }
                            }

                            //活动限制数量
                            shopInfo.LimitCount = 0;
                            shopInfo.SurplusCount = 0;
                            shopInfo.GoodsLabelOneCount = 0;
                            shopInfo.GoodsLabelTwoCount = 0;
                            if (shopGoodsInfos.IsNotNull() && shopGoodsInfos.IsHasRow())
                            {
                                var shopGoodsDatas = shopGoodsInfos.Where(c => c.ShopSysNo == shopInfo.SysNo).ToList();
                                if (shopGoodsDatas.IsNotNull() && shopGoodsDatas.IsHasRow())
                                {
                                    shopInfo.LimitCount = shopGoodsDatas.Sum(c => c.CouponCount).GetValueOrDefault();
                                    shopInfo.SurplusCount = shopGoodsDatas.Sum(c => c.OverCouponCount).GetValueOrDefault();

                                    var gLabelOnes = shopGoodsDatas.Where(c => c.GoodsLabelOne != "").ToList();
                                    if (gLabelOnes.IsHasRow())
                                    {
                                        shopInfo.GoodsLabelOneCount = gLabelOnes.Count();
                                        shopInfo.GoodsLabelOne = gLabelOnes[0].GoodsLabelOne;
                                    }

                                    var gLabelTwos = shopGoodsDatas.Where(c => c.GoodsLabelTwo != "").ToList();
                                    if (gLabelTwos.IsHasRow())
                                    {
                                        shopInfo.GoodsLabelTwoCount = gLabelTwos.Count();
                                        shopInfo.GoodsLabelTwo = gLabelTwos[0].GoodsLabelOne;
                                    }
                                }
                            }

                            #endregion

                            mShopInfos.Add(shopInfo);
                        }

                        #endregion

                        int total = DbSession.MLT.ExecuteSql<int>(sqlCount).FirstOrDefault();
                        M_QueryShopRes mQuery = new M_QueryShopRes();
                        mQuery.Total = total;
                        mQuery.ShopInfos = mShopInfos;

                        return mQuery;
                    }

                    return null;
                }, new TimeSpan(0, 1, 0));

            ptcp.ReturnValue = allDatas;
            ptcp.DoFlag = PtcpState.Success;
            ptcp.DoResult = "查询成功";

            return ptcp;
        }

        /// <summary>
        /// 根据店铺ID查询店铺信息
        /// </summary>
        /// <param name="shopId"></param>
        /// <returns></returns>
        public Ptcp<M_QueryShopInfoRes> QueryShopInfo(int shopId)
        {
            var ptcp = new Ptcp<M_QueryShopInfoRes>();

            if (shopId <= 0)
            {
                ptcp.DoResult = "店铺ID错误";
                return ptcp;
            }

            #region 组装查询SQL语句

            string sql = string.Format(@"SELECT * FROM dbo.T_InforConfigure WHERE SysNo = {0} AND IsEnable = 1 ",shopId);

            #endregion

            var shop = DbSession.MLT.ExecuteSql<T_InforConfigure>(sql).FirstOrDefault();
            if (shop.IsNotNull() && shop.SysNo > 0)
            {
                //根据店铺信息拉取店铺商品信息
                string sqlShopGoods = string.Format(@"SELECT * FROM T_ShopGoods WHERE ShopSysNo = {0} AND IsEnable = 1", shopId);
                var shopGoodsInfos = DbSession.MLT.ExecuteSql<T_ShopGoods>(sqlShopGoods).ToList();

                //根据商品信息拉取抵用抵用的信息
                string sqlCoupons = string.Format(@"SELECT * FROM T_CouponInfo WHERE ShopSysNo = {0} AND IsEnable = 1", shopId);
                var couponInfos = DbSession.MLT.ExecuteSql<T_CouponInfo>(sqlCoupons).ToList();

                #region 组装数据

                M_ShopInfo shopInfo = new M_ShopInfo();
                shopInfo.SysNo = shop.SysNo.GetValueOrDefault();
                shopInfo.ShopName = shop.InforName;
                shopInfo.ShopDesc = shop.InforDesc;
                shopInfo.ShopRemark = shop.InforRemark;
                shopInfo.LogoIcon = shop.LogoIcon;
                shopInfo.HeadPic = shop.HeadPic;
                shopInfo.CoverPic = shop.CoverPic;
                shopInfo.PushPic = shop.PushPic;
                shopInfo.ShopPic = shop.ShopPic;
                shopInfo.VideoUrl = shop.VideoUrl;
                shopInfo.CateId = shop.CateId.GetValueOrDefault();
                shopInfo.InforSource = shop.InforSource;
                shopInfo.LinkUrl = shop.LinkUrl;

                if (shop.SourceDateTime != null)
                {
                    shopInfo.SourceDateTime = Convert.ToDateTime(shop.SourceDateTime);
                    shopInfo.StrSourceDateTime = shop.SourceDateTime.ToString();
                }

                #region 处理最高抵佣金、活动限制数量、剩余数量

                shopInfo.HighMoney = 0;
                shopInfo.StrHighMoney = shopInfo.HighMoney.ToString();
                //最高抵佣金
                if (couponInfos.IsNotNull() && couponInfos.IsHasRow())
                {
                    var shopCouponInfos = couponInfos.Where(c => c.ShopSysNo == shopInfo.SysNo).ToList();
                    if (shopCouponInfos.IsNotNull() && shopCouponInfos.IsHasRow())
                    {
                        shopInfo.HighMoney = Convert.ToDecimal(shopCouponInfos.Max(c => c.ExcAmount));
                        shopInfo.StrHighMoney = shopInfo.HighMoney.ToString();
                    }
                }

                //活动限制数量
                shopInfo.LimitCount = 0;
                shopInfo.SurplusCount = 0;
                shopInfo.GoodsLabelOneCount = 0;
                shopInfo.GoodsLabelTwoCount = 0;
                if (shopGoodsInfos.IsNotNull() && shopGoodsInfos.IsHasRow())
                {
                    var shopGoodsDatas = shopGoodsInfos.Where(c => c.ShopSysNo == shopInfo.SysNo).ToList();
                    if (shopGoodsDatas.IsNotNull() && shopGoodsDatas.IsHasRow())
                    {
                        shopInfo.LimitCount = shopGoodsDatas.Sum(c => c.CouponCount).GetValueOrDefault();
                        shopInfo.SurplusCount = shopGoodsDatas.Sum(c => c.OverCouponCount).GetValueOrDefault();

                        var gLabelOnes = shopGoodsDatas.Where(c => c.GoodsLabelOne != "").ToList();
                        if (gLabelOnes.IsHasRow())
                        {
                            shopInfo.GoodsLabelOneCount = gLabelOnes.Count();
                            shopInfo.GoodsLabelOne = gLabelOnes[0].GoodsLabelOne;
                        }

                        var gLabelTwos = shopGoodsDatas.Where(c => c.GoodsLabelTwo != "").ToList();
                        if (gLabelTwos.IsHasRow())
                        {
                            shopInfo.GoodsLabelTwoCount = gLabelTwos.Count();
                            shopInfo.GoodsLabelTwo = gLabelTwos[0].GoodsLabelTwo;
                        }
                    }
                }

                #endregion

                #endregion

                ptcp.ReturnValue = new M_QueryShopInfoRes();
                ptcp.ReturnValue.ShopInfo = shopInfo;
                ptcp.DoFlag = PtcpState.Success;
                ptcp.DoResult = "查询成功";
                return ptcp;
            }

            return ptcp;
        }

        /// <summary>
        /// 根据店铺ID，获取店铺下面所有的商品信息
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public Ptcp<M_QueryShopGoodsRes> QueryShopGoods(M_QueryShopGoodsReq req)
        {
            var ptcp = new Ptcp<M_QueryShopGoodsRes>();

            if (req.IsNull())
            {
                ptcp.DoResult = "请求数据非法";
                return ptcp;
            }

            string jsonParam = JsonConvert.SerializeObject(req);
            Logger.Write(LoggerLevel.Error, "QueryShopGoods_in", "", jsonParam, "");

            if (req.ShopId <= 0)
            {
                ptcp.DoResult = "店铺ID错误";
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

            string goodsLabel = req.GoodsLabelOne;
            if (string.IsNullOrEmpty(goodsLabel))
            {
                goodsLabel = req.GoodsLabelTwo;
            }

            if (string.IsNullOrEmpty(goodsLabel))
            {
                goodsLabel = "0";
            }

            var chacheKeyShop = string.Format("{0}.QueryByShopSysNo.{1}", GetType().Name, req.ShopId);
            var shopInfo = CacheClientSession.LocalCacheClient.Get(chacheKeyShop, () =>
                {
                    return DbSession.MLT.T_InforConfigureRepository.QueryBy(new T_InforConfigure()
                        {
                            SysNo = req.ShopId,
                            IsEnable = true
                        }).FirstOrDefault();
                }, new TimeSpan(0,10,0));

            if (shopInfo.IsNull() || shopInfo.SysNo <= 0)
            {
                ptcp.DoResult = "获取店铺信息失败";
                return ptcp;
            }

            #region

            string sqlgoodsLab = " AND 1 = 1 ";
            if (!string.IsNullOrEmpty(req.GoodsLabelOne))
            {
                sqlgoodsLab = string.Format(@" AND GoodsLabelOne = '{0}'", req.GoodsLabelOne);
            }
            else
            {
                if (!string.IsNullOrEmpty(req.GoodsLabelTwo))
                {
                    sqlgoodsLab = string.Format(@" AND GoodsLabelTwo = '{0}'", req.GoodsLabelTwo);
                }
            }

            string sql = string.Format(@"SELECT TOP {0} * FROM (SELECT ROW_NUMBER() OVER (ORDER BY IntSort DESC) AS RowNumber,* FROM T_ShopGoods WHERE ShopSysNo = {1} {3} AND IsEnable = 1) as A  
                         WHERE RowNumber > {0}*({2}-1) ORDER BY A.IntSort DESC", req.PageSize, req.ShopId, req.PageIndex, sqlgoodsLab);

            string sqlCount = string.Format(@"SELECT COUNT(0) FROM T_ShopGoods WHERE ShopSysNo = {0} {1} AND IsEnable = 1", req.ShopId, sqlgoodsLab);

            M_QueryShopGoodsRes queryShop = new M_QueryShopGoodsRes();
            var goodsInfos = DbSession.MLT.ExecuteSql<T_ShopGoods>(sql).ToList();
            if (goodsInfos.IsNotNull() && goodsInfos.IsHasRow())
            {
                int total = DbSession.MLT.ExecuteSql<int>(sqlCount).FirstOrDefault();

                var coupons = DbSession.MLT.T_CouponInfoRepository.QueryBy(new T_CouponInfo()
                {
                    ShopSysNo = req.ShopId,
                    IsEnable = true
                }).ToList();

                List<M_ShopGoodsEntity> shopGoods = new List<M_ShopGoodsEntity>();
                foreach (var goods in goodsInfos)
                {
                    #region

                    M_ShopGoodsEntity shopGoodsEntity = new M_ShopGoodsEntity();
                    shopGoodsEntity.SysNo = goods.SysNo.GetValueOrDefault();
                    shopGoodsEntity.ShopSysNo = goods.ShopSysNo.GetValueOrDefault();
                    shopGoodsEntity.GoodsName = goods.GoodsName;
                    shopGoodsEntity.GoodsPic = goods.GoodsPic;
                    shopGoodsEntity.GoodsOutLink = goods.GoodsOutLink;
                    shopGoodsEntity.MarketPrice = Convert.ToDecimal(goods.MarketPrice);
                    shopGoodsEntity.StrMarketPrice = shopGoodsEntity.MarketPrice.ToString();
                    shopGoodsEntity.GoodsLabelOne = goods.GoodsLabelOne;
                    shopGoodsEntity.GoodsLabelTwo = goods.GoodsLabelTwo;

                    shopGoodsEntity.ExcCouponSysNo = goods.ExcCouponSysNo.GetValueOrDefault();
                    shopGoodsEntity.CouponCount = goods.CouponCount.GetValueOrDefault();
                    shopGoodsEntity.UseCouponCount = goods.UseCouponCount.GetValueOrDefault();
                    shopGoodsEntity.OverCouponCount = goods.OverCouponCount.GetValueOrDefault();

                    if (coupons.IsNotNull() && coupons.IsHasRow())
                    {
                        var couponInfo = coupons.Where(c => c.SysNo == goods.ExcCouponSysNo).FirstOrDefault();
                        if (couponInfo.IsNotNull() && couponInfo.SysNo > 0)
                        {
                            shopGoodsEntity.ExcAmount = Convert.ToDecimal(couponInfo.ExcAmount);
                            shopGoodsEntity.StrExcAmount = shopGoodsEntity.ExcAmount.ToString();

                            M_ExcCouponInfo mExc = new M_ExcCouponInfo();
                            mExc.ShopName = shopInfo.InforName;
                            mExc.LogoIcon = shopInfo.LogoIcon;
                            mExc.GoodsName = goods.GoodsName;
                            mExc.GoodsPic = goods.GoodsPic;
                            mExc.ShopRemark = shopInfo.InforRemark;
                            mExc.ShopDesc = shopInfo.InforDesc;
                            mExc.HeadPic = shopInfo.HeadPic;
                            mExc.CoverPic = shopInfo.CoverPic;
                            mExc.ExcAmount = couponInfo.ExcAmount.GetValueOrDefault();
                            mExc.StrExcAmount = mExc.ExcAmount.ToString();
                            mExc.StrIsEffective = "有效";
                            mExc.CouponType = couponInfo.CouponType.GetValueOrDefault();

                            //mExc.CouponValue = couponInfo.CouponCode;
                            mExc.CouponValue = "";
                            //if (mExc.CouponType == (int)Enums.CouponType.PriCode)
                            //{
                            //    mExc.CouponValue = code;
                            //}

                            mExc.UseRule = couponInfo.UseRule;
                            mExc.RuleContent = couponInfo.RuleContent;

                            shopGoodsEntity.ExcCoupon = mExc;
                        }
                    }

                    #endregion

                    shopGoods.Add(shopGoodsEntity);
                }

                queryShop.GoodsEntities = shopGoods;
                queryShop.Total = total;
            }

            #endregion

            ptcp.ReturnValue = queryShop;
            ptcp.DoFlag = PtcpState.Success;
            ptcp.DoResult = "查询成功";

            return ptcp;
        }

        /// <summary>
        /// 根据广告(答题)咨询ID获取所有的题目信息
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="inforSysNo"></param>
        /// <returns></returns>
        public Ptcp<M_QuerySubjectRes> QuerySubject(int userId,int inforSysNo)
        {
            var ptcp = new Ptcp<M_QuerySubjectRes>();

            string jsonParam = string.Format("userId：{0};inforSysNo:{1}", userId, inforSysNo);
            Logger.Write(LoggerLevel.Error, "QuerySubject_in", "", jsonParam, "");

            if (userId <= 0)
            {
                ptcp.DoResult = "会员ID错误";
                return ptcp;
            }

            if (inforSysNo <= 0)
            {
                ptcp.DoResult = "信息ID错误";
                return ptcp;
            }

            //获取当前信息下面的所有的一级题目
            var subOne = DbSession.MLT.T_SubjectRepository.QueryBy(new T_Subject()
                {
                    InforSysNo = inforSysNo,
                    IsEnable = true
                }).FirstOrDefault();
            if (subOne.IsNull() || subOne.SysNo <= 0)
            {
                ptcp.DoResult = "没有题目";
                return ptcp;
            }

            //检查当前会员是否已经答过了
            var answerRecord = DbSession.MLT.T_AnswerRecordRepository.QueryBy(new T_AnswerRecord()
                {
                    UserId = userId,
                    SubSysNo = subOne.SysNo,
                    IsEnable = true
                }).FirstOrDefault();

            List<M_SubjectEntity> subjects = new List<M_SubjectEntity>();
            M_SubjectEntity subject = new M_SubjectEntity();
            subject.SysNo = subOne.SysNo.GetValueOrDefault();
            subject.InforSysNo = subOne.InforSysNo.GetValueOrDefault();
            subject.ProblemNameUrl = subOne.ProblemNameUrl;
            subject.AnswerMoney = Convert.ToDecimal(subOne.AnswerMoney);
            subject.StrAnswerMoney = subject.AnswerMoney.ToString();

            if (answerRecord.IsNotNull() && answerRecord.SysNo >= 0)
            {
                //已经回答过问题了
                subjects.Add(subject);

                ptcp.ReturnValue = new M_QuerySubjectRes();
                ptcp.ReturnValue.SubjectEntities = subjects;
                ptcp.ReturnValue.IsAnswer = 1;        //是否已经回答过了，0 未回答  1 已回答
                ptcp.DoFlag = PtcpState.Success;
                ptcp.DoResult = "已经答过了";
                return ptcp;
            }

            subjectEntities = new List<M_SubjectEntity>();
            subjects = RecurSubject(subOne.SysNo.GetValueOrDefault());
            ptcp.ReturnValue = new M_QuerySubjectRes();
            ptcp.ReturnValue.SubjectEntities = subjects;
            ptcp.ReturnValue.IsAnswer = 0;    //是否已经回答过了，0 未回答  1 已回答
            ptcp.DoFlag = PtcpState.Success;
            ptcp.DoResult = "获取成功";
            return ptcp;
        }

        /// <summary>
        /// 2018-01-07 作废老的分享答题逻辑 启用新的答题逻辑：根据题目ID直接获取题目信息，不判断是否已经答过
        /// 分享 没有注册会员时 根据广告(答题)咨询ID获取所有的题目信息
        /// </summary>
        /// <param name="moblie"></param>
        /// <param name="inforSysNo"></param>
        /// <returns></returns>
        public Ptcp<M_QueryShareSubjectRes> QueryShareSubject(string moblie, int inforSysNo)
        {
            var ptcp = new Ptcp<M_QueryShareSubjectRes>();

            string jsonParam = string.Format("inforSysNo:{0}", inforSysNo);
            Logger.Write(LoggerLevel.Error, "QueryShareSubject_in", "", jsonParam, "");

            if (inforSysNo <= 0)
            {
                ptcp.DoResult = "信息ID错误";
                return ptcp;
            }

            //获取当前信息下面的所有的一级题目
            var subOne = DbSession.MLT.T_SubjectRepository.QueryBy(new T_Subject()
            {
                InforSysNo = inforSysNo,
                IsEnable = true
            }).FirstOrDefault();
            if (subOne.IsNull() || subOne.SysNo <= 0)
            {
                ptcp.DoResult = "没有题目";
                return ptcp;
            }

            ////检查当前会员是否已经答过了
            //var answerRecord = DbSession.MLT.T_ShareAnswerRecordRepository.QueryBy(new T_ShareAnswerRecord()
            //{
            //    Mobile = moblie,
            //    SubSysNo = subOne.SysNo,
            //    IsEnable = true
            //}).FirstOrDefault();

            List<M_SubjectEntity> subjects = new List<M_SubjectEntity>();
            M_SubjectEntity subject = new M_SubjectEntity();
            subject.SysNo = subOne.SysNo.GetValueOrDefault();
            subject.InforSysNo = subOne.InforSysNo.GetValueOrDefault();
            subject.ProblemNameUrl = subOne.ProblemNameUrl;
            subject.AnswerMoney = Convert.ToDecimal(subOne.AnswerMoney);
            subject.StrAnswerMoney = subject.AnswerMoney.ToString();

            //if (answerRecord.IsNotNull() && answerRecord.SysNo >= 0)
            //{
            //    //已经回答过问题了
            //    subjects.Add(subject);

            //    ptcp.ReturnValue = new M_QueryShareSubjectRes();
            //    ptcp.ReturnValue.SubjectEntities = subjects;
            //    ptcp.ReturnValue.IsAnswer = 1;        //是否已经回答过了，0 未回答  1 已回答
            //    ptcp.DoFlag = PtcpState.Success;
            //    ptcp.DoResult = "已经答过了";
            //    return ptcp;
            //}

            subjectEntities = new List<M_SubjectEntity>();
            subjects = RecurSubject(subOne.SysNo.GetValueOrDefault());
            ptcp.ReturnValue = new M_QueryShareSubjectRes();
            ptcp.ReturnValue.SubjectEntities = subjects;
            ptcp.ReturnValue.IsAnswer = 0;    //是否已经回答过了，0 未回答  1 已回答
            ptcp.DoFlag = PtcpState.Success;
            ptcp.DoResult = "获取成功";
            return ptcp;
        }

        /// <summary>
        /// 获取参与答题的会员记录(头像、数量)
        /// </summary>
        /// <param name="inforSysNo"></param>
        /// <returns></returns>
        public Ptcp<M_SubjectParticipateRes> SubjectParticipate(int inforSysNo)
        {
            var ptcp = new Ptcp<M_SubjectParticipateRes>();

            if (inforSysNo <= 0)
            {
                ptcp.DoResult = "题目编号错误";
                return ptcp;
            }

            string cacheKey = string.Format("{0}.SubjectParticipate.{1}", GetType().Name, inforSysNo);

            var allPart = CacheClientSession.LocalCacheClient.Get(cacheKey, () =>
                {
                    //获取根题目
                    var subject = DbSession.MLT.T_SubjectRepository.QueryBy(new T_Subject()
                        {
                            InforSysNo = inforSysNo,
                            IsEnable = true
                        }).FirstOrDefault();

                    if (subject.IsNotNull() && subject.SysNo > 0)
                    {
                        #region

                        //获取答题记录
                        var ansRecordsAll = DbSession.MLT.T_AnswerRecordRepository.QueryTopBy(6,new T_AnswerRecord()
                            {
                                SubSysNo = subject.SysNo,
                                IsEnable = true
                            }, "ORDER BY SysNo DESC").ToList();


                        if (ansRecordsAll.IsNotNull() && ansRecordsAll.IsHasRow())
                        {
                            //获取答题记录
                            #region 获取答题记录

                            List<int> userids = ansRecordsAll.Select(c => c.UserId.GetValueOrDefault()).ToList();
                            string strUserIds = string.Join(",", userids);

                            string sql = string.Format(@"SELECT * FROM T_Member WHERE SysNo IN ({0})", strUserIds);
                            ;
                            var memberInfos = DbSession.MLT.ExecuteSql<T_Member>(sql).ToList();
                            if (memberInfos.IsNotNull() && memberInfos.IsHasRow())
                            {
                                List<M_ParticipateRecord> mParticipate = new List<M_ParticipateRecord>();
                                foreach (var mp in memberInfos)
                                {
                                    mParticipate.Add(new M_ParticipateRecord()
                                    {
                                        UserId = mp.SysNo.GetValueOrDefault(),
                                        Portrait = mp.Portrait,
                                        NickName = mp.NickName
                                    });
                                }

                                M_SubjectParticipateRes mSubject = new M_SubjectParticipateRes();
                                mSubject.Participates = mParticipate;

                                int allCount = ansRecordsAll.Count + subject.AnswerCount.GetValueOrDefault();
                                string showNum = "0";
                                if (allCount > 1000)
                                {
                                    showNum = string.Format("{0}k", Math.Round((float)allCount / 1000, 1));
                                }
                                else
                                {
                                    showNum = allCount.ToString();
                                }

                                mSubject.ParticipateCount = string.Format("+{0}", showNum);

                                return mSubject;
                            }

                            #endregion
                        }

                        #endregion
                    }

                    return null;
                }, new TimeSpan(0, 5, 0));
            
            ptcp.ReturnValue = new M_SubjectParticipateRes();
            ptcp.ReturnValue = allPart;
            ptcp.DoFlag = PtcpState.Success;
            return ptcp;
        }

        /// <summary>
        /// 保存答案，获得奖励金
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public Ptcp<M_AddAnswerRecordRes> AddAnswerRecord(M_AddAnswerRecordrReq req)
        {
            var ptcp = new Ptcp<M_AddAnswerRecordRes>();

            if (req.IsNull())
            {
                ptcp.DoResult = "请求数据非法";
                return ptcp;
            }

            string jsonParam = JsonConvert.SerializeObject(req);
            Logger.Write(LoggerLevel.Error, "AddAnswerRecord_in", "", jsonParam, "");

            if (req.UserId <= 0)
            {
                ptcp.DoResult = "请输入会员ID";
                return ptcp;
            }

            if (req.RecordEntities.IsNull() || !req.RecordEntities.IsHasRow())
            {
                ptcp.DoResult = "请求数据非法";
                return ptcp;
            }

            List<M_AnswerRecordEntity> mAnswer = new List<M_AnswerRecordEntity>();
            foreach (var re in req.RecordEntities)
            {
                if (re.SubSysNo <= 0)
                {
                    ptcp.DoResult = "题目ID不能小于等于0";
                    return ptcp;
                }

                if (re.AnsSysNo <= 0)
                {
                    ptcp.DoResult = "答案ID不能小于等于0";
                    return ptcp;
                }
                if (!mAnswer.Any(c => c.SubSysNo == re.SubSysNo && c.AnsSysNo == re.AnsSysNo))
                {
                    mAnswer.Add(re);
                }
            }

            req.RecordEntities = mAnswer;

            List<int> subSysNos = req.RecordEntities.Select(c => c.SubSysNo).ToList();
            string strSubSysNo = string.Join(",", subSysNos);

            string sql = string.Format(@"SELECT * FROM T_Subject WHERE SysNo IN ({0}) AND InforSysNo != 0 AND IsEnable = 1",strSubSysNo);
            var tsub = DbSession.MLT.ExecuteSql<T_Subject>(sql).FirstOrDefault();
            if (tsub.IsNull() || tsub.SysNo <= 0)
            {
                ptcp.DoResult = "获取抵用金额失败，请稍后再试";
                return ptcp;
            }

            //检查当前会员是否已经答过了
            var answerRecord = DbSession.MLT.T_AnswerRecordRepository.QueryBy(new T_AnswerRecord()
            {
                UserId = req.UserId,
                SubSysNo = tsub.SysNo,
                IsEnable = true
            }).FirstOrDefault();
            if (answerRecord.IsNotNull() && answerRecord.SysNo > 0)
            {
                ptcp.DoResult = "您已经回答过当前题目了";
                return ptcp;
            }

            DateTime dtNow = DateTime.Now;
            foreach (var rec in req.RecordEntities)
            {
                decimal? answerMoney = 0;
                if (rec.SubSysNo == tsub.SysNo)
                {
                    answerMoney = tsub.AnswerMoney;
                }
                DbSession.MLT.T_AnswerRecordRepository.Add(new T_AnswerRecord()
                    {
                        UserId = req.UserId,
                        SubSysNo = rec.SubSysNo,
                        AnsSysNo = rec.AnsSysNo,
                        AnswerMoney = answerMoney,
                        RowCeateDate = dtNow,
                        IsEnable = true
                    });
            }

            //账号新增流水，插入抵用金
            fb.AddAccountRecord(new M_AddAccountRecordReq()
                {
                    TranType = (int)Enums.TranType.Partic,
                    UserId = req.UserId,
                    TranNum = Convert.ToDecimal(tsub.AnswerMoney)
                });

            DbSession.MLT.SaveChange();

            ptcp.ReturnValue = new M_AddAnswerRecordRes();
            ptcp.ReturnValue.AnswerMoney = Convert.ToDecimal(tsub.AnswerMoney);
            ptcp.ReturnValue.StrAnswerMoney = tsub.AnswerMoney.ToString();
            ptcp.DoFlag = PtcpState.Success;
            ptcp.DoResult = "保存成功";
            return ptcp;
        }

        /// <summary>
        /// 2018-01-07 作废老的分享答题逻辑 启用新的答题逻辑：根据题目ID直接获取题目信息，不判断是否已经答过
        /// h5 分享答题 保存答案，获得奖励金
        /// 会员存在：多次答题只获得一次奖励金
        /// 会员不存在：注册会员保存答案，只获得一次奖励金
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public Ptcp<M_AddShareAnswerRecordRes> AddShareAnswerRecord(M_AddShareAnswerRecordReq req)
        {
            var ptcp = new Ptcp<M_AddShareAnswerRecordRes>();

            if (req.IsNull())
            {
                ptcp.DoResult = "请求数据非法";
                return ptcp;
            }

            string jsonParam = JsonConvert.SerializeObject(req);
            Logger.Write(LoggerLevel.Error, "AddShareAnswerRecord_in", "", jsonParam, "");

            if (string.IsNullOrEmpty(req.Mobile))
            {
                ptcp.DoResult = "请输入手机号码";
                return ptcp;
            }

            if (req.ShareUserId <= 0)
            {
                ptcp.DoResult = "分享人不能为空";
                return ptcp;
            }

            if (req.RecordEntities.IsNull() || !req.RecordEntities.IsHasRow())
            {
                ptcp.DoResult = "请求数据非法";
                return ptcp;
            }

            List<M_AnswerRecordEntity> mAnswer = new List<M_AnswerRecordEntity>();
            foreach (var re in req.RecordEntities)
            {
                if (re.SubSysNo <= 0)
                {
                    ptcp.DoResult = "题目ID不能小于等于0";
                    return ptcp;
                }

                if (re.AnsSysNo <= 0)
                {
                    ptcp.DoResult = "答案ID不能小于等于0";
                    return ptcp;
                }

                if (!mAnswer.Any(c => c.SubSysNo == re.SubSysNo && c.AnsSysNo == re.AnsSysNo))
                {
                    mAnswer.Add(re);
                }
            }

            req.RecordEntities = mAnswer;

            List<int> subSysNos = req.RecordEntities.Select(c => c.SubSysNo).ToList();
            string strSubSysNo = string.Join(",", subSysNos);

            string sql = string.Format(@"SELECT * FROM T_Subject WHERE SysNo IN ({0}) AND InforSysNo != 0 AND IsEnable = 1", strSubSysNo);
            var tsub = DbSession.MLT.ExecuteSql<T_Subject>(sql).FirstOrDefault();
            if (tsub.IsNull() || tsub.SysNo <= 0)
            {
                ptcp.DoResult = "获取抵用金额失败，请稍后再试";
                return ptcp;
            }

            DateTime dtNow = DateTime.Now;
            //判断当前手机号码是否已经注册过了
            var memInfo = mem.QueryMemberInfoByMobile(req.Mobile);
            if (memInfo.DoFlag == PtcpState.Success)
            {
                //会员已经存在
                int userid = Converter.ParseInt(memInfo.DoResult, 0);

                #region 已注册的会员

                //检查当前会员是否已经答过了
                var answerRecord = DbSession.MLT.T_AnswerRecordRepository.QueryBy(new T_AnswerRecord()
                {
                    UserId = userid,
                    SubSysNo = tsub.SysNo,
                    IsEnable = true
                }).FirstOrDefault();
                if (answerRecord.IsNotNull() && answerRecord.SysNo > 0)
                {
                    ptcp.DoResult = "您已经回答过当前题目了";
                    ptcp.DoFlag = PtcpState.Success;
                    return ptcp;
                }

                //将答题记录插入到正式的答题记录表
                foreach (var rec in req.RecordEntities)
                {
                    decimal? answerMoney = 0;
                    if (rec.SubSysNo == tsub.SysNo)
                    {
                        answerMoney = tsub.AnswerMoney;
                    }
                    DbSession.MLT.T_AnswerRecordRepository.Add(new T_AnswerRecord()
                    {
                        UserId = userid,
                        SubSysNo = rec.SubSysNo,
                        AnsSysNo = rec.AnsSysNo,
                        AnswerMoney = answerMoney,
                        RowCeateDate = dtNow,
                        IsEnable = true
                    });
                }

                //账号新增流水，插入抵用金  被分享人/当前答题人
                fb.AddAccountRecord(new M_AddAccountRecordReq()
                {
                    TranType = (int)Enums.TranType.Partic,
                    UserId = userid,
                    TranNum = Convert.ToDecimal(tsub.AnswerMoney)
                });

                ////账号新增流水，插入抵用金  分享人
                //fb.AddAccountRecord(new M_AddAccountRecordReq()
                //{
                //    TranType = (int)Enums.TranType.Partic,
                //    UserId = req.ShareUserId,
                //    TranNum = Convert.ToDecimal(tsub.AnswerMoney)
                //});

                DbSession.MLT.SaveChange();

                ptcp.ReturnValue = new M_AddShareAnswerRecordRes();
                ptcp.ReturnValue.AnswerMoney = Convert.ToDecimal(tsub.AnswerMoney);
                ptcp.ReturnValue.StrAnswerMoney = tsub.AnswerMoney.ToString();
                ptcp.DoFlag = PtcpState.Success;
                ptcp.DoResult = "保存成功";
                return ptcp;

                #endregion
            }
            else
            {
                #region  没有注册的会员

                //检查当前会员是否已经答过了
                var answerRecord = DbSession.MLT.T_ShareAnswerRecordRepository.QueryBy(new T_ShareAnswerRecord()
                {
                    Mobile = req.Mobile,
                    SubSysNo = tsub.SysNo,
                    IsEnable = true
                }).FirstOrDefault();
                if (answerRecord.IsNotNull() && answerRecord.SysNo > 0)
                {
                    ptcp.DoResult = "您已经回答过当前题目了";
                    ptcp.DoFlag = PtcpState.Success;
                    return ptcp;
                }

                //保存邀请分享记录，以供注册的时候判断处理
                DbSession.MLT.T_ShareRegisterRepository.Add(new T_ShareRegister()
                {
                    ShareUserId = req.ShareUserId,
                    ShareSysNo = tsub.InforSysNo,
                    CoverMobile = req.Mobile,
                    IsReceive = false,
                    RowCeateDate = dtNow,
                    IsEnable = true
                });

                ////将其他的回答记录作废
                //DbSession.MLT.T_ShareAnswerRecordRepository.Update(new T_ShareAnswerRecord()
                //    {
                //        IsEnable = false
                //    },new T_ShareAnswerRecord()
                //        {
                //            Mobile = req.Mobile,
                //            IsEnable = true
                //        });
                //DbSession.MLT.SaveChange();

                //将答题记录插入到分享的记录表
                foreach (var rec in req.RecordEntities)
                {
                    decimal? answerMoney = 0;
                    if (rec.SubSysNo == tsub.SysNo)
                    {
                        answerMoney = tsub.AnswerMoney;
                    }
                    DbSession.MLT.T_ShareAnswerRecordRepository.Add(new T_ShareAnswerRecord()
                    {
                        Mobile = req.Mobile,
                        SubSysNo = rec.SubSysNo,
                        AnsSysNo = rec.AnsSysNo,
                        AnswerMoney = answerMoney,
                        RowCeateDate = dtNow,
                        IsTransfer = 0,
                        IsEnable = true
                    });
                }

                ////账号新增流水，插入抵用金
                //fb.AddAccountRecord(new M_AddAccountRecordReq()
                //{
                //    TranType = (int)Enums.TranType.Partic,
                //    UserId = req.UserId,
                //    TranNum = Convert.ToDecimal(tsub.AnswerMoney)
                //});

                DbSession.MLT.SaveChange();

                ptcp.ReturnValue = new M_AddShareAnswerRecordRes();
                ptcp.ReturnValue.AnswerMoney = Convert.ToDecimal(tsub.AnswerMoney);
                ptcp.ReturnValue.StrAnswerMoney = tsub.AnswerMoney.ToString();
                ptcp.DoFlag = PtcpState.Success;
                ptcp.DoResult = "保存成功";

                return ptcp;

                #endregion
            }
            
            return ptcp;
        }

        /// <summary>
        /// 答题推荐商品
        /// </summary>
        /// <param name="rootSubSysNo">根题，第一道题的ID</param>
        /// <param name="ansSysNo"></param>
        /// <returns></returns>
        public Ptcp<M_QuerySubjectRecommendRes> QuerySubjectRecommend(int rootSubSysNo, int ansSysNo)
        {
            var ptcp = new Ptcp<M_QuerySubjectRecommendRes>();

            string jsonParam = string.Format("rootSubSysNo：{0}；ansSysNo：{1}",rootSubSysNo,ansSysNo);
            Logger.Write(LoggerLevel.Error, "QuerySubjectRecommend_in", "", jsonParam, "");

            if (rootSubSysNo <= 0)
            {
                ptcp.DoResult = "初始题ID错误";
                return ptcp;
            }

            if (ansSysNo <= 0)
            {
                ptcp.DoResult = "答案ID错误";
                return ptcp;
            }

            //获取配置的推荐数据
            var recSubs = DbSession.MLT.T_AnswerRecommendRepository.QueryBy(new T_AnswerRecommend()
                {
                    AnsSysNo = ansSysNo,
                    IsEnable = true
                }, " ORDER BY ModifyTime ASC").ToList();

            List<int> goodsIds = null;
            if (recSubs.IsNull() || !recSubs.IsHasRow())
            {
                //没有配置推荐数据 则获取当前广告题上面配置的店铺ID，如果配置了则拉取这个店铺下面所有的商品
                var ans = DbSession.MLT.T_SubjectRepository.QueryBy(new T_Subject()
                    {
                        SysNo = rootSubSysNo,
                        IsEnable = true
                    }).FirstOrDefault();
                if (ans.IsNotNull() && ans.SysNo >= 0)
                {
                    var infos = DbSession.MLT.T_InforConfigureRepository.QueryBy(new T_InforConfigure()
                        {
                            SysNo = ans.InforSysNo,
                            IsEnable = true
                        }).FirstOrDefault();
                    if (infos.IsNull() || infos.SysNo <= 0)
                    {
                        ptcp.DoResult = "未获取到题目信息";
                        return ptcp;
                    }

                    if (infos.ShopSysNo.GetValueOrDefault() <= 0)
                    {
                        ptcp.DoResult = "未获取到配置店铺信息";
                        return ptcp;
                    }

                    //获取商品信息
                    var goodsList = DbSession.MLT.T_ShopGoodsRepository.QueryBy(new T_ShopGoods()
                        {
                            ShopSysNo = infos.ShopSysNo,
                            IsEnable = true
                        }).ToList();

                    if (goodsList.IsNotNull() && goodsList.IsHasRow())
                    {
                        goodsIds = goodsList.Select(c => c.SysNo.GetValueOrDefault()).ToList();
                    }
                }
            }
            else
            {
                goodsIds = recSubs.Select(c => c.GoodsSysNo.GetValueOrDefault()).ToList();
            }

            if (goodsIds.IsNull() || !goodsIds.IsHasRow())
            {
                ptcp.DoResult = "未获取到店铺商品信息";
                return ptcp;
            }

            string strGoodsIds = string.Join(",", goodsIds);
            string sql = string.Format(@"SELECT * FROM T_ShopGoods WHERE SysNo IN ({0}) AND IsEnable = 1 ORDER BY IntSort DESC", strGoodsIds);

            var goodsInfos = DbSession.MLT.ExecuteSql<T_ShopGoods>(sql).ToList();
            if (goodsInfos.IsNotNull() && goodsInfos.IsHasRow())
            {
                List<int> shopids = goodsInfos.Select(c => c.ShopSysNo.GetValueOrDefault()).ToList();
                string strShopids = string.Join(",", shopids);
                string sqlCoupon = string.Format(@"SELECT * FROM T_CouponInfo WHERE ShopSysNo IN ({0}) AND IsEnable = 1",strShopids);
                var coupons = DbSession.MLT.ExecuteSql<T_CouponInfo>(sqlCoupon).ToList();

                string sqlShop = string.Format(@"SELECT * FROM T_InforConfigure WHERE SysNo IN ({0}) AND IsEnable = 1", strShopids);
                var shopInfoList = DbSession.MLT.ExecuteSql<T_InforConfigure>(sqlShop).ToList();

                List<M_ShopGoodsEntity> shopGoods = new List<M_ShopGoodsEntity>();
                foreach (var goods in goodsInfos)
                {
                    #region

                    M_ShopGoodsEntity shopGoodsEntity = new M_ShopGoodsEntity();
                    shopGoodsEntity.SysNo = goods.SysNo.GetValueOrDefault();
                    shopGoodsEntity.ShopSysNo = goods.ShopSysNo.GetValueOrDefault();
                    shopGoodsEntity.GoodsName = goods.GoodsName;
                    shopGoodsEntity.GoodsPic = goods.GoodsPic;
                    shopGoodsEntity.GoodsOutLink = goods.GoodsOutLink;
                    shopGoodsEntity.MarketPrice = Convert.ToDecimal(goods.MarketPrice);
                    shopGoodsEntity.StrMarketPrice = shopGoodsEntity.MarketPrice.ToString();
                    shopGoodsEntity.GoodsLabelOne = goods.GoodsLabelOne;
                    shopGoodsEntity.GoodsLabelTwo = goods.GoodsLabelTwo;

                    shopGoodsEntity.ExcCouponSysNo = goods.ExcCouponSysNo.GetValueOrDefault();
                    shopGoodsEntity.CouponCount = goods.CouponCount.GetValueOrDefault();
                    shopGoodsEntity.UseCouponCount = goods.UseCouponCount.GetValueOrDefault();
                    shopGoodsEntity.OverCouponCount = goods.OverCouponCount.GetValueOrDefault();

                    if (coupons.IsNotNull() && coupons.IsHasRow() && shopInfoList.IsNotNull() && shopInfoList.IsHasRow())
                    {
                        var couponInfo = coupons.Where(c => c.SysNo == goods.ExcCouponSysNo).FirstOrDefault();
                        if (couponInfo.IsNotNull() && couponInfo.SysNo > 0)
                        {
                            shopGoodsEntity.ExcAmount = Convert.ToDecimal(couponInfo.ExcAmount);
                            shopGoodsEntity.StrExcAmount = shopGoodsEntity.ExcAmount.ToString();

                            M_ExcCouponInfo mExc = new M_ExcCouponInfo();

                            var shopInfo = shopInfoList.Where(c => c.SysNo == couponInfo.ShopSysNo).FirstOrDefault();
                            if (shopInfo.IsNotNull() && shopInfo.SysNo > 0)
                            {
                                mExc.ShopName = shopInfo.InforName;
                                mExc.GoodsName = goods.GoodsName;
                                mExc.GoodsPic = goods.GoodsPic;
                                mExc.LogoIcon = shopInfo.LogoIcon;
                                mExc.ShopRemark = shopInfo.InforRemark;
                                mExc.ShopDesc = shopInfo.InforDesc;
                                mExc.HeadPic = shopInfo.HeadPic;
                                mExc.CoverPic = shopInfo.CoverPic;
                                mExc.PushPic = shopInfo.PushPic;
                                mExc.ShopPic = shopInfo.ShopPic;
                            }

                            mExc.ExcAmount = couponInfo.ExcAmount.GetValueOrDefault();
                            mExc.StrExcAmount = mExc.ExcAmount.ToString();
                            mExc.StrIsEffective = "有效";
                            mExc.CouponType = couponInfo.CouponType.GetValueOrDefault();

                            //mExc.CouponValue = couponInfo.CouponCode;
                            mExc.CouponValue = "";
                            //if (mExc.CouponType == (int)Enums.CouponType.PriCode)
                            //{
                            //    mExc.CouponValue = code;
                            //}

                            mExc.UseRule = couponInfo.UseRule;
                            mExc.RuleContent = couponInfo.RuleContent;

                            shopGoodsEntity.ExcCoupon = mExc;
                        }
                    }

                    shopGoods.Add(shopGoodsEntity);

                    #endregion
                }

                ptcp.ReturnValue = new M_QuerySubjectRecommendRes();
                ptcp.ReturnValue.GoodsEntities = shopGoods;
                ptcp.DoFlag = PtcpState.Success;
                ptcp.DoResult = "获取成功";
                return ptcp;
            }
            else
            {
                ptcp.DoResult = "获取商品信息失败";
            }

            return ptcp;
        }

        /// <summary>
        /// 递归拉去所有问题和答案
        /// </summary>
        /// <param name="childrenSubSysNo"></param>
        /// <returns></returns>
        private List<M_SubjectEntity> RecurSubject(int childrenSubSysNo)
        {
            M_SubjectEntity subject = new M_SubjectEntity();

            //获取当前信息下面的所有的一级题目
            var subOne = DbSession.MLT.T_SubjectRepository.QueryBy(new T_Subject()
            {
                SysNo = childrenSubSysNo,
                IsEnable = true
            }).FirstOrDefault();
            if (subOne.IsNotNull() && subOne.SysNo > 0)
            {
                subject.SysNo = subOne.SysNo.GetValueOrDefault();
                subject.InforSysNo = subOne.InforSysNo.GetValueOrDefault();
                subject.ProblemNameUrl = subOne.ProblemNameUrl;
                //subject.IsAnswer = 0;
                subject.AnswerMoney = Convert.ToDecimal(subOne.AnswerMoney);
                subject.StrAnswerMoney = subject.AnswerMoney.ToString();

                 //获取答案
                var answers = DbSession.MLT.T_AnswerRepository.QueryBy(new T_Answer()
                {
                    SubSysNo = subOne.SysNo,
                    IsEnable = true
                }).ToList();
                if (answers.IsNotNull() && answers.IsHasRow())
                {
                    List<M_AnswerEntity> mAnswer = new List<M_AnswerEntity>();
                    foreach (var an in answers)
                    {
                        if (an.ChildrenSubSysNo.GetValueOrDefault() > 0)
                        {
                            RecurSubject(an.ChildrenSubSysNo.GetValueOrDefault());
                        }

                        mAnswer.Add(new M_AnswerEntity()
                        {
                            SysNo = an.SysNo.GetValueOrDefault(),
                            SubSysNo = an.SubSysNo.GetValueOrDefault(),
                            ChildrenSubSysNo = an.ChildrenSubSysNo.GetValueOrDefault(),
                            AnswerNameUrl = an.AnswerNameUrl
                        });
                    }
                    subject.AnswerEntities = mAnswer;
                }
            }

            if (!subjectEntities.Any(c => c.SysNo == subject.SysNo))
            {
                subjectEntities.Add(subject);
            }
            return subjectEntities;
        }

        /// <summary>
        /// 兑换抵用劵
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public Ptcp<M_ExcCouponRes> ExcCoupon(M_ExcCouponReq req)
        {
            var ptcp = new Ptcp<M_ExcCouponRes>();

            #region 基础检查以及数据信息获取

            if (req.IsNull())
            {
                ptcp.DoResult = "请求数据非法";
                return ptcp;
            }

            string jsonParam = JsonConvert.SerializeObject(req);
            Logger.Write(LoggerLevel.Error, "ExcCoupon_in", "", jsonParam, "");

            if (req.UserId <= 0)
            {
                ptcp.DoResult = "会员ID错误";
                return ptcp;
            }

            if (req.GoodsId <= 0)
            {
                ptcp.DoResult = "商品ID错误";
                return ptcp;
            }

            //获取账号信息
            var memberInfo = DbSession.MLT.T_MemberRepository.QueryBy(new T_Member()
                {
                    SysNo = req.UserId
                }).FirstOrDefault();
            if (memberInfo.IsNull() || memberInfo.SysNo <= 0)
            {
                ptcp.DoResult = "获取会员信息失败";
                return ptcp;
            }

            //获取商品信息
            var goodsInfo = DbSession.MLT.T_ShopGoodsRepository.QueryBy(new T_ShopGoods()
                {
                    SysNo = req.GoodsId,
                    IsEnable = true
                }).FirstOrDefault();
            if (goodsInfo.IsNull() || goodsInfo.SysNo <= 0)
            {
                ptcp.DoResult = "获取商品信息失败";
                return ptcp;
            }

            //验证商品兑换信息
            if (goodsInfo.OverCouponCount <= 0)
            {
                ptcp.DoResult = "很抱歉，已全部抢光了";
                return ptcp;
            }

            //获取抵用劵的信息
            var couponInfo = DbSession.MLT.T_CouponInfoRepository.QueryBy(new T_CouponInfo()
                {
                    SysNo = goodsInfo.ExcCouponSysNo,
                    IsEnable = true
                }).FirstOrDefault();
            if (couponInfo.IsNull() || couponInfo.SysNo <= 0)
            {
                ptcp.DoResult = "获取抵用劵信息失败";
                return ptcp;
            }

            var shopInfo = DbSession.MLT.T_InforConfigureRepository.QueryBy(new T_InforConfigure()
            {
                SysNo = goodsInfo.ShopSysNo,
                IsEnable = true
            }).FirstOrDefault();
            if (shopInfo.IsNull() || shopInfo.SysNo <= 0)
            {
                ptcp.DoResult = "获取店铺信息失败";
                return ptcp;
            }

            #endregion

            string code = "";
            int priSysNo = 0;

            #region 如果是私码，则需要去除已使用的码  判断账号抵佣金是否满足兑换当前商品

            //如果是私码，则需要去除未使用的码
            if (couponInfo.CouponType == (int) Enums.CouponType.PriCode)
            {
                #region 去除已使用的私码

                string sql =
                    string.Format(
                        @"SELECT TOP 1 * FROM T_CouponPrivateCode WHERE CouponSysNo = {0} AND (UserId <= 0  OR UserId IS NULL) AND IsEnable = 1 ORDER BY SysNo ASC",
                        couponInfo.SysNo);

                var priCode = DbSession.MLT.ExecuteSql<T_CouponPrivateCode>(sql).FirstOrDefault();
                if (priCode.IsNull() || priCode.SysNo <= 0 || string.IsNullOrEmpty(priCode.PrivateCode))
                {
                    ptcp.DoResult = "获取私码失败";
                    return ptcp;
                }

                code = priCode.PrivateCode;
                priSysNo = priCode.SysNo.GetValueOrDefault();

                #endregion
            }
            else if (couponInfo.CouponType == (int) Enums.CouponType.PubCode)
            {
                code = couponInfo.CouponCode;
            }

            //判断账号抵佣金是否满足兑换当前商品
            decimal? rechargeAmount = 0;
            decimal? useScore = 0;
            int recSys = 0;
            if (memberInfo.Score < couponInfo.ExcAmount)
            {
                //当前账号抵佣金不满足兑换当前商品，则需要充值，验证充值金额
                if (req.OrderNo <= 0)
                {
                    ptcp.DoResult = "抵用金不足，请充值";
                    return ptcp;
                }

                var rechInfo = DbSession.MLT.T_RechargeRepository.QueryBy(new T_Recharge()
                    {
                        SysNo = req.OrderNo,
                        PayState = (int)Enums.PayState.Complete,
                        IsUse = 0,
                        IsEnable = true
                    }).FirstOrDefault();
                if (rechInfo.IsNull() || rechInfo.SysNo <= 0)
                {
                    ptcp.DoResult = "抵用金不足，请充值";
                    return ptcp;
                }

                if ((memberInfo.Score + rechInfo.RechargeAmount * Enums.CashProportion) < couponInfo.ExcAmount)
                {
                    ptcp.DoResult = "抵用金不足，请充值";
                    return ptcp;
                }

                rechargeAmount = rechInfo.RechargeAmount;
                useScore = memberInfo.Score;
                recSys = rechInfo.SysNo.GetValueOrDefault();
            }
            else
            {
                useScore = couponInfo.ExcAmount;
            }

            #endregion

            #region 数据持久化

            DateTime dtNow = DateTime.Now;

            //插入兑换码使用记录
            DbSession.MLT.T_CouponExcRecordRepository.Add(new T_CouponExcRecord()
            {
                UserId = req.UserId,
                ShopSysNo = goodsInfo.ShopSysNo,
                GoodsSysNo = goodsInfo.SysNo,
                CouponSysNo = couponInfo.SysNo,
                PrivateCode = code,
                ExcAmount = couponInfo.ExcAmount,
                UseScore = useScore,
                RechargeAmount = rechargeAmount,
                RowCeateDate = dtNow,
                CouponState = (int)Enums.CouponState.Ok,
                IsEnable = true
            });

            //更新充值记录
            if (recSys > 0)
            {
                DbSession.MLT.T_RechargeRepository.Update(new T_Recharge()
                    {
                        IsUse = 1,
                        ModifyTime = dtNow,
                    }, new T_Recharge() {SysNo = recSys});
            }

            //更新抵用劵数量
            DbSession.MLT.T_ShopGoodsRepository.Update(new T_ShopGoods()
                {
                    UseCouponCount = goodsInfo.UseCouponCount + 1,
                    OverCouponCount = goodsInfo.OverCouponCount - 1,
                    ModifyTime = dtNow
                },new T_ShopGoods(){SysNo = goodsInfo.SysNo});

            //如果是私码则更新私码的使用记录
            if (priSysNo > 0)
            {
                DbSession.MLT.T_CouponPrivateCodeRepository.Update(new T_CouponPrivateCode()
                    {
                        UserId = req.UserId,
                        ModifyTime = dtNow
                    },new T_CouponPrivateCode(){SysNo = priSysNo});
            }

            //decimal? scoreDb = memberInfo.Score - useScore;
            //decimal? scoreWithdrawnDb = 0;
            //if (scoreDb < memberInfo.ScoreWithdrawn)
            //{
            //    scoreWithdrawnDb = scoreDb;
            //}
            //else
            //{
            //    scoreWithdrawnDb = memberInfo.ScoreWithdrawn;
            //}

            ////更新账户积分信息
            //DbSession.MLT.T_MemberRepository.Update(new T_Member()
            //    {
            //        Score = scoreDb,
            //        ScoreWithdrawn = scoreWithdrawnDb,
            //        ModifyTime = dtNow
            //    },new T_Member(){SysNo = req.UserId});

            //账号新增流水，插入抵用金
            fb.AddAccountRecord(new M_AddAccountRecordReq()
            {
                TranType = (int)Enums.TranType.ExcGoods,
                UserId = req.UserId,
                TranNum = useScore.GetValueOrDefault()
            });

            DbSession.MLT.SaveChange();

            #endregion

            M_ExcCouponInfo mExc = new M_ExcCouponInfo();
            mExc.ShopName = shopInfo.InforName;
            mExc.LogoIcon = shopInfo.LogoIcon;
            mExc.ShopRemark = shopInfo.InforRemark;
            mExc.ShopDesc = shopInfo.InforDesc;
            mExc.HeadPic = shopInfo.HeadPic;
            mExc.CoverPic = shopInfo.CoverPic;
            mExc.ShopPic = shopInfo.ShopPic;
            mExc.PushPic = shopInfo.PushPic;
            mExc.GoodsName = goodsInfo.GoodsName;
            mExc.GoodsPic = goodsInfo.GoodsPic;
            mExc.ExcAmount = couponInfo.ExcAmount.GetValueOrDefault();
            mExc.StrExcAmount = mExc.ExcAmount.ToString();
            mExc.StrIsEffective = "有效";
            mExc.CouponType = couponInfo.CouponType.GetValueOrDefault();

            mExc.CouponValue = couponInfo.CouponCode;
            if (mExc.CouponType == (int) Enums.CouponType.PriCode)
            {
                mExc.CouponValue = code;
            }

            mExc.UseRule = couponInfo.UseRule;
            mExc.RuleContent = couponInfo.RuleContent;

            ptcp.ReturnValue = new M_ExcCouponRes();
            ptcp.ReturnValue.ExcCoupon = mExc;
            ptcp.DoFlag = PtcpState.Success;
            ptcp.DoResult = "兑换成功";
            return ptcp;
        }

        /// <summary>
        /// 根据抵用劵ID获取抵用劵信息、店铺名称、图标
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public Ptcp<M_QueryCouponInfoRes> QueryCouponInfo(M_QueryCouponInfoReq req)
        {
            var ptcp = new Ptcp<M_QueryCouponInfoRes>();

            if (req.IsNull())
            {
                ptcp.DoResult = "请求数据非法";
                return ptcp;
            }

            if (req.ExcCouponSysNo <= 0)
            {
                ptcp.DoResult = "抵用劵ID不能为空";
                return ptcp;
            }

            //获取抵用劵的信息
            var couponInfo = DbSession.MLT.T_CouponInfoRepository.QueryBy(new T_CouponInfo()
            {
                SysNo = req.ExcCouponSysNo,
                IsEnable = true
            }).FirstOrDefault();
            if (couponInfo.IsNull() || couponInfo.SysNo <= 0)
            {
                ptcp.DoResult = "获取抵用劵信息失败";
                return ptcp;
            }

            var shopInfo = DbSession.MLT.T_InforConfigureRepository.QueryBy(new T_InforConfigure()
            {
                SysNo = couponInfo.ShopSysNo,
                IsEnable = true
            }).FirstOrDefault();
            if (shopInfo.IsNull() || shopInfo.SysNo <= 0)
            {
                ptcp.DoResult = "获取店铺信息失败";
                return ptcp;
            }

            M_ExcCouponInfo mExc = new M_ExcCouponInfo();
            mExc.ShopName = shopInfo.InforName;
            mExc.LogoIcon = shopInfo.LogoIcon;
            mExc.ShopRemark = shopInfo.InforRemark;
            mExc.ShopDesc = shopInfo.InforDesc;
            mExc.HeadPic = shopInfo.HeadPic;
            mExc.CoverPic = shopInfo.CoverPic;
            mExc.PushPic = shopInfo.PushPic;
            mExc.ShopPic = shopInfo.ShopPic;
            mExc.ExcAmount = couponInfo.ExcAmount.GetValueOrDefault();
            mExc.StrExcAmount = mExc.ExcAmount.ToString();
            mExc.StrIsEffective = "有效";
            mExc.CouponType = couponInfo.CouponType.GetValueOrDefault();

            mExc.CouponValue = couponInfo.CouponCode;
            //if (mExc.CouponType == (int)Enums.CouponType.PriCode)
            //{
            //    mExc.CouponValue = code;
            //}

            mExc.UseRule = couponInfo.UseRule;
            mExc.RuleContent = couponInfo.RuleContent;

            ptcp.ReturnValue = new M_QueryCouponInfoRes();
            ptcp.ReturnValue.ExcCoupon = mExc;
            ptcp.DoFlag = PtcpState.Success;
            ptcp.DoResult = "获取成功";
            return ptcp;
        }

        /// <summary>
        /// 我的抵用劵列表
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public Ptcp<M_QueryMyCouponRes> QueryMyCoupon(M_QueryMyCouponReq req)
        {
            var ptcp = new Ptcp<M_QueryMyCouponRes>();

            if (req.IsNull())
            {
                ptcp.DoResult = "请求数据非法";
                return ptcp;
            }

            string jsonParam = JsonConvert.SerializeObject(req);
            Logger.Write(LoggerLevel.Error, "QueryMyCoupon_in", "", jsonParam, "");

            if (req.UserId <= 0)
            {
                ptcp.DoResult = "会员ID错误";
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

            string sql = string.Format(@"SELECT TOP {0} * FROM (SELECT ROW_NUMBER() OVER (ORDER BY RowCeateDate DESC) AS RowNumber,* FROM T_CouponExcRecord WHERE UserId = {1} AND IsEnable = 1) as A  
                         WHERE RowNumber > {0}*({2}-1) ORDER BY A.RowCeateDate DESC", req.PageSize, req.UserId, req.PageIndex);

            string sqlCount =
                string.Format(@"SELECT COUNT(0) FROM T_CouponExcRecord WHERE UserId = {0} AND IsEnable = 1", req.UserId);


            var excRecords = DbSession.MLT.ExecuteSql<T_CouponExcRecord>(sql).ToList();
            if (excRecords.IsNull() || !excRecords.IsHasRow())
            {
                ptcp.DoResult = "没有抵用劵";
                return ptcp;
            }
            int total = DbSession.MLT.ExecuteSql<int>(sqlCount).FirstOrDefault();
            
            List<int> shopIds = excRecords.Select(c => c.ShopSysNo.GetValueOrDefault()).ToList();
            string strShopIds = string.Join(",", shopIds);
            string sqlShop = string.Format(@"SELECT * FROM dbo.T_InforConfigure  WHERE SysNo IN ({0}) AND IsEnable = 1",strShopIds);
            var shopInfos = DbSession.MLT.ExecuteSql<T_InforConfigure>(sqlShop).ToList();
            if (shopInfos.IsNull() || !shopInfos.IsHasRow())
            {
                ptcp.DoResult = "获取店铺信息失败";
                return ptcp;
            }
            
            List<int> souponIds = excRecords.Select(c => c.CouponSysNo.GetValueOrDefault()).ToList();
            string strCouponIds = string.Join(",", souponIds);
            string sqlCoupon = string.Format(@"SELECT * FROM dbo.T_CouponInfo  WHERE SysNo IN ({0}) AND IsEnable = 1",strCouponIds);
            var couponInfos = DbSession.MLT.ExecuteSql<T_CouponInfo>(sqlCoupon).ToList();
            if (couponInfos.IsNull() || !couponInfos.IsHasRow())
            {
                ptcp.DoResult = "获取抵用劵信息失败";
                return ptcp;
            }

            List<int> goodsIds = excRecords.Select(c => c.GoodsSysNo.GetValueOrDefault()).ToList();
            string strGoodsIds = string.Join(",", goodsIds);
            string sqlGoods = string.Format(@"SELECT * FROM dbo.T_ShopGoods  WHERE SysNo IN ({0}) AND IsEnable = 1", strGoodsIds);
            var goodInfos = DbSession.MLT.ExecuteSql<T_ShopGoods>(sqlGoods).ToList();
            if (goodInfos.IsNull() || !goodInfos.IsHasRow())
            {
                ptcp.DoResult = "获取商品信息失败";
                return ptcp;
            }

            #region 组装数据

            List<M_ExcCouponInfo> mExcCouponInfos = new List<M_ExcCouponInfo>();
            foreach (var rec in excRecords)
            {
                var shopInfo = shopInfos.Where(c => c.SysNo == rec.ShopSysNo).FirstOrDefault();
                if (shopInfo.IsNotNull() && shopInfo.SysNo > 0)
                {
                    M_ExcCouponInfo mExc = new M_ExcCouponInfo();
                    mExc.ShopName = shopInfo.InforName;
                    mExc.LogoIcon = shopInfo.LogoIcon;
                    mExc.ShopRemark = shopInfo.InforRemark;
                    mExc.ShopDesc = shopInfo.InforDesc;
                    mExc.HeadPic = shopInfo.HeadPic;
                    mExc.CoverPic = shopInfo.CoverPic;
                    mExc.PushPic = shopInfo.PushPic;
                    mExc.ShopPic = shopInfo.ShopPic;
                    mExc.ExcAmount = rec.ExcAmount.GetValueOrDefault();
                    mExc.StrExcAmount = mExc.ExcAmount.ToString();

                    mExc.StrIsEffective = Pm.TableCouponState(rec.CouponState.GetValueOrDefault());

                    var couponInfo = couponInfos.Where(c => c.SysNo == rec.CouponSysNo).FirstOrDefault();
                    if (couponInfo.IsNotNull() && couponInfo.SysNo > 0)
                    {
                        mExc.CouponType = couponInfo.CouponType.GetValueOrDefault();
                        mExc.CouponValue = couponInfo.CouponCode;
                        mExc.UseRule = couponInfo.UseRule;
                        mExc.RuleContent = couponInfo.RuleContent;
                    }

                    if (mExc.CouponType == (int)Enums.CouponType.PriCode)
                    {
                        mExc.CouponValue = rec.PrivateCode;
                    }

                    var goodInfo = goodInfos.Where(c => c.SysNo == rec.GoodsSysNo).FirstOrDefault();
                    {
                        mExc.GoodsName = goodInfo.GoodsName;
                        mExc.GoodsPic = goodInfo.GoodsPic;
                    }

                    mExcCouponInfos.Add(mExc);
                }
            }

            #endregion

            ptcp.ReturnValue = new M_QueryMyCouponRes();
            ptcp.ReturnValue.ExcCoupons = mExcCouponInfos;
            ptcp.ReturnValue.Total = total;
            ptcp.DoFlag = PtcpState.Success;
            ptcp.DoResult = "查询成功";
            return ptcp;
        }

        /// <summary>
        /// 检查是否已经收藏了
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="dataType">咨讯类型 只能是资讯才能收藏</param>
        /// <param name="InforSysNo">咨讯ID</param>
        /// <returns></returns>
        public Ptcp<M_CheckFavoritesRes> CheckFavorites(int userid, int dataType, int InforSysNo)
        {
            var ptcp = new Ptcp<M_CheckFavoritesRes>();
            ptcp.DoFlag = PtcpState.Success;
            ptcp.ReturnValue = new M_CheckFavoritesRes();

            if (userid <= 0)
            {
                ptcp.DoResult = "请输入会员ID";
                ptcp.ReturnValue.CheckRes = -1;
                return ptcp;
            }

            if (dataType != (int)Enums.DataType.News)
            {
                ptcp.DoResult = "只能收藏咨询、新闻";
                ptcp.ReturnValue.CheckRes = -2;
                return ptcp;
            }

            if (InforSysNo <= 0)
            {
                ptcp.DoResult = "请输入资讯ID";
                ptcp.ReturnValue.CheckRes = -4;
                return ptcp;
            }

            var check = DbSession.MLT.T_FavoritesRepository.QueryBy(new T_Favorites()
                {
                    UserId = userid,
                    InforSysNo = InforSysNo,
                    IsEnable = true
                }).FirstOrDefault();

            if (check.IsNotNull() && check.SysNo > 0)
            {
                ptcp.DoResult = "已经收藏过了";
                ptcp.ReturnValue.CheckRes = 1;
                ptcp.DoFlag = PtcpState.Success;
                return ptcp;
            }
            else
            {
                ptcp.DoResult = "没有收藏";
                ptcp.ReturnValue.CheckRes = 0;
                ptcp.DoFlag = PtcpState.Success;
                return ptcp;
            }
        }

        /// <summary>
        /// 收藏
        /// </summary>
        /// <param name="userid">会员ID</param>
        /// <param name="dataType">咨讯类型 只能是资讯才能收藏</param>
        /// <param name="InforSysNo">咨讯ID</param>
        /// <returns></returns>
        public Ptcp<string> AddFavorites(int userid, int dataType, int InforSysNo)
        {
            var ptcp = new Ptcp<string>();

            string jsonParam = string.Format("userid:{0}；dataType：{1}；InforSysNo：{2}", userid, dataType,InforSysNo);
            Logger.Write(LoggerLevel.Error, "AddFavorites_in", "", jsonParam, "");

            if (userid <= 0)
            {
                ptcp.DoResult = "请输入会员ID";
                return ptcp;
            }

            if (dataType != (int)Enums.DataType.News)
            {
                ptcp.DoResult = "只能收藏咨询、新闻";
                return ptcp;
            }

            if (InforSysNo <= 0)
            {
                ptcp.DoResult = "请输入资讯ID";
                return ptcp;
            }

            var favAny = DbSession.MLT.T_FavoritesRepository.QueryBy(new T_Favorites()
                {
                    UserId = userid,
                    InforSysNo = InforSysNo,
                    IsEnable = true
                }).FirstOrDefault();
            
            if (favAny.IsNotNull() && favAny.SysNo > 0)
            {
                ptcp.DoResult = "已经收藏过了";
                return ptcp;
            }

            DbSession.MLT.T_FavoritesRepository.Add(new T_Favorites()
                {
                    UserId = userid,
                    InforSysNo = InforSysNo,
                    RowCeateDate = DateTime.Now,
                    IsEnable = true
                });
            DbSession.MLT.SaveChange();
            ptcp.DoFlag = PtcpState.Success;
            ptcp.DoResult = "收藏成功";

            return ptcp;
        }

        /// <summary>
        /// 获取我的收藏
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public Ptcp<M_QueryFavoritesRes> QueryFavorites(M_QueryFavoritesReq req)
        {
            var ptcp = new Ptcp<M_QueryFavoritesRes>();

            if (req.IsNull())
            {
                ptcp.DoResult = "请求数据非法";
                return ptcp;
            }

            string jsonParam = JsonConvert.SerializeObject(req);
            Logger.Write(LoggerLevel.Error, "QueryFavorites_in", "", jsonParam, "");

            if (req.UserId <= 0)
            {
                ptcp.DoResult = "请输入会员ID";
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

            var favs = DbSession.MLT.T_FavoritesRepository.QueryBy(new T_Favorites()
                {
                    UserId = req.UserId,
                    IsEnable = true
                }).ToList();

            if (favs.IsNull() || !favs.IsHasRow())
            {
                ptcp.DoResult = "没有收藏";
                return ptcp;
            }

            string strInforSysNo = "";
            foreach (var fav in favs)
            {
                strInforSysNo += fav.InforSysNo + ",";
            }

            strInforSysNo = strInforSysNo.Trim(',');

            string sql = string.Format(@"SELECT TOP {0} * FROM (SELECT ROW_NUMBER() OVER (ORDER BY IntSort DESC) AS RowNumber,* FROM T_InforConfigure WHERE SysNo IN ({1}) AND IsEnable = 1) as A  
                         WHERE RowNumber > {0}*({2}-1) ORDER BY A.IntSort DESC", req.PageSize, strInforSysNo, req.PageIndex);

            string sqlCount = string.Format(@"SELECT COUNT(0) FROM T_InforConfigure WHERE SysNo IN ({0}) AND IsEnable = 1", strInforSysNo);

            var records = DbSession.MLT.ExecuteSql<T_InforConfigure>(sql).ToList();
            M_QueryFavoritesRes mQuery = new M_QueryFavoritesRes();
            if (records.IsNotNull() && records.IsHasRow())
            {
                int total = DbSession.MLT.ExecuteSql<int>(sqlCount).FirstOrDefault();

                mQuery.Total = total;
                mQuery.PageDatas = Mapper.MapperGeneric<T_InforConfigure, M_HomePageData>(records).ToList();
                foreach (var m in mQuery.PageDatas)
                {
                    m.StrSourceDateTime = m.SourceDateTime.ToString();
                }
            }

            ptcp.ReturnValue = mQuery;
            ptcp.DoFlag = PtcpState.Success;
            ptcp.DoResult = "查询成功";

            return ptcp;
        }

        /// <summary>
        /// 取消我的收藏
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="sysNo"></param>
        /// <returns></returns>
        public Ptcp<string> CancelFavorites(int userid, int sysNo)
        {
            var ptcp = new Ptcp<string>();

            string jsonParam = string.Format("userid:{0}；sysNo：{1}",userid,sysNo);
            Logger.Write(LoggerLevel.Error, "CancelFavorites_in", "", jsonParam, "");

            if (userid <= 0)
            {
                ptcp.DoResult = "会员ID不能为空";
                return ptcp;
            }

            if (sysNo <= 0)
            {
                ptcp.DoResult = "收藏标识不能为空";
                return ptcp;
            }

            DbSession.MLT.T_FavoritesRepository.Update(new T_Favorites()
                {
                    IsEnable = false,
                    ModifyTime = DateTime.Now
                },new T_Favorites()
                    {
                        InforSysNo = sysNo,
                        UserId = userid,
                        IsEnable = true
                    });
            DbSession.MLT.SaveChange();

            ptcp.DoResult = "取消收藏成功";
            ptcp.DoFlag = PtcpState.Success;
            return ptcp;
        }

        /// <summary>
        /// 查询账户中心推荐数据
        /// PS：调用本服务之后，前端需要自行处理掉对应页面上面的红点，后端服务会修改标识
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public Ptcp<M_QueryAccountRecommendRes> QueryAccountRecommend(M_QueryAccountRecommendReq req)
        {
            var ptcp = new Ptcp<M_QueryAccountRecommendRes>();

            if (req.IsNull())
            {
                ptcp.DoResult = "请求非法";
                return ptcp;
            }

            string jsonParam = JsonConvert.SerializeObject(req);
            Logger.Write(LoggerLevel.Error, "QueryAccountRecommend_in", "", jsonParam, "");

            if (req.UserId <= 0)
            {
                ptcp.DoResult = "请输入会员ID";
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

            var favs = DbSession.MLT.T_AccountRecommendRepository.QueryBy(new T_AccountRecommend()
            {
                UserId = req.UserId,
                IsEnable = true
            }).ToList();

            if (favs.IsNull() || !favs.IsHasRow())
            {
                ptcp.DoResult = "没有推荐内容";
                return ptcp;
            }
            string strInforSysNo = "";
            foreach (var fav in favs)
            {
                strInforSysNo += fav.InforSysNo + ",";
            }

            strInforSysNo = strInforSysNo.Trim(',');
            string sql = string.Format(@"SELECT TOP {0} * FROM (SELECT ROW_NUMBER() OVER (ORDER BY IntSort DESC) AS RowNumber,* FROM T_InforConfigure WHERE SysNo IN ({1}) AND IsEnable = 1) as A  
                         WHERE RowNumber > {0}*({2}-1) ORDER BY A.IntSort DESC", req.PageSize, strInforSysNo, req.PageIndex);

            string sqlCount = string.Format(@"SELECT COUNT(0) FROM T_InforConfigure WHERE SysNo IN ({0}) AND IsEnable = 1", strInforSysNo);

            M_QueryAccountRecommendRes mQuery = new M_QueryAccountRecommendRes();
            var records = DbSession.MLT.ExecuteSql<T_InforConfigure>(sql).ToList();
            if (records.IsNotNull() && records.IsHasRow())
            {
                int total = DbSession.MLT.ExecuteSql<int>(sqlCount).FirstOrDefault();

                mQuery.Total = total;
                mQuery.PageDatas = Mapper.MapperGeneric<T_InforConfigure, M_HomePageData>(records).ToList();
                foreach (var m in mQuery.PageDatas)
                {
                    m.StrSourceDateTime = m.SourceDateTime.ToString();
                }

                //修改红点标识
                DbSession.MLT.T_AccountRecommendRepository.Update(new T_AccountRecommend()
                    {
                        IsPushIn = 1,
                        ModifyTime = DateTime.Now
                    },new T_AccountRecommend(){UserId = req.UserId,IsPushIn = 0,IsEnable = true});
                DbSession.MLT.SaveChange();
            }

            ptcp.ReturnValue = mQuery;
            ptcp.DoFlag = PtcpState.Success;
            ptcp.DoResult = "查询成功";

            return ptcp;
        }

        /// <summary>
        /// 更新会员中心数据为已读状态，一次性全部更新掉所有的未读消息
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public Ptcp<string> UpdateAccountRecordPush(int userid)
        {
            var ptcp = new Ptcp<string>();

            if (userid <= 0)
            {
                ptcp.DoResult = "会员ID不能为空";
                return ptcp;
            }

            DbSession.MLT.T_AccountRecordRepository.Update(new T_AccountRecord()
            {
                IsPushIn = 1
            }, new T_AccountRecord() { UserId = userid, IsPushIn = 0, IsEnable = true });
            DbSession.MLT.SaveChange();

            ptcp.DoFlag = PtcpState.Success;
            ptcp.DoResult = "更新成功";
            return ptcp;
        }

        /// <summary>
        /// 获取兑换或个人账户中心未读取消息数量
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public Ptcp<M_QueryNoReadInfoRes> QueryNoReadInfo(int userid)
        {
            var ptcp = new Ptcp<M_QueryNoReadInfoRes>();

            if (userid <= 0)
            {
                ptcp.DoResult = "会员ID不能为空";
                return ptcp;
            }

            long recCount = DbSession.MLT.T_AccountRecommendRepository.QueryCountBy(new T_AccountRecommend()
                {
                    UserId = userid,
                    IsPushIn = 0,
                    IsEnable = true
                });

            long accRecCount = DbSession.MLT.T_AccountRecordRepository.QueryCountBy(new T_AccountRecord()
                {
                    UserId = userid,
                    IsPushIn = 0,
                    IsEnable = true
                });

            ptcp.ReturnValue = new M_QueryNoReadInfoRes();
            ptcp.ReturnValue.AccountCount = Converter.ParseInt(recCount, 0);
            ptcp.ReturnValue.ScoreCount = Converter.ParseInt(accRecCount, 0);
            ptcp.DoFlag = PtcpState.Success;
            ptcp.DoResult = "查询成功";

            return ptcp;
        }

        /// <summary>
        /// 根据ID查询分享的标题
        /// </summary>
        /// <param name="sysno"></param>
        /// <returns></returns>
        public Ptcp<M_QueryShareTitleRes> QueryShareTitle(int sysno)
        {
            var ptcp = new Ptcp<M_QueryShareTitleRes>();

            var info = DbSession.MLT.T_InforConfigureRepository.QueryBy(new T_InforConfigure()
                {
                    SysNo = sysno,
                    IsEnable = true
                }).FirstOrDefault();

            if (info.IsNotNull())
            {
                var pl = Mapper.Map<T_InforConfigure, M_HomePageData>(info);
                ptcp.ReturnValue = new M_QueryShareTitleRes();
                ptcp.ReturnValue.PageData = pl;
                ptcp.DoFlag = PtcpState.Success;
            }

            return ptcp;
        }

        /// <summary>
        /// T_SelfMediaArticle 转换为 T_InforConfigure
        /// </summary>
        /// <param name="art"></param>
        /// <returns></returns>
        private static T_InforConfigure TableTInforConfigure(T_SelfMediaArticle art,List<T_SelfMediaAuthor> authors)
        {
            if (art.IsNotNull())
            {
                T_InforConfigure infor = new T_InforConfigure();
                infor.SysNo = art.SysNo;
                infor.DataType = 8;
                infor.StrInforType = art.StrInforType;
                infor.HeadPic = art.HeadPic;

                infor.InforName = art.Title;
                infor.InforRemark = art.Subtitle;

                infor.InforDesc = "";
                if (authors.IsNotNull() && authors.IsHasRow())
                {
                    var auth = authors.Where(c => c.SysNo == art.AuthorSysNo).FirstOrDefault();
                    if (auth.IsNotNull())
                    {
                        infor.InforDesc = auth.AuthorName;   //作者
                    }
                }

                infor.ShowMode = art.ShowMode;
                infor.IsShowIndex = art.IsShowIndex;
                infor.IntSort = art.SortId;

                infor.RowCeateDate = art.RowCeateDate;
                infor.SourceDateTime = art.RowCeateDate;

                return infor;
            }
            else
            {
                return null;
            }
        }
        
        private List<T_SelfMediaAuthor> AllAuthorInfo()
        {
            string cachKey = string.Format("{0}.AllAuthorInfo", GetType().Name);

            List<T_SelfMediaAuthor> authors = CacheClientSession.LocalCacheClient.Get(cachKey, () =>
                {
                    return DbSession.MLT.T_SelfMediaAuthorRepository.QueryBy(new T_SelfMediaAuthor()
                        {
                            IsEnable = true
                        }).ToList();
                }, new TimeSpan(1, 0, 0));

            return authors;
        }
    }
}
