using System;
using System.Linq;
using System.Web.UI;

namespace WebAppCommons.Classes.Controls.CallbackRegistration
{
    public class ControlCallbackRegistrator<T> : BaseCallbackRegistrator<T> where T : EventArgs
    {
        public Control Control { get; protected set; }



        public ControlCallbackRegistrator(Control control)
        {
            Control = control;
        }



        public T Register(T eventArgs)
        {
            return RegisterInternal(Control, eventArgs);
        }


        public CallbackRepository<T> InCallbacks()
        {
            var registeredSenderEvenArgs = RegisteredCallbacksRepository
                .Select(x => x.EventArgs)
                .ToList();

            return new CallbackRepository<T>(Control, registeredSenderEvenArgs);
        }
    }
}