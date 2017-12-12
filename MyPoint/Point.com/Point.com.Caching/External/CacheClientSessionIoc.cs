using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Point.com.Caching.Impl;

namespace Point.com.Caching.External
{
    public class CacheClientSessionIoc
    {
        private static ICacheClientSession _cacheClientSession;
        public static ICacheClientSession GetCacheClientSession()
        {
            return _cacheClientSession ?? new CacheClientSessionImpl();
        }
    }
}
