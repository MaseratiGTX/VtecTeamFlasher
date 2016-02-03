using System.ComponentModel;
using DevExpress.Web.ASPxClasses;
using DevExpress.Web.ASPxGridView;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Settings
{
    public class ASPxSmartGridViewBehaviorSettings : ASPxGridViewBehaviorSettings
    {
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        public bool ConfirmEditFormWindowUnload
        {
            get { return GetBoolProperty("ConfirmEditFormWindowUnload", false); }
            set
            {
                if (value == ConfirmEditFormWindowUnload) return;

                SetBoolProperty("ConfirmEditFormWindowUnload", false, value);
                Changed();
            }
        }



        public ASPxSmartGridViewBehaviorSettings(ASPxGridView grid) : base(grid)
        {
        }



        public override void Assign(PropertiesBase source)
        {
            BeginUpdate();
            try
            {
                base.Assign(source);

                
                var behaviorSettings = source as ASPxSmartGridViewBehaviorSettings;
                
                if (behaviorSettings == null) return;


                ConfirmEditFormWindowUnload = behaviorSettings.ConfirmEditFormWindowUnload;
            }
            finally
            {
                EndUpdate();
            }
        }
    }
}