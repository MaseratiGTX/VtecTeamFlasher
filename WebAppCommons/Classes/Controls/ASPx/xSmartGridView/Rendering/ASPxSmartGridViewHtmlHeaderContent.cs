using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Utils;
using DevExpress.Web.ASPxClasses;
using DevExpress.Web.ASPxClasses.Internal;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.ASPxGridView.Rendering;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Rendering
{
    public class ASPxSmartGridViewHtmlHeaderContent : GridViewHtmlHeaderContent
    {
        public new ASPxSmartGridView Grid
        {
            get { return (ASPxSmartGridView) base.Grid; }
        }

        public new ASPxSmartGridViewRenderHelper RenderHelper
        {
            get { return (ASPxSmartGridViewRenderHelper) base.RenderHelper; }
        }



        public ASPxSmartGridViewHtmlHeaderContent(GridViewColumn column, GridViewHeaderLocation location) 
            : base(column, location)
        {
        }



        protected override void PrepareControlHierarchy()
        {
            CellPadding = 0;
            CellSpacing = 0;
            
            Width = Unit.Percentage(100.0);
            
            if (RenderHelper.AllowColumnResizing && RenderUtils.Browser.IsIE)
            {
                Style[HtmlTextWriterStyle.TextOverflow] = "ellipsis";
            }

            PrepareTextCell();
            PrepareImagesCell();
            PrepareSortImage();
            PrepareFilterImage();
        }

        protected new void PrepareTextCell()
        {
            HeaderStyle.AssignToControl(TextCell, AttributesRange.Font);
            HeaderStyle.AssignToControl(TextCell, AttributesRange.Cell);
            
            RenderUtils.SetPaddings(TextCell, HeaderStyle.Paddings);

            
            if (NewButtonControl != null)
            {
                TextCell.HorizontalAlign = HorizontalAlign.Center;
            }

            if (Location == GridViewHeaderLocation.Group)
            {
                if (Grid.GroupPanelHeaderNoWrap)
                {
                    RenderUtils.SetWrap(TextCell, DefaultBoolean.False);
                }

                if (HeaderStyle.Paddings.GetPaddingLeft().IsEmpty)
                {
                    RenderUtils.SetStyleUnitAttribute(TextCell, "padding-left", Unit.Pixel(1));
                }
            }

            if (Location == GridViewHeaderLocation.Customization)
            {
                var horizontalAlign = RenderHelper.GetCustomizationWindowContentStyle().HorizontalAlign;
                
                if (horizontalAlign != HorizontalAlign.NotSet)
                {
                    RenderUtils.SetHorizontalAlign(TextCell, horizontalAlign);
                }
            }
        }

    }
}