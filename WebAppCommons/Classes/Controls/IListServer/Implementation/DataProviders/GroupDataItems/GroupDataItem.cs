using WebAppCommons.Classes.Controls.IListServer.Implementation.DataProviders.SummaryRepositories;

namespace WebAppCommons.Classes.Controls.IListServer.Implementation.DataProviders.GroupDataItems
{
    public class GroupDataItem
    {
        public string Key { get; set; }
        public object[] PropertyValues { get; set; }
        public SummaryRepository SummaryRepository { get; set; }
    }
}