using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace ДП
{
    class PasswordHashing
    {
        public static string hashPassword(string password)
        {
            MD5 md5 = MD5.Create();
            byte[] b = Encoding.ASCII.GetBytes(password);
            byte[] hashes = md5.ComputeHash(b);

            StringBuilder stringBuilder = new StringBuilder();
            foreach (byte hash in hashes)
                stringBuilder.Append(hash.ToString("x2"));

            return Convert.ToString(stringBuilder);
        }
    }
}
