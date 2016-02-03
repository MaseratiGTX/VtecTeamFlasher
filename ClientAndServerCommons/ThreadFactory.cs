using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Threading;
using Commons.Logging;

namespace ClientAndServerCommons
{
    public static class ThreadFactory
    {
        public static Thread CreateThread(ThreadStart command )
        {
            return new Thread(() =>
                {
                    try
                    {
                        command();
                    }
                    catch (Exception e)
                    {
                        try { Log.Error(e); } catch {}
                        if (Debugger.IsAttached) throw;
                    }
                });
        }

        public static bool InvokeSafe(Action method)
        {
            return InvokeSafe(() =>
            {
                method();
                return null;
            });
        }
        public static bool InvokeSafe(Func<Exception> method)
        {
            Exception inner = null;
            try
            {
                inner = method();
            }
            catch (Exception ex)
            {
                SafeLog(ex);
                if (Debugger.IsAttached) throw;
                return false;
            }
            if (inner != null)
            {
                SafeLog(inner);
                if (Debugger.IsAttached) throw inner;
                return false;
            }
            return true;
        }

        public static bool InvokeSafe(this Dispatcher dispatcher, Delegate method, DispatcherPriority priority = DispatcherPriority.Normal, params object[] args )
        {
            return InvokeSafe(() =>
                {
                    Exception inner = null;
                    dispatcher.Invoke((Action)(() =>
                    {
                        try
                        {
                            method.DynamicInvoke(args);
                        }
                        catch (Exception ex)
                        {
                            inner = ex;
                        }
                    }), priority);

                    return inner;
                });
        }

        private static void SafeLog(Exception e)
        {
            try { Log.Error(e); }
            catch { }
        }

    }

}
