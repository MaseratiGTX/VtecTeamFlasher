using System;
using System.Reflection;
using System.Web.UI;

namespace WebAppCommons.Classes.Resources.ResourceHelpers
{
    public static class AssemblyResourceLoaderExtensions
    {
        public static string GetWebResourceUrl(Type type, string resourceName)
        {
            return AssemblyResourceLoaderMethodsRepository.GetWebResourceUrl
                .Invoke(type, resourceName);
        }


        public static string GetWebResourceUrl(Assembly assembly, string resourceName)
        {
            return GetWebResourceUrl(assembly, resourceName, false, null);
        }

        public static string GetWebResourceUrl(Assembly assembly, string resourceName, bool htmlEncoded) {
            return GetWebResourceUrl(assembly, resourceName, htmlEncoded, null);
        }

        public static string GetWebResourceUrl(Assembly assembly, string resourceName, bool htmlEncoded, ScriptManager scriptManager) {
            var enableCdn = (scriptManager != null && scriptManager.EnableCdn);
            return GetWebResourceUrl(assembly, resourceName, htmlEncoded, false, scriptManager, enableCdn);
        }

        public static string GetWebResourceUrl(Assembly assembly, string resourceName, bool htmlEncoded, bool forSubstitution, ScriptManager scriptManager, bool enableCdn)
        {
            return AssemblyResourceLoaderMethodsRepository.GetWebResourceUrlInternal
                .Invoke(assembly, resourceName, htmlEncoded, forSubstitution, scriptManager, enableCdn);
        }
    }
}