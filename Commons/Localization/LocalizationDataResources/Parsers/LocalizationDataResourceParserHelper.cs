using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Commons.Localization.LocalizationDataResources.Parsers
{
    internal static class LocalizationDataResourceParserHelper
    {
        public static XElement Root(this XDocument source)
        {
            return source.Elements("LocalizationDataResource").Single();
        }


        public static XElement DescriptionSection(this XElement source)
        {
            return source.Elements("Description").Single();
        }

        public static XElement PresentedLanguages(this XElement source)
        {
            return source.Elements("PresentedLanguages").Single();
        }

        public static IEnumerable<XElement> LanguageSections(this XElement source)
        {
            return source.Elements("Language");
        }

        public static XElement DefaultLanguage(this XElement source)
        {
            return source.Elements("DefaultLanguage").SingleOrDefault();
        }


        public static XElement ItemsSection(this XElement source)
        {
            return source.Elements("Items").Single();
        }

        public static IEnumerable<XElement> ItemSections(this XElement source)
        {
            return source.Elements("Item");
        }
    }
}