using DevExpress.Web.ASPxPopupControl;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartPopupControl
{
    public class ASPxSmartPopupControl : ASPxPopupControl
    {
        public override bool IsClientSideAPIEnabled()
        {
            return true;
        }

        protected override string GetClientObjectClassName()
        {
            return "ASPxClientSmartPopupControl";
        }

        protected override void RegisterIncludeScripts()
        {
            base.RegisterIncludeScripts();

            RegisterIncludeScript(typeof(ASPxSmartPopupControl), "WebAppCommons.Scripts.Controls.ASPx.ASPxCollectionsInfrastructure.js");
            RegisterIncludeScript(typeof(ASPxSmartPopupControl), "WebAppCommons.Scripts.Controls.ASPx.ASPxControlsInfrastructure.js");
            RegisterIncludeScript(typeof(ASPxSmartPopupControl), "WebAppCommons.Scripts.Controls.ASPx.ASPxSmartKbdHelper.js");
            RegisterIncludeScript(typeof(ASPxSmartPopupControl), "WebAppCommons.Scripts.Controls.ASPx.ASPxSmartPopupControl.js");
        }
    }
}