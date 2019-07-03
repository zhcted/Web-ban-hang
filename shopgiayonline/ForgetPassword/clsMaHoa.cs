using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace shopgiayonline.ForgetPassword
{
    public class clsMaHoa
    {
        private static string keyValue = "CuaHangDienMay";
        public static string Key
        {
            set { keyValue = value; }
            get { return keyValue; }
        }

        public static string EncryptPassword(string password)
        {
            string encryptPassword = password + keyValue;
            try
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(encryptPassword);

                HashAlgorithm hash = new MD5CryptoServiceProvider();
                byte[] hashBytes = hash.ComputeHash(passwordBytes);

                encryptPassword = Convert.ToBase64String(passwordBytes);
            }
            catch
            {
            }
            return encryptPassword;
        }
    }
}