using System.Collections.Generic;
using System.Linq;
using Commons.Helpers.Objects;
using DevExpress.Data;
using DevExpress.Data.Filtering;
using WebAppCommons.Classes.Controls.IListServer.Implementation.DataProviders.GroupDataItems;
using WebAppCommons.Classes.Controls.IListServer.Implementation.GroupInfoRepositories.ListSourceGroupInfos;
using WebAppCommons.Classes.Controls.IListServer.Implementation.Helpers;

namespace WebAppCommons.Classes.Controls.IListServer.Implementation.GroupInfoRepositories.GroupInfoManagers
{
    public class GroupInfoManager
    {
        private string KeyFieldName { get; set; }
        private int GroupCount { get; set; }
        private IEnumerable<ServerModeSummaryDescriptor> GroupSummaryInfo { get; set; }

        private GroupInfoRepository ResultsRepository { get; set; }



        public GroupInfoManager(string keyFieldName, int groupCount, IEnumerable<ServerModeSummaryDescriptor> groupSummaryInfo)
        {
            KeyFieldName = keyFieldName;
            GroupCount = groupCount;
            GroupSummaryInfo = groupSummaryInfo;

            Reset();
        }



        public GroupInfoManager Reset()
        {
            ResultsRepository = new GroupInfoRepository();

            return this;
        }



        public GroupInfoRepository CalculateRepository(List<GroupDataItem> dataSource)
        {
            Reset();

            CalculateChilds(null, dataSource);

            return ResultsRepository;
        }


        private void CalculateChilds(ListSourceGroupInfo parent, IEnumerable<GroupDataItem> dataSource)
        {
            var level = parent != null ? parent.Level + 1 : 0;


            if (level >= GroupCount)
            {
                ResultsRepository.AddItem(parent, new List<ListSourceGroupInfo>());

                return;
            }


            var groupedDataSource = dataSource.GroupBy(x => x.PropertyValues[level]);


            var repositoryValue = new List<ListSourceGroupInfo>();

            foreach (var keyValuePair in groupedDataSource)
            {
                var childsDataSource = keyValuePair.ToList();

                var summaryRepositories = childsDataSource.Select(x => x.SummaryRepository);

                var summaryRepository = summaryRepositories.Aggregate();

                var groupValue = keyValuePair.Key;
                var childDataRowCount = summaryRepository.Value(Aggregate.Count, KeyFieldName).As<int>();
                var summaries = summaryRepository.Values(GroupSummaryInfo);


                var groupInfo = new SimpleListSourceGroupInfo
                {
                    Level = level,
                    GroupValue = groupValue,
                    ChildDataRowCount = childDataRowCount
                }
                .AddSummaries(summaries);


                repositoryValue.Add(groupInfo);


                CalculateChilds(groupInfo, childsDataSource);
            }

            ResultsRepository.AddItem(parent, repositoryValue);
        }
    }
}