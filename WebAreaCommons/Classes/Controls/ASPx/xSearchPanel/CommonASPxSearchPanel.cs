using Commons.Localization.Extensions;
using DevExpress.Web.ASPxClasses;
using DevExpress.Web.ASPxClasses.Internal;
using WebAppCommons.Classes.Controls.ASPx.xSearchPanel;
using WebAreaCommons.ResourceRepositories;

namespace WebAreaCommons.Classes.Controls.ASPx.xSearchPanel
{
    public class CommonASPxSearchPanel : ASPxSearchPanel
    {
        public CommonASPxSearchPanel()
        {
            InitializeDefaults();
        }

        protected CommonASPxSearchPanel(ASPxWebControl ownerControl) : base(ownerControl)
        {
            InitializeDefaults();
        }



        private void InitializeDefaults()
        {
            HeaderImage.Url = WebAreaCommonResources.ProvideURLFor("Images.btnSearch.png");

            HeaderSearchUndefined = "Поиск: критерии поиска не заданы".Localize();
            HeaderSearchPerformed = "Поиск: поиск по критериям".Localize();
            HeaderSearchCancelled = "Поиск: критерии поиска очищены".Localize();

            PerformSearchText = "Найти".Localize();
            CancelSearchText = "Очистить поиск".Localize();
        }



        protected override void PrepareControlStyle(AppearanceStyleBase style)
        {
            base.PrepareControlStyle(style);

            style.CssClass = RenderUtils.CombineCssClasses(style.CssClass, "CommonASPxSearchPanel");
        }
    }
}