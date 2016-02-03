using System;
using System.Web.Configuration;
using Commons.Logging;

namespace WebAreaCommons.Classes.Providers.Configurations
{
    public class SessionStateConfigurationProvider
    {
        public SessionStateSection GetSection()
        {
            try
            {
                return (SessionStateSection) WebConfigurationManager.GetSection("system.web/sessionState");
            }
            catch (Exception exception)
            {
                Log.Error(exception);

                throw new Exception("Произошла ошибка при инициализации контекста секции sessionState.", exception);
            }
        }

        public TimeSpan Timeout()
        {
            return GetSection().Timeout;
        }
    }
}