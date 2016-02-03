using System.Linq;
using NHibernateContext.ADORepository;

namespace ClientAndServerCommons
{
    public static class AbstractDataObjectFetchingHelper
    {
        public static bool IsNewEntry<T>(this T source) where T : AbstractDataObject
        {
            return source.Id == 0;
        }

        public static bool IsAlreadyPersisted<T>(this T source) where T : AbstractDataObject
        {
            return source.IsNewEntry() == false;
        }


        public static T FetchEntity<T>(this IADORepository source, T entity) where T : AbstractDataObject
        {
            return source.Entities<T>().ThatIs(entity).SingleOrDefault();
        }


        public static IQueryable<T> OtherThen<T>(this IQueryable<T> source, T entity) where T : AbstractDataObject
        {
            return entity.IsAlreadyPersisted() ? source.ThatHas(x => x.Id != entity.Id) : source;
        }

        public static IQueryable<T> Is<T>(this IQueryable<T> source, T entity) where T : AbstractDataObject
        {
            return source.ThatIs(entity);
        }

        public static IQueryable<T> ThatIs<T>(this IQueryable<T> source, T entity) where T : AbstractDataObject
        {
            return source.ThatHas(x => x.Id == entity.Id);
        }
    }
}