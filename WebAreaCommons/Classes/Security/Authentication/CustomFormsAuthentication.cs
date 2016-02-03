using System;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using Commons.Helpers.CommonObjects;
using Commons.Helpers.Objects;
using WebAreaCommons.Classes.Helpers;
using WebAreaCommons.Classes.Security.Authentication.Configuration;

namespace WebAreaCommons.Classes.Security.Authentication
{
    public sealed class CustomFormsAuthentication
    {
        private static readonly string cookieName;
        private static readonly string loginUrl;

        public static string AlternativeCookieName { get; private set; }
        public static string DefaultUrl { get; private set; }
        public static int  CookieTimeout{ get; private set;}
        public static bool SlidingExpiration { get; private set;}

        public static string CookieName
        {
            get
            {
                var clientCode = HttpContext.Current.GetCurrentClientCode();

                return clientCode.IsEmpty() ? cookieName : "{0}_{1}".FillWith(cookieName, clientCode);
            }
        }

        public static string LoginUrl
        {
            get
            {
                return HttpContextHelper.GetUrlWithAppContext(loginUrl);
            }
        }

        static CustomFormsAuthentication()
        {
            var customFormsConfig = CustomAuthenticationConfigContext.GetCustomFormsElement();

            cookieName = customFormsConfig.Name;
            AlternativeCookieName = customFormsConfig.AlternativeName;

            loginUrl = customFormsConfig.LoginUrl;
            DefaultUrl = customFormsConfig.DefaultUrl;
            CookieTimeout = customFormsConfig.Timeout;
            SlidingExpiration = true;
        }


        public static bool IsLoginPage()
        {
            var absoluteLoginUrl = VirtualPathUtility.ToAbsolute(LoginUrl);

            return HttpContext.Current.Request.FilePath.Equals(absoluteLoginUrl, StringComparison.OrdinalIgnoreCase);
        }
        

        public static void RedirectToLoginPage()
        {
            HttpContext.Current.Response.Redirect(LoginUrl);
        }

        public static void RedirectToDefaultPage()
        {
            HttpContext.Current.Response.Redirect(DefaultUrl);
        }


        public static void SignOut()
        {
            MakeCookieExpired(CookieName);

            HttpContext.Current.User = null;

            var ticket = ExtractTicketFromCookie(AlternativeCookieName);

            if (ticket == null || ticket.Expired)
                return;

            InitializeUserContext(ticket);
        }


        public static void  MakeCookieExpired(string name)
        {
            var context = HttpContext.Current;
            var cookieValue = String.Empty;

            if (context.Request.Browser["supportsEmptyStringInCookieValue"] == "false")
                cookieValue = "NoCookie";

            var cookie = new HttpCookie(name, cookieValue)
                         {
                             HttpOnly = true,
                             Expires = new DateTime(1999, 10, 12)
                         };

            context.Response.Cookies.Remove(name);
            context.Response.Cookies.Add(cookie);
        }


        public static void SetAuthCookie(string value, bool createPersistentCookie, string userData)
        {
            var authCookie = GetAuthCookie(value, createPersistentCookie, userData);

            HttpContext.Current.Response.Cookies.Add(authCookie);
        }


        public static HttpCookie GetAuthCookie(string value, bool createPersistentCookie, string userData)
        {
            var ticket = new FormsAuthenticationTicket(2, value, DateTime.Now, DateTime.Now.AddMinutes(CookieTimeout), createPersistentCookie, userData);

            return GetAuthCookie(CookieName, ticket, createPersistentCookie);
        }

        public static HttpCookie GetAuthCookie(string name, FormsAuthenticationTicket ticket, bool createPersistentCookie)
        {
            InitializeUserContext(ticket);
            
            var encryptedTicket = FormsAuthentication.Encrypt(ticket);

            if (String.IsNullOrEmpty(encryptedTicket))
            {
                throw new HttpException("Unable_to_encrypt_cookie_ticket");
            }

            var httpCookie = new HttpCookie(name, encryptedTicket)
            {
                HttpOnly = true
            };

            if (ticket.IsPersistent)
            {
                httpCookie.Expires = ticket.Expiration;
            }

            return httpCookie;
        }


        public static string GetActualCookieName()
        {
            if (HttpContext.Current.Request.Cookies[CookieName] != null)
                return CookieName;

            if (HttpContext.Current.Request.Cookies[AlternativeCookieName] != null)
                return AlternativeCookieName;

            return CookieName;
        }


        public static FormsAuthenticationTicket ExtractTicketFromCookie(string name)
        {
            var context = HttpContext.Current;
            var cookie = context.Request.Cookies[name];

            // ReSharper disable once PossibleNullReferenceException
            if (cookie.IsEmpty() || cookie.Value.IsEmpty())
                return null;

            try
            {
                return FormsAuthentication.Decrypt(cookie.Value);
            }
            // ReSharper disable once EmptyGeneralCatchClause
            catch
            {
                context.Request.Cookies.Remove(name);
                return null;
            }
        }


        public static void InitializeUserContext(FormsAuthenticationTicket ticket)
        {
            var context = HttpContext.Current;
            var loggedUser = context.SetLoggedUser(ticket.Name.ParseInt());

            if (loggedUser == null)
            {
                MakeCookieExpired(GetActualCookieName());
                RedirectToLoginPage();

                return;
            }

            //var roles = loggedUser.Roles.Select(x => x.Code).ToArray();

            //context.User = new GenericPrincipal(new FormsIdentity(ticket), roles);
        }
    }
}