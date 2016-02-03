using System;

namespace WebAppCommons.Classes.Controls.ASPx.xComboBox.DataSources.FilterKeyProviders
{
    public class SimpleFilterKeyProvider<T> : IFilterKeyProvider<T> where T : class
    {
        public Func<T, string> FilterKeyFunction { get; private set; }


        public SimpleFilterKeyProvider(Func<T, string> filterKeyFunction)
        {
            FilterKeyFunction = filterKeyFunction;
        }


        public string ProvideKeyFor(T source)
        {
            return FilterKeyFunction.Invoke(source);
        }
    }
}