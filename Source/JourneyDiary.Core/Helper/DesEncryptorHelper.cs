using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace JourneyDiary.Common.Helper
{
    /// <summary>
    /// 新版DES加解密算法，直接调用无需创建本类的实例。
    /// </summary>
    public class DesEncryptorHelper
    {
		#region DES缺省值

		private static readonly byte[] DefaultIv = { 0x12, 0x34, 0x56, 0x78, 
									       0x90, 0xAB, 0xCD, 0xEF,
			                               0xA9, 0x3A, 0xCF, 0xAE,
			                               0xB1, 0xF0, 0xF3, 0x9B
		                                 };
		#endregion

		#region 根据密码创建DESCryptoServiceProvider

        /// <summary>
        /// 获取DES加密算法的提供程序
        /// </summary>
        /// <param name="encryptKey">密钥，长度为8位。如果字符超长则截断，不足8位自动用字符@补充。</param>
        /// <returns>DES加密算法的提供程序</returns>
		private static DESCryptoServiceProvider CreateDesProvider(string encryptKey)
		{
            //如果密钥长度小于8位，自动补足到8位。
            int keyLength = encryptKey.Length;
            if (keyLength < 8)
            {
                for (int i = 0; i < (8 - keyLength); i++)
                {
                    encryptKey += "@";
                }
            }

			var des = new DESCryptoServiceProvider();
			des.Key = Encoding.UTF8.GetBytes(encryptKey.Substring(0, des.KeySize/8));
			var byIv = new byte[des.BlockSize/8];
			Array.Copy(DefaultIv, 0, byIv, 0, byIv.Length);
			des.IV = byIv;
			return des;
		}

		#endregion

        #region 加密解密字符串

        /// <summary>
        /// 加密字符串
        /// </summary>
        /// <param name="strText">字符串数据</param>
        /// <param name="encryptKey">密钥，长度为8位。如果字符超长则截断，不足8位自动用字符@补充。</param>
        /// <returns>加密后的字符串</returns>
        public static string Encrypt(string strText, string encryptKey)
        {
            if (string.IsNullOrEmpty(strText))
            {
                return strText;
            }

            var des = CreateDesProvider(encryptKey);
            byte[] inputByteArray = Encoding.UTF8.GetBytes(strText);
            var ms = new MemoryStream();
            var cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return Convert.ToBase64String(ms.ToArray());
        }

        /// <summary>
        /// 解密字符串
        /// </summary>
        /// <param name="encryptedText">加了密的字符串</param>
        /// <param name="decryptKey">密钥，长度为8位。如果字符超长则截断，不足8位自动用字符@补充。</param>
        /// <returns>解密后的字符串</returns>
        public static string Decrypt(string encryptedText, string decryptKey)
        {
            if (string.IsNullOrEmpty(encryptedText))
            {
                return encryptedText;
            }

            DESCryptoServiceProvider des = CreateDesProvider(decryptKey);
            byte[] inputByteArray = Convert.FromBase64String(encryptedText);
            var ms = new MemoryStream();
            var cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return new UTF8Encoding().GetString(ms.ToArray());
        }

        #endregion

        #region 加密解密文件

        /// <summary>
        /// DES加密文件
        /// </summary>
        /// <param name="inputFilePath">源文件路径</param>
        /// <param name="outFilePath">输出文件路径</param>
        /// <param name="encryptKey">密钥，长度为8位。如果字符超长则截断，不足8位自动用字符@补充。</param>
        public static void EncryptFile(string inputFilePath, string outFilePath, string encryptKey)
        {
            FileStream fin = null;
            FileStream fout = null;
            CryptoStream encStream = null;
            try
            {
                fin = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read);
                fout = new FileStream(outFilePath, FileMode.OpenOrCreate, FileAccess.Write);
                fout.SetLength(0);
                
                var bin = new byte[100]; 
                long rdlen = 0; 
                long totlen = fin.Length; 

                DES des = CreateDesProvider(encryptKey);
                encStream = new CryptoStream(fout, des.CreateEncryptor(), CryptoStreamMode.Write);
                while (rdlen < totlen)
                {
                    int len = fin.Read(bin, 0, 100); 
                    encStream.Write(bin, 0, len);
                    rdlen = rdlen + len;
                }
            }
            finally
            {
                if (encStream != null)
                {
                    encStream.Close();
                }
                if (fout != null)
                {
                    fout.Close();
                }
                if (fin != null)
                {
                    fin.Close();
                }
            }
        }


        /// <summary>
        /// 解密文件
        /// </summary>
        /// <param name="inputFilePath">加密了的文件路径</param>
        /// <param name="outFilePath">输出文件路径</param>
        /// <param name="decryptKey">密钥，长度为8位。如果字符超长则截断，不足8位自动用字符@补充。</param>
        public static void DecryptFile(string inputFilePath, string outFilePath, string decryptKey)
        {
            FileStream fin = null;
            FileStream fout = null;
            CryptoStream encStream = null;
            try
            {
                fin = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read);
                fout = new FileStream(outFilePath, FileMode.OpenOrCreate, FileAccess.Write);
                fout.SetLength(0);
   
                var bin = new byte[100]; 
                long rdlen = 0;
                long totlen = fin.Length;
                int len; 

                DES des = CreateDesProvider(decryptKey);
                encStream = new CryptoStream(fout, des.CreateDecryptor(), CryptoStreamMode.Write);
                while (rdlen < totlen)
                {
                    len = fin.Read(bin, 0, 100);
                    encStream.Write(bin, 0, len);
                    rdlen = rdlen + len;
                }
            }
            finally
            {
                if (encStream != null)
                {
                    encStream.Close();
                }
                if (fout != null)
                {
                    fout.Close();
                }
                if (fin != null)
                {
                    fin.Close();
                }
            }
        }

        #endregion

      
    }
}
