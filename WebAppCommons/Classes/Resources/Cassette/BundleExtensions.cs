using System.Linq;
using System.Reflection;
using Cassette;
using Commons.Helpers.Collections.Generic;
using WebAppCommons.Classes.Resources.ResourceHelpers;

namespace WebAppCommons.Classes.Resources.Cassette
{
    public static class BundleExtensions
    {
        public static T AddEmbeddedResources<T>(this T source, string assemblyString, string resourceNamespace, params string[] resourceNames) where T : Bundle
        {
            return source.AddEmbeddedResources(
                ResourcePriority.Default, 
                assemblyString, 
                resourceNamespace, 
                resourceNames
            );
        }

        public static T AddEmbeddedResources<T>(this T source, ResourcePriority resourcePriority, string assemblyString, string resourceNamespace, params string[] resourceNames) where T : Bundle
        {
            return source.AddEmbeddedResources(
                resourcePriority,
                Assembly.Load(assemblyString),
                resourceNamespace,
                resourceNames
            );
        }

        public static T AddEmbeddedResources<T>(this T source, Assembly assembly, string resourceNamespace, params string[] resourceNames) where T : Bundle
        {
            return source.AddEmbeddedResources(
                ResourcePriority.Default, 
                assembly, 
                resourceNamespace, 
                resourceNames
            );
        }

        public static T AddEmbeddedResources<T>(this T source, ResourcePriority resourcePriority, Assembly assembly, string resourceNamespace, params string[] resourceNames) where T : Bundle
        {
            if(resourceNames == null) return source;


            var resourceAssets = resourceNames.Select(x => new ResourceAsset(x.TryToFix(resourceNamespace), assembly));

            if(resourcePriority == ResourcePriority.High)
            {
                resourceAssets.Reverse().Each(x => source.Assets.Insert(0, x));
            }
            else
            {
                resourceAssets.Each(x => source.Assets.Add(x));
            }
            

            return source;
        }
    }
}