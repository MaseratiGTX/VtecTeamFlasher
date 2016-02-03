using System.Collections.Generic;
using System.Linq;
using DevExpress.Data;
using DevExpress.Data.Filtering;
using WebAppCommons.Classes.Controls.IListServer.Implementation.DataProviders.SummaryRepositories.Items;
using WebAppCommons.Classes.Controls.IListServer.Implementation.Helpers;

namespace WebAppCommons.Classes.Controls.IListServer.Implementation.DataProviders.SummaryRepositories
{
    public class SummaryRepository
    {
        protected Dictionary<string, ISummaryRepositoryItem> ItemsDictionary { get; set; }



        public SummaryRepository(IEnumerable<ISummaryRepositoryItem> summaryRepositoryItems)
        {
            ItemsDictionary = summaryRepositoryItems.ToDictionary(x => x.Key);
        }



        public bool Contains(Aggregate aggregateType, string propertyName)
        {
            return Contains(aggregateType.CreateDescriptorFor(propertyName));
        }

        public bool Contains(ServerModeSummaryDescriptor summaryDescriptor)
        {
            return ItemsDictionary.ContainsKey(summaryDescriptor.CalculateKey());
        }

        public List<ServerModeSummaryDescriptor> Keys()
        {
            return ItemsDictionary.Values.Select(x => x.SourceDescriptor).ToList();
        }


        public ISummaryRepositoryItem Item(Aggregate aggregateType, string propertyName)
        {
            return Item(aggregateType.CreateDescriptorFor(propertyName));
        }

        public ISummaryRepositoryItem Item(ServerModeSummaryDescriptor summaryDescriptor)
        {
            return ItemsDictionary[summaryDescriptor.CalculateKey()];
        }

        public List<ISummaryRepositoryItem> Items(IEnumerable<ServerModeSummaryDescriptor> summaryDescriptors)
        {
            return summaryDescriptors.Select(Item).ToList();
        }

        public List<ISummaryRepositoryItem> Items()
        {
            return ItemsDictionary.Values.ToList();
        }


        public object Value(Aggregate aggregateType, string propertyName)
        {
            return Item(aggregateType, propertyName).Value;
        }

        public object Value(ServerModeSummaryDescriptor summaryDescriptor)
        {
            return Item(summaryDescriptor).Value;
        }

        public List<object> Values(IEnumerable<ServerModeSummaryDescriptor> summaryDescriptors)
        {
            return Items(summaryDescriptors).Select(x => x.Value).ToList();
        }

        public List<object> Values()
        {
            return Items().Select(x => x.Value).ToList();
        }
    }
}