using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Commons.Helpers.Objects;
using Commons.Reflections;
using DevExpress.Web.ASPxClasses;
using DevExpress.Web.ASPxClasses.Internal;
using DevExpress.Web.ASPxEditors;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartListBox
{
    public class SmartListBoxProperties : ListBoxProperties
    {
        [Category("Appearance")]
        [NotifyParentProperty(true)]
        [DefaultValue(false)]
        public bool DisplayAll
        {
            get { return GetBoolProperty("DisplayAll", false); }
            set
            {
                if (DisplayAll == value) return;

                SetBoolProperty("DisplayAll", false, value);
                LayoutChanged();
            }
        }

        [Category("Appearance")]
        [NotifyParentProperty(true)]
        [DefaultValue(0)]
        public int DisplayItemCount
        {
            get { return GetIntProperty("DisplayItemCount", 0); }
            set
            {
                CommonUtils.CheckNegativeValue(value, "DisplayItemCount");

                if (DisplayItemCount == value) return;
                
                SetIntProperty("DisplayItemCount", 0, value);
                LayoutChanged();
            }
        }



        public SmartListBoxProperties()
        {
        }

        public SmartListBoxProperties(IPropertiesOwner owner) : base(owner)
        {
        }



        protected override bool IsNativeSupported()
        {
            return false;
        }



        protected override ASPxEditBase CreateEditInstance()
        {
            return new ASPxSmartListBox();
        }

        public override ASPxEditBase CreateEdit(CreateEditControlArgs args, bool isInternal)
        {
            var aspxListBox = (ASPxSmartListBox)base.CreateEdit(args, isInternal);
                aspxListBox.SetValues(FetchEditValues(args));

            return aspxListBox;
        }


        protected IEnumerable<object> FetchEditValues(CreateEditControlArgs args)
        {
            if (args.EditValue == null) return null;

            if (args.DataType.IsEnumeration())
            {
                if (args.EditValue.IsNotInstanceOf<IEnumerable>())
                {
                    return new[] { args.EditValue };
                }

                if (args.EditValue.IsInstanceOf(ValueType))
                {
                    return new[] { args.EditValue };
                }

                return ((IEnumerable) args.EditValue).Cast<object>().ToArray();    
            }

            return new[] { args.EditValue };
        }


        protected override void AssignInplaceProperties(CreateEditorArgs args)
        {
            ParentImages = args.Images;
            ParentStyles = args.Styles;
        }


        public override void Assign(PropertiesBase source)
        {
            BeginUpdate();
            try
            {
                base.Assign(source);
                

                var smartListBoxProperties = source as SmartListBoxProperties;
                
                if (smartListBoxProperties == null) return;

                DisplayAll = smartListBoxProperties.DisplayAll;
                DisplayItemCount = smartListBoxProperties.DisplayItemCount;
            }
            finally
            {
                this.EndUpdate();
            }
        }
    }
}