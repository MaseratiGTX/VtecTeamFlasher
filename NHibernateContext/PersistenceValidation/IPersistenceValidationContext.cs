using System;
using System.Collections.Generic;
using System.Reflection;
using NHibernateContext.PersistenceValidation.ValidatorsBase;

namespace NHibernateContext.PersistenceValidation
{
    public interface IPersistenceValidationContext
    {
        List<Type> AvailableEntityTypes { get; }

        IPersistenceValidationContext Add(Type validatorType);
        IPersistenceValidationContext Add<T>() where T: IPersistenceValidator;
        IPersistenceValidationContext AddFromAssembly(Assembly assembly);
        IPersistenceValidationContext AddFromAssemblyOf<T>() where T : class;

        bool HasContextFor(Type entityType);
        bool HasContextFor<T>();
        bool HasContextFor<T>(T entity);

        IPersistenceValidator ProvideValidatorFor(Type entityType);
        IPersistenceValidator ProvideValidatorFor<T>() where T : class;
        IPersistenceValidator ProvideValidatorFor<T>(T entity) where T : class;

        IPersistenceValidationContext EnsureNotEmpty();

        IPersistenceValidator Validate<T>(T entity) where T : class;
    }
}