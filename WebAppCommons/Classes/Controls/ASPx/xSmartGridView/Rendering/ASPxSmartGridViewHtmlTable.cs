using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxClasses.Internal;
using DevExpress.Web.ASPxGridView.Rendering;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Rendering
{
    public class ASPxSmartGridViewHtmlTable : GridViewHtmlTable
    {
        protected new ASPxSmartGridViewRenderHelper RenderHelper
        {
            get { return (ASPxSmartGridViewRenderHelper) base.RenderHelper; }
        }

        protected new ASPxSmartGridView Grid
        {
            get { return (ASPxSmartGridView) base.Grid; }
        }



        public ASPxSmartGridViewHtmlTable(ASPxSmartGridViewRenderHelper renderHelper) : base(renderHelper)
        {
        }

        public ASPxSmartGridViewHtmlTable(ASPxSmartGridViewRenderHelper renderHelper, GridViewHtmlTableRenderPart renderPart) : base(renderHelper, renderPart)
        {
        }



        protected override void CreateHeaders()
        {
            if (Grid.Settings.ShowColumnHeaders)
            {
                Rows.Add(new ASPxSmartGridViewTableHeaderRow(RenderHelper, 0));

                for (var layoutLevel = 1; layoutLevel < ColumnHelper.Layout.Count; layoutLevel++)
                {
                    Rows.Add(new ASPxSmartGridViewTableHeaderRow(RenderHelper, layoutLevel));
                }
            }
        }


        protected override void PrepareControlHierarchy()
        {
            CellPadding = 0;
            CellSpacing = 0;

            RenderHelper.GetTableStyle().AssignToControl(this);
            Width = Unit.Percentage(100.0);
            Style["empty-cells"] = "show";
            
            Attributes["onclick"] = Scripts.GetMainTableClickFunction();
            
            if (RequireUseDblClick)
                Attributes["ondblclick"] = Scripts.GetMainTableDblClickFunction();

            if (RenderHelper.RequireFixedTableLayout)
            {
                Style["table-layout"] = "fixed";
                Style[HtmlTextWriterStyle.Overflow] = "hidden";

                if (RenderHelper.AllowColumnResizing)
                    Style[HtmlTextWriterStyle.TextOverflow] = "ellipsis";
                
                if (RenderHelper.IsRightToLeft && RenderHelper.HasFixedColumns)
                    Style["float"] = "right";
            }

            if (RenderPart == GridViewHtmlTableRenderPart.All || RenderPart == GridViewHtmlTableRenderPart.Header)
            {
                Caption = Grid.Caption;
                RenderUtils.SetStringAttribute(this, "summary", Grid.SummaryText);
            }

            if (RenderHelper.IsRightToLeft)
                Attributes["dir"] = "rtl";

            if (Grid.IsSwipeGesturesEnabled_Internal() || RenderPart == GridViewHtmlTableRenderPart.Header && RenderHelper.HasFixedColumns && RenderHelper.ShowVerticalScrolling)
                RenderUtils.AppendMSTouchDraggableClassNameIfRequired(this);

            var contextMenuScript = Scripts.GetContextMenu();
            
            if (!string.IsNullOrEmpty(contextMenuScript))
                Attributes["oncontextmenu"] = contextMenuScript;


            new ASPxSmartGridViewBottomBorderRemovalHelper(Rows, RenderHelper).Run();
        }



        protected override GridViewTableRow CreateDetailRow(int visibleIndex)
        {
            return new ASPxSmartGridViewTableDetailRow(RenderHelper, visibleIndex);
        }

        protected override void CreateEmptyRow()
        {
            AddRowAndRaiseRowCreated(new ASPxSmartGridViewTableEmptyDataRow(RenderHelper));
        }

        protected override void CreateFilterRow()
        {
            if (!Grid.Settings.ShowFilterRow || LeafColumns.Count == 0) return;
            
            AddRowAndRaiseRowCreated(new ASPxSmartGridViewTableFilterRow(RenderHelper));
        }

        protected override void CreateFooter()
        {
            if (!ShowFooter) return;
            
            AddRowAndRaiseRowCreated(new ASPxSmartGridViewTableFooterRow(RenderHelper));
        }

        protected override void CreateGroupFooterRow(List<int> visibleIndexes)
        {
            for (var index = 0; index < visibleIndexes.Count; ++index)
            {
                AddRowAndRaiseRowCreated(
                    new ASPxSmartGridViewTableGroupFooterRow(
                        RenderHelper, 
                        visibleIndexes[index], 
                        index == visibleIndexes.Count - 1
                    )
                );
            }
        }

        protected override void CreateGroupRow(int visibleIndex, bool hasGroupFooter)
        {
            AddRowAndRaiseRowCreated(new ASPxSmartGridViewTableGroupRow(RenderHelper, visibleIndex, hasGroupFooter));
        }

        protected override GridViewTableRow CreatePreviewRow(int visibleIndex, bool hasGroupFooter)
        {
            return new ASPxSmartGridViewTablePreviewRow(RenderHelper, visibleIndex, hasGroupFooter);
        }
    }
}