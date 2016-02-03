using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Utils;
using DevExpress.Web.ASPxClasses;
using DevExpress.Web.ASPxClasses.Internal;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxRoundPanel.Internal;

namespace WebAppCommons.Classes.Controls.ASPx.xExpandablePanel.Internal
{
    public class RPExpandablePanelControl : RPRoundPanelControl
    {
        protected new ASPxExpandablePanel RoundPanel
        {
            get { return (ASPxExpandablePanel) base.RoundPanel; }
        }

        
        protected InternalTable HeaderTable { get; set; }
        protected TableRow HeaderContentRow { get; set; }
        protected TableCell HeaderImageCell { get; set; }
        protected TableCell HeaderTextCell { get; set; }
        protected TableCell HeaderECButtonCell { get; set; }
        
        protected Image HeaderImage { get; set; }
        protected WebControl HeaderText { get; set; }
        protected ASPxButton HeaderECButton { get; set; }

        protected WebControl CStateElement { get; set; }



        public RPExpandablePanelControl(ASPxExpandablePanel panel) : base(panel)
        {
        }



        protected internal virtual void RefreshState()
        {
            PrepareHeaderText();
            PrepareCellContent();
            PrepareCStateElement();
        }



        protected override void ClearControlFields()
        {
            base.ClearControlFields();

            HeaderTable = null;
            HeaderContentRow = null;
            HeaderImageCell = null;
            HeaderTextCell = null;
            HeaderECButtonCell = null;
            
            HeaderImage = null;
            HeaderText = null;
            HeaderECButton = null;
        }


        protected override void CreateControlHierarchy()
        {
            base.CreateControlHierarchy();

            CellHeaderContent.ID = RoundPanel.GetRoundPanelHeaderID();

            if (RoundPanel.HeaderTemplate == null)
            {
                HeaderControl.Clear();

                HeaderControl.Add(
                    HeaderTable = RenderUtils.CreateTable().Add(
                        HeaderContentRow = RenderUtils.CreateTableRow()
                    )
                );

                if (RoundPanel.HeaderImage.IsEmpty == false)
                {
                    CreateHeaderImageBlock();
                }
                
                CreateHeaderTextBlock();
                CreateHeaderECButton();
                CreateECStateControl();
            }
        }


        protected virtual void CreateHeaderImageBlock()
        {
            HeaderContentRow.Add(
                HeaderImageCell = RenderUtils.CreateTableCell().Add(
                    HeaderImage = RenderUtils.CreateImage()
                )
            );
        }

        protected virtual void CreateHeaderTextBlock()
        {
            HeaderContentRow.Add(
                HeaderTextCell = RenderUtils.CreateTableCell().Add(
                    HeaderText = RenderUtils.CreateWebControl(HtmlTextWriterTag.Span)
                )
            );

            HeaderText.ID = RoundPanel.GetHeaderTextContainerID();
        }

        protected virtual void CreateHeaderECButton()
        {
            HeaderContentRow.Add(
                HeaderECButtonCell = RenderUtils.CreateTableCell().Add(
                    HeaderECButton = new ASPxButton()
                )
            );

            HeaderECButton.ID = RoundPanel.GetHeaderECButtonID();
        }

        protected virtual void CreateECStateControl()
        {
            HeaderContentRow.Add(
                RenderUtils.CreateTableCell().SetStyle("display", "none").Add(
                    CStateElement = RenderUtils.CreateWebControl(HtmlTextWriterTag.Input)
                )
            );

            CStateElement.ID = RoundPanel.GetCStateControlID();
        }



        protected override void PrepareControlHierarchy()
        {
            base.PrepareControlHierarchy();

            FixHeaderPaddings();
            FixContentPaddings();

            PrepareHeaderTable();
            
            PrepareHeaderImage();
            PrepareHeaderText();
            PrepareHeaderECButton();

            PrepareCellContent();

            PrepareCStateElement();
        }


        protected virtual void FixHeaderPaddings()
        {
            // Приходится менять Paddings у CellHeaderContent именно на этом этапе
            // Это самый простой способ реализовать видимость "корректного" поведения
            
            var defaultPaddings = new Paddings(6, 5, 5, 5);
            var rightToLeftPaddings = new Paddings(5, 5, 6, 5);
            
            var paddings = RoundPanel.RightToLeft == DefaultBoolean.True ? rightToLeftPaddings : defaultPaddings;
            
            RenderUtils.SetPaddings(CellHeaderContent, paddings);
        }

        protected virtual void FixContentPaddings()
        {
            // Приходится менять Paddings у CellContent именно на этом этапе
            // Это самый простой способ реализовать видимость "корректного" поведения
            RenderUtils.SetPaddings(CellContent, new Paddings(10, 10, 10, 10));
        }

        protected virtual void PrepareHeaderTable()
        {
            if (HeaderTable == null) return;


            HeaderTable.Width = Unit.Percentage(100);
        }
       
        protected virtual void PrepareHeaderImage()
        {
            if (HeaderImage == null) return;


            HeaderImageCell.Width = Unit.Pixel(1);

            HeaderImage.CssClass = RoundPanel.GetHeaderImageCssClassName();
            RoundPanel.HeaderImage.AssignToControl(HeaderImage, DesignMode);

            if (IsRightToLeft)
            {
                RenderUtils.SetHorizontalMargins(HeaderImage, RoundPanel.GetImageSpacing(), Unit.Empty);
                RenderUtils.AlignBlockLevelElement(HeaderImage, HorizontalAlign.Right);
            }
            else
            {
                RenderUtils.SetHorizontalMargins(HeaderImage, Unit.Empty, RoundPanel.GetImageSpacing());
                RenderUtils.AlignBlockLevelElement(HeaderImage, HorizontalAlign.Left);
            }

            HeaderImage.AlternateText = RoundPanel.ToolTip;
            RenderUtils.AppendDefaultDXClassName(HeaderImage, RoundPanel.GetCssClassNamePrefix());
        }

        protected virtual void PrepareHeaderText()
        {
            if (HeaderText == null) return;


            HeaderText.CssClass = RoundPanel.GetHeaderTextCssClassName();
            
            RoundPanel.GetHeaderStyle().AssignToControl(HeaderText, AttributesRange.Font);
            
            HeaderText.Add(
                RenderUtils.CreateLiteralControl(
                    RoundPanel.HtmlEncode(RoundPanel.HeaderText)
                )
            );
        }

        protected virtual void PrepareHeaderECButton()
        {
            if (HeaderECButton == null) return;


            HeaderECButtonCell.Width = Unit.Pixel(1);

            HeaderECButton.EnableClientSideAPI = true;
            HeaderECButton.AutoPostBack = false;
            HeaderECButton.UseSubmitBehavior = false;
            HeaderECButton.AllowFocus = false;
            HeaderECButton.Width = Unit.Pixel(28);
            HeaderECButton.Height = Unit.Pixel(28);
        }

        protected virtual void PrepareCellContent()
        {
            if (CellContent == null) return;

            if (RoundPanel.Expanded == false)
            {
                RenderUtils.SetStyleStringAttribute(CellContent, "display", "none");
            }
        }

        protected virtual void PrepareCStateElement()
        {
            if (CStateElement == null) return;

            RenderUtils.SetStringAttribute(CStateElement, "name", CStateElement.ClientID);
            RenderUtils.SetStringAttribute(CStateElement, "type", "hidden");
            RenderUtils.SetStringAttribute(CStateElement, "value", CommonUtils.ValueToString(RoundPanel.ControlState.Save()));
            RenderUtils.SetStringAttribute(CStateElement, "autocomplete", "off");
        }
    }
}