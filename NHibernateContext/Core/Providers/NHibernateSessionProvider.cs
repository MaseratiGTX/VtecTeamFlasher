using NHibernate;
using NHibernateContext.Interceptors;

namespace NHibernateContext.Core.Providers
{
    public class NHibernateSessionProvider
    {
        public ISessionFactory SessionFactory { get; private set; }


        public NHibernateSessionProvider(ISessionFactory sessionFactory)
        {
            SessionFactory = sessionFactory;
        }


        public ISession OpenSession(FlushMode flushMode, bool? defaultReadOnly)
        {
            var result = SessionFactory.OpenSession(new CommonSessionLocalInterceptor());
                result.FlushMode = flushMode;

            if (defaultReadOnly.HasValue)
            {
                result.DefaultReadOnly = defaultReadOnly.Value;
            }    

            return result;
        }
    }
}