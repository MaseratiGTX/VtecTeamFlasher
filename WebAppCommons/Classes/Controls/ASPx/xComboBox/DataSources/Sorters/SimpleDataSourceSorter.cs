using System;
using System.Collections.Generic;
using System.Linq;
using WebAppCommons.Classes.Controls.ASPx.xComboBox.DataSources.DataItems;

namespace WebAppCommons.Classes.Controls.ASPx.xComboBox.DataSources.Sorters
{
    public class SimpleDataSourceSorter<T, TKey> : IDataSourceSorter<T> where T : class
    {
        public List<Func<T, TKey>> OrderKeySelectors { get; private set; }


        public SimpleDataSourceSorter(params Func<T, TKey>[] orderKeySelectors)
        {
            OrderKeySelectors = orderKeySelectors.ToList();
        }


        public List<DataSourceDataItem<T>> OrderBase(List<DataSourceDataItem<T>> source)
        {
            if (OrderKeySelectors.Count > 0)
            {
                var baseOrderSelector = OrderKeySelectors[0];

                var result = source.OrderBy(x => baseOrderSelector.Invoke(x.Source));

                for (var index = 1; index < OrderKeySelectors.Count; index++)
                {
                    var nextOrderSelector = OrderKeySelectors[index];

                    result = result.ThenBy(x => nextOrderSelector.Invoke(x.Source));
                }

                return result.ToList();
            }

            return source;
        }

        public List<DataSourceDataItem<T>> OrderFiltered(List<DataSourceDataItem<T>> source)
        {
            return OrderBase(source);
        }
    }
}