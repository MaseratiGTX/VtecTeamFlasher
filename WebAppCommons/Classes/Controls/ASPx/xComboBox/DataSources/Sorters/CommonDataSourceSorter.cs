using System.Collections.Generic;
using System.Linq;
using WebAppCommons.Classes.Controls.ASPx.xComboBox.DataSources.DataItems;

namespace WebAppCommons.Classes.Controls.ASPx.xComboBox.DataSources.Sorters
{
    public class CommonDataSourceSorter<T> : IDataSourceSorter<T> where T : class
    {
        public List<DataSourceDataItem<T>> OrderBase(List<DataSourceDataItem<T>> source)
        {
            return source.OrderBy(x => x.FilterKey).ToList();
        }

        public List<DataSourceDataItem<T>> OrderFiltered(List<DataSourceDataItem<T>> source)
        {
            return OrderBase(source);
        }
    }
}