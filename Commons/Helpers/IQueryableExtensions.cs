using System;
using System.Linq;
using System.Linq.Expressions;

namespace Commons.Helpers
{
    public static class IQueryableExtensions
    {
        public static bool None<T>(this IQueryable<T> source)
        {
            return source.Any() == false;
        }

        public static bool None<T>(this IQueryable<T> source, Expression<Func<T, bool>> predicate)
        {
            return source.Any(predicate) == false;
        }
    }
}