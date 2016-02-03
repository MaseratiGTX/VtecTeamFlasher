using System;
using System.Web;
using Commons.Helpers.Objects;

namespace WebAppCommons.Classes.Localization.HttpModules
{
    public class LanguageContextHttpModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.PostAcquireRequestState += context_PostAcquireRequestState;
        }

        public void Dispose()
        {
        }


        private void context_PostAcquireRequestState(object sender, EventArgs e)
        {
            var HttpApplication = (HttpApplication) sender;

            var languageContext = HttpApplication.Request[LocalizationConstants.LANGUAGE_CONTEXT_KEY];

            if (languageContext.IsNotNull())
            {
                HttpApplication.Session[LocalizationConstants.LANGUAGE_CONTEXT_KEY] = languageContext;
            }
        }
    }
}