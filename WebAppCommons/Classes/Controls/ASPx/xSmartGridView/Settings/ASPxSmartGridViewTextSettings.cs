using System.ComponentModel;
using System.Web.UI;
using DevExpress.Web.ASPxClasses;
using DevExpress.Web.ASPxClasses.Internal;
using DevExpress.Web.ASPxGridView;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Settings
{
    public class ASPxSmartGridViewTextSettings : ASPxGridViewTextSettings
    {
        protected new ASPxSmartGridView Grid
        {
            get { return (ASPxSmartGridView)base.Grid; }
        }


        protected ASPxSmartGridViewEditFormTextSettings initNewRow;
        protected ASPxSmartGridViewEditFormTextSettings startRowEditing;


        [Localizable(true)]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        public string GroupItemCountFormat
        {
            get { return GetStringProperty("GroupItemCountFormat", string.Empty); }
            set
            {
                if (value == GroupItemCountFormat) return;

                SetStringProperty("GroupItemCountFormat", string.Empty, value);
                Changed();
            }
        }

        [Localizable(true)]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        public string NullGroupDisplayText
        {
            get { return GetStringProperty("NullGroupDisplayText", string.Empty); }
            set
            {
                if (value == NullGroupDisplayText) return;

                SetStringProperty("NullGroupDisplayText", string.Empty, value);
                Changed();
            }
        }

        [Localizable(true)]
        [DefaultValue("\"{0}\"")]
        [NotifyParentProperty(true)]
        public string GroupDisplayTextFormat
        {
            get { return GetStringProperty("GroupDisplayTextFormat", "\"{0}\""); }
            set
            {
                if (value == GroupDisplayTextFormat) return;

                SetStringProperty("GroupDisplayTextFormat", "\"{0}\"", value);
                Changed();
            }
        }

        
        [Localizable(true)]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        public string ConfirmEditFormWindowUnload
        {
            get { return GetStringProperty("ConfirmEditFormWindowUnload", string.Empty); }
            set
            {
                if (value == ConfirmEditFormWindowUnload) return;

                SetStringProperty("ConfirmEditFormWindowUnload", string.Empty, value);
                Changed();
            }
        }


        [Localizable(true)]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        public string SearchResultsSummary
        {
            get { return GetStringProperty("SearchResultsSummary", string.Empty); }
            set
            {
                if (value == SearchResultsSummary) return;
                
                SetStringProperty("SearchResultsSummary", string.Empty, value);
                
                Changed();
            }
        }

        [Localizable(true)]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        public string SearchResultsEmptyDetails
        {
            get { return GetStringProperty("SearchResultsEmptyDetails", string.Empty); }
            set
            {
                if (value == SearchResultsEmptyDetails) return;

                SetStringProperty("SearchResultsEmptyDetails", string.Empty, value);
                
                Changed();
            }
        }

        [Localizable(true)]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        public string SourceElementNotFound
        {
            get { return GetStringProperty("SourceElementNotFound", string.Empty); }
            set
            {
                if (value == SourceElementNotFound) return;

                SetStringProperty("SourceElementNotFound", string.Empty, value);
                
                Changed();
            }
        }

        [Localizable(true)]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        public string CallbackTargetNotFound
        {
            get { return GetStringProperty("CallbackTargetNotFound", string.Empty); }
            set
            {
                if (value == CallbackTargetNotFound) return;

                SetStringProperty("CallbackTargetNotFound", string.Empty, value);
                
                Changed();
            }
        }


        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public ASPxSmartGridViewEditFormTextSettings InitNewRow
        {
            get
            {
                return initNewRow ?? (initNewRow = new ASPxSmartGridViewEditFormTextSettings(Grid));
            }
        }

        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public ASPxSmartGridViewEditFormTextSettings StartRowEditing
        {
            get
            {
                return startRowEditing ?? (startRowEditing = new ASPxSmartGridViewEditFormTextSettings(Grid));
            }
        }



        public ASPxSmartGridViewTextSettings(ASPxSmartGridView grid) : base(grid)
        {
        }



        protected internal new string GetGroupPanel()
        {
            return base.GetGroupPanel();
        }

        protected internal new string GetCommandButtonText(ColumnCommandButtonType buttonType)
        {
            return base.GetCommandButtonText(buttonType);
        }



        public override void Assign(PropertiesBase source)
        {
            BeginUpdate();
            try
            {
                base.Assign(source);

            
                var textSettings = source as ASPxSmartGridViewTextSettings;
                
                if (textSettings == null) return;

                GroupItemCountFormat = textSettings.GroupItemCountFormat;
                NullGroupDisplayText = textSettings.NullGroupDisplayText;
                GroupDisplayTextFormat = textSettings.GroupDisplayTextFormat;
                ConfirmEditFormWindowUnload = textSettings.ConfirmEditFormWindowUnload;
                SearchResultsSummary = textSettings.SearchResultsSummary;
                SearchResultsEmptyDetails = textSettings.SearchResultsEmptyDetails;
                SourceElementNotFound = textSettings.SourceElementNotFound;
                CallbackTargetNotFound = textSettings.CallbackTargetNotFound;

                InitNewRow.Assign(textSettings.InitNewRow);
                StartRowEditing.Assign(textSettings.StartRowEditing);
            }
            finally
            {
                EndUpdate();
            }
        }

        protected override IStateManager[] GetStateManagedObjects()
        {
            return ViewStateUtils.GetMergedStateManagedObjects(
                base.GetStateManagedObjects(),
                new IStateManager[]
                {
                    InitNewRow,
                    StartRowEditing
                }
            );
        }

    }
}