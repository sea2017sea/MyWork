using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;
using Newtonsoft.Json;
using Point.com.Common;
using Point.com.Logging;
using Point.com.Model;
using Point.com.Model.Base;
using Point.com.ServiceInterface;

namespace Point.com.ServiceImplement
{
    public class SmsImpl : BaseService, ISms
    {
        private static MemberDepImpl md = new MemberDepImpl();

        enum EBodyType : uint
        {
            EType_XML = 0,
            EType_JSON
        }

        private string m_restAddress = "app.cloopen.com";
        private string m_restPort = "8883";
        private string m_mainAccount = "aaf98f894fa5766f014fa72f897102e6";
        private string m_mainToken = "999249ff15ad4222aa268c7374430107";
        private string m_subAccount = null;
        private string m_subToken = null;
        private string m_voipAccount = null;
        private string m_voipPwd = null;
        private string m_appId = "8a48b5515249574b01525396075b1323";

        private EBodyType m_bodyType = EBodyType.EType_XML;

        /// <summary>
        /// 服务器api版本
        /// </summary>
        const string softVer = "2013-12-26";

        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public Ptcp<string> SendSms(M_SendSmsReq req)
        {
            var ptcp = new Ptcp<string>();


            string jsonParam = JsonConvert.SerializeObject(req);
            Logger.Write(LoggerLevel.Error, "SendSms_in", "", jsonParam, "");

            if (req.IsNull())
            {
                ptcp.DoResult = "请求数据非法";
                return ptcp;
            }

            if (req.SmsType <= 0 || (req.SmsType != (int)Enums.SmsType.Login && req.SmsType != (int)Enums.SmsType.PwdBack && 
                req.SmsType != (int)Enums.SmsType.Reg))
            {
                ptcp.DoResult = "短信类型错误";
                return ptcp;
            }

            if (string.IsNullOrEmpty(req.ClientIp))
            {
                ptcp.DoResult = "IP不能为空";
                return ptcp;
            }

            if (string.IsNullOrEmpty(req.DeviceCode))
            {
                ptcp.DoResult = "设备码不能为空";
                return ptcp;
            }

            if (req.SourceTypeSysNo <= 0)
            {
                ptcp.DoResult = "来源渠道不能为空";
                return ptcp;
            }

            if (string.IsNullOrEmpty(req.Mobile))
            {
                ptcp.DoResult = "手机号码不能为空";
                return ptcp;
            }

            DateTime dtNow = DateTime.Now;
            string smTemp = "125246";
            if (req.SmsType == (int) Enums.SmsType.Reg)
            {
                #region 注册

                //检查会员是否已经存在
                var isExtRes = md.CheckMemberIsExist(Enums.SelectCustomer.Mobile, req.Mobile);
                if (isExtRes.IsNotNull() && isExtRes.DoFlag == PtcpState.Success)
                {
                    ptcp.DoResult = "手机号码已经存在，请直接登录";
                    return ptcp;
                }

                smTemp = "125246";

                #endregion
            }
            else if (req.SmsType == (int) Enums.SmsType.PwdBack)
            {
                #region 密码找回

                //检查会员是否已经存在
                var isExtRes = md.CheckMemberIsExist(Enums.SelectCustomer.Mobile, req.Mobile);
                if (isExtRes.IsNotNull() && isExtRes.DoFlag == PtcpState.Failed)
                {
                    ptcp.DoResult = "手机号码不存在，请核对";
                    return ptcp;
                }

                smTemp = "125246";

                #endregion
            }
            else
            {
                ptcp.DoResult = "发送短信类型错误";
                return ptcp;
            }

            #region 核心逻辑

            //生成验证码
            string code = IsForbidWord(6, 0);
            if (string.IsNullOrEmpty(code))
            {
                ptcp.DoResult = "发送失败，请稍后再试";
                return ptcp;
            }

            //发送短信
            string[] dataTemp = new string[2];
            dataTemp[0] = code;
            dataTemp[1] = "30分钟";
            Dictionary<string, object> sendRes = SendTemplateSMS(req.Mobile, smTemp, dataTemp);
            if (sendRes != null && sendRes.ContainsKey("statusCode"))
            {
                if (sendRes["statusCode"].ToString() == "000000")
                {
                    //短信发送成功
                    DbSession.MLT.T_SmsRepository.Add(new T_Sms()
                    {
                        Mobile = req.Mobile,
                        SmsType = req.SmsType,
                        SmsCode = code,
                        SmsStatus = (int)Enums.SmsStatus.No,
                        ExpireTime = dtNow.AddMinutes(30),
                        RowCeateDate = dtNow
                    });
                    DbSession.MLT.SaveChange();
                    ptcp.DoFlag = PtcpState.Success;
                    ptcp.DoResult = "发送短信成功";
                    return ptcp;
                }
                else
                {
                    if (sendRes.ContainsKey("statusMsg"))
                    {
                        string staMst = sendRes["statusMsg"].ToString();
                        if (!string.IsNullOrEmpty(staMst))
                        {
                            ptcp.DoResult = staMst;
                            return ptcp;
                        }
                    }

                    ptcp.DoResult = "发送失败，请稍后再试";
                    return ptcp;
                }
            }
            else
            {
                ptcp.DoResult = "发送失败，请稍后再试";
                return ptcp;
            }

            #endregion
        }

