namespace WebAppCommons.Classes.Controls.IListServer.Implementation.DataProviders.NHibernate.Processors
{
    public class JoinContext
    {
        public string Section { get; set; }
        public string Mapping { get; set; }
        public string Alias { get; set; }
        public bool IsPermanent { get; set; }
    }
}