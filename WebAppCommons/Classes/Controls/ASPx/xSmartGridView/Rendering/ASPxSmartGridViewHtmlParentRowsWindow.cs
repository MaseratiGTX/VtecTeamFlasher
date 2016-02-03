using System.Web.UI.WebControls;
using DevExpress.Web.ASPxClasses.Internal;
using DevExpress.Web.ASPxGridView.Rendering;
using DevExpress.Web.Data;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Rendering
{
    public class ASPxSmartGridViewHtmlParentRowsWindow : GridViewHtmlParentRowsWindow
    {
        protected new ASPxSmartGridViewRenderHelper RenderHelper
        {
            get { return (ASPxSmartGridViewRenderHelper) base.RenderHelper; }
        }

        protected new ASPxSmartGridView Grid
        {
            get { return (ASPxSmartGridView) base.Grid; }
        }



        public ASPxSmartGridViewHtmlParentRowsWindow(ASPxSmartGridViewRenderHelper renderHelper, WebDataProxy dataProxy) : base(renderHelper, dataProxy)
        {
        }



        protected override Table CreateTable()
        {
            var table = RenderUtils.CreateTable();
            
            var parentRows = DataProxy.GetParentRows();
            
            foreach (var visibleIndex in parentRows)
            {
                table.Rows.Add(
                    new ASPxSmartGridViewTableParentGroupRow(RenderHelper, visibleIndex)
                );
            }

            return table;
        }
    }
}