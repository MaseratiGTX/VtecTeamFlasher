using DevExpress.Web.ASPxClasses;
using DevExpress.Web.ASPxClasses.Internal;
using WebAppCommons.Classes.Controls.ASPx.xSmartDataView.xDataViewItems.xSimple;

namespace WebAreaCommons.Classes.Controls.ASPx.xDataView.xDataViewItems.xSimple
{
    public class CommonASPxDataViewItem : ASPxSimpleDataViewItem
    {
        protected override void PrepareControlStyle(AppearanceStyleBase style)
        {
            base.PrepareControlStyle(style);

            style.CssClass = RenderUtils.CombineCssClasses(style.CssClass, "CommonASPxDataViewItem");
        }
    }
}