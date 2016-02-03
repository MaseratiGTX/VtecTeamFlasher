using System.Linq;
using Commons.Helpers.Objects;
using DevExpress.Data.Filtering;

namespace WebAppCommons.Classes.Controls.IListServer.Implementation.DataProviders.NHibernate.Processors.CriteriaOperators.Criterias.Parsers
{
    public class HQLSubQueryCriteriaParser
    {
        public const string HQL_SUBQUERY_MARKER = "[HQL SUBQUERY]";


        public HQLSubQueryCriteria Parse(CriteriaOperatorCollection operands)
        {
            if (operands.IsEmpty())
            {
                return null;
            }

            if (operands.All(x => x is ConstantValue) == false)
            {
                return null;
            }

            var constantValues = operands.Cast<ConstantValue>().ToList();

            if (constantValues.Count < 2)
            {
                return null;
            }


            var markerOperand = constantValues[0];

            if (markerOperand.Value.Equals(HQL_SUBQUERY_MARKER) == false)
            {
                return null;
            }


            var bodyOperand = constantValues[1];

            if (bodyOperand.Value is string == false)
            {
                return null;
            }


            var parameterOperands = constantValues.Skip(2).ToList();


            return new HQLSubQueryCriteria
            {
                QueryTemplate = bodyOperand.Value.As<string>(),
                Parameters = parameterOperands
            };
        }
    }
}