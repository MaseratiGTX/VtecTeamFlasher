using System.Configuration;
using Commons.Helpers.Objects;

namespace WebAreaCommons.Classes.Providers.Configurations
{
    public class PermissibleWorkSessionOrDaysRangeProvider
    {
        // ReSharper disable once InconsistentNaming
        private const int DEFAULT_VALUE = 3;

        public int GetValue()
        {
            var appSetting = ConfigurationManager.AppSettings["PermissibleWorkSessionOrDaysRange"];

            return appSetting.SafelyParseInt() ?? DEFAULT_VALUE;
        }
    }
}