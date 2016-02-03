using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Commons.DataCache;
using Commons.Helpers.CommonObjects;
using Commons.Helpers.Objects;
using Commons.Reflections.PropertyManagers;
using DevExpress.Data;
using DevExpress.Data.Filtering;
using WebAppCommons.Classes.Controls.IListServer.Implementation.Configuration;
using WebAppCommons.Classes.Controls.IListServer.Implementation.DataProviders.Base;
using WebAppCommons.Classes.Controls.IListServer.Implementation.DataProviders.SummaryRepositories;
using WebAppCommons.Classes.Controls.IListServer.Implementation.GroupInfoRepositories;
using WebAppCommons.Classes.Controls.IListServer.Implementation.GroupInfoRepositories.GroupInfoManagers;
using WebAppCommons.Classes.Controls.IListServer.Implementation.Helpers;
using WebAppCommons.Classes.Controls.IListServer.Implementation.Helpers.PropertyDescriptors;
using WebAppCommons.Classes.Controls.IListServer.Implementation.RowsRepositories;

namespace WebAppCommons.Classes.Controls.IListServer.Implementation
{
    public class SmartDataSource<T> : ISmartDataSourse where T : class
    {
        public SmartDataSourceConfiguration<T> Configuration { get; protected set; }

        
        public string KeyPropertyName 
        {
            get { return Configuration.KeyPropertyName; }
        }

        public IDataProvider<T> DataProvider 
        {
            get { return Configuration.DataProvider; }
        }

        public int PageSize 
        {
            get { return Configuration.PageSize; }
        }

        public Action<List<PropertyDescriptor>> ItemPropertiesExpandingAction 
        {
            get { return Configuration.ItemPropertiesExpandingAction; }
        }


        protected PropertyManager<T> PropertyManager { get; set; }

        protected IDataCache<PropertyDescriptorCollection> ItemPropertiesCache { get; set; }
        
        protected IDataCache<SummaryRepository> TotalSummaryRepositoryCache { get; set; }

        protected IDataCache<RowsRepository<T>> RowsRepositoryCache { get; set; }
        protected IDataCache<int> RowsCountCache { get; set; }
        protected IDataCache<List<object>> TotalSummaryCache { get; set; }
        protected IDataCache<GroupInfoRepository> GroupInfoRepositoryCache { get; set; }


        protected CriteriaOperator FilterCriteria { get; set; }
        protected ICollection<ServerModeOrderDescriptor> SortInfo { get; set; }
        protected int GroupCount { get; set; }
        protected ICollection<ServerModeSummaryDescriptor> GroupSummaryInfo { get; set; }
        protected ICollection<ServerModeSummaryDescriptor> TotalSummaryInfo { get; set; }



        private SmartDataSource()
        {
            ItemPropertiesCache = new DataCache<PropertyDescriptorCollection>(InitializeItemPropertiesCache);

            TotalSummaryRepositoryCache = new DataCache<SummaryRepository>(InitializeTotalSummaryRepositoryCache);

            RowsRepositoryCache = new DataCache<RowsRepository<T>>(InitializeRowsRepositoryCache);
            RowsCountCache = new DataCache<int>(InitializeRowsCountCache);
            TotalSummaryCache = new DataCache<List<object>>(InitializeTotalSummaryCache);
            GroupInfoRepositoryCache = new DataCache<GroupInfoRepository>(InitializeGroupInfoRepositoryCache);

            PropertyManager = new PropertyManager<T>();
        }

        public SmartDataSource(SmartDataSourceConfiguration<T> configuration) : this()
        {
            Configuration = configuration;

            DataProvider.ItemsChanged += DataProvider_OnItemsChanged;
            DataProvider.GroupInfoChanged += DataProvider_OnGroupInfoChanged;
            DataProvider.TotalSummaryChanged += DataProvider_OnTotalSummaryChanged;

            Apply(null, null, 0, null, null);
        }


