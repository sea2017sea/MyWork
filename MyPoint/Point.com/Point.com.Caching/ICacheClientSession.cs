using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Point.com.Caching
{
    public interface ICacheClientSession
    {
        /// <summary>
        /// 本地
        /// </summary>
        ICacheClients LocalCacheClient { get; }
        /// <summary>
        /// 分布式
        /// </summary>
        ICacheClients MemcachedClient { get; }
    }
}
