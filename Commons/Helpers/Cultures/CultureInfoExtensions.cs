using System.Globalization;

namespace Commons.Helpers.Cultures
{
    public static class CultureInfoExtensions
    {
        public static string ThreeLetterWindowsLanguageName(this CultureInfo source)
        {
            if (source == null) return null;

            return source.ThreeLetterWindowsLanguageName;
        }

        public static string EnglishName(this CultureInfo source)
        {
            if (source == null) return null;

            return source.EnglishName;
        }

        public static string NativeName(this CultureInfo source)
        {
            if (source == null) return null;

            return source.NativeName;
        }
    }
}