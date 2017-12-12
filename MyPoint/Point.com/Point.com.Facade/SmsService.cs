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
    public class SmsService : BaseService<ISms>
    {
        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public SendSmsRes Any(SendSmsReq req)
        {
            var res = new SendSmsRes();

            try
            {
                var m_req = Mapper.Map<SendSmsReq, M_SendSmsReq>(req);
                var ptcp = ServiceImpl.SendSms(m_req);
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
