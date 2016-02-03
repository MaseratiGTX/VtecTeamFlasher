using System.Web.UI.WebControls;
using DevExpress.Web.ASPxGridView.Rendering;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Rendering
{
    public class ASPxSmartGridViewTableEmptyDataRow : GridViewTableEmptyDataRow
    {
        protected new ASPxSmartGridViewRenderHelper RenderHelper
        {
            get { return (ASPxSmartGridViewRenderHelper)base.RenderHelper; }
        }

        public new ASPxSmartGridView Grid
        {
            get { return (ASPxSmartGridView) base.Grid; }
        }



        public ASPxSmartGridViewTableEmptyDataRow(ASPxSmartGridViewRenderHelper renderHelper) : base(renderHelper)
        {
        }



        protected override void CreateControlHierarchy()
        {
            CreateIndentCells();
            
            if (RenderHelper.AddEmptyDataRowTemplateControl(this, LeafColumns.Count)) return;
            
            Cells.Add(CreateEmptyDataCell());
            RenderHelper.AddHorzScrollExtraCell(this);
        }

        protected override TableCell CreateEmptyDataCell()
        {
            var result = base.CreateEmptyDataCell();

            if (Grid.ReadOnly)
            {
                if (NewButtonControl != null)
                    NewButtonControl.Visible = false;
            }

            return result;
        }
    }
}