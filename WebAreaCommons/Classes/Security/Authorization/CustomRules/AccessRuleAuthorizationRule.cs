using System.Web;
using WebAreaCommons.Classes.Helpers;

namespace WebAreaCommons.Classes.Security.Authorization.CustomRules
{
    public class AccessRuleAuthorizationRule : BaseCustomRule
    {
        protected override void Validate()
        {
            var loggedUser = HttpContext.Current.GetLoggedUser();
            //var accessRuleTemplate = loggedUser.AccessRuleTemplate;
            //var dateTimeNow = DateTime.Now;
            //var hasError = true;

            //AssertionHelper
            //    .AssertTrue(accessRuleTemplate.Enabled)
            //    .Return("График работ текущего пользователя не активен.");

            //var rules = accessRuleTemplate.Rules.Enabled()
            //                              .ToList();

            //var temporaryRules = rules.OfType<TemporaryAccessRule>()
            //                          .ThatHas(x => x.ValidityDate.Date == dateTimeNow.Date);

            //var permanentRules = rules.OfType<PermanentAccessRule>()
            //                          .ThatHas(x => x.DayOfWeek == dateTimeNow.DayOfWeek);


            //if (temporaryRules.IsNotEmpty())
            //{
            //    hasError = temporaryRules.Any(x => x.PeriodStart <= dateTimeNow.TimeOfDay && x.PeriodEnd >= dateTimeNow.TimeOfDay) == false;
            //}
            //else if (permanentRules.IsNotEmpty())
            //{
            //    hasError = permanentRules.Any(x => x.PeriodStart <= dateTimeNow.TimeOfDay && x.PeriodEnd >= dateTimeNow.TimeOfDay) == false;
            //}

            //AssertionHelper
            //    .AssertFalse(hasError)
            //    .Return("График работ текущего пользователя не подразумевает использование приложения в данное время суток");
        }
    }
}