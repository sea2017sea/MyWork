using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Point.com.Logging;
using Point.com.Model;
using Point.com.Model.Base;
using Point.com.Model.VersionTwo;
using Point.com.ServiceInterface.VersionTwo;

namespace Point.com.ServiceImplement.VersionTwo
{
    public class ForIndexImpl : BaseService, IForIndex
    {
        /// <summary>
        /// 首页的数据
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public Ptcp<M_QueryIndexDataPageRes> QueryIndexDataPage(M_QueryIndexDataPageReq req)
        {
            var ptcp = new Ptcp<M_QueryIndexDataPageRes>();
             
            #region 基础验证

            if (req.IsNull())
            {
                ptcp.DoResult = "请求数据非法";
                return ptcp;
            }

            if (req.UserId <= 0)
            {
                ptcp.DoResult = "会员ID不能为空";
                return ptcp;
            }

            string jsonParam = JsonConvert.SerializeObject(req);
            Logger.Write(LoggerLevel.Error, "QueryIndexDataPage_in", "", jsonParam, "");

            if (req.PageIndex <= 0 || req.PageIndex > 10000)
            {
                req.PageIndex = 1;
            }

            if (req.PageSize <= 0 || req.PageSize > 100)
            {
                req.PageSize = 10;
            }

            #endregion

            #region 业务逻辑

            //判断是否有配置的信息
            var total = DbSession.MLT.B_RecommendConfigureRepository.QueryCountBy(new B_RecommendConfigure()
                {
                    UserId = req.UserId,
                    IsEnable = true
                });

            if (total <= 0)
            {
                ptcp.DoResult = "没有配置数据，请联系运营人员";
                return ptcp;
            }

            var recList = DbSession.MLT.B_RecommendConfigureRepository.QueryPageBy(req.PageIndex,req.PageSize,new B_RecommendConfigure()
            {
                UserId = req.UserId,
                IsEnable = true
            });

            if (!recList.IsHasRow())
            {
                ptcp.DoResult = "没有配置数据，请联系运营人员";
                return ptcp;
            }

            List<int> sysnoList = recList.Select(c => c.InforSysNo.GetValueOrDefault()).ToList();
            string strSysNo = string.Join(",", sysnoList);

            string sql = string.Format(@"SELECT * FROM B_InforConfigure WHERE SysNo IN ({0}) AND IsEnable = 1",strSysNo);

            var infoList = DbSession.MLT.ExecuteSql<B_InforConfigure>(sql).ToList();
            if (!infoList.IsHasRow())
            {
                ptcp.DoResult = "没有配置数据，请联系运营人员";
                return ptcp;
            }

            //获取广告参与记录
            List<int> sysInfo = infoList.Select(c => c.SysNo.GetValueOrDefault()).ToList();
            string strSysInfo = string.Join(",", sysInfo);
            var sqlAdvRec = string.Format(@"select * from B_AdvGoodsRecord where AdvSysNo in ({0}) and IsEnable = 1", strSysInfo);
            var advResList = DbSession.MLT.ExecuteSql<B_AdvGoodsRecord>(sqlAdvRec).ToList();

            List<B_AdvGoods> advGoodses = null;
            if (advResList.IsHasRow())
            {
                List<int> sysAdvRes = advResList.Select(c => c.AdvSysNo.GetValueOrDefault()).ToList();
                string strSysAdvRes = string.Join(",", sysAdvRes);
                var sqlAdvGoods = string.Format(@"select * from B_AdvGoods where AdvSysNo in ({0}) and IsEnable = 1 order by IntSort desc", strSysAdvRes);
                advGoodses = DbSession.MLT.ExecuteSql<B_AdvGoods>(sqlAdvGoods).ToList();
            }

            //组装数据
            List<M_IndexPageData> indexPageDatas = Mapper.MapperGeneric<B_InforConfigure, M_IndexPageData>(infoList).ToList();

            foreach (var indexData in indexPageDatas)
            {
                if (advGoodses.IsHasRow())
                {
                    var advs = advGoodses.Where(c => c.AdvSysNo == indexData.SysNo).ToList();
                    if (advs.IsHasRow())
                    {
                        indexData.AdvGoodsModels = Mapper.MapperGeneric<B_AdvGoods, M_AdvGoodsModel>(advs).ToList();
                    }
                }

                var recEntity = recList.FirstOrDefault(c => c.InforSysNo == indexData.SysNo);
                if (recEntity.IsNotNull())
                {
                    indexData.IntSort = recEntity.IntSort.GetValueOrDefault();
                }
            }

            if (recList.Any(c => c.DataType == 1))
            {
                //如果存在人工的配置，需要将将推送红点标识更新为已经推送
                DbSession.MLT.B_RecommendConfigureRepository.Update(new B_RecommendConfigure()
                    {
                        PushState = 1,
                        ModifyTime = DateTime.Now
                    },new B_RecommendConfigure()
                        {
                            UserId = req.UserId,
                            DataType = 1,
                            PushState = 0
                        });
                DbSession.MLT.SaveChange();
            }

            ptcp.DoFlag = PtcpState.Success;
            ptcp.DoResult = "成功";
            ptcp.ReturnValue = new M_QueryIndexDataPageRes();
            ptcp.ReturnValue.PageDatas = indexPageDatas.OrderByDescending(c => c.IntSort).ToList();
            ptcp.ReturnValue.Total = (int)total;

            #endregion

            return ptcp;
        }

