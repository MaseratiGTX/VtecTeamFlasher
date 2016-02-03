using System;
using System.Collections.Generic;
using System.Web.UI;

namespace WebAppCommons.Classes.Controls.CallbackRegistration
{
    public abstract class BaseCallbackRegistrator<T> where T : EventArgs
    {
        protected List<CallbackInfo<T>> RegisteredCallbacksRepository { get; set; }


        protected BaseCallbackRegistrator()
        {
            Reset();
        }


        public void Reset()
        {
            RegisteredCallbacksRepository = new List<CallbackInfo<T>>();
        }


        protected virtual T RegisterInternal(Control sender, T eventArgs)
        {
            RegisteredCallbacksRepository.Add(
                new CallbackInfo<T>
                {
                    Sender = sender,
                    EventArgs = eventArgs
                }
            );

            return eventArgs;
        }
    }
}