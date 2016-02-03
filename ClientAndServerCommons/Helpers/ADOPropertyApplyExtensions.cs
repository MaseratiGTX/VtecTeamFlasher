using System.Collections.Generic;
using System.Collections.Specialized;
using Commons.Reflections.PropertyValues.Applying.Manager;

namespace ClientAndServerCommons.Helpers
{
    public static class ADOPropertyApplyExtensions
    {
        public static bool Apply<T>(this T source, string propertyName, object propertyValue) where T : AbstractDataObject
        {
            return PropertyValueManager().Apply(propertyName, propertyValue).To(source);
        }

        public static bool Apply<T>(this T source, IDictionary<string, object> propertyValues) where T : AbstractDataObject
        {
            return PropertyValueManager().Apply(propertyValues).To(source);
        }

        public static bool Apply<T>(this T source, OrderedDictionary propertyValues) where T : AbstractDataObject
        {
            return PropertyValueManager().Apply(propertyValues).To(source);
        }


        private static PropertyValueManager PropertyValueManager()
        {
            return new PropertyValueManager()
                .Configure(configuration =>
                    configuration
                        .SetEntityDescriptor<AbstractDataObject>("Id")
                        .ShouldIgnorePropertyNotFound()
                        .ShouldIgnoreComplexProperties()
                        .ShouldIgnoreNullPropertyValue()
                );
        }
    }
}