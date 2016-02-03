using DevExpress.Web.ASPxGridView.Rendering;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Rendering
{
    public class ASPxSmartGridViewTablePreviewRow : GridViewTablePreviewRow
    {
        protected new ASPxSmartGridViewRenderHelper RenderHelper
        {
            get { return (ASPxSmartGridViewRenderHelper)base.RenderHelper; }
        }

        public new ASPxSmartGridView Grid
        {
            get { return (ASPxSmartGridView)base.Grid; }
        }



        public ASPxSmartGridViewTablePreviewRow(ASPxSmartGridViewRenderHelper renderHelper, int visibleIndex, bool hasGroupFooter) 
            : base(renderHelper, visibleIndex, hasGroupFooter)
        {
        }



        protected override void CreateControlHierarchy()
        {
            ID = RenderHelper.GetPreviewRowId(VisibleIndex);
            CreateIndentCells();
            
            if (RenderHelper.AddPreviewRowTemplateControl(VisibleIndex, this, LeafColumns.Count)) return;
            
            Cells.Add(CreatePreviewCell());
        }
    }
}