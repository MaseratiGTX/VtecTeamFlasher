using DevExpress.Data.Filtering;

namespace WebAppCommons.Classes.Controls.IListServer.Implementation.DataProviders.NHibernate.Processors.CriteriaOperators
{
    public class FirstNbytesOperandOperator : OperandProperty
    {
        public const string OPERAND_PREFIX = "[FIRST_NBYTES]";
        public const char DELIMETER = '|';

        public FirstNbytesOperandOperator(string propertyName, int length)
            : base(OPERAND_PREFIX + propertyName + DELIMETER + length)
        {
        }
    }
}
