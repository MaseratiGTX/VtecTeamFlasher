using System;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxClasses.Internal;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.ASPxGridView.Rendering;
using WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Helpers.GridViewPagerBarTemplateContainers;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.TemplateReplacements
{
    public class ASPxSmartGridViewTemplateReplacement : ASPxGridViewTemplateReplacement
    {
        protected new GridViewBaseTemplateContainer Container { get;set; }

        protected ASPxSmartGridView Grid
        {
            get { return (ASPxSmartGridView) Container.Grid; }
        }
        


        protected override void CreateChildControls()
        {
            Container = null;
            
            if (DesignMode) return;
            
            Container = FindTemplateContainer<GridViewBaseTemplateContainer>();

            if (Container == null)
            {
                throw new InvalidOperationException("A control of type 'ASPxGridViewTemplateReplacement' can only be placed inside a ASPxGridView template.");
            }

            CreateStuffing();
            
            RenderUtils.EnsureChildControlsRecursive(this, false);
        }


        private T FindTemplateContainer<T>() where T : GridViewBaseTemplateContainer
        {
            for (var parent = Parent; parent != null; parent = parent.Parent)
            {
                var result = parent as T;
                
                if (result != null)
                {
                    return result;
                }
            }
            
            return default(T);
        }


        private void CreateStuffing()
        {
            switch (ReplacementType)
            {
                case GridViewTemplateReplacementType.EditFormContent:
                    CreateEditorsTable(true);
                    break;
                case GridViewTemplateReplacementType.EditFormCancelButton:
                    CreateCancelButton();
                    break;
                case GridViewTemplateReplacementType.EditFormUpdateButton:
                    CreateUpdateButton();
                    break;
                case GridViewTemplateReplacementType.EditFormEditors:
                    CreateEditorsTable(false);
                    break;
                case GridViewTemplateReplacementType.EditFormCellEditor:
                    CreateCellEditor();
                    break;
                case GridViewTemplateReplacementType.Pager:
                    CreatePager();
                    break;
                default:
                    throw new NotSupportedException();
            }
        }


        private void CreateEditorsTable(bool renderUpdateCancelButtons)
        {
            var templateContainer = (GridViewEditFormTemplateContainer)Container;
            
            Controls.Add(
                new GridViewEditFormTable(Grid.RenderHelper, templateContainer.VisibleIndex, renderUpdateCancelButtons)
            );
        }

        private void CreateCancelButton()
        {
            var postponeClick = Container is GridViewEditFormTemplateContainer && !Grid.RenderHelper.RequireRenderEditFormPopup;

            GridViewCommandItemsCell.CreateCancelButton(this, Grid, postponeClick);
        }

        private void CreateUpdateButton()
        {
            if(Grid.ReadOnly) return;

            var postponeClick = Container is GridViewEditFormTemplateContainer && !Grid.RenderHelper.RequireRenderEditFormPopup;

            GridViewCommandItemsCell.CreateUpdateButton(this, Grid, postponeClick);
        }

        private void CreateCellEditor()
        {
            var templateContainer = (GridViewEditFormTemplateContainer) Container;
            
            try
            {
                var column = Grid.ColumnHelper.FindColumnByKey(ColumnID) as GridViewDataColumn;
                
                // ReSharper disable PossibleNullReferenceException
                var editingRowValue = Grid.DataProxy.GetEditingRowValue(templateContainer.VisibleIndex, column.FieldName);
                // ReSharper restore PossibleNullReferenceException
                
                var gridEditor = Grid.RenderHelper.CreateGridEditor(column, editingRowValue, EditorInplaceMode.EditForm, false);
                
                Controls.Add(gridEditor);
                
                Grid.RenderHelper.ApplyEditorSettings(gridEditor, column);

                if (RequireFullCellEditorWidth(gridEditor))
                    gridEditor.Width = Unit.Percentage(100.0);
                if (RequireFullCellEditorHeight(gridEditor))
                    gridEditor.Height = Unit.Percentage(100.0);

                Grid.RaiseEditorInitialize_Internal(
                    new ASPxGridViewEditorEventArgs(column, templateContainer.VisibleIndex, gridEditor, Grid.DataProxy.EditingKeyValue, editingRowValue)
                );
            }
            catch
            {
                Controls.Add(
                    RenderUtils.CreateLiteralControl(
                        string.Format("[Replacement failed for column '{0}']", ColumnID)
                    )
                );
            }
        }

        private static bool RequireFullCellEditorWidth(ASPxEditBase cellEditor)
        {
            return cellEditor.Width.IsEmpty;
        }

        private static bool RequireFullCellEditorHeight(ASPxEditBase cellEditor)
        {
            var aspxMemo = cellEditor as ASPxMemo;
            if (aspxMemo != null)
            {
                return aspxMemo.Height.IsEmpty && aspxMemo.Rows == 0;
            }

            return false;
        }


        private void CreatePager()
        {
            var templateContainer = (GridViewPagerBarTemplateContainer) Container;
            
            Controls.Add(
                GridViewHtmlPagerPanelBase.CreatePager(templateContainer.Grid, templateContainer._PagerId())
            );
        }
    }
}