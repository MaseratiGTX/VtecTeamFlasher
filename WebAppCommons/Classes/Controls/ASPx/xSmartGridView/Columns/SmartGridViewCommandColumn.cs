using System;
using System.ComponentModel;
using DevExpress.Web.ASPxGridView;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Columns
{
    public class SmartGridViewCommandColumn : GridViewCommandColumn, IAutosizeable
    {
        [Category("Buttons")]
        [NotifyParentProperty(true)]
        [DefaultValue(false)]
        public bool Autosize
        {
            get { return GetBoolProperty("Autosize", false); }
            set
            {
                if (Autosize == value) return;

                SetBoolProperty("Autosize", false, value);
                OnColumnChanged();
            }
        }

        [Category("Buttons")]
        [NotifyParentProperty(true)]
        [DefaultValue(false)]
        public bool ShowCommandButtonsInline
        {
            get { return GetBoolProperty("ShowCommandButtonsInline", false); }
            set
            {
                if (ShowCommandButtonsInline == value) return;

                SetBoolProperty("ShowCommandButtonsInline", false, value);
                OnColumnChanged();
            }
        }

        [Category("Buttons")]
        [NotifyParentProperty(true)]
        [DefaultValue(false)]
        public bool ShowExpandCollapseAllButtons
        {
            get { return GetBoolProperty("ShowExpandCollapseAllButtons", false); }
            set
            {
                if (ShowExpandCollapseAllButtons == value) return;
                
                SetBoolProperty("ShowExpandCollapseAllButtons", false, value);
                OnColumnChanged();
            }
        }

        public new bool ShowSelectCheckbox
        {
            get { return base.ShowSelectCheckbox; }
            set
            {
                throw new NotSupportedException();
            }
        }



        public SmartGridViewCommandColumn()
        {
            ShowEditButton = true;
            ShowNewButton = true;
            ShowDeleteButton = true;

            Caption = "&nbsp;";
        }
    }
}