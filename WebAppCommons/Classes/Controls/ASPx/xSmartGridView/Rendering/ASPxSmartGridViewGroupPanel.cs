using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxClasses;
using DevExpress.Web.ASPxClasses.Internal;
using DevExpress.Web.ASPxGridView.Rendering;
using WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Settings;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Rendering
{
    public class ASPxSmartGridViewGroupPanel : ASPxInternalWebControl
    {
        protected ASPxSmartGridViewRenderHelper RenderHelper { get; set; }

        protected ASPxSmartGridView Grid
        {
            get { return RenderHelper.Grid; }
        }

        protected int GroupCount
        {
            get { return RenderHelper.GroupCount; }
        }


        protected ASPxSmartGridViewTextSettings SettingsText
        {
            get { return Grid.SettingsText; }
        }

        protected string GroupPanelText
        {
            get { return SettingsText.GetGroupPanel(); }
        }

        
        protected override HtmlTextWriterTag TagKey
        {
            get { return HtmlTextWriterTag.Div; }
        }


        protected List<TableCell> GroupPanelColumnIndents { get; set; }
        
        protected Table GroupHeadersTable { get; set; }
        
        protected TableRow GroupHeadersRow { get; set; }
        


        public ASPxSmartGridViewGroupPanel(ASPxSmartGridViewRenderHelper renderHelper)
        {
            RenderHelper = renderHelper;
        }



        protected override bool HasRootTag()
        {
            return true;
        }


        
        protected override void ClearControlFields()
        {
            GroupPanelColumnIndents = null;
            GroupHeadersTable = null;
            GroupHeadersRow = null;
        }


        protected override void CreateControlHierarchy()
        {
            if (GroupCount > 0)
            {
                CreateGroupHeaders();
            }
            else
            {
                ID = RenderHelper.GetGroupPanelId();
                
                Controls.Add(
                    new LiteralControl
                    {
                        Text = GroupPanelText
                    }
                );
            }
        }

        protected virtual void CreateGroupHeaders()
        {
            GroupPanelColumnIndents = new List<TableCell>();


            GroupHeadersTable = RenderUtils.CreateTable();
            GroupHeadersTable.GridLines = GridLines.None;
            GroupHeadersTable.BorderStyle = BorderStyle.None;
            GroupHeadersTable.Rows.Add(
                GroupHeadersRow = RenderUtils.CreateTableRow()
            );
            
            Controls.Add(GroupHeadersTable);
            

            for (var index = 0; index < GroupCount; ++index)
            {
                GroupHeadersRow.Cells.Add(
                    new ASPxSmartGridViewTableHeaderCell(RenderHelper, Grid.GetSortedColumns()[index], GridViewHeaderLocation.Group, false, false)
                );
                
                if (index < GroupCount - 1)
                {
                    var columnIndent = RenderUtils.CreateTableCell();
                        columnIndent.Text = "&nbsp;";

                    GroupHeadersRow.Cells.Add(columnIndent);
                    
                    GroupPanelColumnIndents.Add(columnIndent);
                }
            }

            var tableCell = RenderUtils.CreateTableCell();
                tableCell.ID = RenderHelper.GetGroupPanelId();
                tableCell.Width = Unit.Percentage(100.0);

            GroupHeadersRow.Cells.Add(tableCell);
        }


        protected override void PrepareControlHierarchy()
        {
            var groupPanelStyle = RenderHelper.GetGroupPanelStyle();
                groupPanelStyle.AssignToControl(this, true);
            
            if (GroupPanelColumnIndents != null)
            {
                foreach (var columnIndent in GroupPanelColumnIndents)
                {
                    columnIndent.Width = groupPanelStyle.Spacing;
                }
            }
            
            if (GroupHeadersTable != null)
            {
                if (RenderUtils.Browser.Family.IsWebKit)
                {
                    GroupHeadersTable.Width = Unit.Percentage(100.0);
                }
                

                var contextMenuScript = RenderHelper.Scripts.GetContextMenu();

                if (string.IsNullOrEmpty(contextMenuScript) == false)
                {
                    RenderUtils.SetStringAttribute(GroupHeadersTable, "oncontextmenu", contextMenuScript);
                }
            }

            if (RenderUtils.Browser.Platform.IsMSTouchUI)
            {
                RenderUtils.AppendDefaultDXClassName(this, "dxgvMSDraggable");
            }
        }
    }
}