using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Point.com.Common;
using Point.com.Logging;
using Point.com.Model;
using Point.com.Model.Base;
using Point.com.ServiceImplement.ForJiGuang;
using Point.com.ServiceImplement.ForWxPay;
using Point.com.ServiceInterface;
using cn.jpush.api.push.mode;

namespace Point.com.ServiceImplement
{
    public class ForBaseImpl : BaseService, IForBase
    {
        public static ForJiGuangPushImpl jg = new ForJiGuangPushImpl();
        public static ForWxPayImpl wx = new ForWxPayImpl();

        /// <summary>
        /// 清空全部缓存
        /// </summary>
        /// <returns></returns>
        public Ptcp<string> LocalCacheAll()
        {
            var ptcp = new Ptcp<string>();

            try
            {
                CacheClientSession.LocalCacheClient.FlushAll();
                ptcp.DoResult = "清空缓存成功";
                ptcp.DoFlag = PtcpState.Success;
            }
            catch (Exception exception)
            {
                ptcp.DoResult = "清空缓存失败，异常信息：" + exception.ToString();
            }

            return ptcp;
        }

        /// <summary>
        /// 保存客户手机上面其他的APP信息
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public Ptcp<string> AddApp(M_AddAppReq req)
        {
            var ptcp = new Ptcp<string>();

            if (req.IsNull())
            {
                ptcp.DoResult = "请求数据非法";
                return ptcp;
            }

            string jsonParam = JsonConvert.SerializeObject(req);
            Logger.Write(LoggerLevel.Error, "AddApp_in", "", jsonParam, "");

            if (string.IsNullOrEmpty(req.Mobile))
            {
                ptcp.DoResult = "手机号码不能为空";
                return ptcp;
            }

            if (string.IsNullOrEmpty(req.DeviceCode))
            {
                ptcp.DoResult = "设备码不能为空";
                return ptcp;
            }

            if (string.IsNullOrEmpty(req.ClientIp))
            {
                ptcp.DoResult = "客户端IP不能为空";
                return ptcp;
            }

            if (req.SourceTypeSysNo <= 0)
            {
                ptcp.DoResult = "来源渠道错误";
                return ptcp;
            }

            if (req.AppName.IsNull() || !req.AppName.IsHasRow())
            {
                ptcp.DoResult = "APP信息为空";
                return ptcp;
            }

            DateTime dtNow = DateTime.Now;
            foreach (var an in req.AppName)
            {
                DbSession.MLT.Base_SaveAppRepository.Add(new Base_SaveApp()
                    {
                        Mobile = req.Mobile,
                        UserId = req.UserId,
                        DeviceCode = req.DeviceCode,
                        ClientIp = req.ClientIp,
                        AppName = an,
                        SourceTypeSysNo = req.SourceTypeSysNo,
                        RowCeateDate = dtNow,
                        IsEnable = true
                    });
            }

            DbSession.MLT.SaveChange();

            ptcp.DoFlag = PtcpState.Success;
            ptcp.DoResult = "保存成功";
            return ptcp;
        }

        /// <summary>
        /// 获取所有的分类信息
        /// </summary>
        /// <returns></returns>
        public Ptcp<M_QueryCategoryRes> QueryCategory()
        {
            var ptcp = new Ptcp<M_QueryCategoryRes>();

            string cacheKey = string.Format("{0}.QueryCategory", GetType().Name);
            var cates = CacheClientSession.LocalCacheClient.Get(cacheKey, () =>
                {
                    var cateDBs = DbSession.MLT.T_CategoryRepository.QueryBy(new T_Category()
                        {
                            IsEnable = true
                        }, " ORDER BY IntSort DESC").ToList();

                    if (cateDBs.IsNotNull() && cateDBs.IsHasRow())
                    {
                        return Mapper.MapperGeneric<T_Category, M_CategoryEntity>(cateDBs).ToList();
                    }

                    return null;
                }, new TimeSpan(1, 0, 0));

            ptcp.ReturnValue = new M_QueryCategoryRes();
            ptcp.ReturnValue.Entities = cates;
            ptcp.DoFlag = PtcpState.Success;
            return ptcp;
        }

