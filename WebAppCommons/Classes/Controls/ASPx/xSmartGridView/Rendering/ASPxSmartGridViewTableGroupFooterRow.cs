using DevExpress.Web.ASPxGridView.Rendering;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Rendering
{
    public class ASPxSmartGridViewTableGroupFooterRow : GridViewTableGroupFooterRow
    {
        protected new ASPxSmartGridViewRenderHelper RenderHelper
        {
            get { return (ASPxSmartGridViewRenderHelper)base.RenderHelper; }
        }

        public new ASPxSmartGridView Grid
        {
            get { return (ASPxSmartGridView)base.Grid; }
        }



        public ASPxSmartGridViewTableGroupFooterRow(ASPxSmartGridViewRenderHelper renderHelper, int visibleIndex, bool isLastFooterRow)
            : base(renderHelper, visibleIndex, isLastFooterRow)
        {
        }



        protected override void CreateControlHierarchy()
        {
            CreateIndentCells();

            if (RenderHelper.AddGroupFooterRowTemplateControl(this, Column, GetTemplateCellSpanCount(), VisibleIndex)) return;

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
                    new GridViewTableNoColumnsCell(RenderHelper)
                );
            }
        }
    }
}