using ClientAndServerCommons.DataClasses;
using WebAreaCommons.Classes.Security.Authorization;
using WebAreaCommons.Classes.Security.Authorization.Configuration;
using WebAreaCommons.Classes.Security.Authorization.CustomRules;

namespace VtecTeamFlasherWeb
{
    public class ApplicationAuthorizationConfiguration
    {
        public static void Configure(AuthorizationRuleManager manager)
        {
            manager.SetAuthorizationFailedUrl("~/AuthorizationFailed");

            manager.RootDirectory
                   .AddRule<UserRule>("?", CustomAuthorizationRuleAction.Deny)
                   .AddCustomRule<AccessRuleAuthorizationRule>()
                   .AddCustomRule<UserActivityAuthorizationRule>();

            manager.Register("favicon.ico")
                   .AddRule<UserRule>("?", CustomAuthorizationRuleAction.Allow)
                   .AddRule<UserRule>("*", CustomAuthorizationRuleAction.Allow);

            manager.Register("Java")
                   .AddRule<UserRule>("?", CustomAuthorizationRuleAction.Allow)
                   .AddRule<UserRule>("*", CustomAuthorizationRuleAction.Allow);

            manager.Register("AuthorizationFailed")
                   .AddRule<UserRule>("?", CustomAuthorizationRuleAction.Allow)
                   .AddRule<UserRule>("*", CustomAuthorizationRuleAction.Allow);

            manager.Register("VtecTeamWebService")
                   .AddRule<UserRule>("?", CustomAuthorizationRuleAction.Allow)
                   .AddRule<UserRule>("*", CustomAuthorizationRuleAction.Allow);

            manager.Register("License")
                    //.AddRule<RoleRule>(UserRole.AdminAreaAdmin.Code, CustomAuthorizationRuleAction.Allow)
                    .AddRule<UserRule>("*", CustomAuthorizationRuleAction.Deny)
                    .AddCustomRule<AccessRuleAuthorizationRule>()
                    .AddCustomRule<UserActivityAuthorizationRule>();
        }
    }
}