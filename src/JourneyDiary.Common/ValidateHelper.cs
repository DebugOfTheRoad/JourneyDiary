using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace JuiceZone.Infrastructure.Helper
{
    public class ValidateHelper
    {
        #region 验证字符串是否是正确的Email格式

        /// <summary>
        /// 验证字符串是否是正确的Email格式
        /// </summary>
        public static bool IsValidEmail(string email)
        {
            if (String.IsNullOrEmpty(email))
                return false;

            email = email.Trim();
            var result = Regex.IsMatch(email,
                "^(?:[\\w\\!\\#\\$\\%\\&\\'\\*\\+\\-\\/\\=\\?\\^\\`\\{\\|\\}\\~]+\\.)*[\\w\\!\\#\\$\\%\\&\\'\\*\\+\\-\\/\\=\\?\\^\\`\\{\\|\\}\\~]+@(?:(?:(?:[a-zA-Z0-9](?:[a-zA-Z0-9\\-](?!\\.)){0,61}[a-zA-Z0-9]?\\.)+[a-zA-Z0-9](?:[a-zA-Z0-9\\-](?!$)){0,61}[a-zA-Z0-9]?)|(?:\\[(?:(?:[01]?\\d{1,2}|2[0-4]\\d|25[0-5])\\.){3}(?:[01]?\\d{1,2}|2[0-4]\\d|25[0-5])\\]))$",
                RegexOptions.IgnoreCase);
            return result;
        }

        #endregion

        #region 校验字符串是否是正确的IP地址格式

        /// <summary>
        /// 校验字符串是否是正确的IP地址格式
        /// </summary>
        public static bool IsValidIpAddress(string ipAddress)
        {
            IPAddress ip;
            return IPAddress.TryParse(ipAddress, out ip);
        }

        #endregion

        #region 是否是图片文件

        public static bool IsPictureFile(string fileExtName)
        {
            if (fileExtName != null)
            {
                return fileExtName.Contains(".jpg") || fileExtName.Contains(".png") || fileExtName.Contains(".jpeg");
            }

            return false;
        }

        #endregion

        #region 是否是MP3文件

        public static bool IsMp3File(string fileExtName)
        {
            return fileExtName != null && !fileExtName.ToLower().Contains(".mp3");
        }

        #endregion
    }
}
