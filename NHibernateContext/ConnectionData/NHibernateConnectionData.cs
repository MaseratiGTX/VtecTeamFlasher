namespace NHibernateContext.ConnectionData
{
    public class NHibernateConnectionData
    {
        //EXTENSIONS
        public string CommandTimeout { get; set; }

        //NATIVE PARAMETERS
        public string ConnectionTimeout { get; set; }
        public string ConnectTimeout { get; set; }
        public string DataSource { get; set; }
        public string InitialCatalog { get; set; }
        public string Password { get; set; }
        public string PersistSecurityInfo { get; set; }
        public string TypeSystemVersion { get; set; }
        public string UserID { get; set; }
        public string ApplicationName { get; set; }
        public string ApplicationIntent { get; set; }
        public string AsynchronousProcessing { get; set; }
        public string AttachDBFilename { get; set; }
        public string ConnectionLifetime { get; set; }
        public string ContextConnection { get; set; }
        public string CurrentLanguage { get; set; }
        public string Encrypt { get; set; }
        public string Enlist { get; set; }
        public string FailoverPartner { get; set; }
        public string IntegratedSecurity { get; set; }
        public string MaxPoolSize { get; set; }
        public string MinPoolSize { get; set; }
        public string MultipleActiveResultSets { get; set; }
        public string MultiSubnetFailover { get; set; }
        public string NetworkLibrary { get; set; }
        public string PacketSize { get; set; }
        public string Pooling { get; set; }
        public string Replication { get; set; }
        public string TransactionBinding { get; set; }
        public string TrustServerCertificate { get; set; }
        public string UserInstance { get; set; }
        public string WorkstationID { get; set; }
        public string Server { get; set; }
        public string Port { get; set; }
        public string Database { get; set; }
    }
}