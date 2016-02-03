using System;
using System.Reflection;
using Commons.Logging;
using Commons.Reflections.Assemblies;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cache;
using NHibernateContext.ConnectionData;
using NHibernateContext.CustomDialects;
using NHibernateContext.CustomDrivers;
using NHibernateContext.Helpers;

namespace NHibernateContext.Core.Providers
{
    public class NHibernateSessionFactoryProvider
    {
        public NHibernateConnectionData NHConnectionData { get; private set; }

        public Assembly MappingAssembly { get; private set; }



        public NHibernateSessionFactoryProvider(string connectionString)
        {
            NHConnectionData = new NHibernateConnectionDataParser().Parse(connectionString);
        }

        public NHibernateSessionFactoryProvider(string connectionString, string mappingAssembly)
            : this(connectionString)
        {
            MappingAssembly = AssemblyHelper.LoadSafely(mappingAssembly);
        }



        public ISessionFactory CreateSessionFactory()
        {
            lock (typeof(NHibernateSessionFactoryProvider))
            {
                try
                {
                    return Fluently.Configure()
                        .Database(
                            MsSqlConfiguration.MsSql2008.Dialect<MsSql2008CustomDialect>()
                                .ConnectionString(
                                    new SQLConnectionStringBuilder().Build(NHConnectionData)
                                 )
                                .Driver<MSSQL2008CustomDriver>()
                                .DefaultSchema("dbo")
                        )
                        .Cache(
                            cacheBuilder => cacheBuilder
                                .UseQueryCache()
                                .ProviderClass<HashtableCacheProvider>())
                        .Mappings(
                            mappingConfiguration => mappingConfiguration.FluentMappings.AddFromAssembly(
                                MappingAssembly ?? Assembly.GetExecutingAssembly()
                                ))
                        .ExposeConfiguration(
                            configuration => configuration
                                .SetCommandTimeout(NHConnectionData.CommandTimeout))
                        .BuildSessionFactory()
                        .EnsureHasClassMetadata();
                }
                catch (Exception ex)
                {
                    Log.Error("Произошла ошибка при создании NhibernateSessionFactory:\r\n{0}", ex);

                    throw;
                }
            }
        }
    }
}