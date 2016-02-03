using System;
using System.Configuration;
using Commons.Helpers.Objects;
using Commons.Logging;

namespace WebAreaCommons.Classes.Providers.Configurations
{
    public class UseCSPAuthorizationProvider
    {
        // ReSharper disable InconsistentNaming
        public const bool USE_CSP_AUTHORIZATION = true;
        // ReSharper restore InconsistentNaming


        public bool GetUseCSPAuthorization()
        {
            var appSetting = ConfigurationManager.AppSettings["UseCSPAuthorization"];

            if (appSetting.NotFound())
            {
                return USE_CSP_AUTHORIZATION;
            }

            try
            {
                return bool.Parse(appSetting);
            }
            catch(Exception exception)
            {
                Log.Error(exception);
            }

            return USE_CSP_AUTHORIZATION;
        } 
    }
}