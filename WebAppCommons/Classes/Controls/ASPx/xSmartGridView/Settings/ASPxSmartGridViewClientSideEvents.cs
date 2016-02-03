using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.Web.ASPxGridView;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Settings
{
    public class ASPxSmartGridViewClientSideEvents : GridViewClientSideEvents
    {
        [NotifyParentProperty(true)]
        [Localizable(false)]
        [DefaultValue("")]
        public string EditFormAttached
        {
            get { return GetEventHandler("EditFormAttached"); }
            set { SetEventHandler("EditFormAttached", value); }
        }

        [NotifyParentProperty(true)]
        [Localizable(false)]
        [DefaultValue("")]
        public string EditFormDetached
        {
            get { return GetEventHandler("EditFormDetached"); }
            set { SetEventHandler("EditFormDetached", value); }
        }

        [NotifyParentProperty(true)]
        [Localizable(false)]
        [DefaultValue("")]
        public string EditFormInit
        {
            get { return GetEventHandler("EditFormInit"); }
            set { SetEventHandler("EditFormInit", value); }
        }

        [NotifyParentProperty(true)]
        [Localizable(false)]
        [DefaultValue("")]
        public string EditFormPopUp
        {
            get { return GetEventHandler("EditFormPopUp"); }
            set { SetEventHandler("EditFormPopUp", value); }
        }

        [NotifyParentProperty(true)]
        [Localizable(false)]
        [DefaultValue("")]
        public string EditFormCloseUp
        {
            get { return GetEventHandler("EditFormCloseUp"); }
            set { SetEventHandler("EditFormCloseUp", value); }
        }

        
        [NotifyParentProperty(true)]
        [Localizable(false)]
        [DefaultValue("")]
        public string ValidationError
        {
            get { return GetEventHandler("ValidationError"); }
            set { SetEventHandler("ValidationError", value); }
        }

        [NotifyParentProperty(true)]
        [Localizable(false)]
        [DefaultValue("")]
        public string SourceElementNotFound
        {
            get { return GetEventHandler("SourceElementNotFound"); }
            set { SetEventHandler("SourceElementNotFound", value); }
        }

        [NotifyParentProperty(true)]
        [Localizable(false)]
        [DefaultValue("")]
        public string CallbackTargetNotFound
        {
            get { return GetEventHandler("CallbackTargetNotFound"); }
            set { SetEventHandler("CallbackTargetNotFound", value); }
        }

        [NotifyParentProperty(true)]
        [Localizable(false)]
        [DefaultValue("")]
        public string CommonCallbackError
        {
            get { return GetEventHandler("CommonCallbackError"); }
            set { SetEventHandler("CommonCallbackError", value); }
        }



        protected override void AddEventNames(List<string> names)
        {
            base.AddEventNames(names);

            names.Add("EditFormAttached");
            names.Add("EditFormDetached");
            names.Add("EditFormInit");
            names.Add("EditFormPopUp");
            names.Add("EditFormCloseUp");
            
            names.Add("ValidationError");
            names.Add("SourceElementNotFound");
            names.Add("CallbackTargetNotFound");
            names.Add("CommonCallbackError");
        }
    }
}