        /// <summary>
        /// 检查短信验证码是否有效并更新短信验证码状态
        /// </summary>
        /// <param name="smsType"></param>
        /// <param name="mobile"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public Ptcp<string> CheckSmsCode(int smsType,string mobile,string code)
        {
            var ptcp = new Ptcp<string>();

            if (string.IsNullOrEmpty(mobile))
            {
                ptcp.DoResult = "手机号码不能为空";
                return ptcp;
            }

            if (string.IsNullOrEmpty(code))
            {
                ptcp.DoResult = "验证码不能为空";
                return ptcp;
            }

            var smsRes = DbSession.MLT.T_SmsRepository.QueryBy(new T_Sms()
                {
                    SmsType = smsType,
                    Mobile = mobile,
                    SmsCode = code,
                }, " ORDER BY SysNo DESC").FirstOrDefault();
            if (smsRes.IsNull() || smsRes.SysNo <= 0)
            {
                ptcp.DoResult = "验证码无效，请重新获取";
                return ptcp;
            }

            if (smsRes.SmsStatus != (int) Enums.SmsStatus.No)
            {
                ptcp.DoResult = "验证码无效，请重新获取";
                return ptcp;
            }

            if (smsRes.ExpireTime < DateTime.Now)
            {
                ptcp.DoResult = "验证码已过期，请重新获取";
                return ptcp;
            }

            //更新验证码
            DbSession.MLT.T_SmsRepository.Update(new T_Sms()
                {
                    SmsStatus = (int)Enums.SmsStatus.OK,
                    VerifTime = DateTime.Now
                },new T_Sms(){SysNo = smsRes.SysNo});
            DbSession.MLT.SaveChange();

            ptcp.DoFlag = PtcpState.Success;
            ptcp.DoResult = "操作成功";
            return ptcp;
        }

        /// <summary>
        /// 生成的短信验证码
        /// </summary>
        /// <param name="strLength"></param>
        /// <param name="isMix"></param>
        /// <returns></returns>
        private static string IsForbidWord(int strLength, int isMix)
        {
            string code = "";
            code = Converter.CreateRandom(strLength, isMix);
            return code;
        }

