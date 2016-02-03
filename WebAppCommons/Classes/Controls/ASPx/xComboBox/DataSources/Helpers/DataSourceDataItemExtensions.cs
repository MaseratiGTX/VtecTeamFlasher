using System.Collections.Generic;
using System.Linq;
using WebAppCommons.Classes.Controls.ASPx.xComboBox.DataSources.DataItems;

namespace WebAppCommons.Classes.Controls.ASPx.xComboBox.DataSources.Helpers
{
    public static class DataSourceDataItemExtensions
    {
        public static IEnumerable<T> ToSource<T>(this IEnumerable<DataSourceDataItem<T>> source) where T : class
        {
            return source.Select(x => x.Source);
        }
    }
}