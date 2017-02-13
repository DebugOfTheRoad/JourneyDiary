using System;

namespace JourneyDiary.Manager.Caching
{
    public interface ICacheManager
    {
        T Get<T>(string key);

        void Set(string key, object value, DateTime absoluteExpiration);

        void Remove(string key);

        void Clear();
    }
}
