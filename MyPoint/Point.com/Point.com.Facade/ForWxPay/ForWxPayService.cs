using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using Point.com.Logging;
using Point.com.Model.Base;
using Point.com.ServiceInterface;
using Point.com.ServiceModel;

namespace Point.com.Facade.ForWxPay
{
    public class ForWxPayService : BaseService<IForWxPay>
    {
        /// <summary>
        /// 微信支付回调，异步通知
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public WxAsyncNotifyRes Any(WxAsyncNotifyReq req)
        {
            var res = new WxAsyncNotifyRes();

            try
            {
                string jsonParam = JsonConvert.SerializeObject(req);
                Logger.Write(LoggerLevel.Error, "WxAsyncNotifyReq_in", "微信支付回调", jsonParam, "");
                var ptcp = ServiceImpl.WxAsyncNotify(req.SendData);

                if (ptcp.DoFlag == PtcpState.Success)
                {
                    res.DoFlag = (int)PtcpState.Success;
                }
                res.DoResult = ptcp.DoResult;
            }
            catch (Exception ex)
            {
                res.DoResult = ex.ToString();
            }

            return res;
        }
    }
}
