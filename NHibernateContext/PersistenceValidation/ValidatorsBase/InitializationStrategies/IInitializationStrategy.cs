using System;

namespace NHibernateContext.PersistenceValidation.ValidatorsBase.InitializationStrategies
{
    public interface IInitializationStrategy
    {
        IPersistenceValidator Initialize(Type validatorType);
    }
}