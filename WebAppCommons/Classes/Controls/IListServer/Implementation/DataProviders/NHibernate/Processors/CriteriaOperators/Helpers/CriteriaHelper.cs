using System.Collections.Generic;
using System.Linq;
using Commons.Helpers.Collections.Generic;
using Commons.Helpers.Objects;
using DevExpress.Data.Filtering;

namespace WebAppCommons.Classes.Controls.IListServer.Implementation.DataProviders.NHibernate.Processors.CriteriaOperators.Helpers
{
    public static class CriteriaHelper
    {
        public static CriteriaOperator ToGroup(this IEnumerable<CriteriaOperator> source, GroupOperatorType groupOperatorType)
        {
            return Concat(groupOperatorType, source.ToArray());
        }

        public static CriteriaOperator Concat(GroupOperatorType groupOperatorType, params CriteriaOperator[] operators)
        {
            var actualSource = operators.EvictNull().ToList();

            if (actualSource.IsEmpty()) return null;

            if (actualSource.Count == 1) return actualSource[0];

            return new GroupOperator(groupOperatorType, actualSource);
        }


        public static CriteriaOperator Concat(this CriteriaOperator source, CriteriaOperator anotherCriteria, GroupOperatorType groupOperatorType)
        {
            return Concat(groupOperatorType, source, anotherCriteria);
        }

        public static CriteriaOperator ConcatAnd(this CriteriaOperator source, CriteriaOperator anotherCriteria)
        {
            return source.Concat(anotherCriteria, GroupOperatorType.And);
        }

        public static CriteriaOperator ConcatOr(this CriteriaOperator source, CriteriaOperator anotherCriteria)
        {
            return source.Concat(anotherCriteria, GroupOperatorType.Or);
        }



        public static BinaryOperator BinaryOperand(string propertyName, BinaryOperatorType binaryOperatorType, object value)
        {
            return new BinaryOperator(new OperandProperty(propertyName), new ConstantValue(value), binaryOperatorType);
        }

        public static GroupOperator GroupOperand(GroupOperatorType type, params CriteriaOperator[] operands)
        {
            return new GroupOperator(type, operands);
        }
    }
}