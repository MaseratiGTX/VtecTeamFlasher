using System.Collections.Generic;

namespace WebAppCommons.Classes.Controls.IListServer.Implementation.DataProviders.NHibernate.Processors.InterpritationResults
{
    public abstract class BaseInterpritationResult
    {
        public string ResultString { get; set; }

        public List<JoinContext> UsedJOINS { get; set; }
    }
}