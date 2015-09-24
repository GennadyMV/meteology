using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeteologyEntity.Helper
{
    public static class Helper
    {
        public static decimal ConvertDecimal(string token)
        {
            decimal res = decimal.MaxValue;
            try
            {
                token = token.Replace(" ", "");
                token = token.Replace(".", ",");
                res = Convert.ToDecimal(token);
            }
            catch { }
            return res;
        }
        public static String  readFileAsUtf8(string fileName)
        {
            Encoding encoding = Encoding.Default;
            String original = String.Empty;

            using (StreamReader sr = new StreamReader(fileName, Encoding.Default))
            {
                original = sr.ReadToEnd();
                encoding = sr.CurrentEncoding;
                sr.Close();
            }

            if (encoding == Encoding.UTF8)
                return original;

            byte[] encBytes = encoding.GetBytes(original);
            byte[] utf8Bytes = Encoding.Convert(encoding, Encoding.UTF8, encBytes);
            return Encoding.UTF8.GetString(utf8Bytes);
        }
    }
}
