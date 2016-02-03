using DevExpress.Data;

namespace WebAppCommons.Classes.Controls.IListServer.Implementation.DataProviders.SummaryRepositories.Items
{
    public class AVGSummaryRepositoryItem : BaseSummaryRepositoryItem
    {
        public decimal Sum { get; set; }
        public int Count { get; set; }


        public AVGSummaryRepositoryItem(ServerModeSummaryDescriptor sourceDescriptor)
            : base(sourceDescriptor)
        {
        }
    }
}