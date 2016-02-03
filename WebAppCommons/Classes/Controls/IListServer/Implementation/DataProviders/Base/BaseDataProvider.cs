using System;
using System.Collections.Generic;
using Commons.Helpers;
using DevExpress.Data;
using DevExpress.Data.Filtering;
using WebAppCommons.Classes.Controls.IListServer.Implementation.DataProviders.GroupDataItems;
using WebAppCommons.Classes.Controls.IListServer.Implementation.DataProviders.SummaryRepositories;

namespace WebAppCommons.Classes.Controls.IListServer.Implementation.DataProviders.Base
{
    public abstract class BaseDataProvider<T> : IDataProvider<T> where T : class
    {
        public virtual event EventHandler ItemsChanged;
        public virtual event EventHandler GroupInfoChanged;
        public virtual event EventHandler TotalSummaryChanged;

        protected CriteriaOperator FilterCriteria { get; set; }
        protected ICollection<ServerModeOrderDescriptor> SortInfo { get; set; }
        protected int GroupCount { get; set; }
        protected ICollection<ServerModeSummaryDescriptor> GroupSummaryInfo { get; set; }
        protected ICollection<ServerModeSummaryDescriptor> TotalSummaryInfo { get; set; }



        protected void OnItemsChanged()
        {
            this.RaiseEvent(ItemsChanged);
        }

        protected void OnGroupInfoChanged()
        {
            this.RaiseEvent(GroupInfoChanged);
        }

        protected void OnTotalSummaryChanged()
        {
            this.RaiseEvent(TotalSummaryChanged);
        }



        public IDataProvider<T> Apply(CriteriaOperator filterCriteria, ICollection<ServerModeOrderDescriptor> sortInfo, int groupCount, ICollection<ServerModeSummaryDescriptor> groupSummaryInfo, ICollection<ServerModeSummaryDescriptor> totalSummaryInfo)
        {
            FilterCriteria = filterCriteria;
            SortInfo = sortInfo;
            GroupCount = groupCount;
            GroupSummaryInfo = groupSummaryInfo;
            TotalSummaryInfo = totalSummaryInfo;

            PrepareForFetchingProcess();

            return this;
        }

        protected abstract void PrepareForFetchingProcess();



        public IDataProvider<T> Fetch()
        {
            return this;
        }



        public abstract T[] Items(int firstResult, int maxResults);


        public abstract List<GroupDataItem> GroupInfoDataItems();

        public abstract SummaryRepository TotalSummaryRepository();
    }
}