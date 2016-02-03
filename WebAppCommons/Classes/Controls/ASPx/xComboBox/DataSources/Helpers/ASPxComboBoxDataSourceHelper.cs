using System;
using System.Collections.Generic;
using System.Linq;
using Commons.Helpers.Objects;
using DevExpress.Web.ASPxEditors;
using WebAppCommons.Classes.Controls.ASPx.xComboBox.DataSources.FilterKeyProviders;
using WebAppCommons.Classes.Controls.ASPx.xComboBox.DataSources.InitialDataProviders;
using WebAppCommons.Classes.Controls.ASPx.xComboBox.DataSources.Sorters;

namespace WebAppCommons.Classes.Controls.ASPx.xComboBox.DataSources.Helpers
{
    public static class ASPxComboBoxDataSourceHelper
    {
        public static ASPxComboBox SetComboBoxDataSource<T>(this ASPxComboBox source, IEnumerable<T> dataSource) where T : class
        {
            return source.SetComboBoxDataSource(
                ConstructSimpleDataSourceInitialDataProvider(dataSource)
            );
        }

        public static ASPxComboBox SetComboBoxDataSource<T, TKey>(this ASPxComboBox source, IEnumerable<T> dataSource, Func<T, TKey> orderKeySelector) where T : class
        {
            return source.SetComboBoxDataSource(
                ConstructSimpleDataSourceInitialDataProvider(dataSource),
                ConstructSmartFilterKeyProvider<T>(source),
                ConstructSimpleDataSourceSorter(orderKeySelector)
            );
        }

        public static ASPxComboBox SetComboBoxDataSource<T, TKey>(this ASPxComboBox source, IEnumerable<T> dataSource, params Func<T, TKey>[] orderKeySelectors) where T : class
        {
            return source.SetComboBoxDataSource(
                ConstructSimpleDataSourceInitialDataProvider(dataSource),
                ConstructSmartFilterKeyProvider<T>(source),
                ConstructSimpleDataSourceSorter(orderKeySelectors)
            );
        }

        public static ASPxComboBox SetComboBoxDataSource<T>(this ASPxComboBox source, IDataSourceInitialDataProvider<T> dataSourceInitialDataProvider) where T : class
        {
            return source.SetComboBoxDataSource(
                dataSourceInitialDataProvider,
                ConstructSmartFilterKeyProvider<T>(source),
                ConstructCommonDataSourceSorter<T>()
            );
        }


        public static ASPxComboBox SetComboBoxDataSource<T, TKey>(this ASPxComboBox source, IDataSourceInitialDataProvider<T> dataSourceInitialDataProvider, Func<T, TKey> orderKeySelector) where T : class
        {
            return source.SetComboBoxDataSource(
                dataSourceInitialDataProvider,
                ConstructSmartFilterKeyProvider<T>(source),
                ConstructSimpleDataSourceSorter(orderKeySelector)
            );
        }

        public static ASPxComboBox SetComboBoxDataSource<T>(this ASPxComboBox source, IDataSourceInitialDataProvider<T> dataSourceInitialDataProvider, IDataSourceSorter<T> dataSourceSorter) where T : class
        {
            return source.SetComboBoxDataSource(
                dataSourceInitialDataProvider,
                ConstructSmartFilterKeyProvider<T>(source),
                dataSourceSorter
            );
        }


        public static ASPxComboBox SetComboBoxDataSource<T, F>(this ASPxComboBox source, IDataSourceInitialDataProvider<T> dataSourceInitialDataProvider, Func<T, string> filterKeyFunction, Func<T, F> orderKeySelector) where T : class
        {
            return source.SetComboBoxDataSource(
                dataSourceInitialDataProvider,
                ConstructSimpleFilterKeyProvider(filterKeyFunction),
                ConstructSimpleDataSourceSorter(orderKeySelector)
            );
        }


        public static ASPxComboBox SetComboBoxDataSource<T>(this ASPxComboBox source,
                                                             IDataSourceInitialDataProvider<T> dataSourceInitialDataProvider,
                                                             IFilterKeyProvider<T> filterKeyProvider,
                                                             IDataSourceSorter<T> dataSourceSorter) where T : class
        {
            source.DataSource = new ASPxComboBoxDataSource<T>(
                dataSourceInitialDataProvider,
                filterKeyProvider,
                dataSourceSorter
            );

            return source;
        }



        private static IDataSourceInitialDataProvider<T> ConstructSimpleDataSourceInitialDataProvider<T>(IEnumerable<T> dataSource) where T : class
        {
            return new SimpleDataSourceInitialDataProvider<T>(dataSource);
        }


        private static IFilterKeyProvider<T> ConstructSimpleFilterKeyProvider<T>(Func<T, string> filterKeyFunction) where T : class
        {
            return new SimpleFilterKeyProvider<T>(filterKeyFunction);
        }

        private static IFilterKeyProvider<T> ConstructSmartFilterKeyProvider<T>(ASPxComboBox source) where T : class
        {
            if (source.TextFormatString.IsNotEmpty())
            {
                var sourceColumns = source.Columns.Cast<ListBoxColumn>();

                return new SmartFilterKeyProvider<T>(
                    PrepareTextFormatString(source.TextFormatString),
                    sourceColumns.Select(column => column.FieldName)
                );
            }

            return new SmartFilterKeyProvider<T>(
                "{0}", source.TextField
            );
        }

        private static string PrepareTextFormatString(string source)
        {
            return source.Replace("\'", "'");
        }


        private static IDataSourceSorter<T> ConstructSimpleDataSourceSorter<T, TKey>(params Func<T, TKey>[] orderKeySelectors) where T : class
        {
            return new SimpleDataSourceSorter<T, TKey>(orderKeySelectors);
        }

        private static IDataSourceSorter<T> ConstructCommonDataSourceSorter<T>() where T : class
        {
            return new CommonDataSourceSorter<T>();
        }



        public static ASPxComboBox ApplyFilterCondition(this ASPxComboBox source, ListEditItemsRequestedByFilterConditionEventArgs e)
        {
            var comboBoxDataSource = source.DataSource as IASPxComboBoxDataSource;

            if (comboBoxDataSource != null)
            {
                var filteringMode = source.IncrementalFilteringMode;

                comboBoxDataSource.ApplyFilter(e.Filter, filteringMode, e.BeginIndex, e.EndIndex);

                if (e.Filter != comboBoxDataSource.CurrentFilter)
                {
                    source.Text = comboBoxDataSource.CurrentFilter;
                }
            }

            return source;
        }

        public static ASPxComboBox ApplyFilterCondition(this ASPxComboBox source, ListEditItemRequestedByValueEventArgs e)
        {
            var comboBoxDataSource = source.DataSource as IASPxComboBoxDataSource;

            if (comboBoxDataSource != null)
            {
                comboBoxDataSource.ApplyFilter(source.ValueField, e.Value);
            }

            return source;
        }
    }
}