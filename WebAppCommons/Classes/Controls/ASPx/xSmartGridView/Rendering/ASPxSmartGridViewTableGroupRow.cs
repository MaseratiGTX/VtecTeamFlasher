using DevExpress.Web.ASPxGridView.Rendering;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Rendering
{
    public class ASPxSmartGridViewTableGroupRow : GridViewTableGroupRow
    {
        protected new ASPxSmartGridViewRenderHelper RenderHelper
        {
            get { return (ASPxSmartGridViewRenderHelper)base.RenderHelper; }
        }

        public new ASPxSmartGridView Grid
        {
            get { return (ASPxSmartGridView)base.Grid; }
        }



        public ASPxSmartGridViewTableGroupRow(ASPxSmartGridViewRenderHelper renderHelper, int visibleIndex, bool hasGroupFooter) 
            : base(renderHelper, visibleIndex, hasGroupFooter)
        {
        }

        public ASPxSmartGridViewTableGroupRow(ASPxSmartGridViewRenderHelper renderHelper, int visibleIndex, bool hasGroupFooter, bool isGroupButtonLive) 
            : base(renderHelper, visibleIndex, hasGroupFooter, isGroupButtonLive)
        {
        }



        protected override void CreateControlHierarchy()
        {
            if (IsStyledRow) return;
            
            ID = RenderHelper.GetGroupRowId(VisibleIndex);
            CreateIndentCells();
            
            if (RenderHelper.AddGroupRowTemplateControl(VisibleIndex, Column, this, ColumnSpanCount - GroupLevel)) return;
            
            if (Grid.Settings.ShowGroupButtons)
                CreateButtonCell();
            
            CreateContentCell();
        }
    }
}