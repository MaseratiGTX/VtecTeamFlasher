using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.Web.ASPxPopupControl;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Settings
{
    public class ASPxSmartGridViewHtmlEditFormPopupClientSideEvents : PopupControlClientSideEvents
    {
        [NotifyParentProperty(true)]
        [Localizable(false)]
        [DefaultValue("")]
        public string ParentGridViewAttached
        {
            get { return GetEventHandler("ParentGridViewAttached"); }
            set { SetEventHandler("ParentGridViewAttached", value); }
        }

        [NotifyParentProperty(true)]
        [Localizable(false)]
        [DefaultValue("")]
        public string ParentGridViewDetached
        {
            get { return GetEventHandler("ParentGridViewDetached"); }
            set { SetEventHandler("ParentGridViewDetached", value); }
        }



        protected override void AddEventNames(List<string> names)
        {
            base.AddEventNames(names);

            names.Add("ParentGridViewAttached");
            names.Add("ParentGridViewDetached");
        }
    }
}