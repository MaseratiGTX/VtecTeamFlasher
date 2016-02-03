using System;
using NHibernateContext.ADORepository;

namespace NHibernateContext.PersistenceValidation.ValidatorsBase.InitializationStrategies
{
    public class CommonStrategy : AbstractStrategy
    {
        public CommonStrategy(IADORepository adoRepository) : base(adoRepository)
        {
        }


        public override IPersistenceValidator Initialize(Type validatorType)
        {
            return CreateInstance(validatorType);
        }
    }
}