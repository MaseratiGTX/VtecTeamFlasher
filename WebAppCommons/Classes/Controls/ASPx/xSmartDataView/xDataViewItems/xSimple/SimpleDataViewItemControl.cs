using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxClasses;
using DevExpress.Web.ASPxClasses.Internal;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartDataView.xDataViewItems.xSimple
{
    public class SimpleDataViewItemControl : ASPxWebControl
    {
        protected ASPxSimpleDataViewItem DataViewItem { get; set; }

        protected InternalTable MainControl { get; set; }
        protected Image ImageControl { get; set; }
        protected WebControl SpanControl { get; set; }
        protected LiteralControl LiteralControl { get; set; }



        public SimpleDataViewItemControl(ASPxSimpleDataViewItem owner)
        {
            DataViewItem = owner;
        }



        protected override void ClearControlFields()
        {
            base.ClearControlFields();

            MainControl = null;
            ImageControl = null;
            SpanControl = null;
            LiteralControl = null;
        }


        protected override void CreateControlHierarchy()
        {
            base.CreateControlHierarchy();

            Controls.Add(
                MainControl = RenderUtils.CreateTable().Add(
                    RenderUtils.CreateTableRow().Add(
                        RenderUtils.CreateTableCell().Add(
                            ImageControl = RenderUtils.CreateImage()
                        )
                    ),
                    RenderUtils.CreateTableRow().Add(
                        RenderUtils.CreateTableCell().Add(
                            SpanControl = RenderUtils.CreateWebControl(HtmlTextWriterTag.Span).Add(
                                LiteralControl = RenderUtils.CreateLiteralControl()
                            )
                        )
                    )
                )
            );
        }

        protected override void PrepareControlHierarchy()
        {
            if (MainControl == null) return;

            RenderUtils.AssignAttributes(DataViewItem, MainControl);
            RenderUtils.SetVisibility(MainControl, DataViewItem.IsClientVisible(), true);

            var controlStyle = DataViewItem.GetControlStyle();

            if (controlStyle.CssClass != "")
                MainControl.CssClass = controlStyle.CssClass;

            PrepareImageControl();
            PrepareSpanControl();
        }


        protected virtual void PrepareImageControl()
        {
            if (ImageControl == null) return;

            DataViewItem.Image.AssignToControl(ImageControl, DataViewItem.DesignMode, !DataViewItem.Enabled);
        }

        protected virtual void PrepareSpanControl()
        {
            if (SpanControl == null) return;

            DataViewItem.GetControlStyle().AssignToControl(SpanControl, AttributesRange.Font);
            
            PrepareLiteralControl();
        }

        private void PrepareLiteralControl()
        {
            if (LiteralControl == null) return;

            LiteralControl.Text = DataViewItem.Text;
        }
    }
}