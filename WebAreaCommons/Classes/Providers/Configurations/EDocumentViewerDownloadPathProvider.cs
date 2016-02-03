using System.Configuration;
using System.Web;
using Commons.Helpers.Objects;

namespace WebAreaCommons.Classes.Providers.Configurations
{
    public class EDocumentViewerDownloadPathProvider
    {
        private const string DEFAULT_VALUE = "${basedir}\\App_Data\\Downloads\\EDocumentViewer.zip";

        
        public string GetValue()
        {
            var appSetting = ConfigurationManager.AppSettings["EDocumentViewer.DownloadPath"];

            var result = appSetting.NotFound() ? DEFAULT_VALUE : appSetting;

            return result.Replace("${basedir}", HttpContext.Current.Request.PhysicalApplicationPath);
        }
    }
}