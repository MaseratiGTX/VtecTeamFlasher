using System.Collections.Generic;
using NHibernateContext.ADORepository;

namespace WebAppCommons.Classes.Controls.IListServer.Implementation.DataProviders.NHibernate
{
    public class NHibernateDataProviderSimple<TSource> : NHibernateDataProviderBase<TSource, TSource>
        where TSource : class
    {
        protected NHibernateDataProviderSimple(IADORepository ADORepository, params object[] parameters)
            : base(ADORepository, parameters)
        {
        }

        protected override IEnumerable<TSource> FetchingPostProcess(IList<TSource> source)
        {
            return source;
        }
    }
}