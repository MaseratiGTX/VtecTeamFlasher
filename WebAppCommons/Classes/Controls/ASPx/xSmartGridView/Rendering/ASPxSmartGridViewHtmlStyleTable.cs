using DevExpress.Web.ASPxGridView.Rendering;
using DevExpress.Web.Data;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Rendering
{
    public class ASPxSmartGridViewHtmlStyleTable : GridViewHtmlStyleTable
    {
        protected new ASPxSmartGridView Grid
        {
            get { return (ASPxSmartGridView) base.Grid; }
        }

        protected new ASPxSmartGridViewRenderHelper RenderHelper
        {
            get { return (ASPxSmartGridViewRenderHelper) base.RenderHelper; }
        }



        public ASPxSmartGridViewHtmlStyleTable(ASPxSmartGridView grid) : base(grid)
        {
        }



        protected override void CreateRows()
        {
            var num = 0;
            var visibleStartIndex = DataProxy.VisibleStartIndex;
            
            for (var index = 0; index < DataProxy.VisibleRowCountOnPage; ++index)
            {
                var visibleIndex = visibleStartIndex + index;
                if (DataProxy.GetRowType(visibleStartIndex + index) == WebRowType.Data)
                {
                    Rows.Add(
                        new GridViewTableDataRow(RenderHelper, visibleIndex, num++, false, true)
                    );
                }
                else
                {
                    Rows.Add(
                        new ASPxSmartGridViewTableGroupRow(RenderHelper, visibleIndex, false)
                        {
                            IsStyledRow = true
                        }
                    );
                }
            }
        }
    }
}