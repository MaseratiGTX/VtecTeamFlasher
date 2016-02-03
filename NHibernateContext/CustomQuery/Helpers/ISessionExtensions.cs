using System;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Persister.Entity;
using NHibernateContext.CustomQuery.Select;

namespace NHibernateContext.CustomQuery.Helpers
{
    public static class ISessionExtensions
    {
        public static SelectQuery<T> Select<T>(this ISession session) where T : class
        {
            return new SelectQuery<T>(session);
        }

        public static IList<T> ExecuteSQL<T>(this ISession source, string sql, params object[] parameters)
        {
            return source.CreateSQLQuery(string.Format(sql, parameters)).List<T>();
        }


        public static string GetRootTableName(this ISession source, Type entityType)
        {
            return source.SessionFactory.GetRootTableName(entityType);
        }

        public static string GetRootTableName(this ISessionFactory source, Type entityType)
        {
            return ((ILockable) source.GetClassMetadata(entityType)).RootTableName;
        }
    }
}