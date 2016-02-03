using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Commons.DataCache;
using Commons.Helpers.Objects;
using Commons.Reflections.PropertyManagers;
using DevExpress.Web.ASPxEditors;
using WebAppCommons.Classes.Controls.ASPx.xComboBox.DataSources.DataItems;
using WebAppCommons.Classes.Controls.ASPx.xComboBox.DataSources.FilterKeyProviders;
using WebAppCommons.Classes.Controls.ASPx.xComboBox.DataSources.Helpers;
using WebAppCommons.Classes.Controls.ASPx.xComboBox.DataSources.InitialDataProviders;
using WebAppCommons.Classes.Controls.ASPx.xComboBox.DataSources.Sorters;

namespace WebAppCommons.Classes.Controls.ASPx.xComboBox.DataSources
{
    public class ASPxComboBoxDataSource<T> : IASPxComboBoxDataSource, IEnumerable<T> where T : class
    {
        public IDataSourceInitialDataProvider<T> DataSourceInitialDataProvider { get; private set; }
        public IFilterKeyProvider<T> FilterKeyProvider { get; private set; }
        public IDataSourceSorter<T> DataSourceSorter { get; private set; }

        public string CurrentFilter { get; private set; }


        private IDataCache<List<DataSourceDataItem<T>>> BaseData { get; set; }
        private PropertyManager<T> PropertyManager { get; set; }

        private List<DataSourceDataItem<T>> ActualData { get; set; }
        private List<T> ActualDataSource { get; set; }



        public ASPxComboBoxDataSource( IDataSourceInitialDataProvider<T> dataSourceInitialDataProvider,
                                       IFilterKeyProvider<T> filterKeyProvider,
                                       IDataSourceSorter<T> dataSourceSorter )
        {
            BaseData = new DataCache<List<DataSourceDataItem<T>>>(InitializeBaseDataCache);
            PropertyManager = new PropertyManager<T>();

            DataSourceInitialDataProvider = dataSourceInitialDataProvider;
            FilterKeyProvider = filterKeyProvider;
            DataSourceSorter = dataSourceSorter;

            InitializeActuals();
        }



        #region CACHE INITIALIZATION METHODS

        private List<DataSourceDataItem<T>> InitializeBaseDataCache()
        {
            return DataSourceInitialDataProvider.GetInitialData()
                .Select(x =>
                {
                    var filterKey = FilterKeyProvider.ProvideKeyFor(x).ToLower();

                    return new DataSourceDataItem<T>
                    {
                        Source = x,
                        FilterKey = filterKey
                    };
                }
                 )
                .ToList();
        }

        #endregion


        public bool HasActual(string propertyName, object propertyValue)
        {
            var propertyDelegate = PropertyManager.Get(propertyName).Delegate();

            return ActualData.Any(x => propertyDelegate.Invoke(x.Source).Equals(propertyValue));
        }

        public bool HasBase(string propertyName, object propertyValue)
        {
            var propertyDelegate = PropertyManager.Get(propertyName).Delegate();

            return BaseData.Value.Any(x => propertyDelegate.Invoke(x.Source).Equals(propertyValue));
        }


        public void ApplyFilter(string actualFilterValue, IncrementalFilteringMode filteringMode, int beginIndex, int endIndex)
        {
            Filter(actualFilterValue, filteringMode);
            Sort();
            TruncateToBorders(beginIndex, endIndex);

            if (beginIndex == 0 && ActualData.IsEmpty())
            {
                var correctFilterValue = FindCorrectFilter(NextFilterValue(actualFilterValue), filteringMode);

                Filter(correctFilterValue, filteringMode);
                Sort();
                TruncateToBorders(0, endIndex - beginIndex);
            }

            ActualDataSource = ActualData.ToSource().ToList();
        }

        public void ApplyFilter(string propertyName, object propertyValue)
        {
            Filter(propertyName, propertyValue);
            Sort();

            ActualDataSource = ActualData.ToSource().ToList();
        }



        private void InitializeActuals()
        {
            ActualData = BaseData.Value.ToList();
            Sort();

            ActualDataSource = ActualData.ToSource().ToList();
        }


        private void Filter(string propertyName, object propertyValue)
        {
            var propertyDelegate = PropertyManager.Get(propertyName).Delegate();

            var baseDataFiltered = BaseData.Value
                .Where(
                    x => propertyDelegate.Invoke(x.Source).Equals(propertyValue)
                 )
                .ToList();

            ActualData = baseDataFiltered;
        }

        private void Filter(string actualFilterValue, IncrementalFilteringMode filteringMode)
        {
            CurrentFilter = actualFilterValue;

            var baseDataFiltered = BaseData.Value;

            if (actualFilterValue.IsNotEmpty())
            {
                var filterValue = actualFilterValue.ToLower();

                baseDataFiltered = baseDataFiltered.Where(x => x.Satisfies(filterValue, filteringMode)).ToList();
            }

            ActualData = baseDataFiltered;
        }


        private void Sort()
        {
            ActualData = CurrentFilter.IsEmpty()
                ? DataSourceSorter.OrderBase(ActualData)
                : DataSourceSorter.OrderFiltered(ActualData);
        }


        private void TruncateToBorders(int beginIndex, int endIndex)
        {
            var lastItemIndex = Math.Max(ActualData.Count - 1, 0);

            if (beginIndex > lastItemIndex)
            {
                ActualData = new List<DataSourceDataItem<T>>();
                return;
            }

            endIndex = Math.Min(endIndex, lastItemIndex);

            ActualData = ActualData.Skip(beginIndex).Take(endIndex - beginIndex + 1).ToList();
        }


        private string FindCorrectFilter(string possibleFilterValue, IncrementalFilteringMode filteringMode)
        {
            if (possibleFilterValue.IsEmpty()) return null;


            var filterValue = possibleFilterValue.ToLower();

            if (BaseData.Value.Any(x => x.Satisfies(filterValue, filteringMode)))
            {
                return possibleFilterValue;
            }


            return FindCorrectFilter(NextFilterValue(possibleFilterValue), filteringMode);
        }

        private string NextFilterValue(string filter)
        {
            if (filter.IsEmpty()) return null;

            return filter.Length > 1 ? filter.Substring(0, filter.Length - 1) : null;
        }


        public IEnumerator<T> GetEnumerator()
        {
            return ActualDataSource.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}