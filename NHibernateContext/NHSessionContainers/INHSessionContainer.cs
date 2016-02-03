using NHibernate;

namespace NHibernateContext.NHSessionContainers
{
    public interface INHSessionContainer
    {
        ISession NHSession { get; } 
    }
}