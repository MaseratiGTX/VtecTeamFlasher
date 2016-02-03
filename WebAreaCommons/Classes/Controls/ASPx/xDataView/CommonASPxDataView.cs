using Commons.Localization.Extensions;
using DevExpress.Web.ASPxClasses;
using DevExpress.Web.ASPxClasses.Internal;
using WebAppCommons.Classes.Controls.ASPx.xSmartDataView;

namespace WebAreaCommons.Classes.Controls.ASPx.xDataView
{
    public class CommonASPxDataView : ASPxSmartDataView
    {
        public CommonASPxDataView()
        {
            #region PROPERTY DEFAULTS

            EmptyDataText = "нет данных для отображения".Localize();

            #endregion
        }



        protected override void PrepareControlStyle(AppearanceStyleBase style)
        {
            base.PrepareControlStyle(style);

            style.CssClass = RenderUtils.CombineCssClasses(style.CssClass, "CommonASPxDataView");
        }
    }
}