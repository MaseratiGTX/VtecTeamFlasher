using System.Collections.Generic;
using Commons.Helpers.Comparasion;
using DevExpress.Data;
using WebAppCommons.Classes.Controls.IListServer.Implementation.Helpers;

namespace WebAppCommons.Classes.Controls.IListServer.Implementation.DataProviders.NHibernate.QueryInfo
{
    public class TOTALQueryInfo
    {
        public string TOTALQuery { get; set; }

        public List<ServerModeSummaryDescriptor> SummaryDescriptors { get; set; }



        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (obj.GetType() != GetType()) return false;

            return Equals((TOTALQueryInfo)obj);
        }

        protected bool Equals(TOTALQueryInfo obj)
        {
            return TOTALQuery.AreEqual(obj.TOTALQuery) &&
                SummaryDescriptors.AreEqual(obj.SummaryDescriptors, new ServerModeSummaryDescriptorEqualityComparer()); //ServerModeSummaryDescriptor реализует сравнение Equals "по умолчанию" которое НЕ подходит для сранения элементов коллекции
        }
    }
}