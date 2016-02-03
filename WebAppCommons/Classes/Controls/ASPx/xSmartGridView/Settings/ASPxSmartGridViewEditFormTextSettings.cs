using System.ComponentModel;
using DevExpress.Web.ASPxClasses;
using DevExpress.Web.ASPxGridView;
using WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Helpers;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Settings
{
    public class ASPxSmartGridViewEditFormTextSettings : ASPxGridViewBaseSettings
    {
        protected new ASPxSmartGridView Grid
        {
            get { return (ASPxSmartGridView) base.Grid; }
        }


        protected ASPxGridViewItemValuesTemplate popupEditFormCaptionTemplate;


        [NotifyParentProperty(true)]
        [Localizable(true)]
        [DefaultValue("")]
        public string CommandUpdate
        {
            get { return GetStringProperty("CommandUpdate", string.Empty); }
            set
            {
                if (value == CommandUpdate) return;

                SetStringProperty("CommandUpdate", string.Empty, value);
                Changed();
            }
        }

        [NotifyParentProperty(true)]
        [DefaultValue(20)]
        public int CommandUpdateWidth
        {
            get { return GetIntProperty("CommandUpdateWidth", 20); }
            set
            {
                if (value == CommandUpdateWidth) return;

                SetIntProperty("CommandUpdateWidth", 20, value);
                Changed();
            }
        }

        [NotifyParentProperty(true)]
        [Localizable(true)]
        [DefaultValue("")]
        public string PopupEditFormCaption
        {
            get { return GetStringProperty("PopupEditFormCaption", string.Empty); }
            set
            {
                if (value == PopupEditFormCaption) return;

                SetStringProperty("PopupEditFormCaption", string.Empty, value);
                popupEditFormCaptionTemplate = null;
                Changed();
            }
        }

        public ASPxGridViewItemValuesTemplate PopupEditFormCaptionTemplate 
        {
            get { return popupEditFormCaptionTemplate ?? (popupEditFormCaptionTemplate = new ASPxGridViewItemValuesTemplate(PopupEditFormCaption)); }
        }

        [NotifyParentProperty(true)]
        [DefaultValue(60)]
        public int PopupEditFormCaptionWidth
        {
            get { return GetIntProperty("PopupEditFormCaptionWidth", 60); }
            set
            {
                if (value == PopupEditFormCaptionWidth) return;

                SetIntProperty("PopupEditFormCaptionWidth", 60, value);
                Changed();
            }
        }



        public ASPxSmartGridViewEditFormTextSettings(ASPxSmartGridView grid) : base(grid)
        {
        }



        public override void Assign(PropertiesBase source)
        {
            BeginUpdate();
            try
            {
                base.Assign(source);


                var editFormTextSettings = source as ASPxSmartGridViewEditFormTextSettings;
                
                if (editFormTextSettings == null) return;


                CommandUpdate = editFormTextSettings.CommandUpdate;
                CommandUpdateWidth = editFormTextSettings.CommandUpdateWidth;
                PopupEditFormCaption = editFormTextSettings.PopupEditFormCaption;
                PopupEditFormCaptionWidth = editFormTextSettings.PopupEditFormCaptionWidth;
            }
            finally
            {
                EndUpdate();
            }
        }

    }
}