        /// <summary>
        /// 查询交易流水
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public Ptcp<M_QueryAccountRecordRes> QueryAccountRecord(M_QueryAccountRecordReq req)
        {
            var ptcp = new Ptcp<M_QueryAccountRecordRes>();

            if (req.IsNull() || req.UserId <= 0)
            {
                ptcp.DoResult = "请求数据非法";
                return ptcp;
            }

            var rec = DbSession.MLT.T_AccountRecordRepository.QueryBy(new T_AccountRecord()
                {
                    UserId = req.UserId,
                    IsEnable = true
                }, " ORDER BY RowCeateDate DESC").Take(10).ToList();

            if (rec.IsNotNull() && rec.IsHasRow())
            {
                List<M_AccountRecordEntity> mAccount = new List<M_AccountRecordEntity>();
                foreach (var re in rec)
                {
                    if (re.TranType != 4 && re.TranType != 8)
                    {
                        string strTranNum = "";
                        if (re.PlusReduce == 1)
                        {
                            strTranNum = string.Format("+{0} {1}", re.TranNum, re.Company);
                        }
                        else
                        {
                            strTranNum = string.Format("{0} {1}", re.TranNum, re.Company);
                        }

                        mAccount.Add(new M_AccountRecordEntity()
                            {
                                TranName = re.TranName,
                                TranType = re.TranType.GetValueOrDefault(),
                                PicUrl = Pm.TableAccountRecordPicUrl(re.TranType.GetValueOrDefault()),
                                PlusReduce = re.PlusReduce.GetValueOrDefault(),
                                TranNum = re.TranNum.GetValueOrDefault(),
                                IsPushIn = re.IsPushIn.GetValueOrDefault(),
                                //IsPushOut = re.IsPushOut.GetValueOrDefault(),
                                StrTranNum = strTranNum,
                                RowCeateDate = re.RowCeateDate,
                                StrRowCeateDate = Convert.ToDateTime(re.RowCeateDate).ToString("yyyy-MM-dd")
                            });
                    }
                }

                if (mAccount.IsHasRow())
                {
                    ptcp.ReturnValue = new M_QueryAccountRecordRes();
                    ptcp.ReturnValue.Entities = mAccount;
                    ptcp.DoResult = "查询成功";
                }
                else
                {
                    ptcp.DoResult = "没有流水记录";
                }
            }
            else
            {
                ptcp.DoResult = "没有流水记录";
            }

            ptcp.DoFlag = PtcpState.Success;
            return ptcp;
        }

