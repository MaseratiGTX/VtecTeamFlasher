using System;
using NHibernate;
using NHibernate.Engine;
using NHibernate.Type;

namespace NHibernateContext.Helpers.Criterion
{
    public static class TypedValueExtensions
    {
        public static TypedValue ToTypedValue<T>(this T source)
        {
            return source.ToTypedValue(x => NHibernateUtil.GuessType(x));
        }

        public static TypedValue ToTypedValue<T>(this T source, Func<T, IType> typeFunction)
        {
            return new TypedValue(
                typeFunction.Invoke(source),
                source,
                EntityMode.Poco
            );
        }
    }
}