using System;
using System.Configuration;
using System.IO;
using System.Web;
using Commons.Helpers.Objects;
using Commons.Logging;

namespace WebAreaCommons.Classes.Providers.Configurations
{
    public class ReportTemplateProvider
    {
        private const string DEFAULT_VALUE = @"${basedir}\App_Data\Reports\ReportTemplates\";


        public string GetValue()
        {
            try
            {
                var value = ConfigurationManager.AppSettings["ReportTemplatesDirectory"];
                var physicalApplicationPath = HttpContext.Current.Request.PhysicalApplicationPath;


                if (value.Found())
                {
                    value = value.Replace("${basedir}", physicalApplicationPath);

                    if (Directory.Exists(value))
                    {
                        return value;
                    }
                }

                return DEFAULT_VALUE.Replace("${basedir}", physicalApplicationPath);
            }
            catch (Exception exception)
            {
                Log.Error(exception);

                throw new Exception("Произошла системная ошибка. Обратитесь к администратору.", exception);
            }
        }
    }
}