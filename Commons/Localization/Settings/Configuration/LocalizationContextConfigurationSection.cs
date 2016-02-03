using System.Configuration;

namespace Commons.Localization.Settings.Configuration
{
    public class LocalizationContextConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("allowedLanguages", IsRequired = true)]
        public AvailableLanguagesConfigurationElementCollection AvailableLanguages
        {
            get { return (AvailableLanguagesConfigurationElementCollection) this["allowedLanguages"]; }
        }
    }
}