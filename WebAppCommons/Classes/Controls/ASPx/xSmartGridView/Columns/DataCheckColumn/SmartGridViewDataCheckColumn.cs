using System.ComponentModel;
using System.Web.UI;
using Commons.Localization.Extensions;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxGridView;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Columns.DataCheckColumn
{
    public class SmartGridViewDataCheckColumn : GridViewDataCheckColumn
    {
        public SmartGridViewDataCheckColumn()
        {
            PropertiesCheckEdit.DisplayTextChecked = "да".Localize();
            PropertiesCheckEdit.DisplayTextUnchecked = "нет".Localize();
            PropertiesCheckEdit.DisplayTextGrayed = "значение не определено".Localize();
        }


        [NotifyParentProperty(true)]
        [Category("Behavior")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new SmartCheckBoxProperties PropertiesCheckEdit
        {
            get
            {
                return (SmartCheckBoxProperties) this.PropertiesEdit;
            }
        }

        protected override EditPropertiesBase CreateEditProperties()
        {
            return new SmartCheckBoxProperties(this);
        }
    }
}