using System;
using System.Linq;
using System.Linq.Expressions;
using NHibernate;
using NHibernate.Linq;
using NHibernateContext.NHSessionContainers;
using NHibernateContext.NHSessionContainers.Common;

namespace NHibernateContext.ADORepository
{
    public class ADORepository : IADORepository
    {
        protected INHSessionContainer NHSessionContainer { get; set; }


        public ISession NHSession
        {
            get { return NHSessionContainer.NHSession; }
        }



        public ADORepository(INHSessionContainer nhibernateSessionContainer)
        {
            NHSessionContainer = nhibernateSessionContainer;
        }

        public ADORepository(ISession nhibernateSession)
        {
            NHSessionContainer = new SimpleNHSessionContainer(nhibernateSession);
        }
        


        public bool Contains(object obj)
        {
            return NHSession.Contains(obj);
        }

        public T Evict<T>(T obj)
        {
            NHSession.Evict(obj);
            
            return obj;
        }


        public object Get(Type clazz, object id)
        {
            return NHSession.Get(clazz, id);
        }

        public object Get(Type clazz, object id, LockMode lockMode)
        {
            return NHSession.Get(clazz, id, lockMode);
        }

        public T Get<T>(object id)
        {
            return NHSession.Get<T>(id);
        }

        public T Get<T>(object id, LockMode lockMode)
        {
            return NHSession.Get<T>(id, lockMode);
        }


        public void Lock(object obj, LockMode lockMode)
        {
            NHSession.Lock(obj, lockMode);
        }

        public LockMode GetCurrentLockMode(object obj)
        {
            return NHSession.GetCurrentLockMode(obj);
        }


        public bool Refresh(object obj)
        {
            try
            {
                NHSession.Refresh(obj);
                
                return true;
            }
            catch (UnresolvableObjectException)
            {
                return false;
            }
        }

        public bool Refresh(object obj, LockMode lockMode)
        {
            try
            {
                NHSession.Refresh(obj, lockMode);

                return true;
            }
            catch (UnresolvableObjectException)
            {
                return false;
            }
        }


        public IQuery CreateQuery(string queryString)
        {
            return NHSession.CreateQuery(queryString);
        }

        public ISQLQuery CreateSQLQuery(string queryString)
        {
            return NHSession.CreateSQLQuery(queryString);
        }


        public IQueryable<T> Filter<T>() where T : class
        {
            return NHSession.Query<T>();
        }

        public IQueryable<T> FilterBy<T>(Expression<Func<T, bool>> expression) where T : class
        {
            return Filter<T>().Where(expression);
        }

        public T FindBy<T>(Expression<Func<T, bool>> expression) where T : class
        {
            return FilterBy(expression).SingleOrDefault();
        }
    }
}