using System;
using System.Collections.Generic;
using Commons.Helpers.Objects;
using Commons.Reflections.AttachedProperty;
using Commons.Reflections.PropertyValues.Applying.Manager.Configuration;
using Commons.Reflections.PropertyValues.Helpers;

namespace Commons.Reflections.PropertyValues.Applying.Manager.Applier
{
    public sealed class PropertyValueApplier
    {
        private PropertyValueManager PropertyValueManager { get; set; }

        private IDictionary<string, object> PropertyValues { get; set; }

        private bool IgnoreNullSourceObjectValue { get { return PropertyValueManager.IgnoreNullSourceObjectValue; } }
        private bool IgnorePropertyNotFound { get { return PropertyValueManager.IgnorePropertyNotFound; } }
        private bool IgnoreNullPropertyValue { get { return PropertyValueManager.IgnoreNullPropertyValue; } }
        private bool IgnoreHasNoSetter { get { return PropertyValueManager.IgnoreHasNoSetter; } }
        private bool IgnoreHasNoGetter { get { return PropertyValueManager.IgnoreHasNoGetter; } }
        private bool IgnoreComplexProperties { get { return PropertyValueManager.IgnoreComplexProperties; } }
        private bool IgnoreInstanceCreationFailure { get { return PropertyValueManager.IgnoreInstanceCreationFailure; } }



        internal PropertyValueApplier(PropertyValueManager propertyValueManager, IDictionary<string, object> propertyValues)
        {
            PropertyValueManager = propertyValueManager;
            PropertyValues = propertyValues;
        }



        public bool To<T>(T sourceObject) where T : class
        {
            if (sourceObject == null)
            {
                ASSERTION_FAILED(IgnoreNullSourceObjectValue, "PropertyValueApplier.To<T>(T sourceObject): sourceObject имеет значение NULL.");
                return false;
            }


            var result = false;

            foreach (var propertyNameValuePair in PropertyValues)
            {
                var propertyName = propertyNameValuePair.Key;
                var propertyValue = propertyNameValuePair.Value;

                result |= ApplyInternal(sourceObject, propertyName, propertyValue);
            }

            return result;
        }


        private bool ApplyInternal(object sourceObject, string destinationPropertyName, object destinationPropertyValue)
        {
            var propertyNameParts = destinationPropertyName.SplitApart();


            var currentPropertyName = propertyNameParts.BasePart;

            var currentProperty = sourceObject.Property(currentPropertyName);
            
            if (currentProperty.NotFound())
            {
                ASSERTION_FAILED(IgnorePropertyNotFound, "PropertyValueApplier: не можем найти публичное свойство '{0}'.", currentPropertyName);
                return false;
            }


            if (propertyNameParts.OtherPart == null)
            {
                // ReSharper disable ConvertClosureToMethodGroup
                return ApplyPropertyValue(currentProperty, destinationPropertyValue, 
                    (x, y) => SHOULD_APPLY_NEW_COMMON_VALUE(x, y)
                );
                // ReSharper restore ConvertClosureToMethodGroup
            }
            

            var entityDescription = FetchEntityDescription(currentProperty.Type, propertyNameParts.OtherPart);

            if (entityDescription.Found())
            {
                var entityDescriptor = entityDescription.EntityDescriptor;

                if (destinationPropertyValue != null)
                {
                    var entityInstance = CreateEntityInstance(currentProperty.Type, entityDescriptor, destinationPropertyValue);

                    if (entityInstance == null)
                    {
                        ASSERTION_FAILED(IgnoreInstanceCreationFailure, "PropertyValueApplier: не смогли создать необходимую инстанцию значения для поля '{0}'.", currentPropertyName);
                        return false;
                    }

                    destinationPropertyValue = entityInstance;
                }

                return ApplyPropertyValue(currentProperty, destinationPropertyValue, 
                    (x, y) => SHOULD_APPLY_NEW_ENTITY_VALUE(x, y, entityDescriptor)
                );
            }


            ASSERTION_FAILED(IgnoreComplexProperties, "PropertyValueApplier: не поддерживаем работу со \"сложными\" полями.");


            if (currentProperty.Getter.NotFound())
            {
                ASSERTION_FAILED(IgnoreHasNoGetter, "PropertyValueApplier: у свойства '{0}' отсутсвует публичный метод get.", currentPropertyName);
                return false;
            }
            
            var currentPropertyValue = currentProperty.Value();

            if (currentPropertyValue == null)
            {
                ASSERTION_FAILED(IgnoreNullPropertyValue, "PropertyValueApplier: свойство '{0}' имеет значение NULL.", currentPropertyName);
                return false;
            } 

            return ApplyInternal(currentPropertyValue, propertyNameParts.OtherPart, destinationPropertyValue);
        }


        private bool ApplyPropertyValue(AttachedPropertyInfo<object> currentProperty, object propertyValue, Func<AttachedPropertyInfo<object>, object, bool> SHOULD_APPLY_NEW_VALUE)
        {
            if (currentProperty.Setter.NotFound())
            {
                ASSERTION_FAILED(IgnoreHasNoSetter, "PropertyValueApplier: у свойства '{0}' отсутсвует публичный метод set.", currentProperty.Name);
                return false;
            }


            if (SHOULD_APPLY_NEW_VALUE(currentProperty, propertyValue))
            {
                currentProperty.Set(propertyValue);

                return true;
            }

            return false;
        }


        private bool SHOULD_APPLY_NEW_COMMON_VALUE(AttachedPropertyInfo<object> currentProperty, object propertyValue)
        {
            return SHOULD_APPLY_NEW_VALUE(currentProperty, propertyValue, Equals);
        }

        private bool SHOULD_APPLY_NEW_ENTITY_VALUE(AttachedPropertyInfo<object> currentProperty, object propertyValue, string entityDescriptor)
        {
            return SHOULD_APPLY_NEW_VALUE(currentProperty, propertyValue, 
                (x, y) =>
                {
                    return Equals(
                        GetObjectValue(x, entityDescriptor),
                        GetObjectValue(y, entityDescriptor)
                    );
                }
            );
        }

        private bool SHOULD_APPLY_NEW_VALUE(AttachedPropertyInfo<object> currentProperty, object propertyValue, Func<object, object, bool> IS_EQUALS)
        {
            if (currentProperty.Getter.NotFound())
            {
                ASSERTION_FAILED(IgnoreHasNoGetter, "PropertyValueApplier: у свойства '{0}' отсутсвует публичный метод get.", currentProperty.Name);

                return true;
            }

            return IS_EQUALS(currentProperty.Value(), propertyValue) == false;
        }


        private static object GetObjectValue(object sourceObject, string propertyName)
        {
            return sourceObject != null ? sourceObject.GetValue(propertyName) : null;
        }



        private EntityDescription FetchEntityDescription(Type sourceType, string propertyName)
        {
            return PropertyValueManager.FetchEntityDescription(sourceType, propertyName);
        }

        private object CreateEntityInstance(Type entityType, string entityDescriptor, object descriptorValue)
        {
            try
            {
                return entityType.CreateInstance().SetValue(entityDescriptor, descriptorValue);
            }
            // ReSharper disable once UnusedVariable
            catch (Exception ex)
            {
                return null;
            }
        }


        private void ASSERTION_FAILED(bool shouldIgnore, string message, params object[] parameters) //TODO: расписать сообщения
        {
            if (shouldIgnore) return;

            throw new Exception(string.Format(message, parameters));
        }
    }
}