using System.Web.UI.WebControls;
using DevExpress.Utils;
using DevExpress.Web.ASPxClasses.Internal;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.ASPxGridView.Rendering;
using WebAppCommons.Classes.Controls.ASPx.xGridView;
using WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Columns;
using WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Settings;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Rendering
{
    public class ASPxSmartGridViewECAllButtonsBlockContent : InternalTable
    {
        public SmartGridViewCommandColumn Column { get; protected set; }
        
        public GridViewHeaderLocation Location { get; protected set; }


        public ASPxSmartGridView Grid
        {
            get { return (ASPxSmartGridView) Column.Grid; }
        }

        public ASPxSmartGridViewRenderHelper RenderHelper
        {
            get { return Grid.RenderHelper; }
        }


        protected TableRow MainRow { get; set; }

        protected TableCell ExpandAllButtonCell { get; set; }
        protected TableCell ButtonSeparatorCell { get; set; }
        protected TableCell CollapseAllButtonCell { get; set; }

        protected ASPxButton ExpandAllButton { get; set; }
        protected ASPxEditBase ButtonSeparator { get; set; }
        protected ASPxImage ButtonSeparatorImage { get; set; }
        protected ASPxLabel ButtonSeparatorText { get; set; }
        protected ASPxButton CollapseAllButton { get; set; }



        public ASPxSmartGridViewECAllButtonsBlockContent(SmartGridViewCommandColumn column, GridViewHeaderLocation location)
        {
            Column = column;
            Location = location;
        }



        protected override void ClearControlFields()
        {
            MainRow = null;

            ExpandAllButtonCell = null;
            ButtonSeparatorCell = null;
            CollapseAllButtonCell = null;

            ExpandAllButton = null;
            ButtonSeparator = null;
            ButtonSeparatorImage = null;
            ButtonSeparatorText = null;
            CollapseAllButton = null;
        }


        protected override void CreateControlHierarchy()
        {
            Controls.Add(MainRow = RenderUtils.CreateTableRow());
            
            CreateExpandAllButtonCell();
            CreateButtonSeparatorCell();
            CreateCollapseAllButtonCell();
        }

        protected virtual void CreateExpandAllButtonCell()
        {
            MainRow.Cells.Add(
                ExpandAllButtonCell = RenderUtils.CreateTableCell().Add(
                    ExpandAllButton = new ASPxButton()
                )
            );

            ExpandAllButton.ID = GetControlID("ExpandAllButton");
        }

        protected virtual void CreateButtonSeparatorCell()
        {
            var buttonSeparatorType = Grid.SettingsCommandButton.ExpandCollapseAllButtons.ButtonSeparator.SeparatorType;

            MainRow.Cells.Add(
                ButtonSeparatorCell = RenderUtils.CreateTableCell().Add(
                    ButtonSeparator = CreateButtonSeparator(buttonSeparatorType)
                )
            );

            ButtonSeparator.ID = GetControlID("ButtonSeparator");
        }

        protected virtual ASPxEditBase CreateButtonSeparator(ASPxSmartGridViewCommandButtonSeparatorType buttonSeparatorType)
        {
            switch (buttonSeparatorType)
            {
                case ASPxSmartGridViewCommandButtonSeparatorType.Image:
                    return ButtonSeparatorImage = new ASPxImage();
                default:
                    return ButtonSeparatorText = new ASPxLabel();
            }
        }

        protected virtual void CreateCollapseAllButtonCell()
        {
            MainRow.Cells.Add(
                CollapseAllButtonCell = RenderUtils.CreateTableCell().Add(
                    CollapseAllButton = new ASPxButton()
                )
            );

            CollapseAllButton.ID = GetControlID("CollapseAllButton");
        }


        protected override void PrepareControlHierarchy()
        {
            RenderUtils.SetStyleStringAttribute(this, "margin", "0px auto");
            
            PrepareExpandAllButtonCell();
            PrepareButtonSeparatorCell();
            PrepareCollapseAllButtonCell();
        }

        protected virtual void PrepareExpandAllButtonCell()
        {
            if (ExpandAllButtonCell == null) return;

            
            ExpandAllButton.EnableClientSideAPI = true;
            ExpandAllButton.AutoPostBack = false;
            ExpandAllButton.UseSubmitBehavior = false;
            ExpandAllButton.Wrap = DefaultBoolean.False;

            var buttonSettings = Grid.SettingsCommandButton.ExpandCollapseAllButtons.ExpandAllButton;
            
            var buttonType = GetButtonType(buttonSettings, Column.ButtonType);

            ExpandAllButton.RenderMode = ConvertToRenderMode(buttonType);
            ExpandAllButton.Text = GetButtonText(buttonSettings, buttonType, "Expand All");
            SetImageSettings(ExpandAllButton, buttonSettings, buttonType);
            ExpandAllButton.Image.ToolTip = GetToolTipText(buttonSettings, buttonType, "Expand All");

            ExpandAllButton.Enabled = GetButtonEnabledState();

            ExpandAllButton.ClientSideEvents.Click = GetScheduledCommandHandler("ExpandAll");
        }

        protected virtual void PrepareButtonSeparatorCell()
        {
            if(ButtonSeparatorCell == null) return;

            
            var buttonSeparatorSettings = Grid.SettingsCommandButton.ExpandCollapseAllButtons.ButtonSeparator;

            PrepareButtonSeparatorImage(buttonSeparatorSettings);
            PrepareButtonSeparatorText(buttonSeparatorSettings);
        }
        
        protected virtual void PrepareButtonSeparatorImage(ASPxSmartGridViewCommandButtonSeparatorSettings buttonSeparatorSettings)
        {
            if (ButtonSeparatorImage == null) return;

            ButtonSeparatorCell.CssClass = RenderUtils.CombineCssClasses(ButtonSeparatorCell.CssClass, "dxsbsic");

            ButtonSeparatorImage.AssignImageProperties(buttonSeparatorSettings.Image);
            ButtonSeparatorImage.ToolTip = string.Empty;
        }

        protected virtual void PrepareButtonSeparatorText(ASPxSmartGridViewCommandButtonSeparatorSettings buttonSeparatorSettings)
        {
            if (ButtonSeparatorText == null) return;

            ButtonSeparatorCell.CssClass = RenderUtils.CombineCssClasses(ButtonSeparatorCell.CssClass, "dxsbstc");

            ButtonSeparatorText.CssClass = RenderUtils.CombineCssClasses(ButtonSeparatorText.CssClass, "dxeHyperlink");
            ButtonSeparatorText.Text = buttonSeparatorSettings.Text;
        }

        protected virtual void PrepareCollapseAllButtonCell()
        {
            if (CollapseAllButtonCell == null) return;

            
            CollapseAllButton.EnableClientSideAPI = true;
            CollapseAllButton.AutoPostBack = false;
            CollapseAllButton.UseSubmitBehavior = false;
            CollapseAllButton.Wrap = DefaultBoolean.False;

            var buttonSettings = Grid.SettingsCommandButton.ExpandCollapseAllButtons.CollapseAllButton;

            var buttonType = GetButtonType(buttonSettings, Column.ButtonType);

            CollapseAllButton.RenderMode = ConvertToRenderMode(buttonType);
            CollapseAllButton.Text = GetButtonText(buttonSettings, buttonType, "Collapse All");
            SetImageSettings(CollapseAllButton, buttonSettings, buttonType);
            CollapseAllButton.Image.ToolTip = GetToolTipText(buttonSettings, buttonType, "Expand All");

            CollapseAllButton.Enabled = GetButtonEnabledState();

            CollapseAllButton.ClientSideEvents.Click = GetScheduledCommandHandler("CollapseAll");
        }


        private string GetControlID(string context)
        {
            return context + RenderHelper.GetColumnGlobalIndex(Column);
        }

        private static GridViewCommandButtonType GetButtonType(ASPxSmartGridViewECCommandButtonSettings buttonSettings, GridViewCommandButtonType columnButtonType)
        {
            if (buttonSettings.ButtonType != GridViewCommandButtonType.Default)
                return buttonSettings.ButtonType;
            
            if (columnButtonType != GridViewCommandButtonType.Default)
                return columnButtonType;
            
            return GridViewCommandButtonType.Link;
        }

        private static ButtonRenderMode ConvertToRenderMode(GridViewCommandButtonType buttonType)
        {
            switch (buttonType)
            {
                case GridViewCommandButtonType.Image:
                case GridViewCommandButtonType.Link:
                    return ButtonRenderMode.Link;
                default:
                    return ButtonRenderMode.Button;
            }
        }
        
        private static string GetButtonText(ASPxSmartGridViewECCommandButtonSettings buttonSettings, GridViewCommandButtonType buttonType, string defaultText)
        {
            var buttonText = GetValueOrDefault(buttonSettings.Text, defaultText);

            switch (buttonType)
            {
                case GridViewCommandButtonType.Image:
                    return buttonSettings.Image.IsEmpty ? buttonText : string.Empty;
                default:
                    return buttonText;
            }
        }

        private static string GetToolTipText(ASPxSmartGridViewECCommandButtonSettings buttonSettings, GridViewCommandButtonType buttonType, string defaultToolTip)
        {
            switch (buttonType)
            {
                case GridViewCommandButtonType.Image:
                    return GetValueOrDefault(buttonSettings.Text, defaultToolTip);
                default:
                    return string.Empty;
            }
        }

        protected virtual bool GetButtonEnabledState()
        {
            return Grid.IsGrouped() && Grid.HasVisibleRows();
        }


        private static string GetValueOrDefault(string value, string defaultValue)
        {
            return string.IsNullOrEmpty(value) ? defaultValue : value;
        }

        private static void SetImageSettings(ASPxButton button, ASPxSmartGridViewECCommandButtonSettings buttonSettings, GridViewCommandButtonType buttonType)
        {
            switch (buttonType)
            {
                case GridViewCommandButtonType.Link:
                    break;
                default:
                    button.Image.CopyFrom(buttonSettings.Image);
                    break;
            }
        }


        private string GetScheduledCommandHandler(params object[] args)
        {
            return "function(){" + RenderHelper.Scripts.GetScheduledCommandHandler(args, true) + "}";    
        }
    }
}