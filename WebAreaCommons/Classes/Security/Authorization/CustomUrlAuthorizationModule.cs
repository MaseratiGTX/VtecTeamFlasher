using System;
using System.Web;
using Commons.Helpers.Objects;

namespace WebAreaCommons.Classes.Security.Authorization
{
    public class CustomUrlAuthorizationModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.AuthorizeRequest += ContextOnAuthorizeRequest;
        }


        private static void ContextOnAuthorizeRequest(object sender, EventArgs eventArgs)
        {
            var context = ((HttpApplication) sender).Context;

            if (context.SkipAuthorization) return;

            if (ApplicationAuthorizationContext.IsUserAllowed(context.User) == false)
                HandleAuthorizationFail(context);
        }

        private static void HandleAuthorizationFail(HttpContext context)
        {
            var url = ApplicationAuthorizationContext.AuthorizationRuleManager.AuthorizationFailedUrl;

            if (context.User != null && context.User.Identity.IsAuthenticated && url.IsNotEmpty())
                context.Response.Redirect(url);
            else
                ReportUrlAuthorizationFailure();
        }

        private static void ReportUrlAuthorizationFailure()
        {
            HttpContext.Current.Response.StatusCode = 401;
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }

        public void Dispose()
        {
        }
    }
}