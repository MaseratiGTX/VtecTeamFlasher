using System;

namespace NHibernateContext.CustomQuery.Select
{
    public static class InConditionMethodContainer
    {

        // ��������: �� �������� ������� ������ ������� ������ "NHibernateQueryBuilder" 
        // (��. ���������� ��������� ������� ������� ���� "IN" � "TransformWhereExpressionToHQL")
        public const string IsInMethodName = "IsIn";
        public static bool IsIn<T>(this T source, params T[] parameters)
        {
            throw new NotImplementedException();
        }



        // ��������: �� �������� ������� ������ ������� ������ "NHibernateQueryBuilder" 
        // (��. ���������� ��������� ������� ������� ���� "NOT IN" � "TransformWhereExpressionToHQL")
        public const string IsNotInMethodName = "IsNotIn";
        public static bool IsNotIn<T>(this T source, params T[] parameters)
        {
            throw new NotImplementedException();
        }
    }
}