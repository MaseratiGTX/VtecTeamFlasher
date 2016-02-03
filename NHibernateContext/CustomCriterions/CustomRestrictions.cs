using System;
using System.Linq.Expressions;
using NHibernate.Criterion;

namespace NHibernateContext.CustomCriterions
{
    public static class CustomRestrictions
    {
        public static AbstractCriterion Eq(IProjection projection, byte[] value)
        {
            if (value == null)
            {
                return Restrictions.IsNull(projection);
            }

            return new SimpleByteExpression(projection, " = ", value);
        }

        public static AbstractCriterion Eq(string propertyName, byte[] value)
        {
            return Eq(Projections.Property(propertyName), value);
        }

        public static AbstractCriterion Eq(Expression<Func<object>> expression, byte[] value)
        {
            return Eq(Projections.Property(expression), value);
        }

        public static AbstractCriterion Eq<T>(Expression<Func<T, object>> expression, byte[] value)
        {
            return Eq(Projections.Property(expression), value);
        }
    }
}