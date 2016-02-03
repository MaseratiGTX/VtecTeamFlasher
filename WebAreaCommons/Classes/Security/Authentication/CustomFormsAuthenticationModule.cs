using System;
using System.Net;
using System.Security.Principal;
using System.Web;
using System.Web.Security;

namespace WebAreaCommons.Classes.Security.Authentication
{
    public sealed class CustomFormsAuthenticationModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.AuthenticateRequest += ContextOnAuthenticateRequest;
            context.EndRequest += ContextOnEndRequest;
        }

        private void ContextOnAuthenticateRequest(object sender, EventArgs eventArgs)
        {
            var isValidWebResourceRequest = IsValidWebResourceRequest();

            if (isValidWebResourceRequest == false)
            {
                Authenticate();
            }

            HttpContext.Current.SkipAuthorization = isValidWebResourceRequest || CustomFormsAuthentication.IsLoginPage();

            if (HttpContext.Current.User == null)
            {
                HttpContext.Current.User = new GenericPrincipal(new GenericIdentity(String.Empty), null);
            }
        }

        private void Authenticate()
        {
            var context = HttpContext.Current;

            var actualCookieName = CustomFormsAuthentication.GetActualCookieName();

            
            var ticket = CustomFormsAuthentication.ExtractTicketFromCookie(actualCookieName);

            if (ticket == null || ticket.Expired)
                return;

            CustomFormsAuthentication.InitializeUserContext(ticket);
            
            var newTicket = ticket;

            if (CustomFormsAuthentication.SlidingExpiration)
            {
                newTicket = FormsAuthentication.RenewTicketIfOld(ticket);
            }

            if (newTicket != ticket)
            {
                var cookie = CustomFormsAuthentication.GetAuthCookie(actualCookieName, newTicket, true);

                context.Response.Cookies.Remove(cookie.Name);
                context.Response.Cookies.Add(cookie);
            }
        }

        private static bool IsValidWebResourceRequest()
        {
            var filePath = HttpContext.Current.Request.FilePath;

            return filePath.Contains(".axd") || filePath.Contains(".ico");
        }


        private void ContextOnEndRequest(object sender, EventArgs eventArgs)
        {
            if (((HttpApplication) sender).Context.Response.StatusCode == (int) HttpStatusCode.Unauthorized)
            {
                CustomFormsAuthentication.RedirectToLoginPage();
            }
        }

        public void Dispose()
        {
        }
    }
}