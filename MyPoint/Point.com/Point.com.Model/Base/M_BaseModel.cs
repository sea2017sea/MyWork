using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Point.com.Model.Base
{
    public class M_BaseModel
    {
        /// <summary>
        /// 会员ID
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 设备码
        /// </summary>
        public string DeviceCode { get; set; }

        /// <summary>
        /// 来源渠道编号
        /// </summary>
        public int SourceTypeSysNo { get; set; }

        /// <summary>
        /// 客户端IP
        /// </summary>
        public string ClientIp { get; set; }
    }
}
