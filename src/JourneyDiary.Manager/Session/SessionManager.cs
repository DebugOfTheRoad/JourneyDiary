using System;
using System.Web;
using JourneyDiary.Common;
using Newtonsoft.Json;

namespace JourneyDiary.Manager.Session
{
    public class SessionManager:ISessionManager
    {
        private const string Key = "*#jucize_zone_123";

        public T Get<T>(string key)
        {
            var httpCookie= HttpContext.Current.Request.Cookies[key];
            if (httpCookie == null)
            {
                return default(T);
            }

   
            string decryptData = DesEncryptorHelper.Decrypt(httpCookie.Value, Key);
          
            T value = JsonConvert.DeserializeObject<T>(decryptData);
            if (value==null)
            {
                return default(T);
            }

            return (T) value;
        }

        /// <summary>
        /// 设置key和value
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expires">过期时间 单位分钟</param>
        public void Set(string key, object value,int expires)
        {
            var data = JsonConvert.SerializeObject(value);
            var encryptData = DesEncryptorHelper.Encrypt(data,Key);

            var httpCookie = new HttpCookie(key, encryptData) {Expires = DateTime.Now.AddMinutes(expires) };
            HttpContext.Current.Response.Cookies.Add(httpCookie);
        }

        public void Remove(string key)
        {
            var httpCookie = HttpContext.Current.Request.Cookies[key];
            if (httpCookie == null) return;

            httpCookie.Expires = DateTime.Now.AddYears(-20);
            HttpContext.Current.Response.Cookies.Add(httpCookie);
        }
    }
}
