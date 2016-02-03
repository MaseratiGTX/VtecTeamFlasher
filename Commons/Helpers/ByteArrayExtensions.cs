using System;
using System.Linq;
using Commons.Providers;

namespace Commons.Helpers
{
    public static class ByteArrayExtensions
    {
        public static string SizeToString(this byte[] source)
        {
            return source.SizeToString(false);
        }

        public static string SizeToString(this byte[] source, bool allowNullSize)
        {
            if ((allowNullSize == false) && (source.Length == 0)) return null;

            return String.Format(new FileSizeFormatProvider(), "{0:fs}", source.Length);
        }


        public static byte[] ToByteArray(this int source)
        {
            var result = BitConverter.GetBytes(source);

            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(result);
            }

            return result;
        }

        public static byte[] Append(this byte[] source, params int[] paramenters)
        {
            return source.Concat(paramenters.SelectMany(x => x.ToByteArray())).ToArray();
        }

    }
}