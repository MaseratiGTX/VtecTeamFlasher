using System.Collections;
using System.Collections.Generic;
using NHibernate;
using NHibernateContext.CustomQuery.Select;
using NHibernateContext.CustomQuery.Select.LockingModes;

namespace NHibernateContext.CustomQuery.Helpers
{
    public static class IQueryExtensions
    {
        public static IQuery WithParameters(this IQuery source, List<NamedParameter> parameters)
        {
            foreach (var parameter in parameters)
            {
                if(parameter.Value is ICollection)
                {
                    source.SetParameterList(parameter.Name, (ICollection) parameter.Value);
                }
                else
                {
                    source.SetParameter(parameter.Name, parameter.Value);
                }
            }
        
            return source;
        }

        public static IQuery WithLockMode(this IQuery source, string alias, LockingHints lockHints)
        {
            if (lockHints == null) return source;

            return source.SetLockMode(alias, lockHints.TransformToLockMode());
        }

        public static IQuery WithMaxResultCount(this IQuery source, int? maxResultsCount)
        {
            if (maxResultsCount.HasValue == false) return source;

            return source.SetMaxResults(maxResultsCount.Value);
        }
    }
}