using System;
using System.Linq;
using System.Web.UI;

namespace WebAppCommons.Classes.Controls.CallbackRegistration
{
    public class CommonCallbackRegistrator<T> : BaseCallbackRegistrator<T> where T : EventArgs
    {
        public T Register(object sender, T eventArgs)
        {
            return Register((Control)sender, eventArgs);
        }

        public T Register(Control sender, T eventArgs)
        {
            return RegisterInternal(sender, eventArgs);
        }


        public CallbackRepository<T> InCallbacksOf(object sender)
        {
            return InCallbacksOf((Control)sender);
        }

        public CallbackRepository<T> InCallbacksOf(Control sender)
        {
            var registeredSenderEvenArgs = RegisteredCallbacksRepository
                .Where(x => x.Sender.UniqueID == sender.UniqueID)
                .Select(x => x.EventArgs)
                .ToList();

            return new CallbackRepository<T>(sender, registeredSenderEvenArgs);
        }
    }
}