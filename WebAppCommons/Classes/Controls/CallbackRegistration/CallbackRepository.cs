using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;

namespace WebAppCommons.Classes.Controls.CallbackRegistration
{
    public class CallbackRepository<T> where T : EventArgs
    {
        public Control Sender { get; private set; }
        public List<T> RegisteredEvenArgs { get; private set; }


        public CallbackRepository(Control sender, List<T> registeredEvenArgs)
        {
            Sender = sender;
            RegisteredEvenArgs = registeredEvenArgs;
        }


        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return RegisteredEvenArgs.Where(predicate);
        }
    }
}