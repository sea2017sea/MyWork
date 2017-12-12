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
using cn.jpush.api.push.mode;

namespace Point.com.ServiceImplement.ForJiGuang
{
    public class ForJiGuangPushImpl : BaseService, IForJiGuangPush
    {
        /// <summary>
        /// 极光推送
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public Ptcp<string> SendPush(M_SendPushReq req)
        {
            var ptcp = new Ptcp<string>();

            if (req.IsNull())
            {
                ptcp.DoResult = "请求错误";
                return ptcp;
            }
            string jsonParam = JsonConvert.SerializeObject(req);
            Logger.Write(LoggerLevel.Error, "SendPush_in", "", jsonParam, "");

            try
            {
                #region

                if (req.UserId <= 0)
                {
                    ptcp.DoResult = "会员ID错误";
                    return ptcp;
                }

                //if (req.SourceTypeSysNo <= 0)
                //{
                //    ptcp.DoResult = "来源渠道错误";
                //    return ptcp;
                //}

                if (string.IsNullOrEmpty(req.MsgAlert))
                {
                    ptcp.DoResult = "消息alert不能为空";
                    return ptcp;
                }

                var pushInfo = DbSession.MLT.T_JiGuangPushRepository.QueryBy(new T_JiGuangPush()
                {
                    UserId = req.UserId,
                    IsEnable = true
                }, " ORDER BY ModifyTime DESC").FirstOrDefault();

                if (pushInfo.IsNull() || pushInfo.SysNo <= 0)
                {
                    ptcp.DoResult = "没有获取到会员与极光的关联关系";
                    return ptcp;
                }

                int sourceTypeSysNo = pushInfo.SourceTypeSysNo.GetValueOrDefault();
                if (sourceTypeSysNo != (int)Enums.SourceTypeSysNo.AndroIdApp &&
                    sourceTypeSysNo != (int)Enums.SourceTypeSysNo.IosApp)
                {
                    ptcp.DoResult = "平台类型错误";
                    return ptcp;
                }

                if (string.IsNullOrEmpty(pushInfo.JiGuangSysNo))
                {
                    ptcp.DoResult = "没有获取到会员与极光的关联关系";
                    return ptcp;
                }

                PushClient pushClient = new PushClient();
                PushPayload pushPayload = new PushPayload();

                if (sourceTypeSysNo == (int)Enums.SourceTypeSysNo.AndroIdApp)
                {
                    pushPayload.platform = Platform.android();
                    if (!string.IsNullOrEmpty(req.MsgTitle))
                    {
                        pushPayload.notification = Notification.android(req.MsgAlert, req.MsgTitle);
                    }
                    else
                    {
                        pushPayload.notification = new Notification().setAlert(req.MsgAlert);
                    }
                }
                else if (sourceTypeSysNo == (int)Enums.SourceTypeSysNo.IosApp)
                {
                    pushPayload.platform = Platform.ios();
                    pushPayload.notification = new Notification().setAlert(req.MsgAlert);
                }

                pushPayload.audience = Audience.s_registrationId(pushInfo.JiGuangSysNo);

                pushPayload.message = Message.content(req.MsgContent);

                var res = pushClient.sendPush(pushPayload);

                DbSession.MLT.T_JiGuangPushRecordRepository.Add(new T_JiGuangPushRecord()
                {
                    UserId = req.UserId,
                    JiGuangSysNo = pushInfo.JiGuangSysNo,
                    MsgTitle = req.MsgTitle,
                    MsgAlert = req.MsgAlert,
                    MsgContent = req.MsgContent,
                    PushMsgId = res.msg_id.ToString(),
                    PushResult = res.isResultOK() == true ? "1" : "0",
                    SourceTypeSysNo = pushInfo.SourceTypeSysNo,
                    RowCeateDate = DateTime.Now,
                    IsEnable = true
                });
                DbSession.MLT.SaveChange();

                ptcp.DoFlag = PtcpState.Success;
                ptcp.DoResult = "推送成功";

                #endregion
            }
            catch (Exception ex)
            {
                string strEx = string.Format("请求参数：{0}；异常：{1}", req, ex.ToString());
                Logger.Write(LoggerLevel.Error, "SendPush_ex", "异常", strEx, "");
            }

            return ptcp;
        }
    }
}
