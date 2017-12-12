using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Point.com.Common;
using Point.com.Logging;
using Point.com.Model;
using Point.com.Model.Base;
using Point.com.ServiceInterface;
using Point.com.ServiceModel;

namespace Point.com.Facade
{
    public class ForBaseService : BaseService<IForBase>
    {
        /// <summary>
        /// 清空全部缓存
        /// </summary>
        /// <returns></returns>
        public LocalCacheAllRes Any(LocalCacheAllReq req)
        {
            var res = new LocalCacheAllRes();

            try
            {
                var ptcp = ServiceImpl.LocalCacheAll();
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
        /// 上传图片服务
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public AppImgUploadRes Any(AppImgUploadReq req)
        {
            var res = new AppImgUploadRes();
            try
            {
                if (Request.Files != null && Request.Files.Count() > 0)
                {
                    for (int i = 0; i < Request.Files.Count(); i++)
                    {
                        var fileName = "";
                        var reqFile = Request.Files[i];

                        var fileBytes = new byte[reqFile.ContentLength];
                        reqFile.InputStream.Read(fileBytes, 0, (int)reqFile.ContentLength);

                        var upUrl = Configurator.ImageFileService;
                        var imgUrl = Configurator.ImageFileUrl;
                        var httpRequestClient = new HttpRequestClient();
                        var responseText = string.Empty;

                        int userid = req.UserId;
                        if (userid <= 0)
                        {
                            Random rd = new Random();
                            userid = rd.Next();
                        }

                        fileName = reqFile.FileName;
                        httpRequestClient.SetFieldValue("userId", userid.ToString());
                        httpRequestClient.SetFieldValue("upFile", fileName, "application/octet-stream", fileBytes);

                        string dir = "/default/";
                        if (req.UploadType == (int) Enums.UploadType.Head)
                        {
                            dir = "/head/";
                        }
                        else if (req.UploadType == (int)Enums.UploadType.goods)
                        {
                            dir = "/goods/";
                        }
                        httpRequestClient.SetFieldValue("dir", dir);

                        httpRequestClient.Upload(upUrl, out responseText);
                        if (!string.IsNullOrEmpty(responseText))
                        {
                            responseText = responseText.Replace("\\", "");
                            var uploadResult = Newtonsoft.Json.JsonConvert.DeserializeObject<UploadImg>(responseText);
                            if (uploadResult.State.ToUpper() == "SUCCESS")
                            {
                                res.ImgUrl = imgUrl + uploadResult.Url;
                                res.DoFlag = (int)PtcpState.Success;
                                res.DoResult = "上传图片成功";
                                return res;
                            }
                            else
                            {
                                res.DoResult = uploadResult.State.ToUpper();
                            }
                        }
                    }
                }
                else
                {
                    res.DoResult = "请上传图片";
                }

            }
            catch (Exception ex)
            {
                res.DoResult = "图片上传接口错误";
            }

            return res;
        }

        /// <summary>
        /// 保存客户手机上面其他的APP信息
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public AddAppRes Any(AddAppReq req)
        {
            var res = new AddAppRes();

            try
            {
                var m_req = Mapper.Map<AddAppReq, M_AddAppReq>(req);
                var ptcp = ServiceImpl.AddApp(m_req);
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
        /// 获取所有的分类信息
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public QueryCategoryRes Any(QueryCategoryReq req)
        {
            var res = new QueryCategoryRes();

            try
            {
                var ptcp = ServiceImpl.QueryCategory();
                if (ptcp.DoFlag == PtcpState.Success)
                {
                    res.DoFlag = (int)PtcpState.Success;
                }
                res.DoResult = ptcp.DoResult;

                if (ptcp.ReturnValue.IsNotNull() && ptcp.ReturnValue.Entities.IsHasRow())
                {
                    res.Entities = Mapper.MapperGeneric<M_CategoryEntity, CategoryEntity>(ptcp.ReturnValue.Entities).ToList();
                }
            }
            catch (Exception ex)
            {
                res.DoResult = "系统繁忙，请稍后再试";
            }

            return res;
        }

        /// <summary>
        /// 获取账户的交易流水
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public QueryAccountRecordRes Any(QueryAccountRecordReq req)
        {
            var res = new QueryAccountRecordRes();

            try
            {
                var m_req = Mapper.Map<QueryAccountRecordReq, M_QueryAccountRecordReq>(req);
                var ptcp = ServiceImpl.QueryAccountRecord(m_req);
                if (ptcp.DoFlag == PtcpState.Success)
                {
                    res.DoFlag = (int)PtcpState.Success;
                }
                res.DoResult = ptcp.DoResult;

                if (ptcp.ReturnValue.IsNotNull() && ptcp.ReturnValue.Entities.IsHasRow())
                {
                    res.Entities = Mapper.MapperGeneric<M_AccountRecordEntity, AccountRecordEntity>(ptcp.ReturnValue.Entities).ToList();
                }
            }
            catch (Exception ex)
            {
                res.DoResult = "系统繁忙，请稍后再试";
            }

            return res;
        }

        /// <summary>
        /// 保存账号交易流水
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public AddAccountRecordRes Any(AddAccountRecordReq req)
        {
            var res = new AddAccountRecordRes();

            try
            {
                var m_req = Mapper.Map<AddAccountRecordReq, M_AddAccountRecordReq>(req);
                var ptcp = ServiceImpl.AddAccountRecord(m_req);
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
        /// 发起支付，预下单，构建订单数据
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public CreatePaymentRes Any(CreatePaymentReq req)
        {
            var res = new CreatePaymentRes();

            try
            {
                var m_req = Mapper.Map<CreatePaymentReq, M_CreatePaymentReq>(req);
                var ptcp = ServiceImpl.CreatePayment(m_req);
                if (ptcp.DoFlag == PtcpState.Success)
                {
                    res.DoFlag = (int)PtcpState.Success;
                }
                res.DoResult = ptcp.DoResult;

                if (ptcp.ReturnValue.IsNotNull())
                {
                    res.ApiParam = ptcp.ReturnValue.ApiParam;
                    res.OrderNo = ptcp.ReturnValue.OrderNo;
                }
            }
            catch (Exception ex)
            {
                res.DoResult = "系统繁忙，请稍后再试";
            }

            return res;
        }

        /// <summary>
        /// 支付回调，更新订单状态
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public UpdatePayStateRes Any(UpdatePayStateReq req)
        {
            var res = new UpdatePayStateRes();

            try
            {
                var m_req = Mapper.Map<UpdatePayStateReq, M_UpdatePayStateReq>(req);
                var ptcp = ServiceImpl.UpdatePayState(m_req);
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
        /// 查询订单支付状态
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public QueryPayStateRes Any(QueryPayStateReq req)
        {
            var res = new QueryPayStateRes();

            try
            {
                var ptcp = ServiceImpl.QueryPayState(req.UserId,req.OrderNo);
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
        /// 积分转让
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public ScoreTurnRes Any(ScoreTurnReq req)
        {
            var res = new ScoreTurnRes();

            try
            {
                var m_req = Mapper.Map<ScoreTurnReq, M_ScoreTurnReq>(req);
                var ptcp = ServiceImpl.ScoreTurn(m_req);
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
        /// 提现
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public MemberWithdrawalsRes Any(MemberWithdrawalsReq req)
        {
            var res = new MemberWithdrawalsRes();

            try
            {
                var ptcp = ServiceImpl.MemberWithdrawals(req.UserId);
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
        /// 保存极光推送的会员ID
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public AddJiGuangPushRes Any(AddJiGuangPushReq req)
        {
            var res = new AddJiGuangPushRes();

            try
            {
                var ptcp = ServiceImpl.AddJiGuangPush(req.UserId,req.JiGuangSysNo,req.SourceTypeSysNo);
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
