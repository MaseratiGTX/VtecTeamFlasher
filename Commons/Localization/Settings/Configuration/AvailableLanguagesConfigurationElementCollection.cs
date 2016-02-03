using System.Configuration;

namespace Commons.Localization.Settings.Configuration
{
    [ConfigurationCollection(typeof (LanguageConfigurationElement), CollectionType = ConfigurationElementCollectionType.AddRemoveClearMap)]
    public class AvailableLanguagesConfigurationElementCollection : ConfigurationElementCollection
    {
        public LanguageConfigurationElement this[int index]
        {
            get { return (LanguageConfigurationElement) BaseGet(index); }

            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }

                base.BaseAdd(index, value);
            }
        }

        public new LanguageConfigurationElement this[string name]
        {
            get { return (LanguageConfigurationElement) BaseGet(name); }
        }


        protected override ConfigurationElement CreateNewElement()
        {
            return new LanguageConfigurationElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((LanguageConfigurationElement) element).LanguageName;
        }
    }
}