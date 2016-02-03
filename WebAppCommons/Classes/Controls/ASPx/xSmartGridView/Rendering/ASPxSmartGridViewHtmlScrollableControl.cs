using System.Web.UI.WebControls;
using DevExpress.Web.ASPxGridView.Rendering;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Rendering
{
    public class ASPxSmartGridViewHtmlScrollableControl : GridViewHtmlScrollableControl
    {
        protected new ASPxSmartGridViewRenderHelper RenderHelper
        {
            get { return (ASPxSmartGridViewRenderHelper) base.RenderHelper; }
        }

        protected new ASPxSmartGridView Grid
        {
            get { return (ASPxSmartGridView) base.Grid; }
        }



        public ASPxSmartGridViewHtmlScrollableControl(ASPxSmartGridViewRenderHelper helper) : base(helper)
        {
        }



        protected override GridViewHtmlTable CreateTable(GridViewHtmlTableRenderPart renderPart, string id, WebControl container)
        {
            var result = (ASPxSmartGridViewHtmlTable) null;

            container.Controls.Add(
                result = new ASPxSmartGridViewHtmlTable(RenderHelper, renderPart)
                {
                    ID = id
                }
            );
            
            return result;
        }
    }
}