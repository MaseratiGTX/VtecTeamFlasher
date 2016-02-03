using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.SqlCommand;

namespace NHibernateContext.Helpers.Criterion
{
    public static class ProjectionExtensions
    {
        public static SqlString GetColumnName(this IProjection projection, ICriteria criteria, ICriteriaQuery criteriaQuery, IDictionary<string, IFilter> enabledFilters)
        {
            return SqlStringHelper.RemoveAsAliasesFromSql(
                projection.ToSqlString(criteria, criteriaQuery.GetIndexForAlias(), criteriaQuery, enabledFilters)
            );
        }
    }
}