using System;

namespace Commons.Reflections.PropertyValues.Applying.Manager.Configuration
{
    public class EntityDescription
    {
        public Type EntityType { get; private set; }

        public string EntityDescriptor { get; private set; }

        
        public EntityDescription(Type entityType, string entityDescriptor)
        {
            EntityType = entityType;
            EntityDescriptor = entityDescriptor;
        }
    }
}