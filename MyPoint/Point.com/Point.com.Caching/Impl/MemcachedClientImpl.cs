using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Enyim.Caching;
using Enyim.Caching.Memcached;
using Point.com.Logging;
using Point.com.Logging.External;
using log4net.Repository.Hierarchy;

namespace Point.com.Caching.Impl
{
    internal class MemcachedClientImpl : ICacheClients
    {
        //初始化Memcached的链路
        private static readonly MemcachedClient MemcachedClient = new MemcachedClient();

        public bool Add<T>(string key, T value, System.TimeSpan expiresIn)
        {
            return MemcachedClient.Store(StoreMode.Add, key, value, expiresIn);
        }

        public bool Add<T>(string key, T value, System.DateTime expiresAt)
        {
            return MemcachedClient.Store(StoreMode.Add, key, value, expiresAt);
        }

        public bool Add<T>(string key, T value)
        {
            return MemcachedClient.Store(StoreMode.Add, key, value);
        }

        public long Decrement(string key, uint amount)
        {
            /*return MemcachedClient.Decrement(key, amount);*/
            throw new NotImplementedException();
        }

        public void FlushAll()
        {
            MemcachedClient.FlushAll();
        }

        public T Get<T>(string key)
        {
            return MemcachedClient.Get<T>(key);
        }

        public IDictionary<string, T> GetAll<T>(IEnumerable<string> keys)
        {
            /*  //获取指定key 全部数据
              var dics = MemcachedClient.Get_Multi(keys);
              //初始容器
              IDictionary<string, T> dictionary = null;
              //转换数据
              if (dics.Count >= 0)
              {
                  dictionary = new Dictionary<string, T>();
                  foreach (KeyValuePair<string, object> keyValuePair in dics)
                  {
                      dictionary.Add(keyValuePair.Key, (T)keyValuePair.Value);
                  }
              }
              return dictionary;*/
            throw new NotImplementedException();
        }

        public long Increment(string key, uint amount)
        {
            /* return MemcachedClient.Increment(key,2, amount);*/
            throw new NotImplementedException();
        }

        public bool Remove(string key)
        {
            return MemcachedClient.Remove(key);
        }

        public void RemoveAll(IEnumerable<string> keys)
        {
            foreach (string key in keys)
            {
                MemcachedClient.Remove(key);
            }
        }

        public bool Replace<T>(string key, T value, System.TimeSpan expiresIn)
        {
            return MemcachedClient.Store(StoreMode.Replace, key, value, expiresIn);
        }

        public bool Replace<T>(string key, T value, System.DateTime expiresAt)
        {
            return MemcachedClient.Store(StoreMode.Replace, key, value, expiresAt);
        }

        public bool Replace<T>(string key, T value)
        {
            return MemcachedClient.Store(StoreMode.Replace, key, value);
        }

        public bool Set<T>(string key, T value, System.TimeSpan expiresIn)
        {
            return MemcachedClient.Store(StoreMode.Set, key, value, expiresIn);
        }

        public bool Set<T>(string key, T value, System.DateTime expiresAt)
        {
            return MemcachedClient.Store(StoreMode.Set, key, value, expiresAt);
        }

        public bool Set<T>(string key, T value)
        {
            return MemcachedClient.Store(StoreMode.Set, key, value);
        }

        public void SetAll<T>(IDictionary<string, T> values)
        {
            foreach (KeyValuePair<string, T> keyValuePair in values)
            {
                MemcachedClient.Store(StoreMode.Set, keyValuePair.Key, keyValuePair.Value);
            }
        }

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

        /*public T Get<T>(string key, Func<T> function)
        {
            return Get(key, function, new TimeSpan(7, 0, 0, 0));
        }

        public T Get<T>(string key, Func<T> function, TimeSpan timeSpan)
        {
            T t = Get<T>(key);
            if (null == t)
            {
                //重新获取
                //指定格式生成锁Key
                string lockKey = string.Format("{0}{1}", key, LockSuffix);
                //为轮训增加累加器
                int ax = 0;
                //轮询锁 
                while (MemcachedClient.Store(StoreMode.Add, lockKey, 1) == false)
                {
                    ax++;
                    if (ax == 5)
                    {
                        LoggerIoc.GetLogger()
                                 .Write(LoggerLevel.Error, "b8677fa87b1a4c73b0be96ba3e10fc02", "Get轮训锁",
                                        string.Format("5次未获取Get轮训锁:{0}:{1}", lockKey, key));
                        //报警
                        var r = function();
                        MemcachedClient.Remove(lockKey);
                        Set(key, r, timeSpan);
                        return r;
                    }
                    //轮训期间的处理
                    Thread.Sleep(50);
                }
                //获取锁，二次判断
                t = Get<T>(key);
                try
                {
                    if (t == null)
                    {
                        t = function();
                        Set(key, t, timeSpan);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    MemcachedClient.Remove(lockKey);
                }

            }
            return t;
        }*/

        public bool SetWithLock<T>(string key, T value)
        {
            return SetWithLock(key, value, new TimeSpan(17, 0, 0, 0));
        }

        public bool SetWithLock<T>(string key, T value, TimeSpan expiresIn)
        {
            //指定格式生成锁Key
            string lockKey = string.Format("{0}{1}", key, LockSuffix);
            //为轮训增加累加器
            int ax = 0;
            //轮询锁 
            while (!MemcachedClient.Store(StoreMode.Add, lockKey, 1))
            {
                ax++;
                if (ax == 5)
                {
                    //5次拿不到，放弃。。。
                    LoggerIoc.GetLogger().Write(LoggerLevel.Error, "2cf19048128945da95e161232b3f48ce", "Set轮训锁", "5次未获取Set轮训锁");
                    break;
                }
                //中断再retry
                Thread.Sleep(50);
            }

            try
            {
                //覆盖式更新
                return MemcachedClient.Store(StoreMode.Set, key, value, expiresIn);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                //释放
                MemcachedClient.Remove(lockKey);
            }

        }

        private const string LockSuffix = "Ls";

        public void Dispose()
        {
            MemcachedClient.Dispose();
        }
    }
}
