using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.ServiceHost;

namespace Point.com.ServiceModel.Base
{
    public class BaseModel
    {
        [ApiMember(Description = "会员ID")]
        public int UserId { get; set; }

        [ApiMember(Description = "设备码")]
        public string DeviceCode { get; set; }

        [ApiMember(Description = "来源渠道编号  1 安卓  2 IOS")]
        public int SourceTypeSysNo { get; set; }

        [ApiMember(Description = "客户端IP")]
        public string ClientIp { get; set; }
    }
}
