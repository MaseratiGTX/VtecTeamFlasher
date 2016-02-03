using System.Collections.Generic;
using System.Linq;
using Commons.Helpers.Collections;
using WebAppCommons.Classes.Controls.IListServer.Implementation.DataProviders.SummaryRepositories.Items;
using WebAppCommons.Classes.Controls.IListServer.Implementation.Helpers;

namespace WebAppCommons.Classes.Controls.IListServer.Implementation.DataProviders.SummaryRepositories.Aggregators
{
    public class SummaryRepositoryAggregator
    {
        public SummaryRepository Aggregate(IEnumerable<SummaryRepository> summaryRepositories)
        {
            return new SummaryRepository(AggregateItems(summaryRepositories));
        }

        private List<ISummaryRepositoryItem> AggregateItems(IEnumerable<SummaryRepository> summaryRepositories)
        {
            var repositoryItemEnumerators = summaryRepositories.Select(x => (IEnumerator<ISummaryRepositoryItem>)x.Items().GetEnumerator()).ToList();


            var result = new List<ISummaryRepositoryItem>();

            while (repositoryItemEnumerators.MoveNext())
            {
                var current = repositoryItemEnumerators.Current();

                result.Add(current.Aggregate());
            }

            return result;
        }
    }
}