using System.ComponentModel;
using DevExpress.Web.ASPxClasses;
using DevExpress.Web.ASPxDataView;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartDataView
{
    public class SmartDataViewTableLayoutSettings : DataViewTableLayoutSettings
    {
        protected new ASPxSmartDataView DataView
        {
            get { return (ASPxSmartDataView) base.DataView; }
        }


        protected virtual bool DefaultShowInline
        {
            get { return false; }
        }


        public override int ColumnCount
        {
            get
            {
                if (DataView.Layout == Layout.Table)
                {
                    if (ShowInline)
                    {
                        return DataView.AllowPaging == false ? DataView.DataItemCount : base.RowsPerPage;
                    }
                }

                return base.RowsPerPage;
            }
            set { base.ColumnCount = value; }
        }

        public override int RowsPerPage {
            get
            {
                if (DataView.Layout == Layout.Table)
                {
                    if (ShowInline)
                    {
                        return 1;
                    }
                }

                return base.RowsPerPage;
            }
            set { base.RowsPerPage = value; }
        }



        [NotifyParentProperty(true)]
        [DefaultValue(false)]
        public virtual bool ShowInline
        {
            get
            {
                return GetBoolProperty("ShowInline", DefaultShowInline);
            }
            set
            {
                SetBoolProperty("ShowInline", DefaultShowInline, value);
                
                Changed();
                
                if (DataView != null)
                {
                    DataView.DataLayoutChanged();
                }
            }
        }



        public SmartDataViewTableLayoutSettings()
        {
        }

        public SmartDataViewTableLayoutSettings(ASPxSmartDataView owner) : base(owner)
        {
        }



        public override void Assign(PropertiesBase source)
        {
            base.Assign(source);
            
            
            var smartTableLayoutSettings = source as SmartDataViewTableLayoutSettings;
            
            if (smartTableLayoutSettings == null) return;


            ShowInline = smartTableLayoutSettings.ShowInline;
        }
    }
}