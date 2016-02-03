using System.Linq;
using NHibernateContext.ADORepository;

namespace ClientAndServerCommons.Helpers
{
    public static class EntityContextsFetchingHelper
    {
        public static IQueryable<EntityContext> EntityContexts(this IADORepository source)
        {
            return source.EntityContexts<EntityContext>();
        }

        public static IQueryable<T> EntityContexts<T>(this IADORepository source) where T : EntityContext
        {
            return source.Entities<T>();
        }



        public static AdminAreaContext AdminAreaContext(this IADORepository source)
        {
            return source.EntityContexts<AdminAreaContext>().Single();
        }

    }
}