using NHibernate;
using NHibernateContext.Core.Managers;
using NHibernateContext.NHSessionContainers;

namespace NHibernateContext.ADORepository
{
    public class ADORepositoryFactory
    {
        public NHibernateSessionManager NHibernateSessionManager { get; private set; }


        public ADORepositoryFactory(NHibernateSessionManager nHibernateSessionManager)
        {
            NHibernateSessionManager = nHibernateSessionManager;
        }


        public IADORepository CreateADORepository()
        {
            return CreateADORepository(FlushMode.Never, true);
        }

        public IADORepository CreateADORepository(FlushMode flushMode)
        {
            return CreateADORepository(flushMode, null);
        }

        public IADORepository CreateADORepository(FlushMode flushMode, bool? defaultReadOnly)
        {
            return CreateADORepository(
                NHibernateSessionManager.OpenSession(flushMode, defaultReadOnly)
            );
        }


        public static IADORepository CreateADORepository(INHSessionContainer nhibernateSessionContainer)
        {
            return new global::NHibernateContext.ADORepository.ADORepository(nhibernateSessionContainer);
        }

        public static IADORepository CreateADORepository(ISession nhibernateSession)
        {
            return new global::NHibernateContext.ADORepository.ADORepository(nhibernateSession);
        }
    }
}