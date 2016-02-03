using System.Collections.Generic;
using System.Linq;
using Commons.Helpers.Collections.Generic;
using DevExpress.Data.Filtering;

namespace WebAppCommons.Classes.Controls.IListServer.Implementation.DataProviders.NHibernate.Processors.CriteriaOperators
{
    public class HQLInCriteriaOperator : InOperator
    {
        public HQLInCriteriaOperator(string propertyName, string hqlQuery, params object[] parameters)
            : base(
                propertyName,
                new List<CriteriaOperator>()
                    .AddItem(new ConstantValue("[HQL SUBQUERY]"))
                    .AddItem(new ConstantValue(hqlQuery))
                    .AddItems(parameters.Select(x => new ConstantValue(x)))
                    .ToArray()
            )
        {
        }
    }
}