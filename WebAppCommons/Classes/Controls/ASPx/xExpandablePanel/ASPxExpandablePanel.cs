using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using Commons.Helpers.Objects;
using DevExpress.Web.ASPxClasses;
using DevExpress.Web.ASPxClasses.Internal;
using DevExpress.Web.ASPxRoundPanel;
using WebAppCommons.Classes.Controls.ASPx.xControlState;
using WebAppCommons.Classes.Controls.ASPx.xExpandablePanel.Classes;
using WebAppCommons.Classes.Controls.ASPx.xExpandablePanel.Internal;
using View = DevExpress.Web.ASPxRoundPanel.View;

namespace WebAppCommons.Classes.Controls.ASPx.xExpandablePanel
{
    public class ASPxExpandablePanel : ASPxRoundPanel
    {
        private ASPxControlState controlState;


        protected RPExpandablePanelControl PanelControl { get; set; }

        protected internal virtual ASPxControlState ControlState
        {
            get { return controlState ?? (controlState = new ASPxControlState()); }
        }


        public new View View
        {
            get { return base.View; }
            set { throw new NotSupportedException(); }
        }

        public new bool ShowDefaultImages
        {
            get { return base.ShowDefaultImages; }
            set { throw new NotSupportedException(); }
        }

        public override ITemplate HeaderTemplate
        {
            get { return base.HeaderTemplate; }
            set { throw new NotSupportedException(); }
        }

        public new string HeaderNavigateUrl
        {
            get { return base.HeaderNavigateUrl; }
            set { throw new NotSupportedException(); }
        }


        [AutoFormatDisable]
        [Localizable(true)]
        [DefaultValue("Header")]
        public new virtual string HeaderText
        {
            get { return ControlState.Get("HeaderText", "Header"); }
            set
            {
                if (HeaderText == value) return;

                ControlState.Put("HeaderText", value);
                ControlStateChanged();
            }
        }

        [AutoFormatDisable]
        [Localizable(false)]
        [DefaultValue(false)]
        public bool Expanded
        {
            get { return ControlState.Get("Expanded", false); }
            
            set
            {
                if (Expanded == value) return;

                ControlState.Put("Expanded", value);
                ControlStateChanged();
            }
        }

        public new ASPxExpandablePanelClientSideEvents ClientSideEvents
        {
            get { return (ASPxExpandablePanelClientSideEvents) ClientSideEventsInternal; }
        }



        public ASPxExpandablePanel()
        {
        }

        protected ASPxExpandablePanel(ASPxWebControl ownerControl) : base(ownerControl)
        {
        }



        protected virtual void ControlStateChanged()
        {
            if (PanelControl != null)
            {
                PanelControl.RefreshState();
            }
        }
        
        
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            base.View = View.Standard;
            base.ShowDefaultImages = false;
            base.HeaderTemplate = null;
            base.HeaderNavigateUrl = null;
        }



        public ASPxExpandablePanel Expand()
        {
            Expanded = true;

            return this;
        }

        public ASPxExpandablePanel Collapse()
        {
            Expanded = false;

            return this;
        }

        public ASPxExpandablePanel Toggle(bool expandOrCollapse)
        {
            return expandOrCollapse ? Expand() : Collapse();
        }

        public ASPxExpandablePanel Toggle()
        {
            return Toggle(!Expanded);
        }



        protected override bool LoadPostData(NameValueCollection postCollection)
        {
            var baseLoadPostDataResult = base.LoadPostData(postCollection);
            var thisLoadControlStateResult = LoadControlState(postCollection);

            return baseLoadPostDataResult || thisLoadControlStateResult;
        }

        protected virtual bool LoadControlState(NameValueCollection postCollection)
        {
            var postedControlState = postCollection[ClientID + "_" + GetCStateControlID()];

            if (postedControlState.IsNotEmpty())
            {
                ControlState.Load(postedControlState);

                return true;
            }
            
            return false;
        }



        protected override void PrepareControlStyle(AppearanceStyleBase style)
        {
            base.PrepareControlStyle(style);

            style.CssClass = RenderUtils.CombineCssClasses(style.CssClass, "dxep");
        }

        protected override void RegisterDefaultRenderCssFile()
        {
            base.RegisterDefaultRenderCssFile();

            ResourceManager.RegisterCssResource(Page, typeof(ASPxExpandablePanel), "WebAppCommons.Styles.Controls.ASPx.ASPxExpandablePanel.css");
        }



        public override bool IsClientSideAPIEnabled()
        {
            return true;
        }

        protected override ClientSideEventsBase CreateClientSideEvents()
        {
            return new ASPxExpandablePanelClientSideEvents(this);
        }
        
        protected override string GetClientObjectClassName()
        {
            return "ASPxClientExpandablePanel";
        }

        protected override void RegisterIncludeScripts()
        {
            base.RegisterIncludeScripts();

            if (!RequiresScriptsResource()) return;

            RegisterIncludeScript(typeof(ASPxExpandablePanel), "WebAppCommons.Scripts.Controls.ASPx.ASPxCollectionsInfrastructure.js");
            RegisterIncludeScript(typeof(ASPxExpandablePanel), "WebAppCommons.Scripts.Controls.ASPx.ASPxControlsInfrastructure.js");
            RegisterIncludeScript(typeof(ASPxExpandablePanel), "WebAppCommons.Scripts.Controls.ASPx.ASPxClientUtils.js");
            RegisterIncludeScript(typeof(ASPxExpandablePanel), "WebAppCommons.Scripts.Controls.ASPx.ASPxExpandablePanel.js");
        }



        protected override void ClearControlFields()
        {
            PanelControl = null;
        }

        protected override void CreateControlHierarchy()
        {
            PanelControl = new RPExpandablePanelControl(this);

            ControlsBase.Add(PanelControl);
        }



        protected internal string GetRoundPanelHeaderID()
        {
            return "RPH";
        }

        protected internal new string GetHeaderTextContainerID()
        {
            return base.GetHeaderTextContainerID();
        }

        protected internal string GetHeaderECButtonID()
        {
            return "RPHECB";
        }

        protected internal string GetCStateControlID()
        {
            return "RPCSC";
        }


        internal string GetHeaderImageCssClassName()
        {
            return GetCssClassNamePrefix() + (IsRightToLeft() ? "HIR" : "HI");
        }

        internal string GetHeaderTextCssClassName()
        {
            return GetCssClassNamePrefix() + "HT";
        }


        protected internal new Unit GetImageSpacing()
        {
            return base.GetImageSpacing();
        }

        protected internal new HeaderStyle GetHeaderStyle()
        {
            return base.GetHeaderStyle();
        }
    }
}