using System.Net.WebSockets;
using System.Text;

namespace Practice.API.Common
{
    public static class CommonMethod
    {
        public static string Key = "abc@abc";
        public static string  ConvertToEncrypt(string passwrod)
        {
            if (string.IsNullOrEmpty(passwrod)) return "";

            passwrod += Key;
            var PasswordBytes=Encoding.UTF8.GetBytes(passwrod);
            return Convert.ToBase64String(PasswordBytes);
        }

        public static string ConvertToDecrypt(string base64EncodeData)
        {
            if (string.IsNullOrEmpty(base64EncodeData)) return "";
            var base64EncodeBytes=Convert.FromBase64String(base64EncodeData);
            var result=Encoding.UTF8.GetString(base64EncodeBytes);
            result=result.Substring(0, result.Length-7);
            return result;
        }

    }
}
