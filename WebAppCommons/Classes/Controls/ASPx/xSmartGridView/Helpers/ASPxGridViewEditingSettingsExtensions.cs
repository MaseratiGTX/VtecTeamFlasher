using DevExpress.Web.ASPxGridView;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Helpers
{
    public static class ASPxGridViewEditingSettingsExtensions
    {
        public static bool DisplayEditingRow (this ASPxGridViewEditingSettings source)
        {
            return source.Mode == GridViewEditingMode.EditFormAndDisplayRow || source.Mode == GridViewEditingMode.PopupEditForm;
        }
    }
}