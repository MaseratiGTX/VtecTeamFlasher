using DevExpress.Web.ASPxGridView;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Helpers.GridViewPagerBarTemplateContainers
{
    public static class GridViewPagerBarTemplateContainerExtensions
    {
        public static string _PagerId(this GridViewPagerBarTemplateContainer source)
        {
            return GridViewPagerBarTemplateContainerMembersRepository.PagerIdGetter.Invoke(source);
        }
    }
}