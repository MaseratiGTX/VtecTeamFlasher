using System.Collections.Generic;
using System.Linq;
using System.Web;
using Commons.Localization.Extensions;
using Commons.Localization.LanguageContextProviders;

namespace WebAppCommons.Classes.Localization.LanguageContextProviders
{
    public class CommonLanguageContextProvider : ILanguageContextProvider
    {
        public string SessionContextKey { get; private set; }
        public List<string> AvailableLanguages { get; private set; }
        public string DefaultLanguage { get; private set; }



        public CommonLanguageContextProvider(string sessionContextKey, IEnumerable<string> availableLanguages, string defaultLanguage)
        {
            SetSessionContextKey(sessionContextKey);
            SetAvailableLanguages(availableLanguages);
            SetDefaultLanguage(defaultLanguage);
        }



        private CommonLanguageContextProvider SetSessionContextKey(string value)
        {
            SessionContextKey = value;

            return this;
        }

        private CommonLanguageContextProvider SetAvailableLanguages(IEnumerable<string> value)
        {
            AvailableLanguages = value.ToList();

            return this;
        }

        private CommonLanguageContextProvider SetDefaultLanguage(string value)
        {
            DefaultLanguage = AvailableLanguages.Contains(value) ? value : null;

            return this;
        }



        public string CurrentLanguageName()
        {
            return SaveHttpCurrentContext(
                LookForHttpCurrentContext() 
                ?? LookForHttpSessionContext() 
                ?? LookForBrowserAcceptLanguagesContext() 
                ?? DefaultLanguage
            );
        }


        private string SaveHttpCurrentContext(string currentLanguageName)
        {
            if(HttpContext.Current.Items.Contains(this) == false)
            {
                HttpContext.Current.Items[this] = currentLanguageName;
            }

            return currentLanguageName;
        }


        private string LookForHttpCurrentContext()
        {
            return HttpContext.Current.Items[this] as string;
        }

        private string LookForHttpSessionContext()
        {
            var sessionLanguageContext = HttpContext.Current.Session[SessionContextKey] as string;
            
            return AvailableLanguages.Contains(sessionLanguageContext) ? sessionLanguageContext : null;
        }

        private string LookForBrowserAcceptLanguagesContext()
        {
            return HttpContext.Current.Request.UserLanguages
                .NormalizeNames()
                .Where(AvailableLanguages.Contains)
                .FirstOrDefault();
        }
    }
}