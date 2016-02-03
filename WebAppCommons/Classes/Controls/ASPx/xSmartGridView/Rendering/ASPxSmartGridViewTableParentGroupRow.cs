namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Rendering
{
    public class ASPxSmartGridViewTableParentGroupRow : ASPxSmartGridViewTableGroupRow
    {
        public ASPxSmartGridViewTableParentGroupRow(ASPxSmartGridViewRenderHelper renderHelper, int visibleIndex)
            : base(renderHelper, visibleIndex, true, false)
        {
        }


        protected override int GetColSpanCount()
        {
            return RenderHelper.GroupCount - GroupLevel;
        }
    }
}