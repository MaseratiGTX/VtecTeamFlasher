using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxClasses.Internal;
using DevExpress.Web.ASPxEditors.FilterControl;
using DevExpress.Web.ASPxGridView.Rendering;
using WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Helpers;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Rendering
{
    public class ASPxSmartGridViewContainerControl : GridViewContainerControl
    {
        private ASPxSmartGridViewHtmlStyleTable styleTable;


        protected new ASPxSmartGridViewHtmlEditFormPopup PopupEditForm { get; set; }

        protected new ASPxSmartGridView Grid
        {
            get { return (ASPxSmartGridView) base.Grid; }
        }

        protected new ASPxSmartGridViewRenderHelper RenderHelper
        {
            get { return (ASPxSmartGridViewRenderHelper) base.RenderHelper; }
        }

        protected new GridViewHtmlScrollableControl ScrollableControl { get; set; }
        
        protected GridViewHtmlTable InternalDataTable { get; set; }
        
        protected WebControl HiddenInputContainer { get; set; }


        public new ASPxSmartGridViewHtmlStyleTable StyleTable
        {
            get { return styleTable; }
        }
        
        public new GridViewHtmlTable DataTable
        {
            get { return ScrollableControl != null ? ScrollableControl.GridViewContentTable : InternalDataTable; }
        }



        public ASPxSmartGridViewContainerControl(ASPxSmartGridView grid) : base(grid)
        {
        }



        protected override void CreateStyleTable()
        {
            if (RenderHelper.RequireEndlessPagingPartialLoad && RenderHelper.HasEmptyDataRow) return;

            styleTable = new ASPxSmartGridViewHtmlStyleTable(Grid);
            
            Controls.Add(StyleTable);
        }


        protected override void CreateControlHierarchy()
        {
            if (Grid.IsErrorOnCallbackCore) return;

            Grid.OnBeforeCreateControlHierarchy();
            
            if (Grid.Settings.ShowTitlePanel)
                AddControl(new ASPxSmartGridViewHtmlTitle(Grid), "DXTitle");
            
            if (RequireRenderTopPagerControl)
                AddControl(new GridViewHtmlTopPagerPanel(RenderHelper), "DXTopPagerPanel");
            
            if (Grid.Settings.ShowGroupPanel)
                Controls.Add(new ASPxSmartGridViewGroupPanel(RenderHelper));
            
            if (RenderHelper.ShowHorizontalScrolling || RenderHelper.ShowVerticalScrolling)
                AddControl(
                    ScrollableControl = new ASPxSmartGridViewHtmlScrollableControl(RenderHelper), 
                    "Scrollable"
                );
            else
                AddControl(
                    InternalDataTable = new ASPxSmartGridViewHtmlTable(RenderHelper), 
                    "DXMainTable"
                );

            if (RenderHelper.HasFixedColumns)
                AddControl(new GridViewHtmlFixedColumnsScrollableControl(RenderHelper), "FixedColumnsScrollable");
            
            if (!DesignMode)
            {
                Controls.Add(CreateHiddenImage("IADD", "gvDragAndDropArrowDown"));
                Controls.Add(CreateHiddenImage("IADU", "gvDragAndDropArrowUp"));
                Controls.Add(CreateHiddenImage("IDHF", "gvDragAndDropHideColumn"));
            }

            if (CanRenderPopupControls)
            {
                CreateCustomizationWindow();
                CreatePopupEditForm();
                CreatePopupFilterControlForm();
                CreateHeaderFilterControlPopup();
                
                if (DataProxy.HasParentRows)
                    Controls.Add(new ASPxSmartGridViewHtmlParentRowsWindow(RenderHelper, DataProxy));
            }

            if (RequireRenderBottomPagerControl)
                AddControl(new GridViewHtmlBottomPagerPanel(RenderHelper), "DXBottomPagerPanel");
            
            if (RequireRenderFilterBar)
                AddControl(new WebFilterControlPopupRow(Grid), "DXFilterBar");

            if (RequireRenderStatusBar)
                AddControl(new ASPxSmartGridViewHtmlStatusBar(Grid), "DXStatus");

            if (RenderHelper.AllowBatchEditing)
                CreateBatchEditorsContainer();

            CreateLoadingPanel();
            CreateInputControlsAndStyleTable();

            if (RenderHelper.RequireRenderFilterRowMenu)
                Controls.Add(new GridViewFilterRowMenu(Grid));
        }


        protected override void CreatePopupEditForm()
        {
            if (RenderHelper.RequireRenderEditFormPopup)
            {
                PopupEditForm = new ASPxSmartGridViewHtmlEditFormPopup(Grid, DataProxy.EditingRowVisibleIndex);

                Controls.Add(PopupEditForm);
                
                PopupEditForm.EnableViewState = false;
                PopupEditForm.ClientSideEvents.CloseButtonClick = Scripts.GetClosePopupEditFormFunction().ToCommonEventHandler();
            }
        }


        private void CreateBatchEditorsContainer()
        {
            Controls.Add(new GridViewBatchEditorsContainer(RenderHelper));
        }

        protected override void CreateInputControlsAndStyleTable()
        {
            base.CreateInputControlsAndStyleTable();

            Controls.Add(
                HiddenInputContainer = RenderUtils.CreateDiv().SetStyle("display", "none")
            );
        }


        private void AddControl(Control control, string id)
        {
            control.ID = id;
            Controls.Add(control);
        }


        protected WebControl CreateInputControl(string id)
        {
            var result = RenderUtils.CreateWebControl(HtmlTextWriterTag.Input);
            result.ID = id;

            return result;
        }

        protected WebControl CreateHiddenImage(string id, string imageName)
        {
            var result = RenderUtils.CreateImage();
                result.ID = id;
                result.Style.Add(HtmlTextWriterStyle.Position, "absolute");
                result.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
                result.Style.Add(HtmlTextWriterStyle.Top, "-100px");

            RenderHelper.AssignImageToControl(imageName, result);

            return result;
        }



        protected void PrepareHiddenInput(WebControl control, object value = null)
        {
            if (control == null) return;


            RenderUtils.SetStringAttribute(control, "name", control.ClientID);
            RenderUtils.SetStringAttribute(control, "type", "hidden");

            if (value != null)
            {
                RenderUtils.SetStringAttribute(control, "value", CommonUtils.ValueToString(value));
            }

            RenderUtils.SetStringAttribute(control, "autocomplete", "off");
        }
    }
}