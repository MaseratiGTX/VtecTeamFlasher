using System.Collections.Generic;
using System.Linq;
using Commons.Helpers.CommonObjects;
using Commons.Reflections.PropertyManagers;

namespace WebAppCommons.Classes.Controls.ASPx.xComboBox.DataSources.FilterKeyProviders
{
    public class SmartFilterKeyProvider<T> : IFilterKeyProvider<T> where T : class
    {
        private PropertyManager<T> PropertyManager { get; set; }

        public string FilterKeyFormatString { get; private set; }
        public string[] PropertyNames { get; private set; }


        public SmartFilterKeyProvider(string filterKeyFormatString, params string[] propertyNames)
            : this(filterKeyFormatString, (IEnumerable<string>)propertyNames)
        {
        }

        public SmartFilterKeyProvider(string filterKeyFormatString, IEnumerable<string> propertyNames)
        {
            FilterKeyFormatString = filterKeyFormatString;
            PropertyNames = propertyNames.ToArray();

            PropertyManager = new PropertyManager<T>();
        }


        public string ProvideKeyFor(T source)
        {
            var formatArgs = PropertyNames.Select(x => x.Contains(".") == false ? PropertyManager.Get(x).In(source) : null).ToArray();

            return FilterKeyFormatString.FillWith(formatArgs);
        }
    }
}