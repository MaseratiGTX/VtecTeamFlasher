using DevExpress.Web.ASPxClasses;
using DevExpress.Web.ASPxClasses.Internal;
using WebAppCommons.Classes.Controls.ASPx.xExpandablePanel;

namespace WebAreaCommons.Classes.Controls.ASPx.xExpandablePanel
{
    public class CommonASPxExpandablePanel : ASPxExpandablePanel
    {
        public CommonASPxExpandablePanel()
        {
        }

        protected CommonASPxExpandablePanel(ASPxWebControl ownerControl) : base(ownerControl)
        {
        }



        protected override void PrepareControlStyle(AppearanceStyleBase style)
        {
            base.PrepareControlStyle(style);

            style.CssClass = RenderUtils.CombineCssClasses(style.CssClass, "CommonASPxExpandablePanel");
        }
    }
}