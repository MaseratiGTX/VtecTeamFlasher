using System;
using System.Collections;
using System.Web.UI;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.ASPxTreeList;
using WebAppCommons.Classes.Controls.ASPx.xGridView;
using WebAppCommons.Classes.Controls.IListServer.Implementation.Configuration;
using WebAppCommons.Classes.Controls.IListServer.Implementation.DataProviders.Base;

namespace WebAppCommons.Classes.Controls.IListServer.Implementation.Helpers
{
    public static class SmartDataSourceExtensions
    {
        public static ASPxGridView SetSmartDataSource<T>(this ASPxGridView source, IDataProvider<T> dataProvider, Action<SmartDataSourceConfiguration<T>> configurationAction = null)
            where T : class
        {
            return source.SetSmartDataSource<T>(x =>
                {
                    x.SetDataProvider(dataProvider);

                    if (configurationAction != null)
                    {
                        configurationAction.Invoke(x);
                    }
                }
            );
        }

        public static ASPxTreeList SetSmartDataSource<T>(this ASPxTreeList source, IDataProvider<T> dataProvider, Action<SmartDataSourceConfiguration<T>> configurationAction = null)
            where T : class
        {
            return source.SetSmartDataSource<T>(x =>
                {
                    x.SetDataProvider(dataProvider);

                    if (configurationAction != null)
                    {
                        configurationAction.Invoke(x);
                    }
                }
            );
        }

        public static ASPxGridView SetSmartDataSource<T>(this ASPxGridView source, Action<SmartDataSourceConfiguration<T>> configurationAction)
            where T : class
        {
            var smartDataSourceConfiguration = new SmartDataSourceConfiguration<T>()
                .SetKeyPropertyName(source.KeyFieldName)
                .SetPageSize(source.SettingsPager.PageSize);

            if (configurationAction != null)
            {
                configurationAction.Invoke(smartDataSourceConfiguration);
            }

            return source.SetDataSource(
                new SmartDataSource<T>(
                    smartDataSourceConfiguration.EnsureComplete()
                )
            );
        }

        public static ASPxTreeList SetSmartDataSource<T>(this ASPxTreeList source, Action<SmartDataSourceConfiguration<T>> configurationAction)
            where T : class
        {
            var smartDataSourceConfiguration = new SmartDataSourceConfiguration<T>()
                .SetKeyPropertyName(source.KeyFieldName)
                .SetPageSize(source.SettingsPager.PageSize);

            if (configurationAction != null)
            {
                configurationAction.Invoke(smartDataSourceConfiguration);
            }

            source.DataSource = new SmartDataSource<T>(smartDataSourceConfiguration.EnsureComplete());
            source.DataBind();
            return source;
        }
    }
}