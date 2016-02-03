using System.Web.UI;
using DevExpress.Web.ASPxClasses;
using DevExpress.Web.ASPxClasses.Internal;
using DevExpress.Web.ASPxEditors;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartDataView.xDataViewItems.xSimple
{
    public class ASPxSimpleDataViewItem : ASPxStaticEdit, ITextControl
    {
        protected SimpleDataViewItemControl DataViewItemControl { get; set; }


        protected internal new SimpleDataViewItemProperties Properties
        {
            get { return base.Properties as SimpleDataViewItemProperties; }
        }


        public ImagePropertiesEx Image 
        {
            get { return Properties.Image; }
        }

        public virtual string Text
        {
            get { return Properties.Text; }
            set { Properties.Text = value; }
        }

        public override string ToolTip
        {
            get { return Properties.ToolTip; }
            set { Properties.ToolTip = value; }
        }



        public ASPxSimpleDataViewItem()
        {
        }
        
        public ASPxSimpleDataViewItem(ASPxWebControl ownerControl) : base(ownerControl)
        {
        }



        protected override EditPropertiesBase CreateProperties()
        {
            return new SimpleDataViewItemProperties(this);
        }


        public override bool IsClientSideAPIEnabled()
        {
            return false;
        }

        protected override bool HasSpriteCssFile()
        {
            return false;
        }


        protected override void RegisterDefaultRenderCssFile()
        {
            base.RegisterDefaultRenderCssFile();

            ResourceManager.RegisterCssResource(Page, typeof(ASPxSimpleDataViewItem), "WebAppCommons.Styles.Controls.ASPx.ASPxSimpleDataViewItem.css");
        }

        protected override void PrepareControlStyle(AppearanceStyleBase style)
        {
            base.PrepareControlStyle(style);

            style.CssClass = RenderUtils.CombineCssClasses(style.CssClass, "dxsdvi");
        }


        protected override void ClearControlFields()
        {
            DataViewItemControl = null;
        }

        protected override void CreateControlHierarchy()
        {
            Controls.Add(
                DataViewItemControl = new SimpleDataViewItemControl(this)
            );
        }
    }
}