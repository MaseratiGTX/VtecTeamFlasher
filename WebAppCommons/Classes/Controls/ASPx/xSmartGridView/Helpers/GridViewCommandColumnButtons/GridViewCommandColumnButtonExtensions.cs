using DevExpress.Web.ASPxGridView;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Helpers.GridViewCommandColumnButtons
{
    public static class GridViewCommandColumnButtonExtensions
    {
        public static bool _GetIsVisible(this GridViewCommandColumnButton source)
        {
            return GridViewCommandColumnButtonMembersRepository.GetIsVisible.Invoke(source);
        }

        public static GridViewCommandColumn _Column(this GridViewCommandColumnButton source)
        {
            return GridViewCommandColumnButtonMembersRepository.ColumnGetter.Invoke(source);
        }
    }
}