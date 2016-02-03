using System.Collections.Generic;
using Commons.Helpers.Comparasion;
using DevExpress.Data;

namespace WebAppCommons.Classes.Controls.IListServer.Implementation.Helpers
{
    public class ServerModeSummaryDescriptorEqualityComparer : IEqualityComparer<ServerModeSummaryDescriptor>
    {
        public bool Equals(ServerModeSummaryDescriptor x, ServerModeSummaryDescriptor y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }

            if ((x == null) || (y == null))
            {
                return false;
            }

            if (x.GetType() != y.GetType())
            {
                return false;
            }

            return x.SummaryType == y.SummaryType &&
                x.SummaryExpression.AreEqual(y.SummaryExpression); //CriteriaOperator имеет перегруженный метод Equals который вполне подходит для сранения элементов
        }

        public int GetHashCode(ServerModeSummaryDescriptor obj)
        {
            throw new System.NotImplementedException();
        }
    }
}