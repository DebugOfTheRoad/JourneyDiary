namespace JourneyDiary.Manager.Session
{
    public interface ISessionManager
    {
        T Get<T>(string key);

        void Set(string key, object data,int expires);

        void Remove(string key);
    }
}
