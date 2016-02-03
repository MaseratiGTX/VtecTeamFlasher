using System;
using System.Collections.Generic;

namespace Commons.Reflections.PropertyManagers
{
    public class PropertyManager<T> where T : class
    {
        private Dictionary<string, Func<T, object>> DelegatesCache { get; set; }



        public PropertyManager(params string[] propertyNames)
        {
            DelegatesCache = new Dictionary<string, Func<T, object>>();

            foreach (var propertyName in propertyNames)
            {
                Initialize(propertyName);
            }
        }



        public PropertyManager<T> Initialize(params string[] propertyNames)
        {
            return Initialize((IEnumerable<string>)propertyNames);
        }

        public PropertyManager<T> Initialize(IEnumerable<string> propertyNames)
        {
            foreach (var propertyName in propertyNames)
            {
                Initialize(propertyName);
            }

            return this;
        }

        public PropertyManager<T> Initialize(string propertyName)
        {
            if (DelegatesCache.ContainsKey(propertyName) == false)
            {
                var propertyInfo = typeof(T).GetProperty(propertyName);

                var propertyGetterMethod = propertyInfo.GetGetMethod();

                var propertyGetter = propertyGetterMethod.MakeDelegate<T>();


                DelegatesCache.Add(propertyName, propertyGetter);
            }

            return this;
        }


        public PropertyReader<T> Get(string propertyName)
        {
            Initialize(propertyName);

            var propertyDelegate = DelegatesCache[propertyName];

            return new PropertyReader<T>(propertyDelegate);
        }
    }
}