        #region IMPLEMENTATION OF IHasDataCache

        public void Dirty()
        {
            TotalSummaryRepositoryCache.Dirty();
            RowsRepositoryCache.Dirty();
            RowsCountCache.Dirty();
            TotalSummaryCache.Dirty();
            GroupInfoRepositoryCache.Dirty();
        }

        #endregion

        #region DataProvider EVENT HANDLERS

        private void DataProvider_OnItemsChanged(object sender, EventArgs eventArgs)
        {
            RowsRepositoryCache.Dirty();
        }

        private void DataProvider_OnGroupInfoChanged(object sender, EventArgs eventArgs)
        {
            GroupInfoRepositoryCache.Dirty();
        }

        private void DataProvider_OnTotalSummaryChanged(object sender, EventArgs eventArgs)
        {
            TotalSummaryRepositoryCache.Dirty();
            RowsCountCache.Dirty();
            TotalSummaryCache.Dirty();
        }

        #endregion

        #region CACHE INITIALIZATION METHODS

        protected PropertyDescriptorCollection InitializeItemPropertiesCache()
        {
            var propertyDescriptors = FetchDefaultItemProperties();

            if (ItemPropertiesExpandingAction != null)
            {
                ItemPropertiesExpandingAction.Invoke(propertyDescriptors);
            }

            return new PropertyDescriptorCollection(
                propertyDescriptors.Distinct()
                    .Select(x =>
                        {
                            if (x.ComponentType.IsAssignableFrom(typeof (T)) == false)
                            {
                                return new SmartPropertyDescriptor<T>(x);
                            }

                            return x;
                        }
                    )
                    .ToArray()
            );
        }

        protected List<PropertyDescriptor> FetchDefaultItemProperties()
        {
            return TypeDescriptor.GetProperties(typeof (T)).Cast<PropertyDescriptor>().ToList();
        } 


        protected SummaryRepository InitializeTotalSummaryRepositoryCache()
        {
            return DataProvider.Fetch().TotalSummaryRepository();
        }


        protected RowsRepository<T> InitializeRowsRepositoryCache()
        {
            return new RowsRepository<T>(DataProvider, PageSize);
        }

        protected int InitializeRowsCountCache()
        {
            return TotalSummaryRepositoryCache.Value
                .Value(Aggregate.Count, KeyPropertyName)
                .As<int>();
        }

        protected List<object> InitializeTotalSummaryCache()
        {
            return TotalSummaryRepositoryCache.Value
                .Values(TotalSummaryInfo);
        }

        protected GroupInfoRepository InitializeGroupInfoRepositoryCache()
        {
            var groupDataItems = DataProvider.Fetch().GroupInfoDataItems();

            return new GroupInfoManager(KeyPropertyName, GroupCount, GroupSummaryInfo)
                .CalculateRepository(groupDataItems);
        }

        #endregion


        #region IMPLEMENTATION OF IListServer

        //========================= System.Collections.ICollection =========================//

        public int Count
        {
            get { return RowsCountCache.Value; }
        }


        //============================ System.Collections.IList ============================//

        public object this[int index]
        {
            get { return RowsRepositoryCache.Value[index]; }
            set { throw new NotSupportedException("Не поддерживаем set для this[int index]"); }
        }


        //=========================== DevExpress.Data.IListServer ==========================//

        public object GetRowKey(int index)
        {
            return PropertyManager.Get(KeyPropertyName).In((T)this[index]);
        }


