using System.Collections.Generic;
using DevExpress.Data.Filtering;

namespace WebAppCommons.Classes.Controls.IListServer.Implementation.DataProviders.NHibernate.Processors.InterpritationResults
{
    public class PropertiesCollectionProcessingResult : BaseInterpritationResult
    {
        public List<OperandProperty> PropertyExpressions { get; set; }
    }
}