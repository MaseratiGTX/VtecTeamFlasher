using System.Collections.Generic;
using System.Linq;

namespace WebAppCommons.Classes.Controls.ASPx.xComboBox.DataSources.InitialDataProviders
{
    public class SimpleDataSourceInitialDataProvider<T> : IDataSourceInitialDataProvider<T> where T : class
    {
        public List<T> SourceData { get; private set; }


        public SimpleDataSourceInitialDataProvider(params T[] sourceData)
            : this((IEnumerable<T>)sourceData)
        {
        }

        public SimpleDataSourceInitialDataProvider(IEnumerable<T> sourceData)
        {
            SourceData = sourceData.ToList();
        }


        public List<T> GetInitialData()
        {
            return SourceData;
        }
    }
}