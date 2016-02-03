using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxClasses;
using DevExpress.Web.ASPxClasses.Internal;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.ASPxGridView.Rendering;
using WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Columns;
using WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Helpers.GridViewBaseTemplateContainers;
using WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Helpers.GridViewCommandColumnButtons;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Rendering
{
    public class ASPxSmartGridViewRenderHelper : ASPxGridViewRenderHelper
    {
        public new ASPxSmartGridView Grid
        {
            get { return (ASPxSmartGridView) base.Grid; }
        }


        public bool RequireHeaderBottomBorder
        {
            get
            {
                return DataProxy.VisibleRowCountOnPage != 0 || HasEmptyDataRow || ShowHorizontalScrolling || ShowVerticalScrolling;
            }
        }



        public ASPxSmartGridViewRenderHelper(ASPxSmartGridView grid) : base(grid)
        {
        }



        protected internal new string GetSelectInputValue()
        {
            return base.GetSelectInputValue();
        }

        
        public new AppearanceStyle GetRootTableStyle()
        {
            return Grid.PrepareEnabledRootTableStyle_Internal(base.GetRootTableStyle());
        }

        public new AppearanceStyle GetDisabledRootTableStyle()
        {
            return Grid.PrepareDisabledRootTableStyle_Internal(base.GetDisabledRootTableStyle());
        }


        protected internal virtual TableCell CreateHeaderCell(int layoutLevel, GridViewColumn column, GridViewHeaderLocation location, bool removeLeftBorder, bool removeRightBorder)
        {
            if (layoutLevel == 0)
            {
                if (column is SmartGridViewCommandColumn)
                    return new ASPxSmartGridViewCommandColumnHeaderCell(this, column as SmartGridViewCommandColumn, location, removeLeftBorder, removeRightBorder);
            }
            
            return new ASPxSmartGridViewTableHeaderCell(this, column, location, removeLeftBorder, removeRightBorder);
        }

        protected override TableCell CreateContentCell(GridViewTableDataRow row, GridViewColumn column, int index, int visibleRowIndex)
        {
            if (column is GridViewDataColumn)
                return new GridViewTableDataCell(this, row, column as GridViewDataColumn, visibleRowIndex, ShouldRemoveLeftBorder(index), ShouldRemoveRightBorder(index));
            
            if (column is GridViewCommandColumn)
                return new ASPxSmartGridViewTableCommandCell(this, column as GridViewCommandColumn, visibleRowIndex, ShouldRemoveLeftBorder(index), ShouldRemoveRightBorder(index));
            
            if (column is GridViewBandColumn)
                return new GridViewTableEmptyBandCell(this, column, visibleRowIndex, ShouldRemoveLeftBorder(index), ShouldRemoveRightBorder(index));
            
            return RenderUtils.CreateTableCell();
        }



        public new GridViewCommandColumnButtonControl CreateCommandButtonControl(GridViewCommandColumnButton button, int visibleIndex, bool postponeClick, bool visibleByDefault)
        {
            if (!visibleByDefault && !button._GetIsVisible()) return null;

            var commandButtonSettings = GetCommandButtonSettings(button.ButtonType);
            var buttonType = GetButtonType(commandButtonSettings, button._Column().ButtonType);
            
            var text = !string.IsNullOrEmpty(button.Text) ? button.Text : commandButtonSettings.Text;
            
            if (string.IsNullOrEmpty(text))
                text = Grid.SettingsText.GetCommandButtonText(button.ButtonType);
            
            var image = new ImageProperties();
            image.CopyFrom(commandButtonSettings.Image);
            image.CopyFrom(button.Image);

            return CreateCommandButtonControl(button._Column(), button.ButtonType, buttonType, text, image, visibleIndex, postponeClick);
        }

        protected new GridViewCommandColumnButtonControl CreateCommandButtonControl(GridViewCommandColumn column, ColumnCommandButtonType commandItemType, GridViewCommandButtonType buttonType, string text, ImageProperties image, int visibleIndex, bool postponeClick)
        {
            if (!CanCreateCommandButton(commandItemType)) return null;
            
            var isEditingRow = DataProxy.IsNewRowEditing && visibleIndex == -2147483647 || visibleIndex >= 0 && DataProxy.IsRowEditing(visibleIndex);
            
            var eventArgs = new ASPxGridViewCommandButtonEventArgs(column, commandItemType, text, image, visibleIndex, isEditingRow, buttonType);
            
            Grid.RaiseCommandButtonInitialize_Internal(eventArgs);
            
            return eventArgs.Visible ? new GridViewCommandColumnButtonControl(eventArgs, Grid, GetCommandButtonClickHandlerArgs(commandItemType), postponeClick) : null;
        }


        protected new GridViewCommandButtonSettings GetCommandButtonSettings(ColumnCommandButtonType commandItemType)
        {
            switch (commandItemType)
            {
                case ColumnCommandButtonType.Edit:
                    return Grid.ReadOnly ? Grid.SettingsCommandButton.ViewButton : Grid.SettingsCommandButton.EditButton;
                case ColumnCommandButtonType.New:
                    return Grid.SettingsCommandButton.NewButton;
                case ColumnCommandButtonType.Delete:
                    return Grid.SettingsCommandButton.DeleteButton;
                case ColumnCommandButtonType.Select:
                    return Grid.SettingsCommandButton.SelectButton;
                case ColumnCommandButtonType.Update:
                    return Grid.SettingsCommandButton.UpdateButton;
                case ColumnCommandButtonType.Cancel:
                    return Grid.SettingsCommandButton.CancelButton;
                case ColumnCommandButtonType.ClearFilter:
                    return Grid.SettingsCommandButton.ClearFilterButton;
                case ColumnCommandButtonType.ApplyFilter:
                    return Grid.SettingsCommandButton.ApplyFilterButton;
                default:
                    return null;
            }
        }


        protected new GetCommandColumnButtonClickHandlerArgs GetCommandButtonClickHandlerArgs(ColumnCommandButtonType commandItemType)
        {
            switch (commandItemType)
            {
                case ColumnCommandButtonType.New:
                    return GetAddNewRowFuncArgs;
            }
            
            return base.GetCommandButtonClickHandlerArgs(commandItemType);
        }

        protected object[] GetAddNewRowFuncArgs(string id, int visibleIndex)
        {
            return new object[]
            {
                "AddNew", 
                visibleIndex
            };
        }


        
        public override void ApplyEditorSettings(ASPxEditBase baseEditor, GridViewDataColumn column)
        {
            base.ApplyEditorSettings(baseEditor, column);

            if (column.ReadOnly == false)
            {
                baseEditor.ReadOnly(false);
            }
        }



        public new bool AddDetailRowTemplateControl(int visibleIndex, GridViewTableDetailRow row, int spanCount)
        {
            var detailRow = Grid.Templates.DetailRow;
            
            if (detailRow == null) return false;
            
            AddTemplateToControl(
                CreateTemplateCell(row, spanCount), 
                detailRow, 
                new GridViewDetailRowTemplateContainer(
                    Grid, 
                    DataProxy.GetRowForTemplate(visibleIndex), 
                    visibleIndex
                ), 
                DetailRowTemplates
            );
            
            return true;
        }

        public new bool AddEmptyDataRowTemplateControl(TableRow row, int spanCount)
        {
            var emptyDataRow = Grid.Templates.EmptyDataRow;
            
            if (emptyDataRow == null || IsGridExported) return false;
            
            AddTemplateToControl(
                CreateTemplateCell(row, spanCount), 
                emptyDataRow, 
                new GridViewEmptyDataRowTemplateContainer(
                    Grid
                ), 
                EmptyDataRowTemplates
            );

            return true;
        }

        public new bool AddFilterRowTemplateControl(TableRow row, int spanCount)
        {
            var filterRow = Grid.Templates.FilterRow;
            
            if (filterRow == null || IsGridExported) return false;
            
            AddTemplateToControl(
                CreateTemplateCell(row, spanCount), 
                filterRow, 
                new GridViewFilterRowTemplateContainer(
                    Grid
                ), 
                FilterRowTemplates
            );
            
            return true;
        }

        public new bool AddFooterRowTemplateControl(TableRow row, int spanCount)
        {
            var footerRow = Grid.Templates.FooterRow;
            
            if (footerRow == null || IsGridExported) return false;

            AddTemplateToControl(
                CreateTemplateCell(row, spanCount), 
                footerRow, 
                new GridViewFooterRowTemplateContainer(
                    Grid
                ), 
                FooterRowTemplates
            );
            
            return true;
        }

        public new bool AddGroupFooterRowTemplateControl(TableRow row, GridViewDataColumn column, int spanCount, int visibleIndex)
        {
            var groupFooterRow = Grid.Templates.GroupFooterRow;
            
            if (groupFooterRow == null || IsGridExported) return false;
            
            AddTemplateToControl(
                CreateTemplateCell(row, spanCount), 
                groupFooterRow, 
                new GridViewGroupFooterRowTemplateContainer(
                    Grid, 
                    column, 
                    DataProxy.GetRowForTemplate(visibleIndex), 
                    visibleIndex
                ), 
                GroupFooterRowTemplates
            );
            
            return true;
        }

        public new bool AddGroupRowTemplateControl(int visibleIndex, GridViewDataColumn column, TableRow row, int spanCount)
        {
            var template = GetTemplate(Grid.Templates.GroupRow, column.GroupRowTemplate);
            
            if (template == null || IsGridExported) return false;

            AddTemplateToControl(
                CreateTemplateCell(row, spanCount), 
                template, 
                new GridViewGroupRowTemplateContainer(
                    Grid, 
                    column, 
                    DataProxy.GetRowForTemplate(visibleIndex), 
                    visibleIndex
                ), 
                GroupRowTemplates
            );
            
            return true;
        }

        public new bool AddPreviewRowTemplateControl(int visibleIndex, GridViewTablePreviewRow row, int spanCount)
        {
            var previewRow = Grid.Templates.PreviewRow;
            
            if (previewRow == null || IsGridExported) return false;
            
            AddTemplateToControl(
                CreateTemplateCell(row, spanCount), 
                previewRow, 
                new GridViewPreviewRowTemplateContainer(
                    Grid, 
                    DataProxy.GetRowForTemplate(visibleIndex), 
                    visibleIndex
                ), 
                PreviewRowTemplates
            );
            
            return true;
        }


        protected virtual void AddTemplateToControl(Control destination, ITemplate template, GridViewBaseTemplateContainer templateContainer, TemplateContainerCollection collection)
        {
            var templateContainerID = templateContainer._GetID();
            template.InstantiateIn(templateContainer);
            templateContainer.AddToHierarchy(destination, templateContainerID);
            
            if (string.IsNullOrEmpty(destination.ID) && !string.IsNullOrEmpty(templateContainerID))
                destination.ID = "tc" + templateContainerID;
            
            if (collection == null)
                return;
            
            collection.Add(templateContainer);
        }


        protected virtual new TableCell CreateTemplateCell(TableRow row, int spanCount)
        {
            var cell = (TableCell) new GridViewTableCellEx(this);
                cell.ColumnSpan = spanCount;
            
            row.Cells.Add(cell);
            
            AppendGridCssClassName(cell);
            
            return cell;
        }

        private ITemplate GetTemplate(params ITemplate[] templates)
        {
            for (var index = templates.Length - 1; index >= 0; --index)
            {
                if (templates[index] != null)
                    return templates[index];
            }
            return null;
        }
    }
}