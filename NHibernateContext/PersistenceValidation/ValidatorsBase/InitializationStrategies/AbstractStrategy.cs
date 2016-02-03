using System;
using NHibernateContext.ADORepository;

namespace NHibernateContext.PersistenceValidation.ValidatorsBase.InitializationStrategies
{
    public abstract class AbstractStrategy : IInitializationStrategy
    {
        public IADORepository ADORepository { get; private set; }


        
        protected AbstractStrategy(IADORepository adoRepository)
        {
            ADORepository = adoRepository;
        }



        public abstract IPersistenceValidator Initialize(Type validatorType);


        protected IPersistenceValidator CreateInstance(Type validatorType)
        {
            return (IPersistenceValidator) Activator.CreateInstance(validatorType, ADORepository);
        }
    }
}