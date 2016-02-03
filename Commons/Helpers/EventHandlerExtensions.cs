using System;

namespace Commons.Helpers
{
    public static class EventHandlerExtensions
    {
        public static void Raise(this EventHandler source, object sender, EventArgs eventArgs)
        {
            if (source != null)
            {
                source(sender, eventArgs);
            }
        }

        public static void RaiseEvent(this object sender, EventHandler source, EventArgs eventArgs = null)
        {
            source.Raise(sender, eventArgs);
        }


        public static void Raise<T>(this EventHandler<T> source, object sender, T eventArgs) where T : EventArgs
        {
            if (source != null)
            {
                source(sender, eventArgs);
            }
        }

        public static void RaiseEvent<T>(this object sender, EventHandler<T> source, T eventArgs = default(T)) where T : EventArgs
        {
            source.Raise(sender, eventArgs);
        }
    }
}