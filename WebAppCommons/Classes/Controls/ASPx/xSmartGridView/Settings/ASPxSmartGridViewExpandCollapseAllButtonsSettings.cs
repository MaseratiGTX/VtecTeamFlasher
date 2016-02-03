using System.ComponentModel;
using System.Web.UI;
using DevExpress.Web.ASPxClasses;
using DevExpress.Web.ASPxClasses.Internal;
using DevExpress.Web.ASPxGridView;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Settings
{
    public class ASPxSmartGridViewExpandCollapseAllButtonsSettings : ASPxGridViewBaseSettings
    {
        protected ASPxSmartGridViewECCommandButtonSettings expandAllButton;
        protected ASPxSmartGridViewCommandButtonSeparatorSettings buttonSeparator;
        protected ASPxSmartGridViewECCommandButtonSettings collapseAllButton;


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [AutoFormatDisable]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public ASPxSmartGridViewECCommandButtonSettings ExpandAllButton
        {
            get { return expandAllButton ?? (expandAllButton = new ASPxSmartGridViewECCommandButtonSettings(Grid)); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [AutoFormatDisable]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public ASPxSmartGridViewCommandButtonSeparatorSettings ButtonSeparator
        {
            get { return buttonSeparator ?? (buttonSeparator = new ASPxSmartGridViewCommandButtonSeparatorSettings(Grid)); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [AutoFormatDisable]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public ASPxSmartGridViewECCommandButtonSettings CollapseAllButton
        {
            get { return collapseAllButton ?? (collapseAllButton = new ASPxSmartGridViewECCommandButtonSettings(Grid)); }
        }



        public ASPxSmartGridViewExpandCollapseAllButtonsSettings(ASPxSmartGridView grid) : base(grid)
        {
        }



        public override void Assign(PropertiesBase source)
        {
            BeginUpdate();
            try
            {
                base.Assign(source);


                var expandCollapseAllButtonsSettings = source as ASPxSmartGridViewExpandCollapseAllButtonsSettings;
                
                if (expandCollapseAllButtonsSettings == null) return;

                ExpandAllButton.Assign(expandCollapseAllButtonsSettings.ExpandAllButton);
                ButtonSeparator.Assign(expandCollapseAllButtonsSettings.ButtonSeparator);
                CollapseAllButton.Assign(expandCollapseAllButtonsSettings.CollapseAllButton);
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
                    ExpandAllButton,
                    ButtonSeparator,
                    CollapseAllButton
                }
            );
        }
    }
}