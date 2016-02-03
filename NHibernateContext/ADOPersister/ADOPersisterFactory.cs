using System;
using System.Reflection;
using Commons.Reflections.Assemblies;
using NHibernateContext.ADORepository;
using NHibernateContext.Core.Managers;
using NHibernateContext.NHSessionContainers;
using NHibernateContext.PersistenceValidation;
using NHibernateContext.PersistenceValidation.ValidatorsBase.InitializationStrategies;

namespace NHibernateContext.ADOPersister
{
    public class ADOPersisterFactory
    {
        public NHibernateSessionManager NHibernateSessionManager { get; private set; }
        public Assembly ValidationAssembly { get; private set; }



        public ADOPersisterFactory(NHibernateSessionManager nHibernateSessionManager)
        {
            NHibernateSessionManager = nHibernateSessionManager;
        }

        public ADOPersisterFactory(NHibernateSessionManager nHibernateSessionManager, string validationAssembly) : this(nHibernateSessionManager)
        {
            ValidationAssembly = AssemblyHelper.LoadSafely(validationAssembly);
        }



        private IInitializationStrategy DefaultInitializationStrategy(INHSessionContainer nhibernateSessionContainer)
        {
            return new CacheableStrategy(
                ADORepositoryFactory.CreateADORepository(nhibernateSessionContainer)
            );
        }

        private Action<IPersistenceValidationContext> DefaultInitializationAction()
        {
            return persistenceValidationContext =>
            {
                persistenceValidationContext.AddFromAssembly(
                    ValidationAssembly ?? Assembly.GetExecutingAssembly()
                );
            };
        }



        public IADOPersister CreateADOPersister()
        {
            return CreateADOPersister(null, null);
        }

        public IADOPersister CreateADOPersister(IInitializationStrategy initializationStrategy)
        {
            return CreateADOPersister(initializationStrategy, null);
        }

        public IADOPersister CreateADOPersister(Action<IPersistenceValidationContext> initializationAction)
        {
            return CreateADOPersister(null, initializationAction);
        }

        public IADOPersister CreateADOPersister(IInitializationStrategy initializationStrategy, Action<IPersistenceValidationContext> initializationAction)
        {
            var adoPersister = new global::NHibernateContext.ADOPersister.ADOPersister(NHibernateSessionManager);


            var actualInitializationStrategy = initializationStrategy ?? DefaultInitializationStrategy(adoPersister);
            var actualInitializationAction = initializationAction ?? DefaultInitializationAction();


            var persistenceValidationContext = new PersistenceValidationContext(actualInitializationStrategy);

            actualInitializationAction.Invoke(persistenceValidationContext);

            persistenceValidationContext.EnsureNotEmpty();


            adoPersister.Apply(persistenceValidationContext);

            return adoPersister;
        }
    }
}