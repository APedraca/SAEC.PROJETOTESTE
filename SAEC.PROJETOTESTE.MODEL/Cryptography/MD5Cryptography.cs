using System.Security.Cryptography;
using System.Text;

namespace SAEC.PROJETOTESTE.MODEL.Cryptography
{
    public static class MD5Cryptography
    {
        public static string Get(string text)
        {
            MD5CryptoServiceProvider x = new MD5CryptoServiceProvider();
            byte[] bs = Encoding.UTF8.GetBytes(text);
            StringBuilder s = new StringBuilder();

            bs = x.ComputeHash(bs);

            foreach (byte b in bs)
                s.Append(b.ToString("x2").ToLower());

            return s.ToString();
        }
    }
}
