using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.CacheAccess;

namespace Point.com.Caching
{
    public interface ICacheClients : ICacheClient
    {
        T Get<T>(string key, Func<T> function);
        T Get<T>(string key, Func<T> function, TimeSpan timeSpan);

        bool SetWithLock<T>(string key, T value);
        bool SetWithLock<T>(string key, T value, TimeSpan expiresIn);
    }
}
