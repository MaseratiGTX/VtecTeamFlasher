using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using NHibernateContext.ADORepository;

namespace ClientAndServerCommons
{
    public static class BaseFetchingHelper
    {
        public static IQueryable<T> Entities<T>(this IADORepository source) where T : class
        {
            return source.Filter<T>();
        }


        public static IQueryable<T> ThatHas<T>(this IQueryable<T> source, Expression<Func<T, bool>> predicate)
        {
            return source.Where(predicate);
        }

        public static IEnumerable<T> ThatHas<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            return source.Where(predicate);
        }
    }
}