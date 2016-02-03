using System.Collections.Generic;
using Commons.Helpers;
using DevExpress.Data;

namespace WebAppCommons.Classes.Controls.IListServer.Implementation.GroupInfoRepositories
{
    public class GroupInfoRepository
    {
        private Dictionary<object, List<ListSourceGroupInfo>> Source { get; set; }



        public GroupInfoRepository()
        {
            Source = new Dictionary<object, List<ListSourceGroupInfo>>();
        }



        public GroupInfoRepository AddItem(ListSourceGroupInfo parentGroup, List<ListSourceGroupInfo> value)
        {
            Source.Add(CalculateRepositoryKey(parentGroup), value);

            return this;
        }


        public List<ListSourceGroupInfo> GetGroupInfo(ListSourceGroupInfo parentGroup)
        {
            return Source[CalculateRepositoryKey(parentGroup)];
        }



        private static object CalculateRepositoryKey(ListSourceGroupInfo parentGroup)
        {
            return parentGroup ?? (object)Nothing.Value;
        }
    }
}