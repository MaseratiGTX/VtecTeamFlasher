using System.ComponentModel;
using System.Text;
using DevExpress.Web.ASPxClasses;
using DevExpress.Web.ASPxClasses.Internal;
using WebAppCommons.Classes.Controls.ASPx.xExpandablePanel;
using WebAppCommons.Classes.Controls.ASPx.xSearchPanel.Classes;
using WebAppCommons.Classes.Controls.ASPx.xSearchPanel.Internal;

namespace WebAppCommons.Classes.Controls.ASPx.xSearchPanel
{
    public class ASPxSearchPanel : ASPxExpandablePanel
    {
        protected new RPSearchPanelControl PanelControl { get; set; }


        [AutoFormatDisable]
        [Localizable(false)]
        [DefaultValue("")]
        public string ParentGridViewID
        {
            get { return GetStringProperty("ParentGridViewID", ""); }
            set { SetStringProperty("ParentGridViewID", "", value); }
        }


        [AutoFormatDisable]
        [Localizable(true)]
        [DefaultValue("Header")]
        public override string HeaderText
        {
            get
            {
                switch (HeaderTextValue)
                {
                    case HeaderTextValue.SearchUndefined:
                        return HeaderSearchUndefined;
                    case HeaderTextValue.SearchPerformed:
                        return HeaderSearchPerformed;
                    case HeaderTextValue.SearchCancelled:
                        return HeaderSearchCancelled;
                    default:
                        return base.HeaderText;
                }
            }
            
            set
            {
                HeaderTextValue = HeaderTextValue.Custom;
                base.HeaderText = value;
            }
        }


        [AutoFormatDisable]
        [Localizable(false)]
        [DefaultValue(HeaderTextValue.SearchUndefined)]
        public HeaderTextValue HeaderTextValue
        {
            get { return ControlState.Get("HeaderTextValue", HeaderTextValue.SearchUndefined); }

            protected set
            {
                if (HeaderTextValue == value) return;

                ControlState.Put("HeaderTextValue", value);
                ControlStateChanged();
            }
        }

        [AutoFormatDisable]
        [Localizable(true)]
        [DefaultValue("")]
        public string HeaderSearchUndefined
        {
            get { return GetStringProperty("HeaderSearchUndefined", ""); }
            set { SetStringProperty("HeaderSearchUndefined", "", value); }
        }

        [AutoFormatDisable]
        [Localizable(true)]
        [DefaultValue("")]
        public string HeaderSearchPerformed
        {
            get { return GetStringProperty("HeaderSearchPerformed", ""); }
            set { SetStringProperty("HeaderSearchPerformed", "", value); }
        }

        [AutoFormatDisable]
        [Localizable(true)]
        [DefaultValue("")]
        public string HeaderSearchCancelled
        {
            get { return GetStringProperty("HeaderSearchCancelled", ""); }
            set { SetStringProperty("HeaderSearchCancelled", "", value); }
        }


        [AutoFormatDisable]
        [Localizable(true)]
        [DefaultValue("Search")]
        public string PerformSearchText
        {
            get { return GetStringProperty("PerformSearchText", "Search"); }
            set { SetStringProperty("PerformSearchText", "Search", value); }
        }

        [AutoFormatDisable]
        [Localizable(true)]
        [DefaultValue("Cancel")]
        public string CancelSearchText
        {
            get { return GetStringProperty("CancelSearchText", "Cancel"); }
            set { SetStringProperty("CancelSearchText", "Cancel", value); }
        }
        

        public new ASPxSeacrhPanelClientSideEvents ClientSideEvents
        {
            get { return (ASPxSeacrhPanelClientSideEvents)ClientSideEventsInternal; }
        }


        
        public ASPxSearchPanel()
        {
        }

        protected ASPxSearchPanel(ASPxWebControl ownerControl) : base(ownerControl)
        {
        }



        protected override void PrepareControlStyle(AppearanceStyleBase style)
        {
            base.PrepareControlStyle(style);

            style.CssClass = RenderUtils.CombineCssClasses(style.CssClass, "dxsp");
        }

        protected override void RegisterDefaultRenderCssFile()
        {
            base.RegisterDefaultRenderCssFile();

            ResourceManager.RegisterCssResource(Page, typeof(ASPxSearchPanel), "WebAppCommons.Styles.Controls.ASPx.ASPxSearchPanel.css");
        }



        protected override ClientSideEventsBase CreateClientSideEvents()
        {
            return new ASPxSeacrhPanelClientSideEvents(this);
        }

        protected override string GetClientObjectClassName()
        {
            return "ASPxClientSearchPanel";
        }

        protected override void RegisterIncludeScripts()
        {
            base.RegisterIncludeScripts();

            if (!RequiresScriptsResource()) return;

            RegisterIncludeScript(typeof(ASPxSearchPanel), "WebAppCommons.Scripts.Controls.ASPx.ASPxFunctionsInfrastructure.js");
            RegisterIncludeScript(typeof(ASPxSearchPanel), "WebAppCommons.Scripts.Controls.ASPx.ASPxCollectionsInfrastructure.js");
            RegisterIncludeScript(typeof(ASPxSearchPanel), "WebAppCommons.Scripts.Controls.ASPx.ASPxControlsInfrastructure.js");
            RegisterIncludeScript(typeof(ASPxSearchPanel), "WebAppCommons.Scripts.Controls.ASPx.ASPxSearchPanel.js");
        }

        protected override void GetCreateClientObjectScript(StringBuilder stb, string localVarName, string clientName)
        {
            base.GetCreateClientObjectScript(stb, localVarName, clientName);

            stb.AppendFormat("{0}.SetParentGridView({1});\n", localVarName, HtmlConvertor.ToJSON(Page.ToClientID(ParentGridViewID)));
            stb.AppendFormat("{0}.SetHeaderSearchUndefined({1});\n", localVarName, HtmlConvertor.ToJSON(HtmlEncode(HeaderSearchUndefined)));
            stb.AppendFormat("{0}.SetHeaderSearchPerformed({1});\n", localVarName, HtmlConvertor.ToJSON(HtmlEncode(HeaderSearchPerformed)));
            stb.AppendFormat("{0}.SetHeaderSearchCancelled({1});\n", localVarName, HtmlConvertor.ToJSON(HtmlEncode(HeaderSearchCancelled)));
        }


        protected override void ClearControlFields()
        {
            PanelControl = null;
        }

        protected override void CreateControlHierarchy()
        {
            PanelControl = new RPSearchPanelControl(this);

            ControlsBase.Add(PanelControl);
        }


        protected internal string GetPerformSearchButtonID()
        {
            return "RPCBPS";
        }

        protected internal string GetCancelSearchButtonID()
        {
            return "RPCBCS";
        }


        protected internal string GetCBContainerTableClassName()
        {
            return GetCssClassNamePrefix() + "CBContainer";
        }
    }
}