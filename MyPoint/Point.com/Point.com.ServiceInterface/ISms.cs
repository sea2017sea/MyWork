using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Point.com.Model;
using Point.com.Model.Base;

namespace Point.com.ServiceInterface
{
    public interface ISms
    {
        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Ptcp<string> SendSms(M_SendSmsReq req);
    }
}
