using System.Collections.Generic;
using System.Linq;
using Commons.Reflections.AttachedProperty;
using Commons.Reflections.PropertyValues.Helpers;

namespace Commons.Reflections.PropertyValues.Fetching
{
    public static class PropertyFetchExtensions
    {
        public static object FetchPropertyValue<T>(this T source, string propertyName)
        {
            return FetchPropertyValueInternal(source, propertyName);
        }

        public static Dictionary<string, object> FetchPropertyValues<T>(this T source, params string[] propertyNames)
        {
            return source.FetchPropertyValues((IEnumerable<string>)propertyNames);
        }

        public static Dictionary<string, object> FetchPropertyValues<T>(this T source, IEnumerable<string> propertyNames)
        {
            return propertyNames.Distinct().ToDictionary(
                propertyName => propertyName, 
                propertyName => source.FetchPropertyValue(propertyName)
            );
        }


        private static object FetchPropertyValueInternal(object source, string propertyName)
        {
            if (source == null) return null;

            var propertyNameParts = propertyName.SplitApart();

            var result = source.Property(propertyNameParts.BasePart).Value();

            if (propertyNameParts.OtherPart != null)
            {
                result = FetchPropertyValueInternal(result, propertyNameParts.OtherPart);
            }

            return result;
        }
    }
}