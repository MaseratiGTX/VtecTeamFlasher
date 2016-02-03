using System;
using System.Collections.Generic;
using NHibernateContext.ADORepository;

namespace NHibernateContext.PersistenceValidation.ValidatorsBase.InitializationStrategies
{
    public class CacheableStrategy : AbstractStrategy
    {
        private Dictionary<Type, IPersistenceValidator> LocalCache { get; set; }


        public CacheableStrategy(IADORepository adoRepository) : base(adoRepository)
        {
            LocalCache = new Dictionary<Type, IPersistenceValidator>();
        }


        public override IPersistenceValidator Initialize(Type validatorType)
        {
            if(LocalCache.ContainsKey(validatorType))
            {
                var validatorInstance = LocalCache[validatorType];

                validatorInstance.DropState();

                return validatorInstance;
            }
            else
            {
                var validatorInstance = CreateInstance(validatorType);

                LocalCache.Add(validatorType, validatorInstance);

                return validatorInstance;
            }
        }
    }
}