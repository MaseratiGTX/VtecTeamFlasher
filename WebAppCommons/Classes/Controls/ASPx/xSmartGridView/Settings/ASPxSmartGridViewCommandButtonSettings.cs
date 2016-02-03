using System.ComponentModel;
using System.Web.UI;
using DevExpress.Web.ASPxClasses;
using DevExpress.Web.ASPxClasses.Internal;
using DevExpress.Web.ASPxGridView;
using WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Helpers.ASPxGridViewBaseSettings;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Settings
{
    public class ASPxSmartGridViewCommandButtonSettings : ASPxGridViewBaseSettings
    {
        protected ASPxSmartGridViewExpandCollapseAllButtonsSettings expandCollapseAllButtons;
        
        protected GridViewCommandButtonSettings viewButton;


        protected ASPxGridViewCommandButtonSettings Source { get; set; }

        protected new ASPxSmartGridView Grid
        {
            get { return (ASPxSmartGridView) base.Grid; }
        }


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [AutoFormatDisable]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public GridViewCommandButtonSettings NewButton
        {
            get { return Source.NewButton; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [NotifyParentProperty(true)]
        [AutoFormatDisable]
        public GridViewCommandButtonSettings UpdateButton
        {
            get { return Source.UpdateButton; }
        }

        [AutoFormatDisable]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public GridViewCommandButtonSettings CancelButton
        {
            get { return Source.CancelButton; }
        }

        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [NotifyParentProperty(true)]
        [AutoFormatDisable]
        public GridViewCommandButtonSettings EditButton
        {
            get { return Source.EditButton; }
        }

        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [NotifyParentProperty(true)]
        [AutoFormatDisable]
        public GridViewCommandButtonSettings ViewButton
        {
            get { return viewButton ?? (viewButton = new GridViewCommandButtonSettings(Grid) {Text = "View"}); }
        }

        [PersistenceMode(PersistenceMode.InnerProperty)]
        [AutoFormatDisable]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [NotifyParentProperty(true)]
        public GridViewCommandButtonSettings DeleteButton
        {
            get { return Source.DeleteButton; }
        }

        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [NotifyParentProperty(true)]
        [AutoFormatDisable]
        public GridViewCommandButtonSettings SelectButton
        {
            get { return Source.SelectButton; }
        }

        [NotifyParentProperty(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [AutoFormatDisable]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public GridViewCommandButtonSettings ApplyFilterButton
        {
            get { return Source.ApplyFilterButton; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [AutoFormatDisable]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public GridViewCommandButtonSettings ClearFilterButton
        {
            get { return Source.ClearFilterButton; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [AutoFormatDisable]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public ASPxSmartGridViewExpandCollapseAllButtonsSettings ExpandCollapseAllButtons
        {
            get 
            { 
                return expandCollapseAllButtons ?? (expandCollapseAllButtons = new ASPxSmartGridViewExpandCollapseAllButtonsSettings(Grid));
            }
        }



        public ASPxSmartGridViewCommandButtonSettings(ASPxGridViewCommandButtonSettings source) 
            : base(source._Grid())
        {
            Source = source;
        }



        public override void Assign(PropertiesBase source)
        {
            BeginUpdate();
            try
            {
                base.Assign(source);


                if (source is ASPxGridViewCommandButtonSettings)
                {
                    Source.Assign(source);
                }
                
                
                var smartCommandButtonSettings = source as ASPxSmartGridViewCommandButtonSettings;
                
                if (smartCommandButtonSettings == null) return;

                UpdateButton.Assign(smartCommandButtonSettings.UpdateButton);
                CancelButton.Assign(smartCommandButtonSettings.CancelButton);
                NewButton.Assign(smartCommandButtonSettings.NewButton);
                EditButton.Assign(smartCommandButtonSettings.EditButton);
                ViewButton.Assign(smartCommandButtonSettings.ViewButton);
                DeleteButton.Assign(smartCommandButtonSettings.DeleteButton);
                SelectButton.Assign(smartCommandButtonSettings.SelectButton);
                ApplyFilterButton.Assign(smartCommandButtonSettings.ApplyFilterButton);
                ClearFilterButton.Assign(smartCommandButtonSettings.ClearFilterButton);
                ExpandCollapseAllButtons.Assign(smartCommandButtonSettings.ExpandCollapseAllButtons);
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
                    NewButton,
                    UpdateButton,
                    CancelButton,
                    EditButton,
                    ViewButton,
                    DeleteButton,
                    SelectButton,
                    ApplyFilterButton,
                    ClearFilterButton,
                    ExpandCollapseAllButtons
                }
            );
        }
    }
}