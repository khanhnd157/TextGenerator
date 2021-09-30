using System.Security.Cryptography;
using System.Text;

namespace CodeMazeNET.TextGenerator
{
    public static class HashGenerator
    {
        public static string SaltedHash()
        {
            // autu generate key salt
            return TextGenerator.Builder(8);
        }

        public static string MD5(this string text, bool uppercase = true)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text
            md5.ComputeHash(Encoding.UTF8.GetBytes(text));

            //get hash result after compute it
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            var format = uppercase ? "X2" : "x2";
            for (int i = 0; i < result.Length; i++)
            {
                // change it into 2 hexadecimal digits
                // for each byte
                // can be "x2" if want lowercase
                // can be "X2" if want uppercase
                strBuilder.Append(result[i].ToString(format));
            }

            return strBuilder.ToString();
        }

        public static string SHA1(this string text, bool uppercase = true)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(text));
                var sb = new StringBuilder(hash.Length * 2);
                var format = uppercase ? "X2" : "x2";
                foreach (byte b in hash)
                {
                    // change it into 2 hexadecimal digits
                    // for each byte
                    // can be "x2" if want lowercase
                    // can be "X2" if want uppercase
                    sb.Append(b.ToString(format));
                }

                return sb.ToString();
            }
        }
    }
}