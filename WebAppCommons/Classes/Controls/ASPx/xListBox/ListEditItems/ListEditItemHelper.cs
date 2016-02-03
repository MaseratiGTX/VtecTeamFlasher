using DevExpress.Web.ASPxEditors.Internal;

namespace WebAppCommons.Classes.Controls.ASPx.xListBox.ListEditItems
{
    public static class ListEditItemHelper
    {
        internal static object FetchLEIInternalValue(object source, string valueField, string textField, bool designMode)
        {
            var actualValueFieldName = EditDataHelper.GetActualValueFieldName(valueField, textField);

            return EditDataHelper.GetDataItemValue(source, actualValueFieldName, valueField, textField, designMode);
        }
    }
}