        /// <summary>
        /// 模板短信
        /// </summary>
        /// <param name="to">短信接收端手机号码集合，用英文逗号分开，每批发送的手机号数量不得超过100个</param>
        /// <param name="templateId">模板Id</param>
        /// <param name="data">可选字段 内容数据，用于替换模板中{序号}</param>
        /// <exception cref="ArgumentNullException">参数不能为空</exception>
        /// <exception cref="Exception"></exception>
        /// <returns></returns>
        public Dictionary<string, object> SendTemplateSMS(string to, string templateId, string[] data)
        {
            Dictionary<string, object> initError = paramCheckRest();
            if (initError != null)
            {
                return initError;
            }
            initError = paramCheckMainAccount();
            if (initError != null)
            {
                return initError;
            }
            initError = paramCheckAppId();
            if (initError != null)
            {
                return initError;
            }

            if (to == null)
            {
                throw new ArgumentNullException("to");
            }

            if (templateId == null)
            {
                throw new ArgumentNullException("templateId");
            }

            try
            {
                string date = DateTime.Now.ToString("yyyyMMddhhmmss");

                // 构建URL内容
                string sigstr = MD5Encrypt(m_mainAccount + m_mainToken + date);
                string uriStr = string.Format("https://{0}:{1}/{2}/Accounts/{3}/SMS/TemplateSMS?sig={4}", m_restAddress, m_restPort, softVer, m_mainAccount, sigstr);
                Uri address = new Uri(uriStr);

                //WriteLog("SendTemplateSMS url = " + uriStr);

                // 创建网络请求  
                HttpWebRequest request = WebRequest.Create(address) as HttpWebRequest;
                setCertificateValidationCallBack();

                // 构建Head
                request.Method = "POST";

                Encoding myEncoding = Encoding.GetEncoding("utf-8");
                byte[] myByte = myEncoding.GetBytes(m_mainAccount + ":" + date);
                string authStr = Convert.ToBase64String(myByte);
                request.Headers.Add("Authorization", authStr);


                // 构建Body
                StringBuilder bodyData = new StringBuilder();

                if (m_bodyType == EBodyType.EType_XML)
                {
                    request.Accept = "application/xml";
                    request.ContentType = "application/xml;charset=utf-8";

                    bodyData.Append("<?xml version='1.0' encoding='utf-8'?><TemplateSMS>");
                    bodyData.Append("<to>").Append(to).Append("</to>");
                    bodyData.Append("<appId>").Append(m_appId).Append("</appId>");
                    bodyData.Append("<templateId>").Append(templateId).Append("</templateId>");
                    if (data != null && data.Length > 0)
                    {
                        bodyData.Append("<datas>");
                        foreach (string item in data)
                        {
                            bodyData.Append("<data>").Append(item).Append("</data>");
                        }
                        bodyData.Append("</datas>");
                    }
                    bodyData.Append("</TemplateSMS>");
                }
                else
                {
                    request.Accept = "application/json";
                    request.ContentType = "application/json;charset=utf-8";

                    bodyData.Append("{");
                    bodyData.Append("\"to\":\"").Append(to).Append("\"");
                    bodyData.Append(",\"appId\":\"").Append(m_appId).Append("\"");
                    bodyData.Append(",\"templateId\":\"").Append(templateId).Append("\"");
                    if (data != null && data.Length > 0)
                    {
                        bodyData.Append(",\"datas\":[");
                        int index = 0;
                        foreach (string item in data)
                        {
                            if (index == 0)
                            {
                                bodyData.Append("\"" + item + "\"");
                            }
                            else
                            {
                                bodyData.Append(",\"" + item + "\"");
                            }
                            index++;
                        }
                        bodyData.Append("]");
                    }
                    bodyData.Append("}");

                }

                byte[] byteData = UTF8Encoding.UTF8.GetBytes(bodyData.ToString());

                //WriteLog("SendTemplateSMS requestBody = " + bodyData.ToString());

                // 开始请求
                using (Stream postStream = request.GetRequestStream())
                {
                    postStream.Write(byteData, 0, byteData.Length);
                }

                // 获取请求
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    // Get the response stream  
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    string responseStr = reader.ReadToEnd();

                    //WriteLog("SendTemplateSMS responseBody = " + responseStr);

                    if (responseStr != null && responseStr.Length > 0)
                    {
                        Dictionary<string, object> responseResult = new Dictionary<string, object> { { "statusCode", "0" }, { "statusMsg", "成功" }, { "data", null } };

                        if (m_bodyType == EBodyType.EType_XML)
                        {
                            XmlDocument resultXml = new XmlDocument();
                            resultXml.LoadXml(responseStr);
                            XmlNodeList nodeList = resultXml.SelectSingleNode("Response").ChildNodes;
                            foreach (XmlNode item in nodeList)
                            {
                                if (item.Name == "statusCode")
                                {
                                    responseResult["statusCode"] = item.InnerText;
                                }
                                else if (item.Name == "statusMsg")
                                {
                                    responseResult["statusMsg"] = item.InnerText;
                                }
                                else if (item.Name == "TemplateSMS")
                                {
                                    Dictionary<string, object> retData = new Dictionary<string, object>();
                                    foreach (XmlNode subItem in item.ChildNodes)
                                    {
                                        retData.Add(subItem.Name, subItem.InnerText);
                                    }
                                    responseResult["data"] = new Dictionary<string, object> { { item.Name, retData } };
                                }
                            }
                        }
                        else
                        {
                            responseResult.Clear();
                            responseResult["resposeBody"] = responseStr;
                        }

                        return responseResult;
                    }
                    return new Dictionary<string, object> { { "statusCode", 172002 }, { "statusMsg", "无返回" }, { "data", null } };
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        /// <summary>
        /// 检查应用ID
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, object> paramCheckAppId()
        {
            if (m_appId == null)
            {
                return new Dictionary<string, object> { { "statusCode", 172012 + "" }, { "statusMsg", "应用ID为空" }, { "data", null } };
            }

            return null;
        }

        /// <summary>
        /// 检查主帐号信息
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, object> paramCheckMainAccount()
        {
            int statusCode = 0;
            string statusMsg = null;

            if (m_mainAccount == null)
            {
                statusCode = 172006;
                statusMsg = "主帐号空";
            }
            else if (m_mainToken == null)
            {
                statusCode = 172007;
                statusMsg = "主帐号令牌空";
            }

            if (statusCode != 0)
            {
                return new Dictionary<string, object> { { "statusCode", statusCode + "" }, { "statusMsg", statusMsg }, { "data", null } };
            }

            return null;
        }

        /// <summary>
        /// 检查子帐号信息
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, object> paramCheckSunAccount()
        {
            int statusCode = 0;
            string statusMsg = null;

            if (m_subAccount == null)
            {
                statusCode = 172008;
                statusMsg = "子帐号空";
            }
            else if (m_subToken == null)
            {
                statusCode = 172009;
                statusMsg = "子帐号令牌空";
            }
            else if (m_voipAccount == null)
            {
                statusCode = 1720010;
                statusMsg = "VoIP帐号空";
            }
            else if (m_voipPwd == null)
            {
                statusCode = 172011;
                statusMsg = "VoIP密码空";
            }

            if (statusCode != 0)
            {
                return new Dictionary<string, object> { { "statusCode", statusCode + "" }, { "statusMsg", statusMsg }, { "data", null } };
            }

            return null;
        }

        /// <summary>
        /// 检查服务器地址信息
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, object> paramCheckRest()
        {
            int statusCode = 0;
            string statusMsg = null;

            if (m_restAddress == null)
            {
                statusCode = 172004;
                statusMsg = "IP空";
            }
            else if (m_restPort == null)
            {
                statusCode = 172005;
                statusMsg = "端口错误";
            }

            if (statusCode != 0)
            {
                return new Dictionary<string, object> { { "statusCode", statusCode + "" }, { "statusMsg", statusMsg }, { "data", null } };
            }

            return null;
        }

        /// <summary>
        /// 初始化函数
        /// </summary>
        /// <param name="restAddress">服务器地址</param>
        /// <param name="restPort">服务器端口</param>
        /// <returns></returns>
        public bool init(string restAddress, string restPort)
        {
            this.m_restAddress = restAddress;
            this.m_restPort = restPort;

            if (m_restAddress == null || m_restAddress.Length < 0 || m_restPort == null || m_restPort.Length < 0 || Convert.ToInt32(m_restPort) < 0)
                return false;

            return true;
        }

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="source">原内容</param>
        /// <returns>加密后内容</returns>
        public static string MD5Encrypt(string source)
        {
            System.Security.Cryptography.MD5 md5Hasher = System.Security.Cryptography.MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(source));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("X2"));
            }
            return sBuilder.ToString();
        }

        /// <summary>
        /// 设置服务器证书验证回调
        /// </summary>
        public void setCertificateValidationCallBack()
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback = CertificateValidationResult;
        }

        /// <summary>
        ///  证书验证回调函数  
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="cer"></param>
        /// <param name="chain"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool CertificateValidationResult(object obj, System.Security.Cryptography.X509Certificates.X509Certificate cer, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors error)
        {
            return true;
        }

    }
}
