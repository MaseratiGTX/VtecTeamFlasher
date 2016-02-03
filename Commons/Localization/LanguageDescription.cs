using System.Globalization;
using Commons.Helpers.CommonObjects;
using Commons.Helpers.Cultures;

namespace Commons.Localization
{
    public class LanguageDescription
    {
        public string LanguageName { get; set; }
        public string EnglishName { get; set; }
        public string NativeName { get; set; }


        public LanguageDescription()
        {
        }

        public LanguageDescription(string languageName)
        {
            var languageNameNormalized = languageName.ToUpperInvariant();

            var languageCultureInfo = CultureTypes.AllCultures.FirstOrDefaultBy(languageNameNormalized);

            LanguageName = languageNameNormalized;
            EnglishName = languageCultureInfo.EnglishName().FirstLetterToUpper();
            NativeName = languageCultureInfo.NativeName().FirstLetterToUpper();
        }
    }
}