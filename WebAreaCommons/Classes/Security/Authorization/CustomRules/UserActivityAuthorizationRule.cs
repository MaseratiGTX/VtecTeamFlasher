using System.Web;
using Commons.Validation.Assertions;
using WebAreaCommons.Classes.Helpers;

namespace WebAreaCommons.Classes.Security.Authorization.CustomRules
{
    public class UserActivityAuthorizationRule : BaseCustomRule
    {
        protected override void Validate()
        {
            var loggedUser = HttpContext.Current.GetLoggedUser();
            
            AssertionHelper
                .AssertTrue(loggedUser.Enabled)
                .Return("Пользователь с указанным логином не активен.");
        }
    }
}