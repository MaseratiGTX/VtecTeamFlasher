using System;
using System.Security.Cryptography;
using System.Text;

namespace Commons.Helpers
{
    public static class HashExtensions
    {
        public static string ComputeSHA256Hash(this string source)
        {
            if (source == null) return null;

            var sourceBytes = Encoding.Unicode.GetBytes(source);

            return Convert.ToBase64String(
                new SHA256Managed().ComputeHash(sourceBytes)
            );
        }
    }
}