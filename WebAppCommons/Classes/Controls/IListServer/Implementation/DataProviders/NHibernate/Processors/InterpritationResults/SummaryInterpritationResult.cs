using System.Collections.Generic;
using DevExpress.Data;

namespace WebAppCommons.Classes.Controls.IListServer.Implementation.DataProviders.NHibernate.Processors.InterpritationResults
{
    public class SummaryInterpritationResult : BaseInterpritationResult
    {
        public List<ServerModeSummaryDescriptor> PermanentSummaryDescriptors { get; set; }
        public List<ServerModeSummaryDescriptor> ExternalSummaryDescriptors { get; set; }

        public List<ServerModeSummaryDescriptor> SummaryDescriptors { get; set; }
    }
}