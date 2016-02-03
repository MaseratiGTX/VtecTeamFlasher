using System.Configuration;
using Commons.Logging;

namespace ClientAndServerCommons
{
    public static class ConfigurationHelper
    {
        public static string GetConfig(string key, string defaultValue)
        {
            Log.Debug(string.Format("Try get value {0} from app config", key));
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            KeyValueConfigurationElement keyElement = configuration.AppSettings.Settings[key];
            return (keyElement != null ? keyElement.Value : defaultValue);
        }

    }
}
