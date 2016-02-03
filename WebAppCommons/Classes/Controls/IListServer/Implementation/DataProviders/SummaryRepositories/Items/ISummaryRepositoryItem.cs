using DevExpress.Data;

namespace WebAppCommons.Classes.Controls.IListServer.Implementation.DataProviders.SummaryRepositories.Items
{
    public interface ISummaryRepositoryItem
    {
        ServerModeSummaryDescriptor SourceDescriptor { get; }
        string Key { get; }
        object Value { get; }
    }
}