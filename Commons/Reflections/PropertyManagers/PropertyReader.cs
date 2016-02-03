using System;

namespace Commons.Reflections.PropertyManagers
{
    public class PropertyReader<T>
    {
        private Func<T, object> PropertyGetter { get; set; }


        public PropertyReader(Func<T, object> propertyGetter)
        {
            PropertyGetter = propertyGetter;
        }


        public object In(T source)
        {
            return PropertyGetter.Invoke(source);
        }

        public Func<T, object> Delegate()
        {
            return PropertyGetter;
        }
    }
}