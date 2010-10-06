using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace HospitalManager.Libraries
{
    public class MD5Encrypter
    {
        /**
         * Returns the string representation of the hash of input.
         */
        public static string GetMD5Hash(string input)
        {
            MD5 hasher = MD5.Create();
            byte[] hash = hasher.ComputeHash(Encoding.Default.GetBytes(input));

            StringBuilder sb = new StringBuilder();
            foreach (byte b in hash)
            {
                sb.Append(b.ToString("x2").ToLower());
            }

            return sb.ToString();
        }
    }
}