using System.Security.Principal;

namespace WebAreaCommons.Classes.Security.Authorization.Configuration
{
    public class RoleRule : BaseRule
    {
        public override CustomAuthorizationRuleAction IsUserAllowed(IPrincipal user)
        {
            if (user != null && user.Identity.IsAuthenticated && user.IsInRole(Value)) 
                return Action;
            
            return CustomAuthorizationRuleAction.NotExisted;
        }
    }
}
