using System.Collections.Generic;
using Commons.Helpers.Comparasion;
using DevExpress.Data;
using DevExpress.Data.Filtering;
using WebAppCommons.Classes.Controls.IListServer.Implementation.Helpers;

namespace WebAppCommons.Classes.Controls.IListServer.Implementation.DataProviders.NHibernate.QueryInfo
{
    public class GROUPQueryInfo
    {
        public string GROUPQuery { get; set; }
        public string GROUPORDERQuery { get; set; }

        public List<OperandProperty> PropertyExpressions { get; set; }
        public List<ServerModeSummaryDescriptor> SummaryDescriptors { get; set; }


        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (obj.GetType() != GetType()) return false;

            return Equals((GROUPQueryInfo)obj);
        }

        protected bool Equals(GROUPQueryInfo obj)
        {
            return GROUPQuery.AreEqual(obj.GROUPQuery) &&
                   GROUPORDERQuery.AreEqual(obj.GROUPORDERQuery) &&
                   PropertyExpressions.AreEqual(obj.PropertyExpressions) && //OperandProperty имеет перегруженный метод Equals который вполне подходит для сранения элементов коллекции
                   SummaryDescriptors.AreEqual(obj.SummaryDescriptors, new ServerModeSummaryDescriptorEqualityComparer()); //ServerModeSummaryDescriptor реализует сравнение Equals "по умолчанию" которое НЕ подходит для сранения элементов коллекции
        }
    }
}