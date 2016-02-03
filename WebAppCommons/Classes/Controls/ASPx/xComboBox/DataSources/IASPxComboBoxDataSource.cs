using System.Collections;
using DevExpress.Web.ASPxEditors;

namespace WebAppCommons.Classes.Controls.ASPx.xComboBox.DataSources
{
    public interface IASPxComboBoxDataSource : IEnumerable
    {
        string CurrentFilter { get; }

        bool HasActual(string propertyName, object propertyValue);
        bool HasBase(string propertyName, object propertyValue);

        void ApplyFilter(string filter, IncrementalFilteringMode filteringMode, int beginIndex, int endIndex);
        void ApplyFilter(string propertyName, object propertyValue);
    }
}