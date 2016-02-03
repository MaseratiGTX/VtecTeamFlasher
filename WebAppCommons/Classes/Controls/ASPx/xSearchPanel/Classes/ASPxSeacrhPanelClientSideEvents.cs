using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.Web.ASPxClasses;
using WebAppCommons.Classes.Controls.ASPx.xExpandablePanel.Classes;

namespace WebAppCommons.Classes.Controls.ASPx.xSearchPanel.Classes
{
    public class ASPxSeacrhPanelClientSideEvents : ASPxExpandablePanelClientSideEvents
    {
        [NotifyParentProperty(true)]
        [Localizable(false)]
        [DefaultValue("")]
        public string PerformSearchClick
        {
            get { return GetEventHandler("PerformSearchClick"); }
            set { SetEventHandler("PerformSearchClick", value); }
        }

        [NotifyParentProperty(true)]
        [Localizable(false)]
        [DefaultValue("")]
        public string CancelSearchClick
        {
            get { return GetEventHandler("CancelSearchClick"); }
            set { SetEventHandler("CancelSearchClick", value); }
        }



        public ASPxSeacrhPanelClientSideEvents()
        {
        }

        public ASPxSeacrhPanelClientSideEvents(IPropertiesOwner owner) : base(owner)
        {
        }



        protected override void AddEventNames(List<string> names)
        {
            base.AddEventNames(names);

            names.Add("PerformSearchClick");
            names.Add("CancelSearchClick");
        }
    }
}