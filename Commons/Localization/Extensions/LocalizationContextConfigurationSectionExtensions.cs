using System.Collections.Generic;
using System.Linq;
using Commons.Helpers.Objects;
using Commons.Localization.Settings.Configuration;

namespace Commons.Localization.Extensions
{
    public static class LocalizationContextConfigurationSectionExtensions
    {
         public static IEnumerable<string> FetchAllowedLanguages(this LocalizationContextConfigurationSection source)
         {
             if (source == null) return null;

             if (source.AvailableLanguages.IsEmpty()) return null;

             return source.AvailableLanguages
                 .Cast<LanguageConfigurationElement>()
                 .Where(x => x.Enabled)
                 .Select(x => x.LanguageName);
         }
    }
}