using System;
using System.Collections.Generic;
using System.Linq;

namespace Commons.Reflections.PropertyValues.Applying.Manager.Configuration
{
    public class PropertyValueManagerConfiguration
    {
        private List<EntityDescription> EntityDescriptionRepository { get; set; }

        public bool IgnoreNullSourceObjectValue { get; private set; }
        public bool IgnorePropertyNotFound { get; private set; }
        public bool IgnoreNullPropertyValue { get; private set; }
        public bool IgnoreHasNoSetter { get; private set; }
        public bool IgnoreHasNoGetter { get; private set; }
        public bool IgnoreComplexProperties { get; private set; }
        public bool IgnoreInstanceCreationFailure { get; private set; }

        public bool IgnoreAll
        {
            get
            {
                return IgnoreNullSourceObjectValue
                    || IgnorePropertyNotFound
                    || IgnoreNullPropertyValue
                    || IgnoreHasNoSetter
                    || IgnoreHasNoGetter
                    || IgnoreComplexProperties
                    || IgnoreInstanceCreationFailure;
            }
        }



        public PropertyValueManagerConfiguration()
        {
            EntityDescriptionRepository = new List<EntityDescription>();
        }



        public EntityDescription FetchEntityDescription(Type sourceType, string propertyName)
        {
            return EntityDescriptionRepository
                .Where(x => x.EntityType.IsAssignableFrom(sourceType) && x.EntityDescriptor == propertyName)
                .FirstOrDefault();
        }


        public PropertyValueManagerConfiguration SetEntityDescription(EntityDescription entityDescription)
        {
            EntityDescriptionRepository.Add(entityDescription);

            return this;
        }

        public PropertyValueManagerConfiguration SetEntityDescription(Type entityType, string entityDescriptor)
        {
            return SetEntityDescription(
                new EntityDescription(entityType, entityDescriptor)
            );
        }

        public PropertyValueManagerConfiguration SetEntityDescriptor<T>(string entityDescriptor)
        {
            return SetEntityDescription(typeof (T), entityDescriptor);
        }



        public PropertyValueManagerConfiguration ShouldIgnoreNullSourceObjectValue(bool value = true)
        {
            IgnoreNullSourceObjectValue = value;

            return this;
        }

        public PropertyValueManagerConfiguration ShouldIgnorePropertyNotFound(bool value = true)
        {
            IgnorePropertyNotFound = value;

            return this;
        }

        public PropertyValueManagerConfiguration ShouldIgnoreNullPropertyValue(bool value = true)
        {
            IgnoreNullPropertyValue = value;

            return this;
        }

        public PropertyValueManagerConfiguration ShouldIgnoreHasNoSetter(bool value = true)
        {
            IgnoreHasNoSetter = value;

            return this;
        }

        public PropertyValueManagerConfiguration ShouldIgnoreHasNoGetter(bool value = true)
        {
            IgnoreHasNoGetter = value;

            return this;
        }

        public PropertyValueManagerConfiguration ShouldIgnoreComplexProperties(bool value = true)
        {
            IgnoreComplexProperties = value;

            return this;
        }

        public PropertyValueManagerConfiguration ShouldIgnoreInstanceCreationFailure(bool value = true)
        {
            IgnoreInstanceCreationFailure = value;

            return this;
        }

        public PropertyValueManagerConfiguration ShouldIgnoreAll()
        {
            IgnoreNullSourceObjectValue = true;
            IgnorePropertyNotFound = true;
            IgnoreNullPropertyValue = true;
            IgnoreHasNoSetter = true;
            IgnoreHasNoGetter = true;
            IgnoreComplexProperties = true;
            IgnoreInstanceCreationFailure = true;

            return this;
        }
    }
}