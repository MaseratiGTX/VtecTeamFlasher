using DevExpress.Web.ASPxGridView.Rendering;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Helpers.GridViewTableCells
{
    public static class GridViewTableCellExExtensions
    {
        public static bool _RemoveBottomBorder(this GridViewTableCellEx source)
        {
            return GridViewTableCellExMembersRepository.RemoveBottomBorderGetter.Invoke(source);
        }

        public static void _RemoveBottomBorder(this GridViewTableCellEx source, bool value)
        {
            GridViewTableCellExMembersRepository.RemoveBottomBorderSetter.Invoke(source, value);
        }
    }
}