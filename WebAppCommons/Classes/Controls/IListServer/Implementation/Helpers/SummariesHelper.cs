using System.Collections.Generic;
using WebAppCommons.Classes.Controls.IListServer.Implementation.DataProviders.SummaryRepositories;
using WebAppCommons.Classes.Controls.IListServer.Implementation.DataProviders.SummaryRepositories.Aggregators;
using WebAppCommons.Classes.Controls.IListServer.Implementation.DataProviders.SummaryRepositories.Items;

namespace WebAppCommons.Classes.Controls.IListServer.Implementation.Helpers
{
    public static class SummariesHelper
    {
        public static ISummaryRepositoryItem Aggregate(this IEnumerable<ISummaryRepositoryItem> source)
        {
            return new SummaryRepositoryItemAggregator().Aggregate(source);
        }

        public static SummaryRepository Aggregate(this IEnumerable<SummaryRepository> source)
        {
            return new SummaryRepositoryAggregator().Aggregate(source);
        }
    }
}