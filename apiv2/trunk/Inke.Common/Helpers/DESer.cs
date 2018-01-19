using System;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Inke.Common.Helpers
{
    /// <summary>
    /// DES加解密帮助类
    /// </summary>
    public class DESer
    {
        static string key = string.Format("in{0}ke", ConfigurationManager.AppSettings["DesKey"]);

        /// <summary>
        /// DES加密
        /// </summary>
        /// <param name="clearText">明文</param>
        /// <returns>密文</returns>
        public static string Encryption(string clearText)
        {
            string cipherText = string.Empty;
            byte[] inputByteArray = Encoding.UTF8.GetBytes(clearText);

            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                des.Key = Encoding.ASCII.GetBytes(key);
                des.IV = Encoding.ASCII.GetBytes(key);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(inputByteArray, 0, inputByteArray.Length);
                        cs.FlushFinalBlock();
                    }

                    cipherText = Convert.ToBase64String(ms.ToArray());
                }
            }

            return cipherText;
        }

        /// <summary>
        /// DES解密
        /// </summary>
        /// <param name="cipherText">密文</param>
        /// <returns>明文</returns>
        public static string Decryption(string cipherText)
        {
            string clearText = string.Empty;
            byte[] inputByteArray = Convert.FromBase64String(cipherText);

            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                des.Key = Encoding.ASCII.GetBytes(key);
                des.IV = Encoding.ASCII.GetBytes(key);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(inputByteArray, 0, inputByteArray.Length);
                        cs.FlushFinalBlock();
                    }

                    clearText = Encoding.UTF8.GetString(ms.ToArray());
                }
            }

            return clearText;
        }
    }
}
