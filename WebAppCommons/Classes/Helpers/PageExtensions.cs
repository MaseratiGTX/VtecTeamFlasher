using System.Web.UI;
using Commons.Helpers.Objects;

namespace WebAppCommons.Classes.Helpers
{
    public static class PageExtensions
    {
        public static bool IS_FIRST_TIME_LOAD(this Page source)
        {
            return source.IsPostBack == false && source.IsCallback == false;
        }


        public static bool IS_FOREIGN_CALLBACK_FOR(this Page source, object control)
        {
            return source.IS_FOREIGN_CALLBACK_FOR(new[] {(Control) control});
        }

        public static bool IS_FOREIGN_CALLBACK_FOR(this Page source, Control control)
        {
            return source.IS_FOREIGN_CALLBACK_FOR(new[] {control});
        }

        public static bool IS_FOREIGN_CALLBACK_FOR(this Page source, params Control[] controls)
        {
            if (source.IsCallback == false)
            {
                return false;
            }


            var callbackID = source.Request["__CALLBACKID"];

            if (callbackID.IsEmpty())
            {
                return false;
            }


            foreach (var control in controls)
            {
                if (control != null)
                {
                    var controlID = control.UniqueID;

                    if (controlID.IsEmpty()) 
                    {
                        // REMARK: control.UniqueID == null в случае если контрол не включен в иерархию страницы, 
                        // как следствие нельзя восстановить контекст выполнения и нельзя проводить блокирование работы
                        return false;
                    }
                    
                    if (controlID.StartsWith(callbackID))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}