using System;
using System.Collections;
using System.Linq;
using System.Reflection;

namespace Commons.Reflections
{
    public static class TypeExtensions
    {
        public static string Name(this Type source)
        {
            return source != null ? source.Name : null;
        }


        public static bool Is<T>(this Type source)
        {
            return source.IsAssignableTo<T>();
        }

        public static bool IsEnumeration(this Type source)
        {
            if (source == typeof (string)) return false;

            return source.Is<IEnumerable>();
        }


        public static bool IsAssignableTo<T>(this Type source)
        {
            return source.IsAssignableTo(typeof (T));
        }

        public static bool IsAssignableTo(this Type source, Type anotherType)
        {
            return anotherType.IsAssignableFrom(source);
        }


        public static bool Implements<T>(this Type source)
        {
            return source.Implements(typeof(T));
        }

        public static bool Implements(this Type source, Type interfaceType)
        {
            return source == interfaceType || source.GetInterfaces().Any(x => x == interfaceType);
        }


        public static PropertyInfo GetPropertySmart(this Type source, string propertyName, string separator = ".")
        {
            var separatorIndex = propertyName.IndexOf(separator, StringComparison.Ordinal);

            if (separatorIndex != -1)
            {
                var masterPropertyName = propertyName.Substring(0, separatorIndex);
                var masterProperty = source.GetProperty(masterPropertyName);
                var masterPropertyType = masterProperty.PropertyType;

                var slavePropertyName = propertyName.Substring(separatorIndex + 1);

                return masterPropertyType.GetPropertySmart(slavePropertyName);
            }

            return source.GetProperty(propertyName);
        }

        public static Type GetPropertyType(this Type source, string propertyName)
        {
            return source.GetPropertySmart(propertyName).PropertyType;
        }


        public static object CreateInstance(this Type source, params object[] args)
        {
            return Activator.CreateInstance(source, args);
        }

        public static T CreateInstance<T>(this Type source, params object[] args)
        {
            return (T) Activator.CreateInstance(source, args);
        }
    }
}