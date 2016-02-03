using System;

namespace NHibernateContext.CustomQuery.Select
{
    public static class InConditionMethodContainer
    {

        // ВНИМАНИЕ: От названия данного метода зависит работа "NHibernateQueryBuilder" 
        // (см. реализацию обработки условия выборки типа "IN" в "TransformWhereExpressionToHQL")
        public const string IsInMethodName = "IsIn";
        public static bool IsIn<T>(this T source, params T[] parameters)
        {
            throw new NotImplementedException();
        }



        // ВНИМАНИЕ: От названия данного метода зависит работа "NHibernateQueryBuilder" 
        // (см. реализацию обработки условия выборки типа "NOT IN" в "TransformWhereExpressionToHQL")
        public const string IsNotInMethodName = "IsNotIn";
        public static bool IsNotIn<T>(this T source, params T[] parameters)
        {
            throw new NotImplementedException();
        }
    }
}