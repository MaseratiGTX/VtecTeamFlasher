using System;
using System.Diagnostics;
using System.Text;
using NLog;
using NLog.Config;

namespace Commons.Logging
{
    public delegate void LogDelegate(string message);
    public class Log
    {
        public static event LogDelegate OnInfoLog;
        public static event LogDelegate OnErrorLog;
        public static event LogDelegate OnNotice;
        public static event LogDelegate OnImportantWarning;
        public static event LogDelegate OnCriticalError;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public static void Error(Exception exception)
        {
            Logger.Error(exception.ToString);
            try
            {
                if (OnErrorLog != null)
                {
                    OnErrorLog(exception.ToString());
                }
            }
            catch
            {

            }
        }

        public static void CriticalError(Exception exception)
        {
            Logger.Error(exception.ToString);
            try
            {
                if (OnCriticalError != null)
                {
                    OnCriticalError(exception.ToString());
                }
            }
            catch
            {

            }
        }

        public static void Error(string format, params object[] args)
        {
            Logger.Error(format, args);
            try
            {
                if (OnErrorLog != null)
                {
                    OnErrorLog(String.Format(format, args));
                }
            }
            catch
            {

            }
        }

        public static void Info(string message)
        {
            Logger.Info(message);
            try
            {
                if (OnInfoLog != null)
                {
                    OnInfoLog(message);
                }
            }
            catch
            {

            }
        }

        public static void Info(string format, params object[] args)
        {
            Logger.Info(format, args);
            try
            {
                if (OnInfoLog != null)
                {
                    OnInfoLog(String.Format(format, args));
                }
            }
            catch
            {

            }
        }

        public static void ImportantWarning(string format, params object[] args)
        {
            Logger.Info(format, args);
            try
            {
                if (OnImportantWarning != null)
                {
                    OnImportantWarning(String.Format(format, args));
                }
            } 
            catch
            {
                
            }
        }

        public static void Notice(string format, params object[] args)
        {
            Logger.Info(format, args);
            try
            {
                if (OnNotice != null)
                {
                    OnNotice(String.Format(format, args));
                }
            }
            catch
            {

            }
        }

        public static void Debug(string message)
        {
            Logger.Debug(message);
        }

        public static void Debug(string format, params object[] args)
        {
            Logger.Debug(format, args);
        }

        private static string GetCallStack()
        {
            var st = new StackTrace(true);
            var sMessage = new StringBuilder();
            for (int i = 3; i < st.FrameCount; i++)
            {
                StackFrame sf = st.GetFrame(i);
                if (sf.GetFileLineNumber() > 0)
                    sMessage.AppendFormat("\r\n\tat {0} in {1}:line {2}", sf.GetMethod(), sf.GetFileName(),
                                          sf.GetFileLineNumber());
            }
            return sMessage + "\r\n";
        }

        public static void DebugWithStackTrace(string message)
        {
            Debug(GetStackTraceMessage(message));
        }

        private static string GetStackTraceMessage(string message)
        {
            string stackTraceMessage = "";
            if (message.Contains("${StackTrace}"))
            {
                stackTraceMessage = message.Replace("${StackTrace}", GetCallStack());
            }
            return stackTraceMessage;
        }

        public static void ChangeConfig(string config)
        {
            LogManager.Configuration = new XmlLoggingConfiguration(config);
        }
    }
}