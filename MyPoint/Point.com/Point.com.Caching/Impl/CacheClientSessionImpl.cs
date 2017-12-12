using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Point.com.Caching.Impl
{
    internal class CacheClientSessionImpl : ICacheClientSession
    {
        private static ICacheClients _localCacheClient;
        public ICacheClients LocalCacheClient
        {
            get { return _localCacheClient ?? (_localCacheClient = new LocalCacheClientImpl()); }
        }

        private static ICacheClients _memcachedClient;
        public ICacheClients MemcachedClient
        {
            get { return _memcachedClient ?? (_memcachedClient = new MemcachedClientImpl()); }
        }
    }
}
