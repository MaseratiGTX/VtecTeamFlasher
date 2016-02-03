using DevExpress.Web.ASPxGridView.Rendering;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Rendering
{
    public class ASPxSmartGridViewTableDetailRow : GridViewTableDetailRow
    {
        protected new ASPxSmartGridViewRenderHelper RenderHelper
        {
            get { return (ASPxSmartGridViewRenderHelper) base.RenderHelper; }
        }

        protected new ASPxSmartGridView Grid
        {
            get { return (ASPxSmartGridView)base.Grid; }
        }



        public ASPxSmartGridViewTableDetailRow(ASPxSmartGridViewRenderHelper renderHelper, int visibleIndex) : base(renderHelper, visibleIndex)
        {
        }



        protected override void CreateControlHierarchy()
        {
            ID = RenderHelper.GetDetailRowId(VisibleIndex);
            CreateIndentCells();
            RenderHelper.AddDetailRowTemplateControl(VisibleIndex, this, LeafColumns.Count);
        }
    }
}