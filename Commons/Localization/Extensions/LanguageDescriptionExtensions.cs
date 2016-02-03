namespace Commons.Localization.Extensions
{
    public static class LanguageDescriptionExtensions
    {
        public static string LanguageName(this LanguageDescription source)
        {
            return source != null ? source.LanguageName : null;
        }
        
        public static string NativeName(this LanguageDescription source)
        {
            return source != null ? source.NativeName : null;
        }

        public static string EnglishName(this LanguageDescription source)
        {
            return source != null ? source.EnglishName : null;
        }
    }
}