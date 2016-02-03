using System.Linq;
using DevExpress.Web.ASPxGridView;
using WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Events.Args;
using WebAppCommons.Classes.Controls.CallbackRegistration;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Helpers
{
    public static class ASPxGridViewCommandButtonCallbacksRegistrationExtensions
    {
        public static ASPxGridViewCommandButtonCallbackEventArgs FindLastOf(this CallbackRepository<ASPxGridViewCommandButtonCallbackEventArgs> source, ColumnCommandButtonType buttonType)
        {
            return source.Find(x => x.ButtonType == buttonType).LastOrDefault();
        } 
    }
}