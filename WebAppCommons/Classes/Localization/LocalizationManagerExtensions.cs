using System.Reflection;
using Commons.Localization;
using WebAppCommons.Classes.Helpers;
using WebAppCommons.Classes.Resources.ResourceHelpers;

namespace WebAppCommons.Classes.Localization
{
    public static class LocalizationManagerExtensions
    {
        public static LocalizationManager AddResourceByVirtualPath(this LocalizationManager source, string resourceVirtualPath)
        {
            return source.AddResource(resourceVirtualPath.MapPath());
        }


        public static LocalizationManager AddEmbeddedResources(this LocalizationManager source, string assemblyString, string resourceNamespace, params string[] resourceNames)
        {
            if (resourceNames == null) return source;

            foreach (var resourceName in resourceNames)
            {
                source.AddEmbeddedResource(assemblyString, resourceName.TryToFix(resourceNamespace));
            }

            return source;
        }

        public static LocalizationManager AddEmbeddedResources(this LocalizationManager source, Assembly assembly, string resourceNamespace, params string[] resourceNames)
        {
            if (resourceNames == null) return source;

            foreach (var resourceName in resourceNames)
            {
                source.AddEmbeddedResource(assembly, resourceName.TryToFix(resourceNamespace));
            }

            return source;
        }
    }
}