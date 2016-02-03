using System.Configuration;
using System.Web;
using NHibernate;
using NHibernateContext.ADOPersister;
using NHibernateContext.ADORepository;
using NHibernateContext.Core.Managers;
using NHibernateContext.Core.Providers;

namespace NHibernateContext.Core
{
    public static class NHibernateContextManager
    {
        private static NHibernateSessionFactoryProvider _NHibernateSessionFactoryProvider;

        public static NHibernateSessionFactoryProvider NHibernateSessionFactoryProvider
        {
            get
            {
                if (_NHibernateSessionFactoryProvider == null)
                {
                    var connectionString = ConfigurationManager.AppSettings["ConnectionString"];
                    var mappingAssembly = ConfigurationManager.AppSettings["DefaultMappingAssembly"];

                    _NHibernateSessionFactoryProvider = new NHibernateSessionFactoryProvider(connectionString, mappingAssembly);
                }

                return _NHibernateSessionFactoryProvider;
            }
        }



        private static ISessionFactory _SessionFactory;

        public static ISessionFactory SessionFactory
        {
            get { return _SessionFactory ?? (_SessionFactory = NHibernateSessionFactoryProvider.CreateSessionFactory()); }
        }



        private static NHibernateSessionProvider _NHibernateSessionProvider;

        public static NHibernateSessionProvider NHibernateSessionProvider
        {
            get { return _NHibernateSessionProvider ?? (_NHibernateSessionProvider = new NHibernateSessionProvider(SessionFactory));             }
        }



        private const string SESSION_MANAGER_KEY = "SESSION_MANAGER";

        public static NHibernateSessionManager NHibernateSessionManager
        {
            get
            {
                var sessionManager = HttpContext.Current.Items[SESSION_MANAGER_KEY] as NHibernateSessionManager;

                if (sessionManager == null)
                {
                    sessionManager = new NHibernateSessionManager(NHibernateSessionProvider);

                    HttpContext.Current.Items[SESSION_MANAGER_KEY] = sessionManager;
                }

                return sessionManager;
            }
        }



        private const string ADOREPOSITORY_FACTORY_KEY = "ADOREPOSITORY_FACTORY";

        public static ADORepositoryFactory ADORepositoryFactory
        {
            get
            {
                var adoRepositoryFactory = HttpContext.Current.Items[ADOREPOSITORY_FACTORY_KEY] as ADORepositoryFactory;

                if (adoRepositoryFactory == null)
                {
                    adoRepositoryFactory = new ADORepositoryFactory(NHibernateSessionManager);

                    HttpContext.Current.Items[ADOREPOSITORY_FACTORY_KEY] = adoRepositoryFactory;
                }

                return adoRepositoryFactory;
            }
        }



        private const string ADOPERSISTER_FACTORY_KEY = "ADOPERSISTER_FACTORY";

        public static ADOPersisterFactory ADOPersisterFactory
        {
            get
            {
                var adoPersisterFactory = HttpContext.Current.Items[ADOPERSISTER_FACTORY_KEY] as ADOPersisterFactory;

                if (adoPersisterFactory == null)
                {
                    adoPersisterFactory = new ADOPersisterFactory(
                        NHibernateSessionManager,
                        ConfigurationManager.AppSettings["DefaultValidationAssembly"]
                    );

                    HttpContext.Current.Items[ADOPERSISTER_FACTORY_KEY] = adoPersisterFactory;
                }

                return adoPersisterFactory;
            }
        }



        private const string COMMON_ADOREPOSITORY_KEY = "COMMON_ADOREPOSITORY";

        public static IADORepository CommonADORepository
        {
            get
            {
                var commonADORepository = HttpContext.Current.Items[COMMON_ADOREPOSITORY_KEY] as IADORepository;

                if (commonADORepository == null)
                {
                    commonADORepository = ADORepositoryFactory.CreateADORepository();

                    HttpContext.Current.Items[COMMON_ADOREPOSITORY_KEY] = commonADORepository;
                }

                return commonADORepository;
            }
        }



        private const string COMMON_ADOPERSISTER_KEY = "COMMON_ADOPERSISTER";

        public static IADOPersister CommonADOPersister
        {
            get
            {
                var commonADOPersister = HttpContext.Current.Items[COMMON_ADOPERSISTER_KEY] as IADOPersister;

                if (commonADOPersister == null)
                {
                    commonADOPersister = ADOPersisterFactory.CreateADOPersister();

                    HttpContext.Current.Items[COMMON_ADOPERSISTER_KEY] = commonADOPersister;
                }

                return commonADOPersister;
            }
        }
    }
}