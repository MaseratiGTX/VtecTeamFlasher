using DevExpress.Web.ASPxGridView;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Helpers.GridViewBaseTemplateContainers
{
    public static class GridViewBaseTemplateContainerExtensions
    {
        public static string _GetID(this GridViewBaseTemplateContainer source)
        {
            return GridViewBaseTemplateContainerMembersRepository.GetID.Invoke(source);
        }
    }
}