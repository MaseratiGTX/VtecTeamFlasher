using System.ComponentModel;
using System.Web.UI;
using DevExpress.Web.ASPxClasses;
using DevExpress.Web.ASPxClasses.Internal;
using DevExpress.Web.ASPxGridView;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Settings
{
    public class ASPxSmartGridViewECCommandButtonSettings : ASPxGridViewBaseSettings
    {
        protected ButtonImagePropertiesBase image;


        [DefaultValue(GridViewCommandButtonType.Default)]
        [NotifyParentProperty(true)]
        public GridViewCommandButtonType ButtonType
        {
            get { return (GridViewCommandButtonType) GetEnumProperty("ButtonType", GridViewCommandButtonType.Default); }
            set
            {
                if (ButtonType == value) return;

                SetEnumProperty("ButtonType", GridViewCommandButtonType.Default, value);
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
        public ButtonImagePropertiesBase Image
        {
            get
            {
                return image ?? (image = new ButtonImagePropertiesBase(Grid));
            }
        }



        public ASPxSmartGridViewECCommandButtonSettings(ASPxGridView grid) : base(grid)
        {
        }



        public override void Assign(PropertiesBase source)
        {
            BeginUpdate();
            try
            {
                base.Assign(source);


                var commandButtonSettings = source as ASPxSmartGridViewECCommandButtonSettings;

                if (commandButtonSettings == null) return;

                ButtonType = commandButtonSettings.ButtonType;
                Text = commandButtonSettings.Text;
                Image.Assign(commandButtonSettings.Image);
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