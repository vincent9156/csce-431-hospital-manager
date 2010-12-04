using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace HospitalManager.Libraries
{
    /// <summary>
    /// Handles MD5 hashing of strings
    /// </summary>
    public class MD5Encrypter
    {
        /// <summary>
        /// Returns the string representation of the hash of input.
        /// </summary>
        /// <param name="input">The string to hash</param>
        /// <returns>The hashed string</returns>
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