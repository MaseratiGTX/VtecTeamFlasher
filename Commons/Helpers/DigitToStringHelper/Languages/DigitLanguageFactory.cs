namespace Commons.Helpers.DigitToStringHelper.Languages
{
    public class DigitLanguageFactory
    {
        public LanguageDigit CreateDigit(string language)
        {
            switch (language)
            {
                case "KKZ":
                    return new CDigitKz();
                default:
                    return new CDigitRu();
            }
        }
    }
}