        /// <summary>
        /// 保存账号交易流水
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public Ptcp<string> AddAccountRecord(M_AddAccountRecordReq req)
        {
            var ptcp = new Ptcp<string>();

            if (req.IsNull())
            {
                ptcp.DoResult = "请求数据非法";
                return ptcp;
            }

            string jsonParam = JsonConvert.SerializeObject(req);
            Logger.Write(LoggerLevel.Error, "AddAccountRecord_in", "", jsonParam, "");

            if (req.TranType <= 0)
            {
                ptcp.DoResult = "交易类型错误";
                return ptcp;
            }

            if (req.UserId <= 0)
            {
                ptcp.DoResult = "会员ID错误";
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

            T_AccountRecord tRecord = new T_AccountRecord();
            tRecord.TranType = req.TranType;
            tRecord.UserId = req.UserId;
            tRecord.RowCeateDate = DateTime.Now;
            tRecord.IsPushIn = 0;
            //tRecord.IsPushOut = 1;
            tRecord.IsEnable = true;
            tRecord.InRemarks = req.InRemarks;


            //极光推送消息
            M_SendPushReq sendPush = new M_SendPushReq();
            sendPush.UserId = req.UserId;

            #region 处理逻辑

            decimal? scoreDb = 0;
            decimal? scoreWithdrawnDb = 0;

            DateTime dtNow = DateTime.Now;
            switch (req.TranType)
            {
                case (int) Enums.TranType.Partic:
                    //参与互动
                    tRecord.PlusReduce = 1;   //交易获取或者使用 1增加 2 使用（减）
                    tRecord.Company = Enums.Rmb;
                    tRecord.TranName = "参与互动";
                    tRecord.TranNum = req.TranNum;

                    //sendPush.MsgTitle = "参与互动积分增加-Title";
                    //sendPush.MsgAlert = "参与互动积分增加-Alert";
                    //sendPush.MsgContent = string.Format("恭喜您参与互动，获得{0}元奖励金。", req.TranNum);

                    sendPush.MsgTitle = string.Format("参与互动{0}增加", Enums.ScoreName);
                    sendPush.MsgAlert = string.Format("恭喜您参与互动，获得{0}{1}元。", Enums.ScoreName, req.TranNum);
                    sendPush.MsgContent = string.Format("参与互动{0}增加", Enums.ScoreName);

                    #region 更新账户积分信息

                    //更新账户积分信息
                    DbSession.MLT.T_MemberRepository.Update(new T_Member()
                    {
                        Score = (memberInfo.Score + req.TranNum),
                        ModifyTime = dtNow
                    }, new T_Member() { SysNo = req.UserId });

                    #endregion

                    break;
                case (int) Enums.TranType.Share:
                    //邀请好友，分享好友
                    tRecord.PlusReduce = 1;   //交易获取或者使用 1增加 2 使用（减）
                    tRecord.Company = Enums.Rmb;
                    tRecord.TranName = "邀请好友";
                    tRecord.TranNum = req.TranNum;

                    sendPush.MsgTitle = string.Format("邀请好友{0}增加",Enums.ScoreName);
                    sendPush.MsgAlert = string.Format("恭喜您成功邀请好友，获得{0}{1}元。", Enums.ScoreName, req.TranNum);
                    sendPush.MsgContent = string.Format("邀请好友{0}增加", Enums.ScoreName);

                    #region 更新账户积分信息

                    //更新账户积分信息
                    DbSession.MLT.T_MemberRepository.Update(new T_Member()
                    {
                        Score = (memberInfo.Score + req.TranNum),
                        ModifyTime = dtNow
                    }, new T_Member() { SysNo = req.UserId });

                    #endregion

                    break;
                case (int) Enums.TranType.PurchaseScore:
                    //转出积分
                    tRecord.PlusReduce = 2;   //交易获取或者使用 1增加 2 使用（减）
                    tRecord.Company = Enums.Rmb;
                    tRecord.TranName = string.Format("转出{0}", Enums.ScoreName);
                    tRecord.TranNum = req.TranNum;

                    sendPush.MsgTitle = string.Format("申请转出{0}", Enums.ScoreName);
                    sendPush.MsgAlert = string.Format("申请转让{0}成功！", Enums.ScoreName);
                    sendPush.MsgContent = string.Format("申请{0}转出",Enums.ScoreName);

                    #region 更新账户积分信息

                    scoreDb = memberInfo.Score - req.TranNum;
                    scoreWithdrawnDb = 0;

                    if (scoreDb < 0)
                    {
                        scoreDb = 0;
                    }

                    if (scoreDb < memberInfo.ScoreWithdrawn)
                    {
                        scoreWithdrawnDb = scoreDb;
                    }
                    else
                    {
                        scoreWithdrawnDb = memberInfo.ScoreWithdrawn;
                    }

                    //更新账户积分信息
                    DbSession.MLT.T_MemberRepository.Update(new T_Member()
                    {
                        Score = scoreDb,
                        ScoreWithdrawn = scoreWithdrawnDb,
                        ModifyTime = dtNow
                    }, new T_Member() { SysNo = req.UserId });

                    #endregion

                    break;
                case (int) Enums.TranType.Sell:
                    //转入积分
                    tRecord.PlusReduce = 1;   //交易获取或者使用 1增加 2 使用（减）
                    tRecord.Company = Enums.Rmb;
                    tRecord.TranName = string.Format("转入{0}", Enums.ScoreName);
                    tRecord.TranNum = req.TranNum;

                    sendPush.MsgTitle = string.Format("转入{0}增加",Enums.ScoreName);
                    sendPush.MsgAlert = string.Format("恭喜你获得{0}元现金。", req.TranNum);
                    sendPush.MsgContent = string.Format("转入{0}增加", Enums.ScoreName);

                    #region 更新账户积分信息

                    //更新账户积分信息
                    DbSession.MLT.T_MemberRepository.Update(new T_Member()
                    {
                        Score = (memberInfo.Score + req.TranNum),
                        ModifyTime = dtNow
                    }, new T_Member() { SysNo = req.UserId });

                    #endregion

                    break;
                case (int) Enums.TranType.TiXian:
                    //提现
                    tRecord.PlusReduce = 2;   //交易获取或者使用 1增加 2 使用（减）
                    tRecord.Company = Enums.Rmb;
                    tRecord.TranName = "提现";
                    tRecord.TranNum = -req.TranNum;

                    sendPush.MsgTitle = "提现操作";
                    sendPush.MsgAlert = string.Format("恭喜您成功提现{0}元。现金将在24小时通过微信红包发放，尽请查收！", req.TranNum);
                    
                    sendPush.MsgContent = "提现操作";

                    #region

                    //持久化数据
                    //更新会员主表提现记录
                    DbSession.MLT.T_MemberRepository.Update(new T_Member()
                    {
                        Account = 0,
                        //AccountWithdrawn = memberInfo.Account,
                        AccountWithdrawn = 0,
                        ModifyTime = dtNow
                    }, new T_Member() { SysNo = req.UserId });

                    #endregion

                    break;
                case (int) Enums.TranType.ExcGoods:
                    //兑换抵用劵
                    tRecord.PlusReduce = 2;   //交易获取或者使用 1增加 2 使用（减）
                    tRecord.Company = Enums.Rmb;
                    tRecord.TranName = "兑换抵用劵";
                    tRecord.TranNum = -req.TranNum;

                    sendPush.MsgTitle = "兑换抵用劵";
                    sendPush.MsgAlert = string.Format("恭喜您成功兑换抵用劵，扣除{1}{0}元。", Enums.ScoreName, req.TranNum);
                    sendPush.MsgContent = "兑换抵用劵";

                      #region 更新账户积分信息

                    scoreDb = memberInfo.Score - req.TranNum;
                    scoreWithdrawnDb = 0;

                    if (scoreDb < 0)
                    {
                        scoreDb = 0;
                    }

                    if (scoreDb < memberInfo.ScoreWithdrawn)
                    {
                        scoreWithdrawnDb = scoreDb;
                    }
                    else
                    {
                        scoreWithdrawnDb = memberInfo.ScoreWithdrawn;
                    }

                    //更新账户积分信息
                    DbSession.MLT.T_MemberRepository.Update(new T_Member()
                    {
                        Score = scoreDb,
                        ScoreWithdrawn = scoreWithdrawnDb,
                        ModifyTime = dtNow
                    }, new T_Member() { SysNo = req.UserId });

                    #endregion

                    break;
                case (int)Enums.TranType.ReadArticle:
                    //付费，阅读文章
                    tRecord.PlusReduce = 2;    //交易获取或者使用 1增加 2 使用（减）
                    tRecord.Company = Enums.Rmb;
                    tRecord.TranName = "阅读文章";
                    tRecord.TranNum = -req.TranNum;

                    sendPush.MsgTitle = string.Format("阅读文章{0}扣除", Enums.ScoreName);
                    sendPush.MsgAlert = string.Format("阅读文章，扣除{0}{1}元。", Enums.ScoreName, req.TranNum);
                    sendPush.MsgContent = string.Format("阅读文章{0}扣除", Enums.ScoreName);

                    #region 更新账户积分信息

                    //更新账户积分信息
                    DbSession.MLT.T_MemberRepository.Update(new T_Member()
                    {
                        Score = (memberInfo.Score - req.TranNum),
                        ModifyTime = dtNow
                    }, new T_Member() { SysNo = req.UserId });

                    #endregion

                    break;
                default:
                    ptcp.DoResult = "交易类型错误";
                    return ptcp;
            }

            DbSession.MLT.T_AccountRecordRepository.Add(tRecord);
            DbSession.MLT.SaveChange();

            if (req.TranNum > 0)
            {
                //极光推送消息
                jg.SendPush(sendPush);
            }

            #endregion

            ptcp.DoFlag = PtcpState.Success;
            ptcp.DoResult = "保存成功";
            return ptcp;
        }

        /// <summary>
        /// 发起支付，预下单，构建订单数据
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public Ptcp<M_CreatePaymentRes> CreatePayment(M_CreatePaymentReq req)
        {
            var ptcp = new Ptcp<M_CreatePaymentRes>();

            if (req.IsNull())
            {
                ptcp.DoResult = "请求数据非法";
                return ptcp;
            }

            string jsonParam = JsonConvert.SerializeObject(req);
            Logger.Write(LoggerLevel.Error, "CreatePayment_in", "", jsonParam, "");

            #region 基础参数校验，生成订单信息

            if (req.UserId <= 0)
            {
                ptcp.DoResult = "会员ID错误";
                return ptcp;
            }

            if (req.GoodsSysNo <= 0)
            {
                ptcp.DoResult = "商品ID错误";
                return ptcp;
            }

            if (req.RechargeAmount <= 0)
            {
                ptcp.DoResult = "充值金额不能小于等于0";
                return ptcp;
            }

            //获取商品信息
            var goodsInfo = DbSession.MLT.T_ShopGoodsRepository.QueryBy(new T_ShopGoods()
                {
                    SysNo = req.GoodsSysNo,
                    IsEnable = true
                }).FirstOrDefault();

            if (goodsInfo.IsNull() || goodsInfo.SysNo <= 0)
            {
                ptcp.DoResult = "当前商品不存在，请重试";
                return ptcp;
            }

            if (goodsInfo.OverCouponCount <= 0)
            {
                ptcp.DoResult = "很抱歉，已全部抢光了";
                return ptcp;
            }

            //获取抵用劵的新
            var couponInfo = DbSession.MLT.T_CouponInfoRepository.QueryBy(new T_CouponInfo()
                {
                    SysNo = goodsInfo.ExcCouponSysNo,
                    IsEnable = true
                }).FirstOrDefault();
            if (couponInfo.IsNull() || couponInfo.SysNo <= 0)
            {
                ptcp.DoResult = "当前抵用劵不存在，请重试";
                return ptcp;
            }

            //获取会员信息
            var memInfo = DbSession.MLT.T_MemberRepository.QueryBy(new T_Member()
                {
                    SysNo = req.UserId
                }).FirstOrDefault();
            if (memInfo.IsNull() || memInfo.SysNo <= 0)
            {
                ptcp.DoResult = "会员信息获取失败，请重试";
                return ptcp;
            }

            if ((couponInfo.ExcAmount - memInfo.Score) / Enums.CashProportion != req.RechargeAmount)
            {
                ptcp.DoResult = "充值金额校验失败";
                return ptcp;
            }

            string goodsName = string.Format("趣赞-{0}", goodsInfo.GoodsName);
            //构建充值订单信息
            string sql =
              string.Format(
                  @"INSERT INTO T_Recharge(UserId,ShopSysNo,GoodsSysNo,GoodsName,RechargeAmount,PaymentNumber,PayTime,PayState,IsUse,RowCeateDate,ModifyTime,IsEnable) OUTPUT INSERTED.SysNo VALUES
                    ({0},{1},{2},'{3}',{4},NULL,NULL,0,0,GETDATE(),NULL,1)",
                  req.UserId, goodsInfo.ShopSysNo, req.GoodsSysNo, goodsName, req.RechargeAmount);
            int sysNo = DbSession.MLT.ExecuteSql<int>(sql).FirstOrDefault();
            if (sysNo <= 0)
            {
                ptcp.DoResult = "构建订单信息失败";
                return ptcp;
            }

            #endregion

            #region 调用微信预下单，生成 预支付交易会话标识

            var wxRes = wx.GetWxPayRequestData(new M_GetWxPayRequestDataReq()
                {
                    UserId = req.UserId,
                    OrderNo = sysNo,
                    RechargeAmount = req.RechargeAmount,
                    GoodsName = goodsName
                });
            if (wxRes.DoFlag == PtcpState.Failed)
            {
                if (!string.IsNullOrEmpty(wxRes.DoResult))
                {
                    ptcp.DoResult = wxRes.DoResult;
                    return ptcp;
                }

                ptcp.DoResult = "支付失败，请稍后重试";
                return ptcp;
            }

            #endregion

            ptcp.ReturnValue = new M_CreatePaymentRes();
            ptcp.ReturnValue.ApiParam = wxRes.DoResult;
            ptcp.ReturnValue.OrderNo = sysNo;
            ptcp.DoFlag = PtcpState.Success;
            ptcp.DoResult = "构建微信APP支付预处理统一下单成功";

            return ptcp;
        }

        /// <summary>
        /// 支付回调，更新订单状态
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public Ptcp<string> UpdatePayState(M_UpdatePayStateReq req)
        {
            var ptcp = new Ptcp<string>();

            if (req.IsNull())
            {
                ptcp.DoResult = "请求数据非法";
                return ptcp;
            }

            string jsonParam = JsonConvert.SerializeObject(req);
            Logger.Write(LoggerLevel.Error, "UpdatePayState_in", "", jsonParam, "");

            if (req.UserId <= 0)
            {
                ptcp.DoResult = "会员ID错误";
                return ptcp;
            }

            if (req.OrderNo <= 0)
            {
                ptcp.DoResult = "订单号错误";
                return ptcp;
            }

            if (req.PayTime == null)
            {
                ptcp.DoResult = "支付时间不能为空";
                return ptcp;
            }

            //校验订单金额
            var orderInfo = DbSession.MLT.T_RechargeRepository.QueryBy(new T_Recharge()
                {
                    SysNo = req.OrderNo,
                    IsEnable = true
                }).FirstOrDefault();

            if (orderInfo.IsNull() || orderInfo.SysNo <= 0)
            {
                ptcp.DoResult = "订单号错误";
                return ptcp;
            }

            if (orderInfo.RechargeAmount != req.RechargeAmount)
            {
                ptcp.DoResult = "支付金额校验失败";
                return ptcp;
            }

            if (orderInfo.PayState == (int) Enums.PayState.Complete)
            {
                ptcp.DoResult = "已支付成功";
                ptcp.DoFlag = PtcpState.Success;
                return ptcp;
            }

            DbSession.MLT.T_RechargeRepository.Update(new T_Recharge()
                {
                    PaymentNumber = req.PaymentNumber,
                    PayTime = req.PayTime,
                    PayState = req.PayState,
                    ModifyTime = DateTime.Now
                },new T_Recharge(){SysNo = req.OrderNo});
            DbSession.MLT.SaveChange();

            ptcp.DoResult = "修改支付状态成功";
            ptcp.DoFlag = PtcpState.Success;
            return ptcp;
        }

        /// <summary>
        /// 查询订单支付状态
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="orderNo"></param>
        /// <returns></returns>
        public Ptcp<string> QueryPayState(int userid, int orderNo)
        {
            var ptcp = new Ptcp<string>();

            if (userid <= 0)
            {
                ptcp.DoResult = "会员ID错误";
                return ptcp;
            }

            if (orderNo <= 0)
            {
                ptcp.DoResult = "订单号错误";
                return ptcp;
            }

            var orderInfo = DbSession.MLT.T_RechargeRepository.QueryBy(new T_Recharge()
                {
                    SysNo = orderNo,
                    UserId = userid,
                    IsEnable = true
                }).FirstOrDefault();

            if (orderInfo.IsNull() || orderInfo.SysNo <= 0)
            {
                ptcp.DoResult = "没有订单信息";
                return ptcp;
            }

            if (orderInfo.PayState == (int) Enums.PayState.Complete)
            {
                ptcp.DoResult = "已支付成功";
                ptcp.DoFlag = PtcpState.Success;
                return ptcp;
            }

            return ptcp;
        }

        /// <summary>
        /// 积分转让
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public Ptcp<string> ScoreTurn(M_ScoreTurnReq req)
        {
            var ptcp = new Ptcp<string>();

            if (req.IsNull())
            {
                ptcp.DoResult = "请求错误";
                return ptcp;
            }

            string jsonParam = JsonConvert.SerializeObject(req);
            Logger.Write(LoggerLevel.Error, "ScoreTurn_in", "", jsonParam, "");


            if (req.UserId <= 0)
            {
                ptcp.DoResult = "会员ID错误";
                return ptcp;
            }

            if (req.ScoreTurn <= 0)
            {
                ptcp.DoResult = "申请的金额不能小于0";
                return ptcp;
            }

            //获取会员信息
            var memberInfo = DbSession.MLT.T_MemberRepository.QueryBy(new T_Member()
                {
                    SysNo = req.UserId
                }).FirstOrDefault();
            if (memberInfo.IsNull() || memberInfo.SysNo <= 0)
            {
                ptcp.DoResult = "会员ID错误";
                return ptcp;
            }

            if (memberInfo.Score - req.ScoreTurn < 0)
            {
                ptcp.DoResult = string.Format("金额不足，您最多只能转让{0}元", memberInfo.Score);
                return ptcp;
            }

            DateTime dtNow = DateTime.Now;
            //持久化数据
            //更新会员主表，积分信息
            DbSession.MLT.T_MemberRepository.Update(new T_Member()
                {
                    ScoreWithdrawn = req.ScoreTurn,
                    ModifyTime = dtNow
                },new T_Member(){SysNo = req.UserId});
            
            ////保存积分转让记录 不要了
            //DbSession.MLT.T_ScoreTurnRecordRepository.Add(new T_ScoreTurnRecord()
            //    {
            //        UserId = req.UserId,
            //        FatherId = 0,
            //        TurnScore = req.ScoreTurn,
            //        TurnState = (int)Enums.TurnState.Untreated,
            //        RowCeateDate = dtNow,
            //        IsEnable = true
            //    });

            //保存账户流水交易
            //AddAccountRecord(new M_AddAccountRecordReq()
            //{
            //    TranType = (int)Enums.TranType.PurchaseScore,
            //    TranNum = req.ScoreTurn,
            //    UserId = req.UserId,
            //    InRemarks = ""
            //});

            DbSession.MLT.SaveChange();
            ptcp.DoFlag = PtcpState.Success;
            ptcp.DoResult = "申请成功";
            return ptcp;
        }

        /// <summary>
        /// 提现 2017-12-11改版新的提现接口
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="amount">提现金额</param>
        /// <returns></returns>
        public Ptcp<string> MemberWithdrawalsTwo(int userid, decimal amount)
        {
            var ptcp = new Ptcp<string>();

            if (userid <= 0)
            {
                ptcp.DoResult = "会员ID错误";
                return ptcp;
            }

            if (amount < 1)
            {
                //ptcp.DoResult = "提现金额不能小于1元";
                ptcp.DoResult = "提现金额不足";
                return ptcp;
            }

            //获取会员信息
            var memberInfo = DbSession.MLT.T_MemberRepository.QueryBy(new T_Member()
            {
                SysNo = userid
            }).FirstOrDefault();
            if (memberInfo.IsNull() || memberInfo.SysNo <= 0)
            {
                ptcp.DoResult = "会员ID错误";
                return ptcp;
            }

            //低佣金转为金额 
            decimal scoreRmb = memberInfo.Score.GetValueOrDefault()/100;
            if (scoreRmb < 1)
            {
                //ptcp.DoResult = "账户金额小于1元，不能提现";
                ptcp.DoResult = "提现金额不足";
                return ptcp;
            }
            
            if (amount > scoreRmb)
            {
                //ptcp.DoResult = string.Format("账户金额不足，可提现金额{0}元", scoreRmb);
                ptcp.DoResult = "账户金额不足";
                return ptcp;
            }

            //当前账户配置的最低提现额度
            if (amount < memberInfo.MinWithdrawals)
            {
                //ptcp.DoResult = string.Format("您的账户提现额度最低{0}元起", memberInfo.MinWithdrawals);
                ptcp.DoResult = "提现金额不足";
                return ptcp;
            }

            if (string.IsNullOrEmpty(memberInfo.OpenidWxOpen))
            {
                ptcp.DoResult = "微信账号未关联，无法提现";
                return ptcp;
            }

            DateTime dtNow = DateTime.Now;
            //持久化数据
            //更新会员主表提现记录
            DbSession.MLT.T_MemberRepository.Update(new T_Member()
                {
                    Score = memberInfo.Score - (amount * 100),               //账户剩余低佣金
                    ScoreWithdrawn = memberInfo.ScoreWithdrawn + (amount * 100),   //累计提现金额
                    ModifyTime = dtNow
                }, new T_Member() { SysNo = userid });
            
            //保存提交记录
            DbSession.MLT.T_WithdrawalsRepository.Add(new T_Withdrawals()
                {
                    UserId = userid,
                    OpenidWxOpen = memberInfo.OpenidWxOpen,
                    WithdrawalsMoney = amount,
                    WithdrawalsState = (int)Enums.WithdrawalsState.Untreated,
                    RowCeateDate = dtNow,
                    IsEnable = true
                });

            //保存账户流水交易
            AddAccountRecord(new M_AddAccountRecordReq()
            {
                TranType = (int)Enums.TranType.TiXian,
                TranNum = amount,
                UserId = userid,
                InRemarks = ""
            });

            DbSession.MLT.SaveChange();
            ptcp.DoFlag = PtcpState.Success;
            ptcp.DoResult = "现金将在24小时通过微信红包发放，尽请查收";
            return ptcp;
        }

        /// <summary>
        /// 提现
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public Ptcp<string> MemberWithdrawals(int userid)
        {
            var ptcp = new Ptcp<string>();
            
            //ptcp.DoResult = "请升级APP版本";
            //return ptcp;

            if (userid <= 0)
            {
                ptcp.DoResult = "会员ID错误";
                return ptcp;
            }

            //获取会员信息
            var memberInfo = DbSession.MLT.T_MemberRepository.QueryBy(new T_Member()
            {
                SysNo = userid
            }).FirstOrDefault();
            if (memberInfo.IsNull() || memberInfo.SysNo <= 0)
            {
                ptcp.DoResult = "会员ID错误";
                return ptcp;
            }

            if (memberInfo.Account < 1)
            {
                ptcp.DoResult = "账户金额小于1元，不能提现";
                return ptcp;
            }

            if (string.IsNullOrEmpty(memberInfo.OpenidWxOpen))
            {
                ptcp.DoResult = "微信账号未关联，无法提现";
                return ptcp;
            }

            DateTime dtNow = DateTime.Now;
            ////持久化数据
            ////更新会员主表提现记录
            //DbSession.MLT.T_MemberRepository.Update(new T_Member()
            //    {
            //        Account = 0,
            //        AccountWithdrawn = memberInfo.Account,
            //        ModifyTime = dtNow
            //    },new T_Member(){SysNo = userid});

            //保存提交记录
            DbSession.MLT.T_WithdrawalsRepository.Add(new T_Withdrawals()
            {
                UserId = userid,
                OpenidWxOpen = memberInfo.OpenidWxOpen,
                WithdrawalsMoney = memberInfo.Account,
                WithdrawalsState = (int)Enums.WithdrawalsState.Untreated,
                RowCeateDate = dtNow,
                IsEnable = true
            });

            //保存账户流水交易
            AddAccountRecord(new M_AddAccountRecordReq()
            {
                TranType = (int)Enums.TranType.TiXian,
                TranNum = memberInfo.Account.GetValueOrDefault(),
                UserId = userid,
                InRemarks = ""
            });

            DbSession.MLT.SaveChange();
            ptcp.DoFlag = PtcpState.Success;
            ptcp.DoResult = "现金将在24小时通过微信红包发放，尽请查收";
            return ptcp;
        }

        /// <summary>
        /// 保存极光推送的会员ID
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="jiGuangSysNo"></param>
        /// <param name="sourceTypeSysNo"></param>
        /// <returns></returns>
        public Ptcp<string> AddJiGuangPush(int userid, string jiGuangSysNo, int sourceTypeSysNo)
        {
            var ptcp = new Ptcp<string>();

            if (userid <= 0)
            {
                ptcp.DoResult = "会员ID错误";
                return ptcp;
            }

            if (string.IsNullOrEmpty(jiGuangSysNo))
            {
                ptcp.DoResult = "极光用户标识错误";
                return ptcp;
            }

            if (sourceTypeSysNo <= 0)
            {
                ptcp.DoResult = "来源渠道错误";
                return ptcp;
            }

            //判断是否存在
            var jiguang = DbSession.MLT.T_JiGuangPushRepository.QueryBy(new T_JiGuangPush()
                {
                    UserId = userid,
                    JiGuangSysNo = jiGuangSysNo,
                    SourceTypeSysNo = sourceTypeSysNo,
                    IsEnable = true
                }).FirstOrDefault();
            if (jiguang.IsNotNull() && jiguang.SysNo > 0)
            {
                //更新时间
                DbSession.MLT.T_JiGuangPushRepository.Update(new T_JiGuangPush()
                    {
                        ModifyTime = DateTime.Now,
                    },new T_JiGuangPush()
                        {
                            SysNo = jiguang.SysNo
                        });
                ptcp.DoFlag = PtcpState.Success;

                ptcp.DoFlag = PtcpState.Success;
                ptcp.DoResult = "已经存在了";
                return ptcp;
            }

            DbSession.MLT.T_JiGuangPushRepository.Add(new T_JiGuangPush()
                {
                    UserId = userid,
                    JiGuangSysNo = jiGuangSysNo,
                    SourceTypeSysNo = sourceTypeSysNo,
                    RowCeateDate = DateTime.Now,
                    ModifyTime = DateTime.Now,
                    IsEnable = true
                });
            DbSession.MLT.SaveChange();

            ptcp.DoFlag = PtcpState.Success;
            ptcp.DoResult = "保存成功";
            return ptcp;
        }
    }
}

