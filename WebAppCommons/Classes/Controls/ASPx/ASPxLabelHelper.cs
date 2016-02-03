using System.Web.UI;
using Commons.Helpers.Objects;
using DevExpress.Web.ASPxEditors;

namespace WebAppCommons.Classes.Controls.ASPx
{
    public static class ASPxLabelHelper
    {
        public static T AssociatedControl<T>(this ASPxLabel source) where T : Control
        {
            if (source.AssociatedControlID.IsEmpty()) return null;

            return source.Parent.FindControl(source.AssociatedControlID) as T;
        }
    }
}