using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Point.com.Model.Base;

namespace Point.com.ServiceInterface
{
    public interface IForWxPay
    {
        /// <summary>
        /// 支付回调，通知
        /// </summary>
        /// <param name="sendData"></param>
        /// <returns></returns>
        Ptcp<string> WxAsyncNotify(string sendData);
    }
}
