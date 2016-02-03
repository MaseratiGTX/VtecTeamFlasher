using System.Collections.Generic;
using DevExpress.Data;

namespace WebAppCommons.Classes.Controls.IListServer.Implementation.GroupInfoRepositories.ListSourceGroupInfos
{
    public class SimpleListSourceGroupInfo : ListSourceGroupInfo
    {
        private readonly List<object> summary;

        public override List<object> Summary
        {
            get { return summary; }
        }



        public SimpleListSourceGroupInfo()
        {
            summary = new List<object>();
        }

        public SimpleListSourceGroupInfo(List<object> summary)
        {
            this.summary = summary;
        }



        public SimpleListSourceGroupInfo AddSummary(object value)
        {
            summary.Add(value);

            return this;
        }

        public SimpleListSourceGroupInfo AddSummaries(IEnumerable<object> summaries)
        {
            foreach (var item in summaries)
            {
                AddSummary(item);
            }

            return this;
        }
    }
}