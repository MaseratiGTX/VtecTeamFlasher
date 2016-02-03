using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Commons.Helpers.Collections.Generic;
using Commons.Helpers.Objects;

namespace Commons.Reflections.Assemblies
{
    public static class AssemblyHelper
    {
        public static Assembly LoadSafely(string assemblyString)
        {
            if (assemblyString.IsEmpty()) return null;

            try
            {
                return Assembly.Load(assemblyString);    
            }
            catch(Exception)
            {
                return null;
            }
        }


        public static IEnumerable<T> GetAttributes<T>(this Assembly source) where T : Attribute
        {
            return Attribute.GetCustomAttributes(source, typeof(T)).Cast<T>();
        }

        public static T GetAttribute<T>(this Assembly source) where T : Attribute
        {
            return source.GetAttributes<T>().FirstOrDefault();
        }



        public static Version Version(this Assembly source)
        {
            return source != null ? source.GetName().Version : null;
        }

        public static string VersionString(this Assembly source)
        {
            var version = source.Version();

            return version != null ? version.ToString() : null;
        }


        public static AssemblyVersionDescription FetchVersionDescription(this Assembly source)
        {
            var assemblyFileVersionAttribute = source.GetAttribute<AssemblyFileVersionAttribute>();
            var assemblyDescriptionAttribute = source.GetAttribute<AssemblyDescriptionAttribute>();

            var assemblyDescriptions = assemblyDescriptionAttribute.Parse();
                
            return new AssemblyVersionDescription
            {
                Version = assemblyFileVersionAttribute.Value() ?? source.VersionString(),
                Revision = assemblyDescriptions.ValueOrDefault("Revision"),
                Build = assemblyDescriptions.ValueOrDefault("Build"),
            };
        }
    }
}