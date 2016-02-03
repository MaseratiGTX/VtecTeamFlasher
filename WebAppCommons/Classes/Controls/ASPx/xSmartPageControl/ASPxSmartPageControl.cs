using System.ComponentModel;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxClasses.Internal;
using DevExpress.Web.ASPxTabControl;
using DevExpress.Web.ASPxTabControl.Internal;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartPageControl
{
    public class ASPxSmartPageControl : ASPxPageControl
    {
        [NotifyParentProperty(true)]
        [Category("Layout")]
        [DefaultValue(typeof(Unit), "")]
        [AutoFormatEnable]
        public Unit MinWidth
        {
            get { return GetUnitProperty("MinWidth", Unit.Empty); }
            set
            {
                if (MinWidth == value) return;

                SetUnitProperty("MinWidth", Unit.Empty, value);
                LayoutChanged();
            }
        }

        [NotifyParentProperty(true)]
        [Category("Layout")]
        [DefaultValue(typeof(Unit), "")]
        [AutoFormatEnable]
        public Unit MinHeight
        {
            get { return GetUnitProperty("MinHeight", Unit.Empty); }
            set
            {
                if(MinHeight == value) return;

                SetUnitProperty("MinHeight", Unit.Empty, value);
                LayoutChanged();
            }
        }




        public override bool IsClientSideAPIEnabled()
        {
            return true;
        }

        protected override string GetClientObjectClassName()
        {
            return "ASPxClientSmartPageControl";
        }

        protected override void RegisterIncludeScripts()
        {
            base.RegisterIncludeScripts();

            RegisterIncludeScript(typeof(ASPxSmartPageControl), "WebAppCommons.Scripts.Controls.ASPx.ASPxCollectionsInfrastructure.js");
            RegisterIncludeScript(typeof(ASPxSmartPageControl), "WebAppCommons.Scripts.Controls.ASPx.ASPxControlsInfrastructure.js");
            RegisterIncludeScript(typeof(ASPxSmartPageControl), "WebAppCommons.Scripts.Controls.ASPx.ASPxSmartKbdHelper.js");
            RegisterIncludeScript(typeof(ASPxSmartPageControl), "WebAppCommons.Scripts.Controls.ASPx.ASPxSmartPageControl.js");
        }



        protected override void CreateTabControlHierarchy()
        {
            fMainControl = CreatePageControl();
            Controls.Add(fMainControl);
            Controls.Add(RenderUtils.CreateClearElement());
            ClearChildViewState();
        }

        protected new PageControlLite CreatePageControl()
        {
            if (DesignMode)
            {
                return new PageControlLiteDesignMode(this);
            }
            
            return new SmartPageControlLite(this);
        }


        internal virtual ContentControlLite CreateContentControl(int visibleIndex)
        {
            return new SmartContentControlLite(TabPages.GetVisibleTabPage(visibleIndex));
        }
    }
}