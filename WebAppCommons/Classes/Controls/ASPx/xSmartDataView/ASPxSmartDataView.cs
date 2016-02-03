using System;
using DevExpress.Web.ASPxClasses;
using DevExpress.Web.ASPxClasses.Internal;
using DevExpress.Web.ASPxDataView;
using WebAppCommons.Classes.Helpers;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartDataView
{
    public class ASPxSmartDataView : ASPxDataView
    {
        protected internal new int DataItemCount
        {
            get { return base.DataItemCount; }
        }


        public new SmartDataViewTableLayoutSettings SettingsTableLayout
        {
            get { return (SmartDataViewTableLayoutSettings) base.SettingsTableLayout; }
        }



        public ASPxSmartDataView()
        {
            #region PROPERTY DEFAULTS

            AllowPaging = false;

            #endregion
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (THIS_IS_FOREIGN_CALLBACK()) return;

            DataBind();
        }


        protected override DataViewTableLayoutSettings CreateTableLayoutSettings()
        {
            return new SmartDataViewTableLayoutSettings(this);
        }
        

        protected override StylesBase CreateStyles()
        {
            return new SmartDataViewStyles(this);
        }


        protected override void PrepareControlStyle(AppearanceStyleBase style)
        {
            base.PrepareControlStyle(style);

            style.CssClass = RenderUtils.CombineCssClasses(style.CssClass, "dxsdv");
        }

        protected override void RegisterDefaultRenderCssFile()
        {
            base.RegisterDefaultRenderCssFile();

            ResourceManager.RegisterCssResource(Page, typeof(ASPxSmartDataView), "WebAppCommons.Styles.Controls.ASPx.ASPxSmartDataView.css");
        }


        protected internal new virtual void DataLayoutChanged()
        {
            base.DataLayoutChanged();
        }



        protected virtual bool THIS_IS_FOREIGN_CALLBACK()
        {
            return Page.IS_FOREIGN_CALLBACK_FOR(this);
        }
    }
}