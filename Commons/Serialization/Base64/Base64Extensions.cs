using System;
using System.Text;

namespace Commons.Serialization.Base64
{
    public static class Base64Extensions
    {
        public static string SerializeToBase64(this string source)
        {
            return Convert.ToBase64String(source.GetBytes());
        }


        public static byte[] GetBytes(this string source)
        {
            return source.GetBytes(Encoding.Unicode);
        }

        public static byte[] GetBytes(this string source, Encoding encoding)
        {
            return encoding.GetBytes(source);
        }



        public static string DeserializeFromBase64(this string source)
        {
            return Convert.FromBase64String(source).Decode();
        }

        public static string DeserializeFromBase64(this string source, Encoding encoding)
        {
            return Convert.FromBase64String(source).Decode(encoding);
        }
        

        public static string Decode(this byte[] source)
        {
            return source.Decode(Encoding.Unicode);
        }

        public static string Decode(this byte[] source, Encoding encoding)
        {
            return encoding.Decode(source);
        }


        public static string Decode(this Encoding source, byte[] bytes)
        {
            var utf8Decoder = source.GetDecoder();

            var charsCount = utf8Decoder.GetCharCount(bytes, 0, bytes.Length);

            var decodedChars = new char[charsCount];

            utf8Decoder.GetChars(bytes, 0, bytes.Length, decodedChars, 0);

            return new string(decodedChars);
        }
    }
}