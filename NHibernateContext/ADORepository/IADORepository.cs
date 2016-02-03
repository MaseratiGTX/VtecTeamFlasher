using System;
using System.Linq;
using System.Linq.Expressions;
using NHibernate;
using NHibernateContext.NHSessionContainers;

namespace NHibernateContext.ADORepository
{
    public interface IADORepository : INHSessionContainer
    {
        bool Contains(object obj);
        T Evict<T>(T obj);

        object Get(Type clazz, object id);
        object Get(Type clazz, object id, LockMode lockMode);
        T Get<T>(object id);
        T Get<T>(object id, LockMode lockMode);

        void Lock(object obj, LockMode lockMode);
        LockMode GetCurrentLockMode(object obj);

        bool Refresh(object obj);
        bool Refresh(object obj, LockMode lockMode);

        IQuery CreateQuery(string queryString);
        ISQLQuery CreateSQLQuery(string queryString);

        IQueryable<T> Filter<T>() where T : class;
        IQueryable<T> FilterBy<T>(Expression<Func<T, bool>> expression) where T : class;
        T FindBy<T>(Expression<Func<T, bool>> expression) where T : class;
    }
}