using System.Configuration;

namespace WebAreaCommons.Classes.Security.Authentication.Configuration
{
    public class CustomAuthenticationSection : ConfigurationSection
    {
        [ConfigurationProperty("customForms")]
        public CustomFormsAuthenticationElement CustomFormsAuthenticationElement
        {
            get
            {
                return (CustomFormsAuthenticationElement)this["customForms"];
            }
        }
    }
}