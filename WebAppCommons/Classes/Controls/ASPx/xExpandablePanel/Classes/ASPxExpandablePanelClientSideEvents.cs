using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.Web.ASPxClasses;

namespace WebAppCommons.Classes.Controls.ASPx.xExpandablePanel.Classes
{
    public class ASPxExpandablePanelClientSideEvents : ClientSideEvents
    {
        [NotifyParentProperty(true)]
        [Localizable(false)]
        [DefaultValue("")]
        public string HeaderClick
        {
            get { return GetEventHandler("HeaderClick"); }
            set { SetEventHandler("HeaderClick", value); }
        }

        [NotifyParentProperty(true)]
        [Localizable(false)]
        [DefaultValue("")]
        public string Expanded
        {
            get { return GetEventHandler("Expanded"); }
            set { SetEventHandler("Expanded", value); }
        }

        [NotifyParentProperty(true)]
        [Localizable(false)]
        [DefaultValue("")]
        public string Collapsed
        {
            get { return GetEventHandler("Collapsed"); }
            set { SetEventHandler("Collapsed", value); }
        }


        
        public ASPxExpandablePanelClientSideEvents()
        {
        }

        public ASPxExpandablePanelClientSideEvents(IPropertiesOwner owner) : base(owner)
        {
        }



        protected override void AddEventNames(List<string> names)
        {
            base.AddEventNames(names);

            names.Add("HeaderClick");
            names.Add("Expanded");
            names.Add("Collapsed");
        }
    }
}