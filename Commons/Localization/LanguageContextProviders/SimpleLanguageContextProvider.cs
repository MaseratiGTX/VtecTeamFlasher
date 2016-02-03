using System.Threading;

namespace Commons.Localization.LanguageContextProviders
{
    public class SimpleLanguageContextProvider : ILanguageContextProvider
    {
        public string CurrentLanguageName()
        {
            return Thread.CurrentThread.CurrentUICulture.ThreeLetterWindowsLanguageName;
        }
    }
}