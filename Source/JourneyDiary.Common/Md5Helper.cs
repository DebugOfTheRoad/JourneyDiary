
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace JuiceZone.Infrastructure.Helper
{
    public class Md5Helper
    {
        #region 计算字符串的MD5

        public static string ComputeMd5(string value)
        {
            var accountBuffers = Encoding.ASCII.GetBytes(value);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] targetData = md5.ComputeHash(accountBuffers);
            string result = BitConverter.ToString(md5.ComputeHash(accountBuffers));
            result = result.Replace("-", "").ToLower();
            return result;
        }

        #endregion
    }
}
