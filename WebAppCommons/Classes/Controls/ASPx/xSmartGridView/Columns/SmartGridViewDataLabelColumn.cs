using System.ComponentModel;
using System.Web.UI;
using DevExpress.Web.ASPxClasses.Internal;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxGridView;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Columns
{
    public class SmartGridViewDataLabelColumn : GridViewEditDataColumn
    {
        [NotifyParentProperty(true)]
        [Category("Behavior")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public LabelProperties PropertiesLabel
        {
            get { return (LabelProperties) PropertiesEdit; }
        }



        protected override EditPropertiesBase CreateEditProperties()
        {
            return new LabelProperties(this);
        }

        protected override string[] GetDesignTimeHiddenPropertyNames()
        {
            return DataUtils.MergeStringArrays(
                base.GetDesignTimeHiddenPropertyNames(),
                new[]
                {
                    "PropertiesLabel"
                }
            );
        }
    }
}