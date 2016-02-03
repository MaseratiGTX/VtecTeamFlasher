using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Commons.Helpers.Collections.Generic;
using Commons.Helpers.Objects;
using Commons.Logging;
using Commons.Validation.Exceptions;
using NHibernate;
using NHibernateContext.Core.Managers;
using NHibernateContext.Helpers;
using NHibernateContext.PersistenceValidation;

namespace NHibernateContext.ADOPersister
{
    public class ADOPersister : IADOPersister
    {
        public NHibernateSessionManager NHibernateSessionManager { get; private set; }
        public IPersistenceValidationContext PersistenceValidationContext { get; private set; }

        public ISession NHSession { get; private set; }


        public List<Type> AvailableEntityTypes
        {
            get { return PersistenceValidationContext.AvailableEntityTypes; }
        }



        public ADOPersister(NHibernateSessionManager nHibernateSessionManager) : this(nHibernateSessionManager, null)
        {
        }

        public ADOPersister(NHibernateSessionManager nHibernateSessionManager, IPersistenceValidationContext persistenceValidationContext)
        {
            NHibernateSessionManager = nHibernateSessionManager;
            PersistenceValidationContext = persistenceValidationContext;
            
            Begin();            
        }



        public void Apply(IPersistenceValidationContext persistenceValidationContext)
        {
            PersistenceValidationContext = persistenceValidationContext;
        }


        public void Begin()
        {
            if (NHSession.IsNull())
            {
                NHSession = NHibernateSessionManager.OpenSession(FlushMode.Commit);
            }

            if(NHSession.Transaction.IsActive == false)
            {
                NHSession.Transaction.Begin(IsolationLevel.ReadCommitted);
            }
        }

        public void Commit()
        {
            if (NHSession.IsNotNull())
            {
                if (NHSession.Transaction.IsActive)
                {
                    NHSession.Transaction.Commit();
                    NHSession.Transaction.Begin(IsolationLevel.ReadCommitted);
                }
                else
                {
                    throw new Exception("Не можем произвести Commit(): текущая транзакция у NHSession не активна.");
                }
            }
            else
            {
                throw new Exception("Нет информации о текущей NHSession: по всей видимости не был вызван Begin() после отката транзакции.");
            }
        }

        public void Rollback()
        {
            if (NHSession.IsNotNull())
            {
                if (NHSession.Transaction.IsActive)
                {
                    NHSession.Transaction.Rollback();
                }
                else
                {
                    throw new Exception("Не можем произвести Rollback(): текущая транзакция у NHSession не активна.");
                }

                NHSession.Close();
                NHSession.Dispose();
                NHSession = null;
            }
            else
            {
                throw new Exception("Нет информации о текущей NHSession: по всей видимости не был вызван Begin() после отката транзакции.");
            }
        }


        public void ExecuteAsSingle(Action<IADOPersister> action)
        {
            ExecuteAsSingle<object>(x =>
                {
                    action.Invoke(x);
                    
                    return null;
                }
            );
        }

        public T ExecuteAsSingle<T>(Func<IADOPersister, T> function)
        {
            try
            {
                Begin();

                var result = function.Invoke(this);

                Commit();

                return result;
            }
            catch(ValidationException)
            {
                Rollback();
                
                throw;
            }
            catch(Exception ex)
            {
                Rollback();

                Log.Error("Во время выполнения ADOPersister.ExecuteAsSingle возникла ошибка:\r\n{0}", ex);

                throw;
            }
        }


        public T Save<T>(T entity, string validationContext = null) where T : class 
        {
            try
            {
                entity = entity.Unproxy();

                if (PersistenceValidationContext.Found())
                {
                    PersistenceValidationContext.Validate(entity).OnSave();    
                }

                return NHSession.Merge(entity);
            }
            catch(ValidationException ex)
            {
                if (validationContext.Found())
                {
                    ex.FieldName = validationContext + (ex.FieldName.IsNotEmpty() ? "." + ex.FieldName : null);
                }

                throw;
            }
            catch(Exception ex)
            {
                Log.Error("При попытке сохранения объекта в БД возникла ошибка:\r\n{0}", ex);

                throw;
            }
        }

        public IEnumerable<T> Save<T>(IEnumerable<T> entities) where T : class
        {
            return entities.Select(x => Save(x)).ToList();
        }


        public void Delete<T>(T entity) where T : class
        {
            if(entity == null) return;

            try
            {
                entity = entity.Unproxy();

                if (PersistenceValidationContext.Found())
                {
                    PersistenceValidationContext.Validate(entity).OnDelete();
                }

                NHSession.Delete(
                    NHSession.Merge(entity)
                );
            }
            catch (ValidationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                Log.Error("При попытке сохранения объекта в БД возникла ошибка:\r\n{0}", ex);

                throw;
            }
        }

        public void Delete<T>(IEnumerable<T> entities) where T : class
        {
            entities.Each(Delete);
        }
    }
}