using System.Web.UI.WebControls;
using DevExpress.Web.ASPxClasses.Internal;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.ASPxGridView.Rendering;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Rendering
{
    public class ASPxSmartGridViewHtmlTitle : InternalTable
    {
        protected ASPxSmartGridView Grid { get; set; }


        protected ASPxGridViewTextSettings SettingsText
        {
            get { return Grid.SettingsText; }
        }

        protected ASPxGridViewRenderHelper RenderHelper
        {
            get { return Grid.RenderHelper; }
        }

        protected WebControl MainCell
        {
            get { return Rows[0].Cells[0]; }
        }



        public ASPxSmartGridViewHtmlTitle(ASPxSmartGridView grid)
        {
            Grid = grid;
        }



        protected override void CreateControlHierarchy()
        {
            Rows.Add(RenderUtils.CreateTableRow());
            Rows[0].Cells.Add(RenderUtils.CreateTableCell());
            
            if (RenderHelper.AddTitleTemplateControl(MainCell)) return;
            
            MainCell.Controls.Add(RenderUtils.CreateLiteralControl(SettingsText.Title));
        }

        protected override void PrepareControlHierarchy()
        {
            Width = Unit.Percentage(100.0);
            CellSpacing = 0;
            CellPadding = 0;
            RenderHelper.GetTitleStyle().AssignToControl(MainCell, true);
        }
    }
}