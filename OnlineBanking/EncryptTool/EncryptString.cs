using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBanking.EncryptTool
{
    public class EncryptString
    {
        public string Encrypt(string unencryptedString)
        {
            using(MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                byte[] data = md5.ComputeHash(utf8.GetBytes(unencryptedString));
                return Convert.ToBase64String(data);
            }
        }
    }
}
