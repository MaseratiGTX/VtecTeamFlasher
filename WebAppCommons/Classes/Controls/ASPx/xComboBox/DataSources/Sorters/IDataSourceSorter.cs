using System.Collections.Generic;
using WebAppCommons.Classes.Controls.ASPx.xComboBox.DataSources.DataItems;

namespace WebAppCommons.Classes.Controls.ASPx.xComboBox.DataSources.Sorters
{
    public interface IDataSourceSorter<T> where T : class
    {
        List<DataSourceDataItem<T>> OrderBase(List<DataSourceDataItem<T>> source);
        List<DataSourceDataItem<T>> OrderFiltered(List<DataSourceDataItem<T>> source);
    }
}