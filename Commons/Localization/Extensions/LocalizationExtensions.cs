using System.Globalization;
using Commons.Localization.LocalizationContexts;

namespace Commons.Localization.Extensions
{
    public static class LocalizationExtensions
    {
        public static string Localize(this string source)
        {
            return ApplicationLocalizationContext.Localize(source);
        }

        public static string Localize(this string source, CultureInfo culture)
        {
            return ApplicationLocalizationContext.Localize(source, culture);
        }

        public static string Localize(this string source, string languageName)
        {
            return ApplicationLocalizationContext.Localize(source, languageName);
        }
    }
}