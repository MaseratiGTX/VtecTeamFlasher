using NHibernate;

namespace WebAppCommons.Classes.Controls.IListServer.Implementation.DataProviders.NHibernate.DataQueryProviders
{
    public class NHibernateDataQueryProvider
    {
        public ISession NHSession { get; private set; }


        public NHibernateDataQueryProvider(ISession nhSession)
        {
            NHSession = nhSession;
        }


        public NHibernateDataQuery CreateQuery(string queryString)
        {
            return new NHibernateDataQuery(NHSession).SetQueryString(queryString);
        }
    }
}