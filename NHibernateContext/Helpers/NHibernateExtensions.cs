using System;
using NHibernate;
using NHibernate.Proxy;

namespace NHibernateContext.Helpers
{
    public static class NHibernateExtensions
    {
        public static bool IsProxy(this object sourceEntity)
        {
            return NHibernateProxyHelper.IsProxy(sourceEntity);
        }

        public static Type GetEntityClass(this object sourceEntity)
        {
            return NHibernateUtil.GetClass(sourceEntity);
        }

        public static T Unproxy<T>(this T possibleProxy) where T : class
        {
            if (possibleProxy == null) return null;

            if (possibleProxy.IsProxy())
            {
                var lazyInitialiser = ((INHibernateProxy)possibleProxy).HibernateLazyInitializer;

                if (lazyInitialiser.IsUninitialized) lazyInitialiser.Initialize();


                var sessionImplementor = lazyInitialiser.Session;

                return sessionImplementor != null ? (T) sessionImplementor.PersistenceContext.Unproxy(possibleProxy) : possibleProxy;
            }

            return possibleProxy;
        }
    }
}