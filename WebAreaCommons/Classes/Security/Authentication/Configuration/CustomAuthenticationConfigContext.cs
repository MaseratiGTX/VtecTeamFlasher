using System;
using System.Configuration;
using Commons.Logging;

namespace WebAreaCommons.Classes.Security.Authentication.Configuration
{
    public static class CustomAuthenticationConfigContext
    {
        public static CustomAuthenticationSection GetSection()
        {
            try
            {
                return (CustomAuthenticationSection)ConfigurationManager.GetSection("customAuthentication");
            }
            catch (Exception exception)
            {
                Log.Error(exception);

                throw new Exception("Произошла ошибка при инициализации секции мониторинга номеров документов.", exception);
            }
        }

        public static CustomFormsAuthenticationElement GetCustomFormsElement()
        {
            return GetSection().CustomFormsAuthenticationElement;
        }
    }
}