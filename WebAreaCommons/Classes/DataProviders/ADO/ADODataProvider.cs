using ClientAndServerCommons;
using NHibernateContext.ADORepository;
using WebAppCommons.Classes.Controls.IListServer.Implementation.DataProviders.NHibernate;

namespace WebAreaCommons.Classes.DataProviders.ADO
{
    public class ADODataProvider<TSource> : NHibernateDataProviderSimple<TSource> where TSource : AbstractDataObject
    {
        public ADODataProvider(IADORepository ADORepository, params object[] parameters) : base(ADORepository, parameters)
        {
        }
    }
}