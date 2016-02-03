using DevExpress.Data;
using WebAppCommons.Classes.Controls.IListServer.Implementation.Helpers;

namespace WebAppCommons.Classes.Controls.IListServer.Implementation.DataProviders.SummaryRepositories.Items
{
    public abstract class BaseSummaryRepositoryItem : ISummaryRepositoryItem
    {
        public ServerModeSummaryDescriptor SourceDescriptor { get; protected set; }
        public string Key { get; protected set; }
        public object Value { get; set; }


        protected BaseSummaryRepositoryItem(ServerModeSummaryDescriptor sourceDescriptor)
        {
            SourceDescriptor = sourceDescriptor;
            Key = SourceDescriptor.CalculateKey();
        }
    }
}