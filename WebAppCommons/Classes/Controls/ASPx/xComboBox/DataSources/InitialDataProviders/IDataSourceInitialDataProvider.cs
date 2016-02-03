using System.Collections.Generic;

namespace WebAppCommons.Classes.Controls.ASPx.xComboBox.DataSources.InitialDataProviders
{
    public interface IDataSourceInitialDataProvider<T> where T : class
    {
        List<T> GetInitialData();
    }
}