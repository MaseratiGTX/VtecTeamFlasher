using DevExpress.Web.ASPxEditors;

namespace WebAppCommons.Classes.Controls.ASPx.xComboBox.DataSources.DataItems
{
    public class DataSourceDataItem<T> where T : class
    {
        public T Source { get; set; }
        public string FilterKey { get; set; }


        public bool Satisfies(string filterValue, IncrementalFilteringMode filteringMode)
        {
            switch (filteringMode)
            {
                case IncrementalFilteringMode.StartsWith:
                    return FilterKey.StartsWith(filterValue);
                case IncrementalFilteringMode.Contains:
                    return FilterKey.Contains(filterValue);
                default:
                    return true;
            }
        }
    }
}