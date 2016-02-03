using System.Configuration;

namespace WebAreaCommons.Classes.Security.Authentication.Configuration
{
    public class CustomFormsAuthenticationElement : ConfigurationElement
    {
        [ConfigurationProperty("loginUrl", DefaultValue = "~/Login")]
        public string LoginUrl
        {
            get
            {
                return (string)this["loginUrl"];
            }
        }

        [ConfigurationProperty("defaultUrl", DefaultValue = "~/")]
        public string DefaultUrl
        {
            get
            {
                return (string)this["defaultUrl"];
            }
        }

        [ConfigurationProperty("timeout", DefaultValue = "30")]
        public int Timeout
        {
            get
            {
                return (int)this["timeout"];
            }
        }

        [ConfigurationProperty("name", DefaultValue = ".ASPXAUTH")]
        public string Name
        {
            get
            {
                return (string)this["name"];
            }
        }

        [ConfigurationProperty("alternativeName", DefaultValue = null)]
        public string AlternativeName
        {
            get
            {
                return (string)this["alternativeName"];
            }
        }
    }
}