using System.Collections.Generic;
using System.Linq;
using ClientAndServerCommons.Interfaces;

namespace ClientAndServerCommons.Helpers
{
    public static class OthersFetchingHelper
    {
        public static IQueryable<T> Enabled<T>(this IQueryable<T> source, bool enabled = true) where T : IEnableable
        {
            return source.ThatHas(x => x.Enabled == enabled);
        }

        public static IEnumerable<T> Enabled<T>(this IEnumerable<T> source, bool enabled = true) where T : IEnableable
        {
            return BaseFetchingHelper.ThatHas(source, x => x.Enabled == enabled);
        }


        public static IQueryable<T> Of<T>(this IQueryable<T> source, EntityContext entityContext) where T : IHasEntityContext
        {
            return source.ThatHas(x => x.EntityContext.Id == entityContext.Id);
        }

        public static IEnumerable<T> Of<T>(this IEnumerable<T> source, EntityContext entityContext) where T : IHasEntityContext
        {
            return BaseFetchingHelper.ThatHas(source, x => x.EntityContext.Id == entityContext.Id);
        }
    }
}