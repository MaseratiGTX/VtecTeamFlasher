using Commons.ParameterStrings;

namespace NHibernateContext.ConnectionData
{
    public class SQLConnectionStringBuilder
    {
        private ParameterStringBuilder<NHibernateConnectionData> ParameterStringBuilder { get; set; }


        public SQLConnectionStringBuilder()
        {
            ParameterStringBuilder = new ParameterStringBuilder<NHibernateConnectionData>()
                .AddMemberMapping(x => x.DataSource, "Data Source")
                .AddMemberMapping(x => x.InitialCatalog, "Initial Catalog")
                .AddMemberMapping(x => x.PersistSecurityInfo, "Persist Security Info")
                .AddMemberMapping(x => x.UserID, "User ID")
                .AddMemberMapping(x => x.Password, "Password")
                .AddMemberMapping(x => x.TypeSystemVersion, "Type System Version")
                .AddMemberMapping(x => x.ConnectionTimeout, "Connection Timeout")
                .AddMemberMapping(x => x.ConnectTimeout, "Connect Timeout")
                .AddMemberMapping(x => x.ApplicationName, "Application Name")
                .AddMemberMapping(x => x.ApplicationIntent, "ApplicationIntent")
                .AddMemberMapping(x => x.AsynchronousProcessing, "Asynchronous Processing")
                .AddMemberMapping(x => x.AttachDBFilename, "AttachDBFilename")
                .AddMemberMapping(x => x.ConnectionLifetime, "Connection Lifetime")
                .AddMemberMapping(x => x.ContextConnection, "Context Connection")
                .AddMemberMapping(x => x.CurrentLanguage, "Current Language")
                .AddMemberMapping(x => x.Encrypt, "Encrypt")
                .AddMemberMapping(x => x.Enlist, "Enlist")
                .AddMemberMapping(x => x.FailoverPartner, "Failover Partner")
                .AddMemberMapping(x => x.IntegratedSecurity, "Integrated Security")
                .AddMemberMapping(x => x.MaxPoolSize, "Max Pool Size")
                .AddMemberMapping(x => x.MinPoolSize, "Min Pool Size")
                .AddMemberMapping(x => x.MultipleActiveResultSets, "MultipleActiveResultSets")
                .AddMemberMapping(x => x.MultiSubnetFailover, "MultiSubnetFailover")
                .AddMemberMapping(x => x.NetworkLibrary, "Network Library")
                .AddMemberMapping(x => x.PacketSize, "Packet Size")
                .AddMemberMapping(x => x.Pooling, "Pooling")
                .AddMemberMapping(x => x.Replication, "Replication")
                .AddMemberMapping(x => x.TransactionBinding, "Transaction Binding")
                .AddMemberMapping(x => x.TrustServerCertificate, "TrustServerCertificate")
                .AddMemberMapping(x => x.UserInstance, "User Instance")
                .AddMemberMapping(x => x.WorkstationID, "Workstation ID")
                .AddMemberMapping(x => x.Server, "Server")
                .AddMemberMapping(x => x.Database, "Database")
                .AddMemberMapping(x => x.Port, "Port"); 
        }


        public string Build(NHibernateConnectionData connectionData)
        {
            return ParameterStringBuilder.Build(connectionData);
        }
    }
}