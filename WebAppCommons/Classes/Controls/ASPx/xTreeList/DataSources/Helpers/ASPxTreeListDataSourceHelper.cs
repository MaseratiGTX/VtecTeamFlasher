using DevExpress.Web.ASPxTreeList;
using WebAppCommons.Classes.Controls.ASPx.xComboBox.DataSources.InitialDataProviders;

namespace WebAppCommons.Classes.Controls.ASPx.xTreeList.DataSources.Helpers
{
    public static class ASPxTreeListDataSourceHelper
    {
        public static ASPxTreeList SetTreeListDataSource<T>(this ASPxTreeList source, IDataSourceInitialDataProvider<T> initialDataProvider) where T : class
        {
            source.DataSource = initialDataProvider.GetInitialData();

            return source;
        }
    }
}
