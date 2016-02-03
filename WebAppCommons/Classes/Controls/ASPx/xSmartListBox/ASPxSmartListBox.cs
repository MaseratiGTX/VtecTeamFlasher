using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Commons.Helpers.Objects;
using DevExpress.Web.ASPxClasses.Internal;
using DevExpress.Web.ASPxEditors;
using WebAppCommons.Classes.Controls.ASPx.xListBox.ListEditItems;
using WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Helpers;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartListBox
{
    public class ASPxSmartListBox : ASPxListBox
    {
        protected bool IsApplyingPostponedValues { get; set; }

        protected IEnumerable<object> PostponedValues { get; set; }

        protected internal new SmartListBoxProperties Properties
        {
            get { return (SmartListBoxProperties) base.Properties; }
        }


        [Category("Appearance")]
        [NotifyParentProperty(true)]
        [DefaultValue(false)]
        public bool DisplayAll
        {
            get { return Properties.DisplayAll; }
            set { Properties.DisplayAll = value; }
        }

        [Category("Appearance")]
        [NotifyParentProperty(true)]
        [DefaultValue(0)]
        public int DisplayItemCount
        {
            get { return Properties.DisplayItemCount; }
            set { Properties.DisplayItemCount = value; }
        }



        protected override EditPropertiesBase CreateProperties()
        {
            return new SmartListBoxProperties(this);
        }



        protected override string GetClientObjectClassName()
        {
            return "ASPxClientSmartListBox";
        }

        public override void RegisterEditorIncludeScripts()
        {
            base.RegisterEditorIncludeScripts();

            RegisterIncludeScript(typeof(ASPxSmartListBox), "WebAppCommons.Scripts.Controls.ASPx.ASPxSmartListBox.js");
        }

        protected override void GetCreateClientObjectScript(StringBuilder stb, string localVarName, string clientName)
        {
            base.GetCreateClientObjectScript(stb, localVarName, clientName);

            if(DisplayAll)
                stb.AppendFormat("{0}.displayAll={1};\n", localVarName, DisplayAll.ToScript());
            
            if(DisplayItemCount != 0)
                stb.AppendFormat("{0}.displayItemCount={1};\n", localVarName, DisplayItemCount.ToScript());
        }



        public IEnumerable GetValues()
        {
            return SelectedItems.Cast<ListEditItem>().Select(x => x.DataItem()).ToList();
        }

        public void SetValues(IEnumerable values)
        {
            PostponedValues = ConvertToInternalValues(values);
            ApplyPostponedValues();
        }

        public void SetValues(params object[] values)
        {
            SetValues((IEnumerable)values);
        }



        protected override void OnDataBound(EventArgs e)
        {
            ApplyPostponedValues();
            base.OnDataBound(e);
        }


        
        protected IEnumerable<object> ConvertToInternalValues(IEnumerable sourceValues)
        {
            if (sourceValues == null) return null;

            return sourceValues.Cast<object>()
                .Select(ConvertToInternalValue)
                .ToList();
        }

        protected object ConvertToInternalValue(object source)
        {
            var sourceValue = source.IsNotInstanceOf(ValueType) ? FetchInternalValue(source) : source;

            return CommonUtils.GetConvertedArgumentValue(sourceValue, ValueType, "Item[]");
        }

        protected object FetchInternalValue(object source)
        {
            return ListEditItemHelper.FetchLEIInternalValue(source, ValueField, TextField, DesignMode);
        }


        protected void ApplyPostponedValues()
        {
            if (IsApplyingPostponedValues) return;

            IsApplyingPostponedValues = true;

            try
            {
                if (Items.IsEmpty) return;
                if (PostponedValues.IsEmpty()) return;

                ApplyValuesInternal(PostponedValues);

                PostponedValues = null;
            }
            finally
            {
                IsApplyingPostponedValues = false;
            }
        }

        protected void ApplyValuesInternal(IEnumerable<object> values)
        {
            var enumerable = values as IList<object> ?? values.ToList();

            foreach (ListEditItem item in Items)
            {
                item.Selected = enumerable.Contains(item.Value);
            }
        }
    }
}