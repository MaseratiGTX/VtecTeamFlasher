using DevExpress.Web.ASPxGridView;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Helpers.GridViewCommandColumnCustomButtons
{
    public static class GridViewCommandColumnCustomButtonExtensions
    {
        public static bool _IsVisible(this GridViewCommandColumnCustomButton source, GridViewTableCommandCellType cellType, bool isEditingRow)
        {
            return GridViewCommandColumnCustomButtonMembersRepository.IsVisible.Invoke(source, cellType, isEditingRow);
        }
    }
}