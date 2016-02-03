using Commons.Helpers.Collections.Generic;
using DevExpress.Data.Filtering;

namespace WebAppCommons.Classes.Controls.IListServer.Implementation.DataProviders.NHibernate.Processors.CriteriaOperators
{
    public class ConcatOperandOperator : OperandProperty
    {
        public const string OPERAND_PREFIX = "[CONCAT_OPERAND]";
        public const char PROPERTY_DELIMETER = '|';

        public ConcatOperandOperator(params string[] propertyNames)
            : base(OPERAND_PREFIX + propertyNames.ToString(x => x, PROPERTY_DELIMETER.ToString()))
        {
        }
    }
}