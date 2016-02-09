using Commons.ParameterStrings;

namespace NHibernateContext.ConnectionData
{
    public class NHibernateConnectionDataParser
    {
        private ParameterStringParser<NHibernateConnectionData> ParameterStringParser { get; set; }


        public NHibernateConnectionDataParser()
        {
            ParameterStringParser = new ParameterStringParser<NHibernateConnectionData>()
                .AddMemberMapping("Data Source", x => x.DataSource)
                .AddMemberMapping("Initial Catalog", x => x.InitialCatalog)
                .AddMemberMapping("Persist Security Info", x => x.PersistSecurityInfo)
                .AddMemberMapping("User ID", x => x.UserID)
                .AddMemberMapping("Password", x => x.Password)
                .AddMemberMapping("Type System Version", x => x.TypeSystemVersion)
                .AddMemberMapping("Connection Timeout", x => x.ConnectionTimeout)
                .AddMemberMapping("Connect Timeout", x => x.ConnectTimeout)
                .AddMemberMapping("Command Timeout", x => x.CommandTimeout)
                .AddMemberMapping("Application Name", x => x.ApplicationName)
                .AddMemberMapping("ApplicationIntent", x => x.ApplicationIntent)
                .AddMemberMapping("Asynchronous Processing", x => x.AsynchronousProcessing)
                .AddMemberMapping("AttachDBFilename", x => x.AttachDBFilename)
                .AddMemberMapping("Connection Lifetime", x => x.ConnectionLifetime)
                .AddMemberMapping("Context Connection", x => x.ContextConnection)
                .AddMemberMapping("Current Language", x => x.CurrentLanguage)
                .AddMemberMapping("Encrypt", x => x.Encrypt)
                .AddMemberMapping("Enlist", x => x.Enlist)
                .AddMemberMapping("Failover Partner", x => x.FailoverPartner)
                .AddMemberMapping("Integrated Security", x => x.IntegratedSecurity)
                .AddMemberMapping("Max Pool Size", x => x.MaxPoolSize)
                .AddMemberMapping("Min Pool Size", x => x.MinPoolSize)
                .AddMemberMapping("MultipleActiveResultSets", x => x.MultipleActiveResultSets)
                .AddMemberMapping("MultiSubnetFailover", x => x.MultiSubnetFailover)
                .AddMemberMapping("Network Library", x => x.NetworkLibrary)
                .AddMemberMapping("Packet Size", x => x.PacketSize)
                .AddMemberMapping("Pooling", x => x.Pooling)
                .AddMemberMapping("Replication", x => x.Replication)
                .AddMemberMapping("Transaction Binding", x => x.TransactionBinding)
                .AddMemberMapping("TrustServerCertificate", x => x.TrustServerCertificate)
                .AddMemberMapping("User Instance", x => x.UserInstance)
                .AddMemberMapping("Workstation ID", x => x.WorkstationID)
                .AddMemberMapping("Server", x => x.Server)
                .AddMemberMapping("Database", x => x.Database)
                .AddMemberMapping("Port", x => x.Port);
        }


        public NHibernateConnectionData Parse(string connectionString)
        {
            return ParameterStringParser.Parse(connectionString);
        }
    }
}