        /// <summary>
        /// 获取首页的红点(APP logo 上面的红点)
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public Ptcp<int> QueryIndexRedDot(int userid)
        {
            var ptcp = new Ptcp<int>();

            if (userid <= 0)
            {
                ptcp.DoResult = "会员ID不能为空";
                return ptcp;
            }

            var recCount = DbSession.MLT.B_RecommendConfigureRepository.QueryCountBy(new B_RecommendConfigure()
                {
                    UserId = userid,
                    DataType = 1,
                    PushState = 0,
                    IsEnable = true,
                });

            ptcp.DoFlag = PtcpState.Success;
            ptcp.DoResult = "成功";
            ptcp.ReturnValue = new int();
            ptcp.ReturnValue = (int) recCount;

            return ptcp;
        }

        /// <summary>
        /// 根据广告ID获取广告商品信息
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="advSysNo"></param>
        /// <returns></returns>
        public Ptcp<M_QueryAdvGoodsByIdRes> QueryAdvGoodsById(int userid, int advSysNo)
        {
            var ptcp = new Ptcp<M_QueryAdvGoodsByIdRes>();

            if (userid <= 0)
            {
                ptcp.DoResult = "会员ID不能为空";
                return ptcp;
            }

            if (advSysNo <= 0)
            {
                ptcp.DoResult = "广告商品ID不能为空";
                return ptcp;
            }

            var memeberEntity = DbSession.MLT.T_MemberRepository.QueryBy(new T_Member()
                {
                    SysNo = userid
                }).FirstOrDefault();
            if (memeberEntity.IsNull())
            {
                ptcp.DoResult = "会员信息获取失败";
                return ptcp;
            }

            var advList = DbSession.MLT.B_AdvGoodsRepository.QueryBy(new B_AdvGoods()
                {
                    AdvSysNo = advSysNo,
                    IsEnable = true
                }).ToList();
            if (!advList.IsHasRow())
            {
                ptcp.DoResult = "获取广告商品信息失败";
                return ptcp;
            }

            ptcp.ReturnValue = new M_QueryAdvGoodsByIdRes();
            ptcp.ReturnValue.AdvGoodsModels = Mapper.MapperGeneric<B_AdvGoods, M_AdvGoodsModel>(advList).ToList();
            ptcp.ReturnValue.Portrait = memeberEntity.Portrait;
            ptcp.ReturnValue.NickName = memeberEntity.NickName;

            ptcp.DoFlag = PtcpState.Success;
            ptcp.DoResult = "成功";

            return ptcp;
        }
    }
}

