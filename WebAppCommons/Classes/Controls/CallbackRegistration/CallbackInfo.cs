using System;
using System.Web.UI;

namespace WebAppCommons.Classes.Controls.CallbackRegistration
{
    public class CallbackInfo<T> where T : EventArgs
    {
        public Control Sender { get; set; }
        public T EventArgs { get; set; }
    }
}