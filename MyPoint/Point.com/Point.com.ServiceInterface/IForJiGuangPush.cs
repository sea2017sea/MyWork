using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Point.com.Model;
using Point.com.Model.Base;

namespace Point.com.ServiceInterface
{
    public interface IForJiGuangPush
    {
        /// <summary>
        /// 极光推送
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Ptcp<string> SendPush(M_SendPushReq req);
    }
}
