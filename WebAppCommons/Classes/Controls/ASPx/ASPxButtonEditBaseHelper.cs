using DevExpress.Web.ASPxEditors;

namespace WebAppCommons.Classes.Controls.ASPx
{
    public static class ASPxButtonEditBaseHelper
    {
        public static T EnableEditButtons<T>(this T source) where T : ASPxButtonEditBase
        {
            return source.SetEditButtonsEnableState(true);
        }

        public static T DisableEditButtons<T>(this T source) where T : ASPxButtonEditBase
        {
            return source.SetEditButtonsEnableState(false);
        }

        public static T SetEditButtonsEnableState<T>(this T source, bool enableState) where T : ASPxButtonEditBase
        {
            foreach (EditButton editButton in source.Buttons)
            {
                editButton.Enabled = enableState;
            }

            return source;
        } 
    }
}