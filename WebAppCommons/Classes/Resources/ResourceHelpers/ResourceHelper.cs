using System;
using System.Web;
using System.Web.UI;

namespace WebAppCommons.Classes.Resources.ResourceHelpers
{
    public static class ResourceHelper
    {
        public static string GetWebResourceUrl<T>(string resourceName)
        {
            return GetWebResourceUrl(typeof (T), resourceName);
        }

        public static string GetWebResourceUrl(Type type, string resourceName)
        {
            var pageContext = HttpContext.Current.CurrentHandler as Page;

            if (pageContext != null)
            {
                return pageContext.ClientScript.GetWebResourceUrl(type, resourceName);
            }

            return AssemblyResourceLoaderExtensions.GetWebResourceUrl(type, resourceName);
        }
    }
}