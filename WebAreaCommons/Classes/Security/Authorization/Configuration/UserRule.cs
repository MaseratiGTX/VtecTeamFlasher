using System.Security.Principal;

namespace WebAreaCommons.Classes.Security.Authorization.Configuration
{
    public class UserRule : BaseRule
    {
        public bool Everyone
        {
            get { return Value.Equals("*"); }
        }
        
        public bool Annonymous
        {
            get { return Value.Equals("?"); }
        }

        public override CustomAuthorizationRuleAction IsUserAllowed(IPrincipal user)
        {
            if (Annonymous && (user == null || user.Identity.IsAuthenticated == false))
                return Action;

            return Everyone ? Action : CustomAuthorizationRuleAction.NotExisted;
        }
    }
}
