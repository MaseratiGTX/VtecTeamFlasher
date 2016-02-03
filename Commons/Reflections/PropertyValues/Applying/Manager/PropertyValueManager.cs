using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Commons.Reflections.PropertyValues.Applying.Manager.Applier;
using Commons.Reflections.PropertyValues.Applying.Manager.Configuration;

namespace Commons.Reflections.PropertyValues.Applying.Manager
{
    public sealed class PropertyValueManager 
    {
        public PropertyValueManagerConfiguration Configuration { get; set; }

        internal bool IgnoreNullSourceObjectValue { get { return Configuration.IgnoreNullSourceObjectValue; } }
        internal bool IgnorePropertyNotFound { get { return Configuration.IgnorePropertyNotFound; } }
        internal bool IgnoreNullPropertyValue { get { return Configuration.IgnoreNullPropertyValue; } }
        internal bool IgnoreHasNoSetter { get { return Configuration.IgnoreHasNoSetter; } }
        internal bool IgnoreHasNoGetter { get { return Configuration.IgnoreHasNoGetter; } }
        internal bool IgnoreComplexProperties { get { return Configuration.IgnoreComplexProperties; } }
        internal bool IgnoreInstanceCreationFailure { get { return Configuration.IgnoreInstanceCreationFailure; } }



        public PropertyValueManager()
        {
            Configuration = new PropertyValueManagerConfiguration();
        }

        public PropertyValueManager(PropertyValueManagerConfiguration configuration)
        {
            Configuration = configuration;
        }



        public PropertyValueManager Configure(Action<PropertyValueManagerConfiguration> configurationAction)
        {
            if (configurationAction == null) return this;

            configurationAction.Invoke(Configuration);

            return this;
        }



        internal EntityDescription FetchEntityDescription(Type sourceType, string propertyName)
        {
            return Configuration.FetchEntityDescription(sourceType, propertyName);
        }



        public PropertyValueApplier Apply(string propertyName, object propertyValue)
        {
            return Apply(
                new Dictionary<string, object>
                {
                    { propertyName, propertyValue }
                }
            );
        }

        public PropertyValueApplier Apply(IDictionary<string, object> propertyValues)
        {
            return new PropertyValueApplier(this, propertyValues);
        }

        public PropertyValueApplier Apply(OrderedDictionary propertyValues)
        {
            return Apply(
                propertyValues.Cast<DictionaryEntry>()
                    .ToDictionary(
                        x => (string)x.Key,
                        x => x.Value
                    )
            );
        }
    }
}