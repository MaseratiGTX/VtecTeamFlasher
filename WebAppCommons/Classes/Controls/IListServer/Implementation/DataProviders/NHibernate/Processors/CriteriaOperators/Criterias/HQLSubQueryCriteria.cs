using System.Collections.Generic;
using DevExpress.Data.Filtering;

namespace WebAppCommons.Classes.Controls.IListServer.Implementation.DataProviders.NHibernate.Processors.CriteriaOperators.Criterias
{
    public class HQLSubQueryCriteria
    {
        public string QueryTemplate { get; set; }
        public List<ConstantValue> Parameters { get; set; }
    }
}