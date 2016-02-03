using System.Web.UI.WebControls;
using DevExpress.Utils;
using DevExpress.Web.ASPxClasses.Internal;
using DevExpress.Web.ASPxEditors;
using WebAppCommons.Classes.Controls.ASPx.xExpandablePanel.Internal;

namespace WebAppCommons.Classes.Controls.ASPx.xSearchPanel.Internal
{
    public class RPSearchPanelControl : RPExpandablePanelControl
    {
        protected new ASPxSearchPanel RoundPanel
        {
            get { return (ASPxSearchPanel) base.RoundPanel; }
        }


        protected InternalTable CBContainerTable { get; set; }
        protected TableRow CBContainerRow { get; set; }
        protected TableCell CBPerformSearchButtonCell { get; set; }
        protected TableCell CBSeparatorCell { get; set; }
        protected TableCell CBCancelSearchButtonCell { get; set; }
        protected TableCell CBPlaceholderCell { get; set; }
        
        protected ASPxButton PerformSearchButton { get; set; }
        protected ASPxButton CancelSearchButton { get; set; }


        
        public RPSearchPanelControl(ASPxSearchPanel panel) : base(panel)
        {
        }



        protected override void ClearControlFields()
        {
            base.ClearControlFields();

            CBContainerTable = null;
            CBContainerRow = null;
            CBPerformSearchButtonCell = null;
            CBSeparatorCell = null;
            CBCancelSearchButtonCell = null;
            CBPlaceholderCell = null;

            PerformSearchButton = null;
            CancelSearchButton = null;
        }


        protected override void CreateControlHierarchy()
        {
            base.CreateControlHierarchy();

            CellContent.Add(
                CBContainerTable = RenderUtils.CreateTable().Add(
                    CBContainerRow = RenderUtils.CreateTableRow()
                )
            );

            CreatePerformSearchButton();
            CreateSeparatorCell();
            CreateCancelSearchButton();
            CreatePlaceholderCell();
        }


        private void CreatePerformSearchButton()
        {
            CBContainerRow.Add(
                CBPerformSearchButtonCell = RenderUtils.CreateTableCell().Add(
                    PerformSearchButton = new ASPxButton()
                )
            );

            PerformSearchButton.ID = RoundPanel.GetPerformSearchButtonID();
        }

        private void CreateSeparatorCell()
        {
            CBContainerRow.Add(
                CBSeparatorCell = RenderUtils.CreateTableCell()
            );
        }

        private void CreateCancelSearchButton()
        {
            CBContainerRow.Add(
                CBCancelSearchButtonCell = RenderUtils.CreateTableCell().Add(
                    CancelSearchButton = new ASPxButton()
                )
            );

            CancelSearchButton.ID = RoundPanel.GetCancelSearchButtonID();
        }

        private void CreatePlaceholderCell()
        {
            CBContainerRow.Add(
                CBPlaceholderCell = RenderUtils.CreateTableCell()
            );
        }


        
        protected override void PrepareControlHierarchy()
        {
            base.PrepareControlHierarchy();

            PrepareCBContainerTable();
            
            PreparePerformSearchButton();
            PrepareSeparatorCell();
            PrepareCancelSearchButton();
        }


        private void PrepareCBContainerTable()
        {
            if(CBContainerTable == null) return;


            CBContainerTable.CssClass = RoundPanel.GetCBContainerTableClassName();
            CBContainerTable.Width = Unit.Percentage(100);
        }

        private void PreparePerformSearchButton()
        {
            if (PerformSearchButton == null) return;


            CBPerformSearchButtonCell.Width = Unit.Pixel(1);

            PerformSearchButton.EnableClientSideAPI = true;
            PerformSearchButton.AutoPostBack = false;
            PerformSearchButton.UseSubmitBehavior = false;
            PerformSearchButton.Wrap = DefaultBoolean.False;
            PerformSearchButton.Text = RoundPanel.HtmlEncode(RoundPanel.PerformSearchText); 
            PerformSearchButton.Width = Unit.Percentage(100); 
        }

        private void PrepareSeparatorCell()
        {
            if (CBSeparatorCell == null) return;


            CBSeparatorCell.Width = Unit.Pixel(10);
        }

        private void PrepareCancelSearchButton()
        {
            if (CancelSearchButton == null) return;


            CBCancelSearchButtonCell.Width = Unit.Pixel(1);

            CancelSearchButton.EnableClientSideAPI = true;
            CancelSearchButton.AutoPostBack = false;
            CancelSearchButton.UseSubmitBehavior = false;
            CancelSearchButton.Wrap = DefaultBoolean.False;
            CancelSearchButton.Text = RoundPanel.HtmlEncode(RoundPanel.CancelSearchText); 
            CancelSearchButton.Width = Unit.Percentage(100); 
        }
    }
}