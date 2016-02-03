using System.ComponentModel;
using System.Web.UI;
using DevExpress.Web.ASPxClasses;
using DevExpress.Web.ASPxClasses.Internal;
using DevExpress.Web.ASPxEditors;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartDataView.xDataViewItems.xSimple
{
    public class SimpleDataViewItemProperties : StaticEditProperties
    {
        protected ImagePropertiesEx image;

        protected ASPxSimpleDataViewItem DataViewItem
        {
            get { return (ASPxSimpleDataViewItem) Owner; }
        }


        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ImagePropertiesEx Image
        {
            get
            {
                return image ?? (image = new ImagePropertiesEx(Owner));
            }
        }

        [NotifyParentProperty(true)]
        [Localizable(true)]
        [DefaultValue("")]
        public string Text
        {
            get { return GetStringProperty("Text", string.Empty); }
            set
            {
                if (Text == value) return;

                SetStringProperty("Text", string.Empty, value);
                Changed();
            }
        }

        [NotifyParentProperty(true)]
        [Localizable(true)]
        [DefaultValue("")]
        public string ToolTip
        {
            get { return GetStringProperty("ToolTip", string.Empty); }
            set
            {
                if (Text == value) return;

                SetStringProperty("ToolTip", string.Empty, value);
                Changed();
            }
        }



        public SimpleDataViewItemProperties()
        {
        }

        public SimpleDataViewItemProperties(IPropertiesOwner owner) : base(owner)
        {
        }



        protected override ASPxEditBase CreateEditInstance()
        {
            return new ASPxSimpleDataViewItem();
        }



        public override void Assign(PropertiesBase source)
        {
            BeginUpdate();
            try
            {
                base.Assign(source);


                var simpleDataViewItemProperties = source as SimpleDataViewItemProperties;

                if (simpleDataViewItemProperties == null) return;

                Image.Assign(simpleDataViewItemProperties.Image);
                Text = simpleDataViewItemProperties.Text;
                ToolTip = simpleDataViewItemProperties.ToolTip;
            }
            finally
            {
                EndUpdate();
            }

        }

        protected override IStateManager[] GetStateManagedObjects()
        {
            return ViewStateUtils.GetMergedStateManagedObjects(
                base.GetStateManagedObjects(),
                new IStateManager[]
                {
                    Image
                }
            );
        }
    }
}