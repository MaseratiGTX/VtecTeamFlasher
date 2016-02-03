using System.Web.UI.WebControls;
using DevExpress.Web.ASPxTabControl;
using DevExpress.Web.ASPxTabControl.Internal;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartPageControl
{
    public class SmartContentControlLite : ContentControlLite
    {
        public SmartContentControlLite(TabPage tabPage) : base(tabPage)
        {
        }


        protected override void PrepareControlHierarchy()
        {
            base.PrepareControlHierarchy();

            Height = Unit.Percentage(100);
        }
    }
}