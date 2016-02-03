using System.ComponentModel;
using System.Web.UI;
using DevExpress.Web.ASPxClasses;
using DevExpress.Web.ASPxClasses.Internal;
using DevExpress.Web.ASPxGridView;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Settings
{
    public class ASPxSmartGridViewCommandButtonSeparatorSettings : ASPxGridViewBaseSettings
    {
        protected ImageProperties image;


        [DefaultValue(ASPxSmartGridViewCommandButtonSeparatorType.Default)]
        [NotifyParentProperty(true)]
        public ASPxSmartGridViewCommandButtonSeparatorType SeparatorType
        {
            get { return (ASPxSmartGridViewCommandButtonSeparatorType) GetEnumProperty("SeparatorType", ASPxSmartGridViewCommandButtonSeparatorType.Default); }
            set
            {
                if (SeparatorType == value) return;

                SetEnumProperty("SeparatorType", ASPxSmartGridViewCommandButtonSeparatorType.Default, value);
                Changed();
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
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ImageProperties Image {
            get
            {
                return image ?? (image = new ImageProperties(Grid))        ;
            }
        }


        
        public ASPxSmartGridViewCommandButtonSeparatorSettings(ASPxGridView grid) : base(grid)
        {
        }



        public override void Assign(PropertiesBase source)
        {
            BeginUpdate();
            try
            {
                base.Assign(source);


                var commandButtonSeparatorSettings = source as ASPxSmartGridViewCommandButtonSeparatorSettings;

                if (commandButtonSeparatorSettings == null) return;

                SeparatorType = commandButtonSeparatorSettings.SeparatorType;
                Text = commandButtonSeparatorSettings.Text;
                Image.Assign(commandButtonSeparatorSettings.Image);
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