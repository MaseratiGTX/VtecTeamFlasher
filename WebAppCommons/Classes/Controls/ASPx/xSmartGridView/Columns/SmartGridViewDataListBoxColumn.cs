using System.ComponentModel;
using System.Web.UI;
using DevExpress.Web.ASPxClasses.Internal;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxGridView;
using WebAppCommons.Classes.Controls.ASPx.xSmartListBox;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Columns
{
    public class SmartGridViewDataListBoxColumn : GridViewEditDataColumn
    {
        [NotifyParentProperty(true)]
        [Category("Behavior")]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public SmartListBoxProperties PropertiesListBox
        {
            get { return (SmartListBoxProperties) PropertiesEdit; }
        }



        protected override EditPropertiesBase CreateEditProperties()
        {
            return new SmartListBoxProperties(this)
            {
                SelectionMode = ListEditSelectionMode.CheckColumn
            };
        }

        protected override string[] GetDesignTimeHiddenPropertyNames()
        {
            return DataUtils.MergeStringArrays(
                base.GetDesignTimeHiddenPropertyNames(),
                new[]
                {
                    "PropertiesListBox"
                }
            );
        }
    }
}