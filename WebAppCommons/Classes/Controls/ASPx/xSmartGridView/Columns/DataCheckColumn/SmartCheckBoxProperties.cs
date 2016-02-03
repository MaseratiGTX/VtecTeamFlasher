using System.ComponentModel;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxClasses;
using DevExpress.Web.ASPxClasses.Internal;
using DevExpress.Web.ASPxEditors;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Columns.DataCheckColumn
{
    public class SmartCheckBoxProperties : CheckBoxProperties
    {
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        public string DisplayText
        {
            get { return GetStringProperty("DisplayText", string.Empty); }
            set { SetStringProperty("DisplayText", string.Empty, value); }
        }

        [DefaultValue(TextAlign.Right)]
        [NotifyParentProperty(true)]
        public TextAlign DisplayTextAlign
        {
            get { return (TextAlign)GetEnumProperty("DisplayTextAlign", TextAlign.Right); }
            set { SetEnumProperty("DisplayTextAlign", TextAlign.Right, value); }
        }

        [DefaultValue(typeof(Unit), "")]
        [NotifyParentProperty(true)]
        public Unit DisplayTextSpacing
        {
            get { return GetUnitProperty("DisplayTextSpacing", Unit.Empty); }
            set
            {
                CommonUtils.CheckNegativeValue(value.Value, "DisplayTextSpacing");
                SetUnitProperty("DisplayTextSpacing", Unit.Empty, value);
            }
        }


        [DefaultValue(typeof(Unit), "")]
        [NotifyParentProperty(true)]
        public Unit Width
        {
            get { return GetUnitProperty("Width", Unit.Empty); }
            set { SetUnitProperty("Width", Unit.Empty, value); }
        }



        public SmartCheckBoxProperties() : this(null)
        {
        }

        public SmartCheckBoxProperties(IPropertiesOwner owner) : base(owner)
        {
        }



        protected override void AssignEditorProperties(ASPxEditBase edit)
        {
            base.AssignEditorProperties(edit);
            
            var aspxCheckBox = edit as ASPxCheckBox;

            if (aspxCheckBox != null)
            {
                aspxCheckBox.Text = DisplayText;
                aspxCheckBox.TextAlign = DisplayTextAlign;
                aspxCheckBox.TextSpacing = DisplayTextSpacing;
                aspxCheckBox.Width = Width;
            }
        }
    }
}