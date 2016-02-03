using NHibernate;

namespace NHibernateContext.NHSessionContainers.Common
{
    public class SimpleNHSessionContainer : INHSessionContainer
    {
        public ISession NHSession { get; private set; }


        public SimpleNHSessionContainer(ISession nhSession)
        {
            NHSession = nhSession;
        }
    }
}