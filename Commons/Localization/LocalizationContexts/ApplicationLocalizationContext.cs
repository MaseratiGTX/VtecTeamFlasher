using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using Commons.Localization.Extensions;
using Commons.Localization.LanguageContextProviders;
using Commons.Localization.Settings.Configuration;

namespace Commons.Localization.LocalizationContexts
{
    public static class ApplicationLocalizationContext
    {
        public static LocalizationManager LocalizationManager { get; private set; }
        public static LocalizationContextConfigurationSection Settings { get; private set; }



        static ApplicationLocalizationContext()
        {
            Settings = ConfigurationManager.GetSection("localizationContext") as LocalizationContextConfigurationSection;

            LocalizationManager = new LocalizationManager(
                new SimpleLanguageContextProvider(), 
                Settings.FetchAllowedLanguages()
            );
        }



        public static List<LanguageDescription> PresentedLanguageDescriptions()
        {
            return LocalizationManager.PresentedLanguagesDescriptions;
        }

        public static LanguageDescription PresentedLanguageDescription(string languageName)
        {
            return PresentedLanguageDescriptions().FirstOrDefault(x => x.LanguageName == languageName);
        }


        public static string CurrentLanguageName()
        {
            return LocalizationManager.LanguageContextProvider.CurrentLanguageName();
        }


        public static string Localize(string expression)
        {
            return LocalizationManager.Localize(expression);
        }

        public static string Localize(string expression, CultureInfo culture)
        {
            return LocalizationManager.Localize(expression, culture);
        }

        public static string Localize(string expression, string languageName)
        {
            return LocalizationManager.Localize(expression, languageName);
        }
    }
}