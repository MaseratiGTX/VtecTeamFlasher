using System.Web.UI.WebControls;
using DevExpress.Web.ASPxClasses.Internal;
using DevExpress.Web.ASPxTabControl.Internal;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartPageControl
{
    public class SmartPageControlLite : PageControlLite
    {
        protected new ASPxSmartPageControl PageControl
        {
            get { return (ASPxSmartPageControl) base.PageControl; }
        }



        public SmartPageControlLite(ASPxSmartPageControl pageControl) : base(pageControl)
        {
        }


        protected override void CreateControlHierarchy()
        {
            if (IsTabsBeforeContent)
            {
                CreateTabs();
                CreateContent();
            }
            else
            {
                CreateContent();
                CreateTabs();
            }
        }

        protected new void CreateContent()
        {
            ContentsContainer = CreateContentContainer();
            CreateContentInternal();
        }

        protected new void CreateContentInternal()
        {
            for (var visibleIndex = 0; visibleIndex < PageControl.TabPages.GetVisibleTabPageCount(); visibleIndex++)
            {
                ContentsContainer.Controls.Add(
                    PageControl.CreateContentControl(visibleIndex)
                );
            }
        }


        protected override void PrepareControlHierarchy()
        {
            base.PrepareControlHierarchy();

            
            if (PageControl.Width.IsEmpty)
                Width = Unit.Percentage(100);

            if (PageControl.Height.IsEmpty)
                Height = Unit.Percentage(100);


            if (PageControl.MinWidth.IsEmpty == false)
                RenderUtils.SetStyleUnitAttribute(this, "min-width", PageControl.MinWidth);

            if (PageControl.MinHeight.IsEmpty == false)
                RenderUtils.SetStyleUnitAttribute(this, "min-height", PageControl.MinHeight);
        }
    }
}