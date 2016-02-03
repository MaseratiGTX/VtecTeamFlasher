using System.Configuration;

namespace Commons.Localization.Settings.Configuration
{
    public class LanguageConfigurationElement : ConfigurationElement
    {
        [ConfigurationProperty("languageName", IsRequired = true)]
        public string LanguageName
        {
            get { return (string) base["languageName"]; }
        }

        [ConfigurationProperty("enabled", DefaultValue = true, IsRequired = false)]
        public bool Enabled
        {
            get { return (bool) base["enabled"]; }
        }
    }
}