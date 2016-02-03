using System.Security.Principal;

namespace WebAreaCommons.Classes.Security.Authorization.Configuration
{
    public abstract class BaseRule
    {
        public CustomAuthorizationRuleAction Action { get; set; }
        public string Value { get; set; }

        public abstract CustomAuthorizationRuleAction IsUserAllowed(IPrincipal user);
    }
}
