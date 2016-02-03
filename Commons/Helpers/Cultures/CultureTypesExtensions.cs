using System;
using System.Globalization;
using System.Linq;

namespace Commons.Helpers.Cultures
{
    public static class CultureTypesExtensions
    {
        public static CultureInfo FirstOrDefaultBy(this CultureTypes source, string threeLetterWindowsLanguageName)
        {
            return source.FirstOrDefault(x => x.ThreeLetterWindowsLanguageName == threeLetterWindowsLanguageName);
        }

        public static CultureInfo FirstOrDefault(this CultureTypes source, Func<CultureInfo, bool> predicate)
        {
            return CultureInfo.GetCultures(source).FirstOrDefault(predicate);
        }
    }
}