using DevExpress.Web.ASPxGridView.Rendering;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Rendering
{
    public class ASPxSmartGridViewTableFooterRow : GridViewTableFooterRow
    {
        protected new ASPxSmartGridViewRenderHelper RenderHelper
        {
            get { return (ASPxSmartGridViewRenderHelper)base.RenderHelper; }
        }

        public new ASPxSmartGridView Grid
        {
            get { return (ASPxSmartGridView)base.Grid; }
        }



        public ASPxSmartGridViewTableFooterRow(ASPxSmartGridViewRenderHelper renderHelper) : base(renderHelper)
        {
        }



        protected override void CreateControlHierarchy()
        {
            ID = "DXFooterRow";
            CreateIndentCells();
            
            if (RenderHelper.AddFooterRowTemplateControl(this, LeafColumns.Count))return;

            for (var leafIndex = 0; leafIndex < LeafColumns.Count; ++leafIndex)
            {
                Cells.Add(
                    CreateFooterCell(
                        LeafColumns[leafIndex].Column, 
                        RenderHelper.ShouldRemoveLeftBorder(leafIndex), 
                        RenderHelper.ShouldRemoveRightBorder(leafIndex)
                    )
                );
            }

            if (LeafColumns.Count == 0)
            {
                Cells.Add(
                    new GridViewTableIndentCell(RenderHelper)
                );
            }

            RenderHelper.AddHorzScrollExtraCell(this);
        }
    }
}