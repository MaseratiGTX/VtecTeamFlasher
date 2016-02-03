using DevExpress.Web.ASPxGridView.Internal;
using DevExpress.Web.ASPxGridView.Rendering;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Rendering
{
    public class ASPxSmartGridViewTableHeaderRow : GridViewTableHeaderRow
    {
        protected new ASPxSmartGridViewRenderHelper RenderHelper
        {
            get { return (ASPxSmartGridViewRenderHelper) base.RenderHelper; }
        }



        public ASPxSmartGridViewTableHeaderRow(ASPxSmartGridViewRenderHelper renderHelper, int layoutLevel) : base(renderHelper, layoutLevel)
        {
        }



        protected override void AddHeaderCell(GridViewColumnVisualTreeNode node, bool removeRightBorder)
        {
            var headerCell = RenderHelper.CreateHeaderCell(LayoutLevel, node.Column, GridViewHeaderLocation.Row, true, removeRightBorder);

            if (node.ColSpan > 1)
            {
                headerCell.ColumnSpan = node.ColSpan;
            }

            if (node.RowSpan > 1)
            {
                headerCell.RowSpan = node.RowSpan;
            }

            Cells.Add(headerCell);
        }
    }
}