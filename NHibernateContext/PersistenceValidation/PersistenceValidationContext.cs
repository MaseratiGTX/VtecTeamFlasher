using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Commons.Exceptions;
using Commons.Helpers.Objects;
using Commons.Reflections;
using NHibernateContext.Helpers;
using NHibernateContext.PersistenceValidation.ValidatorsBase;
using NHibernateContext.PersistenceValidation.ValidatorsBase.InitializationStrategies;

namespace NHibernateContext.PersistenceValidation
{
    public class PersistenceValidationContext : IPersistenceValidationContext
    {
        private IDictionary<Type, Type> PersistenceValidatorsMap { get; set; }

        public IInitializationStrategy InitializationStrategy { get; private set; }

        public List<Type> AvailableEntityTypes
        {
            get { return PersistenceValidatorsMap.Keys.ToList(); }
        }



        public PersistenceValidationContext(IInitializationStrategy initializationStrategy)
        {
            PersistenceValidatorsMap = new Dictionary<Type, Type>();
            
            InitializationStrategy = initializationStrategy;
        }



        public IPersistenceValidationContext Add(Type validatorType)
        {
            EnsureThat(validatorType.IsNotNull(), "Переданный тип validatorType не может быть NULL.");
            EnsureThat(validatorType.IsAssignableTo<IPersistenceValidator>(), "Переданный тип validatorType должен реализовывать интерфейс 'IPersistenceValidator'.");

            AddIPersistenceValidatorInternal(validatorType);

            return this;
        }

        public IPersistenceValidationContext Add<T>() where T : IPersistenceValidator
        {
            AddIPersistenceValidatorInternal(typeof(T));

            return this;
        }

        public IPersistenceValidationContext AddFromAssembly(Assembly assembly)
        {
            AddPersistenceValidatorsInternal(
                assembly
                    .GetTypes()
                    .Where(x => x.IsAssignableTo<IPersistenceValidator>())
                    .Where(x => x.IsPublic)
                    .Where(x => x.IsAbstract == false)
                    .Where(x => x.IsClass)
                    .Where(x => x.IsGenericType == false)
                    .OrderBy(x => x.FullName)
            );

            return this;
        }

        public IPersistenceValidationContext AddFromAssemblyOf<T>() where T : class
        {
            return AddFromAssembly(typeof (T).Assembly);
        }


        private void AddIPersistenceValidatorInternal(Type validatorType)
        {
            EnsureThat(validatorType.IsPublic, "Переданный тип validatorType должен являться публичным.");
            EnsureThat(validatorType.IsAbstract == false, "Переданный тип validatorType не должен являться абстрактным.");
            EnsureThat(validatorType.IsClass, "Переданный тип validatorType должен являться классом.");
            EnsureThat(validatorType.IsGenericType == false, "Переданный тип validatorType не должен являться 'GenericType'.");

            AddPersistenceValidatorInternal(validatorType);
        }

        private void AddPersistenceValidatorInternal(Type validatorType)
        {
            var entityType = FetchEntityType(validatorType);

            EnsureThat(entityType.IsNotNull(), "Не можем получить тип entity из переданного validatorType.");
            
            AddInternal(entityType, validatorType);
        }

        private void AddPersistenceValidatorsInternal(IEnumerable<Type> validatorTypes)
        {
            foreach (var validatorType in validatorTypes)
            {
                var entityType = FetchEntityType(validatorType);
                
                if (entityType.IsNotNull())
                {
                    AddInternal(entityType, validatorType);
                }
            }

        }

        private void AddInternal(Type entityType, Type validatorType)
        {
            if(PersistenceValidatorsMap.ContainsKey(entityType))
            {
                PersistenceValidatorsMap[entityType] = validatorType;
            }
            else
            {
                PersistenceValidatorsMap.Add(entityType, validatorType);
            }
        }


        private Type FetchEntityType(Type validatorType)
        {
            var currentType = validatorType;

            while (currentType != null)
            {
                if(currentType.IsGenericType)
                {
                    if(currentType.GetGenericTypeDefinition() == typeof (BasePersistenceValdator<>))
                    {
                        return currentType.GetGenericArguments()[0];
                    }
                }

                currentType = currentType.BaseType;
            }

            return null;
        }



        public bool HasContextFor(Type entityType)
        {
            return PersistenceValidatorsMap.ContainsKey(entityType);
        }

        public bool HasContextFor<T>()
        {
            return HasContextFor(typeof (T));
        }

        public bool HasContextFor<T>(T entity)
        {
            return HasContextFor(entity.GetType());
        }



        public IPersistenceValidator ProvideValidatorFor(Type entityType)
        {
            if(HasContextFor(entityType))
            {
                ProvideValidatorInternal(entityType);
            }

            return null;
        }

        public IPersistenceValidator ProvideValidatorFor<T>() where T : class
        {
            return ProvideValidatorFor(typeof(T));
        }

        public IPersistenceValidator ProvideValidatorFor<T>(T entity) where T : class
        {
            var entityType = GetEntityActualType(entity);

            EnsureThat(
                HasContextFor(entityType),
                "Не имеем контекста валидации для переданной сущности: '{0}'.",
                entityType.FullName
            );
            
            return ProvideValidatorInternal(entityType).Validate(entity);    
        }

        private Type GetEntityActualType<T>(T entity)
        {
            //TODO: постараться избавится от этого "костыля"

            if (entity.IsProxy())
            {
                return entity.GetType().BaseType;
            }

            return entity.GetType();
        }


        private IPersistenceValidator ProvideValidatorInternal(Type entityType)
        {
            var entityValidatorType = PersistenceValidatorsMap[entityType];

            return InitializationStrategy.Initialize(entityValidatorType);
        }



        public IPersistenceValidationContext EnsureNotEmpty()
        {
            EnsureThat(
                PersistenceValidatorsMap.Count != 0, 
                "В PersistenceValidationContext отсутствуют какие-либо PersistenceValidator: " +
                "вероятно инициализация ADOPersister не проводилась или была проведена некорректно."
            );

            return this;
        }


        public IPersistenceValidator Validate<T>(T entity) where T : class
        {
            return ProvideValidatorFor(entity);
        }



        // ReSharper disable UnusedParameter.Local
        private void EnsureThat(bool condition, string messageFormat, params object[] messageArgs)
        {
            if (condition == false)
            {
                throw new FormattedException(messageFormat, messageArgs);
            }
        }
        // ReSharper restore UnusedParameter.Local
    }
}