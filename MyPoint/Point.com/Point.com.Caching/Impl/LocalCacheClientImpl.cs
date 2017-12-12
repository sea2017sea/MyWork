using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.CacheAccess.Providers;

namespace Point.com.Caching.Impl
{
    internal class LocalCacheClientImpl : MemoryCacheClient, ICacheClients
    {
        private static readonly object LockObj = new object();

        public T Get<T>(string key, Func<T> function)
        {
            T t = Get<T>(key);
            if (null == t)
            {
                lock (LockObj)
                {
                    t = Get<T>(key);
                    if (null == t)
                    {
                        t = function();
                        Set(key, t);
                    }
                }
            }
            return t;
        }

        public T Get<T>(string key, Func<T> function, TimeSpan timeSpan)
        {
            T t = Get<T>(key);
            if (null == t)
            {
                lock (LockObj)
                {
                    t = Get<T>(key);
                    if (null == t)
                    {
                        t = function();
                        Set(key, t, timeSpan);
                    }
                }
            }
            return t;
        }

        public bool SetWithLock<T>(string key, T value)
        {
            throw new NotImplementedException();
        }

        public bool SetWithLock<T>(string key, T value, TimeSpan expiresIn)
        {
            throw new NotImplementedException();
        }
    }
}
