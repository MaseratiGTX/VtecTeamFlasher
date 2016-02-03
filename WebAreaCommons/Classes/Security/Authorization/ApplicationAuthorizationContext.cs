using System.Security.Principal;
using System.Web;

namespace WebAreaCommons.Classes.Security.Authorization
{
    public static class ApplicationAuthorizationContext
    {
        private const string AUTHORIZATION_FAILURE_MESSAGE_KEY = "AUTHORIZATION_FAILURE_MESSAGE_KEY";

        public static AuthorizationRuleManager AuthorizationRuleManager { get; private set; }

        static ApplicationAuthorizationContext()
        {
            AuthorizationRuleManager = new AuthorizationRuleManager();
        }

        public static bool IsUserAllowed(IPrincipal user)
        {
            return AuthorizationRuleManager.IsUserAllowed(HttpContext.Current.Request.FilePath, user);
        }

        public static string AuthorizationFailureMessage
        {
            get { return HttpContext.Current.Items[AUTHORIZATION_FAILURE_MESSAGE_KEY] as string; }
            set { HttpContext.Current.Items[AUTHORIZATION_FAILURE_MESSAGE_KEY] = value; }
        }
    }
}