        public int LocateByValue(CriteriaOperator expression, object value, int startIndex, bool searchUp)
        {
            // ReSharper disable ConditionIsAlwaysTrueOrFalse

            if (startIndex != -1)
            {
                throw new NotSupportedException("Не поддерживаем значение StartIndex отличное от '-1'. Переданное значение StartIndex: '{0}'".FillWith(startIndex));
            }

            if (searchUp)
            {
                throw new NotSupportedException("Не поддерживаем значение SearchUp отличное от 'false'. Переданное значение SearchUp: '{0}'".FillWith(searchUp));
            }

            // ReSharper restore ConditionIsAlwaysTrueOrFalse


            var operandProperty = expression as OperandProperty;

            if (operandProperty != null)
            {
                var propertyDelegate = PropertyManager.Get(operandProperty.PropertyName).Delegate();

                return RowsRepositoryCache.Value.FindIndex(x => propertyDelegate.Invoke(x).Equals(value));
            }

            throw new NotSupportedException("Не поддерживаем значение Expression отличное от 'OperandProperty'. Переданное значение Expression: '{0}'".FillWith(expression.TypeName()));
        }



        public void Apply(CriteriaOperator filterCriteria, ICollection<ServerModeOrderDescriptor> sortInfo, int groupCount, ICollection<ServerModeSummaryDescriptor> groupSummaryInfo, ICollection<ServerModeSummaryDescriptor> totalSummaryInfo)
        {
            FilterCriteria = filterCriteria;
            SortInfo = sortInfo;
            GroupCount = groupCount;
            GroupSummaryInfo = groupSummaryInfo;
            TotalSummaryInfo = totalSummaryInfo;

            DataProvider.Apply(
                FilterCriteria,
                SortInfo,
                GroupCount,
                GroupSummaryInfo.AddSummaryDesciptor(Aggregate.Count, KeyPropertyName),
                TotalSummaryInfo.AddSummaryDesciptor(Aggregate.Count, KeyPropertyName)
            );
        }


        public List<ListSourceGroupInfo> GetGroupInfo(ListSourceGroupInfo parentGroup)
        {
            return GroupInfoRepositoryCache.Value.GetGroupInfo(parentGroup);
        }


        public List<object> GetTotalSummary()
        {
            return TotalSummaryCache.Value;
        }

        #endregion

        #region IMPLEMENTATION OF ITypedList

        public virtual string GetListName(PropertyDescriptor[] listAccessors)
        {
            return typeof(T).Name;
        }

        public virtual PropertyDescriptorCollection GetItemProperties(PropertyDescriptor[] listAccessors)
        {
            return ItemPropertiesCache.Value;
        }

        #endregion

        #region NO NEED TO IMPLEMENT

        //========================= System.Collections.IEnumerable =========================//

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }


        //========================= System.Collections.ICollection =========================//

        public object SyncRoot
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsSynchronized
        {
            get { throw new NotImplementedException(); }
        }


        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }


        //============================ System.Collections.IList ============================//

        public bool IsFixedSize
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }


        public int Add(object value)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(object value)
        {
            throw new NotImplementedException();
        }

        public int IndexOf(object value)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, object value)
        {
            throw new NotImplementedException();
        }

        public void Remove(object value)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }


        //=========================== DevExpress.Data.IListServer ==========================//

        public event EventHandler<ServerModeExceptionThrownEventArgs> ExceptionThrown
        {
            add { throw new NotImplementedException(); }
            remove { throw new NotImplementedException(); }
        }

        public event EventHandler<ServerModeInconsistencyDetectedEventArgs> InconsistencyDetected
        {
            add { throw new NotImplementedException(); }
            remove { throw new NotImplementedException(); }
        }

        public int FindIncremental(CriteriaOperator expression, string value, int startIndex, bool searchUp, bool ignoreStartRow, bool allowLoop)
        {
            throw new NotImplementedException();
        }

        public IList GetAllFilteredAndSortedRows()
        {
            throw new NotImplementedException();
        }

        public int GetRowIndexByKey(object key)
        {
            throw new NotImplementedException();
        }

        public object[] GetUniqueColumnValues(CriteriaOperator expression, int maxCount, bool includeFilteredOut)
        {
            throw new NotImplementedException();
        }

        public void Refresh()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}