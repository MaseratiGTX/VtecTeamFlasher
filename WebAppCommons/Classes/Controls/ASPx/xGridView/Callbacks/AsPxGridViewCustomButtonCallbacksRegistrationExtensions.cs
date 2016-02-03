using System.Linq;
using DevExpress.Web.ASPxGridView;
using WebAppCommons.Classes.Controls.CallbackRegistration;

namespace WebAppCommons.Classes.Controls.ASPx.xGridView.Callbacks
{
    public static class AsPxGridViewCustomButtonCallbacksRegistrationExtensions
    {

        public static ASPxGridViewCustomButtonCallbackEventArgs FindLastOf(this CallbackRepository<ASPxGridViewCustomButtonCallbackEventArgs> source, string buttonID)
        {
            return source.Find(x => x.ButtonID == buttonID).LastOrDefault();
        } 
    }
}