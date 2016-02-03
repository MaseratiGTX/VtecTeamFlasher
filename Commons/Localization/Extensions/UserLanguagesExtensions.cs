using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Commons.Helpers.Collections.Generic;
using Commons.Helpers.Cultures;

namespace Commons.Localization.Extensions
{
    public static class UserLanguagesExtensions
    {
        public static IEnumerable<string> NormalizeNames(this string[] source)
        {
            if (source == null) return new List<string>();
            
            return source.Select(x => x.NormalizeName()).EvictNull().Distinct();
        }

        public static string NormalizeName(this string source)
        {
            return source.ToCultureInfo().ThreeLetterWindowsLanguageName();
        }
        
            
        public static IEnumerable<CultureInfo> ToCultureInfos(this string[] source)
        {
            if (source == null) return new List<CultureInfo>();

            return source.Select(x => x.ToCultureInfo()).EvictNull().Distinct();
        }

        public static CultureInfo ToCultureInfo(this string source)
        {
            if (source == null) return null;

            try
            {
                return CultureInfo.GetCultureInfo(source.Split(';')[0]);
            }
            catch(Exception)
            {
                return null;
            }
        }
    }
}