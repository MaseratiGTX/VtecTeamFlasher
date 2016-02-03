using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Commons.Helpers.Objects;

namespace Commons.Reflections.Assemblies
{
    public static class AssemblyAttributesExtensions
    {
        public static string Value(this AssemblyFileVersionAttribute source)
        {
            return source.IsNotNull() ? source.Version : null;
        }

        public static string Value(this AssemblyDescriptionAttribute source)
        {
            return source.IsNotNull() ? source.Description : null;
        }


        public static Dictionary<string, string> Parse(this AssemblyDescriptionAttribute source)
        {
            return source.Parse(
                new[] { '\r', '\n', ',', ';', '|' }, 
                new[] { ':' }
            );
        }

        public static Dictionary<string, string> Parse(this AssemblyDescriptionAttribute source, char[] partDelimeters, char[] itemDelimeters)
        {
            var sourceValue = source.Value();

            if(sourceValue.IsEmpty()) return new Dictionary<string, string>();

            return sourceValue.Split(partDelimeters, StringSplitOptions.RemoveEmptyEntries)
                .Select(
                    part => part.Trim()
                )
                .Select(
                    part => part.Split(itemDelimeters, StringSplitOptions.RemoveEmptyEntries)
                )
                .Where(
                    partItems => partItems.Length == 2
                )
                .ToDictionary(
                    partItems => partItems[0].Trim(),
                    partItems => partItems[1].Trim()
                );
        }
    }
}