using System;

namespace Commons.Helpers.CommonObjects
{
    public static class StringSplitExtensions
    {
        public static string[] Split(this string source, char separator, StringSplitOptions options)
        {
            return source.Split(new[] { separator }, options);
        }

        public static string[] Split(this string source, char separator1, char separator2, StringSplitOptions options)
        {
            return source.Split(new[] { separator1, separator2 }, options);
        }

        public static string[] Split(this string source, char separator1, char separator2, char separator3, StringSplitOptions options)
        {
            return source.Split(new[] { separator1, separator2, separator3 }, options);
        }

        public static string[] Split(this string source, char separator1, char separator2, char separator3, char separator4, StringSplitOptions options)
        {
            return source.Split(new[] { separator1, separator2, separator3, separator4 }, options);
        }

        public static string[] Split(this string source, char separator1, char separator2, char separator3, char separator4, char separator5, StringSplitOptions options)
        {
            return source.Split(new[] { separator1, separator2, separator3, separator4, separator5 }, options);
        }


        public static string[] Split(this string source, params string[] separator)
        {
            return source.Split(separator, StringSplitOptions.None);
        }

        public static string[] Split(this string source, string separator, StringSplitOptions options)
        {
            return source.Split(new[] { separator }, options);
        }

        public static string[] Split(this string source, string separator1, string separator2, StringSplitOptions options)
        {
            return source.Split(new[] { separator1, separator2 }, options);
        }

        public static string[] Split(this string source, string separator1, string separator2, string separator3, StringSplitOptions options)
        {
            return source.Split(new[] { separator1, separator2, separator3 }, options);
        }   

        public static string[] Split(this string source, string separator1, string separator2, string separator3, string separator4, StringSplitOptions options)
        {
            return source.Split(new[] { separator1, separator2, separator3, separator4 }, options);
        }   

        public static string[] Split(this string source, string separator1, string separator2, string separator3, string separator4, string separator5, StringSplitOptions options)
        {
            return source.Split(new[] { separator1, separator2, separator3, separator4, separator5 }, options);
        }   
    }
}