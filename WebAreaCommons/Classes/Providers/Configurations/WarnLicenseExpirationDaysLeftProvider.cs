using System.Configuration;
using Commons.Helpers.Objects;

namespace WebAreaCommons.Classes.Providers.Configurations
{
    public class WarnLicenseExpirationDaysLeftProvider
    {
        // ReSharper disable once InconsistentNaming
        private const int DEFAULT_VALUE = 30;


        public int GetValue()
        {
            var value = ConfigurationManager.AppSettings["WarnLicenseExpirationDaysLeft"];
            
            return value.SafelyParseInt() ?? DEFAULT_VALUE;
        }
    }
}