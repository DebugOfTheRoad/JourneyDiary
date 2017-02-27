using System;
using System.Web;

namespace JourneyDiary.Common.Caching
{
    public class AspNetCacheManager:ICacheManager
    {
        public T Get<T>(string key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }

            return (T) HttpRuntime.Cache.Get(key);
        }

        public void Set(string key, object value, DateTime absoluteExpiration)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            HttpRuntime.Cache.Insert(key, value, null, absoluteExpiration, TimeSpan.Zero);
        }

        public void Remove(string key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }

            HttpRuntime.Cache.Remove(key);
        }

        public void Clear()
        {
            var cacheEnum = HttpRuntime.Cache.GetEnumerator();
            while (cacheEnum.MoveNext())
            {
                HttpRuntime.Cache.Remove(cacheEnum.Key.ToString());
            }
        }
    }
}
