using System.Web.UI.WebControls;
using DevExpress.Web.ASPxClasses.Internal;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.ASPxGridView.Rendering;
using WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Columns;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Rendering
{
    public class ASPxSmartGridViewTableHeaderCell : GridViewTableHeaderCell
    {
        protected new ASPxSmartGridViewRenderHelper RenderHelper
        {
            get { return (ASPxSmartGridViewRenderHelper)base.RenderHelper; }
        }

        protected Table HeaderContent { get; set; }

        protected bool Autosize
        {
            get
            {
                return Column is SmartGridViewCommandColumn && ((SmartGridViewCommandColumn)Column).Autosize;
            }
        }



        public ASPxSmartGridViewTableHeaderCell(ASPxGridViewRenderHelper renderHelper, GridViewColumn column, GridViewHeaderLocation location, bool removeLeftBorder, bool removeRightBorder) 
            : base(renderHelper, column, location, removeLeftBorder, removeRightBorder)
        {
        }



        protected override void ClearControlFields()
        {
            HeaderContent = null;
        }


        protected override void CreateControlHierarchy()
        {
            ID = GenerateID();
            
            if (RenderHelper.AddHeaderTemplateControl(Column, this, Location)) return;

            Controls.Add(
                HeaderContent = CreateHeaderContent()
            );

            if (string.IsNullOrEmpty(Column.ToolTip) == false)
            {
                ToolTip = Column.ToolTip;
            }
        }

        protected override void PrepareControlHierarchy()
        {
            base.PrepareControlHierarchy();

            if (Location == GridViewHeaderLocation.Row && !RenderHelper.RequireHeaderBottomBorder)
                RenderUtils.SetStyleUnitAttribute(this, "border-bottom-width", 0);

            if (Autosize)
            {
                Width = RenderHelper.GetNarrowCellWidth();
            }
        }


        protected virtual Table CreateHeaderContent()
        {
            return new ASPxSmartGridViewHtmlHeaderContent(Column, Location);
        }


        private string GenerateID()
        {
            var result = "col" + RenderHelper.GetColumnGlobalIndex(Column);
            
            return Location == GridViewHeaderLocation.Group ? "group" + result : result;
        }
    }
}