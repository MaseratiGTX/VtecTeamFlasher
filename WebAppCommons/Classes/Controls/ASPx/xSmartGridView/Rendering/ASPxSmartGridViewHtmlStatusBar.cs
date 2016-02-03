using System.Collections.Generic;
using System.Web.UI.WebControls;
using Commons.Helpers.CommonObjects;
using DevExpress.Web.ASPxClasses.Internal;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.ASPxGridView.Rendering;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Rendering
{
    public class ASPxSmartGridViewHtmlStatusBar : InternalTable
    {
        protected ASPxSmartGridView Grid { get; set; }
        
        protected TableCell TemplateContainer { get; set; }
        
        protected ASPxLabel SRSummaryControl { get; set; }


        protected ASPxGridViewRenderHelper RenderHelper
        {
            get { return Grid.RenderHelper; }
        }

        protected TableRow MainRow
        {
            get { return Rows[0]; }
        }

        protected TableCell LoadingContainer
        {
            get { return MainRow.Cells.Count > 1 ? MainRow.Cells[1] : null; }
        }



        public ASPxSmartGridViewHtmlStatusBar(ASPxSmartGridView grid)
        {
            Grid = grid;
        }



        protected override void ClearControlFields()
        {
            base.ClearControlFields();

            TemplateContainer = null;
            SRSummaryControl = null;
        }


        protected override void CreateControlHierarchy()
        {
            Rows.Add(RenderUtils.CreateTableRow());
            
            TemplateContainer = RenderUtils.CreateTableCell();
            
            if (!RenderHelper.AddStatusBarTemplateControl(TemplateContainer))
            {
                if (RenderHelper.AllowBatchEditing)
                {
                    TemplateContainer = new GridViewCommandItemsCell(RenderHelper, GetAllowedCommandItems(), false);
                }
                else
                {
                    CreateSearchResultSummaryControl();
                }
            }
            
            MainRow.Cells.Add(TemplateContainer);

            if (Grid.SettingsLoadingPanel.Mode == GridViewLoadingPanelMode.ShowOnStatusBar)
            {
                MainRow.Cells.Add(RenderUtils.CreateTableCell());
                LoadingContainer.ID = "DXLPContainer";
            }
        }


        protected List<ColumnCommandButtonType> GetAllowedCommandItems()
        {
            return new List<ColumnCommandButtonType>
            {
                ColumnCommandButtonType.Update,
                ColumnCommandButtonType.Cancel
            };
        }

        protected virtual void CreateSearchResultSummaryControl()
        {
            TemplateContainer.Add(
                SRSummaryControl = new ASPxLabel()
            );

            SRSummaryControl.ID = Grid.GetSRSummaryControlID();
        }



        protected override void PrepareControlHierarchy()
        {
            RenderHelper.GetStatusBarStyle().AssignToControl(this, true);
            Width = Unit.Percentage(100.0);
            TemplateContainer.Width = Unit.Percentage(100.0);
            RenderHelper.AppendGridCssClassName(MainRow);

            PrepareSearchResultSummaryControl();

            base.PrepareControlHierarchy();
        }


        protected virtual void PrepareSearchResultSummaryControl()
        {
            if(SRSummaryControl == null) return;

            SRSummaryControl.CssClass = RenderUtils.CombineCssClasses(SRSummaryControl.CssClass, "dxsgv", "dxsrsc");
            SRSummaryControl.EncodeHtml = false;
            SRSummaryControl.EnableClientSideAPI = true;
            SRSummaryControl.Width = Unit.Percentage(100);

            SRSummaryControl.Text = "";
            
            if (Grid.ShouldDisplaySearch)
                SRSummaryControl.Text = Grid.SettingsText.SearchResultsSummary.FillWith(Grid.SearchDetails, Grid.GetDataRowCount());

        }
    }
}