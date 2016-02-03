using System;
using System.Reflection;

namespace Commons.Reflections.AttachedProperty
{
    public class AttachedPropertyInfo<T>
    {
        private AttachedPropertySetter<T> SetterInternal { get; set; }
        private AttachedPropertyGetter<T> GetterInternal { get; set; }


        public T SourceObject { get; private set; }

        public PropertyInfo PropertyInfo { get; private set; }

        public Type Type
        {
            get { return PropertyInfo.PropertyType; }
        }

        public string Name
        {
            get { return PropertyInfo.Name; }
        }

        public AttachedPropertySetter<T> Setter
        {
            get { return SetterInternal ?? (SetterInternal = ConstructSetterObject()); }
        }

        public AttachedPropertyGetter<T> Getter
        {
            get { return GetterInternal ?? (GetterInternal = ConstructGetterObject()); }
        }



        public AttachedPropertyInfo(T sourceObject, PropertyInfo propertyInfo)
        {
            SourceObject = sourceObject;
            PropertyInfo = propertyInfo;
        }



        public void Set(object value)
        {
            Setter.Invoke(value);
        }

        public object Value()
        {
            return Getter.Invoke();
        }


        private AttachedPropertySetter<T> ConstructSetterObject()
        {
            var methodInfo = PropertyInfo.GetSetMethod();

            if (methodInfo == null) return null;

            return new AttachedPropertySetter<T>(SourceObject, methodInfo);
        }

        private AttachedPropertyGetter<T> ConstructGetterObject()
        {
            var methodInfo = PropertyInfo.GetGetMethod();

            if (methodInfo == null) return null;
            
            return new AttachedPropertyGetter<T>(SourceObject, methodInfo);
        }
    }
}