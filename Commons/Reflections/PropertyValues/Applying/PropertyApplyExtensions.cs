using System.Collections.Generic;
using System.Collections.Specialized;
using Commons.Reflections.PropertyValues.Applying.Manager;

namespace Commons.Reflections.PropertyValues.Applying
{
    public static class PropertyApplyExtensions
    {
        public static bool ApplyPropertyValue<T>(this T source, string propertyName, object propertyValue) where T : class
        {
            return PropertyValueManager().Apply(propertyName, propertyValue).To(source);
        }

        public static bool ApplyPropertyValues<T>(this T source, Dictionary<string, object> propertyValues) where T : class
        {
            return PropertyValueManager().Apply(propertyValues).To(source);
        }

        public static bool ApplyPropertyValues<T>(this T source, OrderedDictionary propertyValues) where T : class
        {
            return PropertyValueManager().Apply(propertyValues).To(source);
        }


        private static PropertyValueManager PropertyValueManager()
        {
            return new PropertyValueManager()
                .Configure(configuration =>
                    configuration
                        .ShouldIgnoreComplexProperties()
                );
        }
    }
}