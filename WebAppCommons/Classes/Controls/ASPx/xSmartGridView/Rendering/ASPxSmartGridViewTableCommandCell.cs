using System.Linq;
using System.Web.UI.WebControls;
using Commons.Helpers.Collections.Generic;
using DevExpress.Utils;
using DevExpress.Web.ASPxClasses.Internal;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.ASPxGridView.Rendering;
using WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Columns;
using WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Helpers.GridViewCommandColumnButtonControls;
using WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Helpers.GridViewCommandColumnCustomButtons;
using WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Rendering.ControlsContainers;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Rendering
{
    public class ASPxSmartGridViewTableCommandCell : GridViewTableCommandCell
    {
        protected new ASPxSmartGridViewRenderHelper RenderHelper
        {
            get { return (ASPxSmartGridViewRenderHelper) base.RenderHelper; }
        }

        protected new ASPxSmartGridView Grid
        {
            get { return (ASPxSmartGridView) base.Grid; }
        }


        protected IControlsContainer ControlsContainer { get; set; }

        protected bool Autosize
        {
            get
            {
                return Column is SmartGridViewCommandColumn && ((SmartGridViewCommandColumn) Column).Autosize;
            }
        }

        protected bool ShowCommandButtonsInline
        {
            get
            {
                return (Column is SmartGridViewCommandColumn && ((SmartGridViewCommandColumn) Column).ShowCommandButtonsInline) || Autosize;
            }
        }
        


        public ASPxSmartGridViewTableCommandCell(ASPxGridViewRenderHelper renderHelper, GridViewCommandColumn column, int visibleIndex, bool removeLeftBorder, bool removeRightBorder)
            : base(renderHelper, column, visibleIndex, removeLeftBorder, removeRightBorder)
        {
        }


        protected override void CreateControlHierarchy()
        {
            ControlsContainer = CreateControlsContainer();

            if (IsRowEditing)
            {
                if (IsEditorButton && RenderHelper.Grid.SettingsEditing.Mode == GridViewEditingMode.Inline)
                {
                    CreateUpdateCancelButton();
                }
            }
            else
            {
                // ReSharper disable CSharpWarnings::CS0618
                CreateCommandButton(Column.EditButton);
                if (Grid.ReadOnly == false)
                {
                    CreateCommandButton(Column.NewButton);
                    CreateCommandButton(Column.DeleteButton);
                }
                CreateCommandButton(Column.SelectButton);
                // ReSharper restore CSharpWarnings::CS0618
            }

            CreateCustomCommandButtons();

            if (ControlsContainer.IsEmpty)
            {
                Text = "&nbsp;";
            }
        }


        protected override void PrepareControlHierarchy()
        {
            #region IMPLEMENTATION OF GridViewTableCommandCell.PrepareControlHierarchy

            #region IMPLEMENTATION OF GridViewTableBaseCommandCell.PrepareControlHierarchy

            RenderHelper.GetCommandColumnStyle(Column).AssignToControl(this, true);
            
            var commandColumnItemStyle = RenderHelper.GetCommandColumnItemStyle(Column);
                commandColumnItemStyle.CssClass = RenderUtils.CombineCssClasses(commandColumnItemStyle.CssClass, "dxgv__cci");

            ControlsContainer.Controls.Evict(x => x is GridViewCommandColumnSpacer)
                .Select(control =>
                    {
                        if (control is GridViewCommandColumnButtonControl)
                        {
                            return ((GridViewCommandColumnButtonControl) control)._Control();
                        }
                        
                        return control;
                    }
                )
                .Each(actualControl =>
                    {
                        commandColumnItemStyle.AssignToControl(actualControl, true);
                    }
                );


            RenderHelper.AppendGridCssClassName(this);

            Grid.RaiseHtmlCommandCellPrepared_Internal(this);

            #region IMPLEMENTATION OF GridViewTableCellEx.PrepareControlHierarchy

            if (GetRemoveLeftBorder())
                RenderUtils.SetStyleUnitAttribute(this, "border-left-width", 0);

            if (GetRemoveRightBorder())
                RenderUtils.SetStyleUnitAttribute(this, "border-right-width", 0);

            if (RemoveBottomBorder)
                RenderUtils.SetStyleUnitAttribute(this, "border-bottom-width", 0);

            if (HorizontalAlign == HorizontalAlign.NotSet && RenderHelper.IsRightToLeft && RenderHelper.RequireFixedTableLayout)
            {
                HorizontalAlign = HorizontalAlign.Right;
            }

            #endregion

            RenderHelper.SetCellWidthIfRequired(Column, this, VisibleIndex);

            #endregion

            HorizontalAlign = HorizontalAlign.Center;

            #endregion

            if (Autosize)
            {
                Width = RenderHelper.GetNarrowCellWidth();
            }
        }


        protected virtual IControlsContainer CreateControlsContainer()
        {
            if (ShowCommandButtonsInline)
            {
                return new OneRowTableControlsContainer(this);
            }
            
            return new SimpleControlsContainer(this);
        }


        protected virtual void CreateCommandButton(GridViewCommandColumnCustomButton button)
        {
            var eventArgs = new ASPxGridViewCustomButtonEventArgs(button, VisibleIndex, CellType, IsRowEditing);
            
            Grid.RaiseCustomButtonInitialize_Internal(eventArgs);
            
            switch (eventArgs.Visible)
            {
                case DefaultBoolean.False:
                    return;
                case DefaultBoolean.Default:
                    if (button._IsVisible(CellType, IsRowEditing))
                    {
                        break;
                    }
                    
                    return;
            }
            
            CreateCommandButtonSpacerIfNeeded();
            
            ControlsContainer.Add(
                new GridViewCommandColumnButtonControl(eventArgs, Grid, Scripts.GetCustomButtonFuncArgs, true)
            );
        }

        protected virtual void CreateCommandButton(GridViewCommandColumnButton button)
        {
            CreateCommandButton(button, false);
        }

        protected virtual void CreateCommandButton(GridViewCommandColumnButton button, bool visibleByDefault)
        {
            CreateCommandButton(
                RenderHelper.CreateCommandButtonControl(button, VisibleIndex, true, visibleByDefault)
            );
        }

        protected virtual void CreateCommandButton(GridViewCommandColumnButtonControl buttonControl)
        {
            if (buttonControl == null) return;

            CreateCommandButtonSpacerIfNeeded();
            
            ControlsContainer.Add(buttonControl);
        }

        protected virtual void CreateCommandButtonSpacerIfNeeded()
        {
            if (ControlsContainer.IsNotEmpty)
            {
                var spacing = RenderHelper.GetCommandColumnStyle(Column).Spacing;

                if (spacing.IsEmpty)
                {
                    spacing = GetDefaultCommandColumnSpacing();
                }

                if (spacing.IsEmpty == false)
                {
                    ControlsContainer.Add(
                        new GridViewCommandColumnSpacer(spacing)
                    );
                }
            }
        }

        protected virtual Unit GetDefaultCommandColumnSpacing()
        {
            if (ShowCommandButtonsInline)
            {
                return Unit.Pixel(3);
            }

            return Unit.Empty;
        }

        protected virtual void CreateUpdateCancelButton()
        {
            // ReSharper disable CSharpWarnings::CS0618
            CreateCommandButton(Column.UpdateButton, true);
            CreateCommandButton(Column.CancelButton, true);
            // ReSharper restore CSharpWarnings::CS0618
        }

        protected virtual void CreateCustomCommandButtons()
        {
            foreach (GridViewCommandColumnCustomButton button in Column.CustomButtons) {
                CreateCommandButton(button);
            }
        }
    }
}