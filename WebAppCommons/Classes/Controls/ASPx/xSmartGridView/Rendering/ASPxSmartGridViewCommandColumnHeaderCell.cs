using System.Web.UI.WebControls;
using DevExpress.Web.ASPxClasses.Internal;
using DevExpress.Web.ASPxGridView.Rendering;
using WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Columns;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Rendering
{
    public class ASPxSmartGridViewCommandColumnHeaderCell : ASPxSmartGridViewTableHeaderCell
    {
        public new SmartGridViewCommandColumn Column
        {
            get { return (SmartGridViewCommandColumn) base.Column; }
        }



        public ASPxSmartGridViewCommandColumnHeaderCell(ASPxGridViewRenderHelper renderHelper, SmartGridViewCommandColumn column, GridViewHeaderLocation location, bool removeLeftBorder, bool removeRightBorder) 
            : base(renderHelper, column, location, removeLeftBorder, removeRightBorder)
        {
        }



        protected override Table CreateHeaderContent()
        {
            if (Column.ShowExpandCollapseAllButtons)
            {
                return new ASPxSmartGridViewECAllButtonsBlockContent(Column, Location);
            }
            
            return base.CreateHeaderContent();
        }


        protected override void PrepareControlHierarchy()
        {
            base.PrepareControlHierarchy();

            RenderUtils.SetStyleUnitAttribute(this, "min-width", Unit.Pixel(Column.MinWidth));
        }
    }
}