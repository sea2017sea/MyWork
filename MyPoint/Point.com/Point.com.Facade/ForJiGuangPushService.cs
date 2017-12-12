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
    public class ForJiGuangPushService : BaseService<IForJiGuangPush>
    {
        /// <summary>
        /// 极光推送
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public SendPushRes Any(SendPushReq req)
        {
            var res = new SendPushRes();

            try
            {
                var m_req = Mapper.Map<SendPushReq, M_SendPushReq>(req);
                var ptcp = ServiceImpl.SendPush(m_req);
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
