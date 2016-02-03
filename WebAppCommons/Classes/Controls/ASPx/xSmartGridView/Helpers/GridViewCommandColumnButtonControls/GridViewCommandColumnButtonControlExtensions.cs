using System.Web.UI.WebControls;
using DevExpress.Web.ASPxGridView.Rendering;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Helpers.GridViewCommandColumnButtonControls
{
    public static class GridViewCommandColumnButtonControlExtensions
    {
        public static WebControl _Control(this GridViewCommandColumnButtonControl source)
        {
            return GridViewCommandColumnButtonControlMembersRepository.ControlGetter.Invoke(source);
        }
    }
}