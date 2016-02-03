using System;
using System.Collections.Generic;
using NHibernateContext.NHSessionContainers;
using NHibernateContext.PersistenceValidation;

namespace NHibernateContext.ADOPersister
{
    public interface IADOPersister : INHSessionContainer
    {
        IPersistenceValidationContext PersistenceValidationContext { get; }
        List<Type> AvailableEntityTypes { get; }

        void Apply(IPersistenceValidationContext persistenceValidationContext);

        void Begin();
        void Commit();
        void Rollback();

        void ExecuteAsSingle(Action<IADOPersister> action);
        T ExecuteAsSingle<T>(Func<IADOPersister, T> function);

        T Save<T>(T entity, string validationContext = null) where T : class;
        IEnumerable<T> Save<T>(IEnumerable<T> entities) where T : class;
        
        void Delete<T>(T entity) where T : class;
        void Delete<T>(IEnumerable<T> entities) where T : class;
    }
}