using System.Collections.Generic;
using System.Linq;
using DevExpress.Data;
using DevExpress.Data.Filtering;
using WebAppCommons.Classes.Controls.IListServer.Implementation.DataProviders.SummaryRepositories;
using WebAppCommons.Classes.Controls.IListServer.Implementation.DataProviders.SummaryRepositories.Factories;
using WebAppCommons.Classes.Controls.IListServer.Implementation.Helpers;

namespace WebAppCommons.Classes.Controls.IListServer.Implementation.DataProviders.GroupDataItems
{
    public class GroupDataItemFactory
    {
        private List<OperandProperty> PropertyExpressions { get; set; }
        private int PropertiesCount { get; set; }

        private List<ServerModeSummaryDescriptor> SummaryDescriptors { get; set; }



        public GroupDataItemFactory(List<OperandProperty> propertyExpressions, List<ServerModeSummaryDescriptor> summaryDescriptors)
        {
            PropertyExpressions = propertyExpressions;
            PropertiesCount = PropertyExpressions.Count;

            SummaryDescriptors = summaryDescriptors;
        }



        public GroupDataItem Produce(object[] groupData)
        {
            return ProduceFor(groupData);
        }

        public GroupDataItem ProduceFor(object[] groupData)
        {
            var propertyValues = groupData.Take(PropertiesCount).ToArray();

            var key = propertyValues.CalculateKey();


            var summaryRepositoryDataSource = groupData.Skip(PropertiesCount).ToArray();

            var summaryRepositoryItemFactory = new SummaryRepositoryItemFactory(summaryRepositoryDataSource);

            var summaryRepository = new SummaryRepository(
                SummaryDescriptors.Select(summaryRepositoryItemFactory.ProduceFor).ToList()
            );


            return new GroupDataItem
            {
                Key = key,
                PropertyValues = propertyValues,
                SummaryRepository = summaryRepository
            };
        }
    }
}