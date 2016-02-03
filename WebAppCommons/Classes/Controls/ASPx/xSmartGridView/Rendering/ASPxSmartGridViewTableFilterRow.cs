using DevExpress.Web.ASPxGridView.Rendering;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Rendering
{
    public class ASPxSmartGridViewTableFilterRow : GridViewTableFilterRow
    {
        protected new ASPxSmartGridViewRenderHelper RenderHelper
        {
            get { return (ASPxSmartGridViewRenderHelper)base.RenderHelper; }
        }

        public new ASPxSmartGridView Grid
        {
            get { return (ASPxSmartGridView)base.Grid; }
        }


        
        public ASPxSmartGridViewTableFilterRow(ASPxSmartGridViewRenderHelper renderHelper) : base(renderHelper)
        {
        }



        protected override void CreateControlHierarchy()
        {
            CreateIndentCells();

            if (RenderHelper.AddFilterRowTemplateControl(this, LeafColumns.Count)) return;

            for (var leafIndex = 0; leafIndex < LeafColumns.Count; ++leafIndex)
            {
                Cells.Add(
                    CreateFilterCell(
                        LeafColumns[leafIndex].Column,
                        RenderHelper.ShouldRemoveRightBorder(leafIndex)
                    )
                );
            }
        }
    }
}