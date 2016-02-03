using System;
using System.Collections.Generic;
using DevExpress.Data;
using DevExpress.Data.Filtering;
using WebAppCommons.Classes.Controls.IListServer.Implementation.DataProviders.GroupDataItems;
using WebAppCommons.Classes.Controls.IListServer.Implementation.DataProviders.SummaryRepositories;

namespace WebAppCommons.Classes.Controls.IListServer.Implementation.DataProviders.Base
{
    public interface IDataProvider<out T> where T : class
    {
        event EventHandler ItemsChanged;

        event EventHandler GroupInfoChanged;

        event EventHandler TotalSummaryChanged;


        IDataProvider<T> Apply(
            CriteriaOperator filterCriteria,
            ICollection<ServerModeOrderDescriptor> sortInfo,
            int groupCount,
            ICollection<ServerModeSummaryDescriptor> groupSummaryInfo,
            ICollection<ServerModeSummaryDescriptor> totalSummaryInfo
        );


        IDataProvider<T> Fetch();


        T[] Items(int firstResult, int maxResults);


        List<GroupDataItem> GroupInfoDataItems();

        SummaryRepository TotalSummaryRepository();
    }
}