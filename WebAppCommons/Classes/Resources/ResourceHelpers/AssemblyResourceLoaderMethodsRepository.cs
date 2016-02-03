using System;
using System.Reflection;
using System.Web.Handlers;
using System.Web.UI;
using Commons.Reflections.Delegates;

namespace WebAppCommons.Classes.Resources.ResourceHelpers
{
    public static class AssemblyResourceLoaderMethodsRepository
    {
        private static readonly object getWebResourceUrl_lockingObject = new object();
        
        private static Func<Type, string, string> getWebResourceUrl_MethodDelegate;

        public static Func<Type, string, string> GetWebResourceUrl
        {
            get
            {
                if (getWebResourceUrl_MethodDelegate != null)
                {
                    return getWebResourceUrl_MethodDelegate;
                }

                lock(getWebResourceUrl_lockingObject)
                {
                    // ReSharper disable ConvertIfStatementToNullCoalescingExpression
                    if(getWebResourceUrl_MethodDelegate == null)
                    // ReSharper restore ConvertIfStatementToNullCoalescingExpression
                    {
                        getWebResourceUrl_MethodDelegate = (Func<Type, string, string>) 
                            typeof(AssemblyResourceLoader).FetchMethodDelegate(
                                BindingFlags.NonPublic | BindingFlags.Static, "GetWebResourceUrl", typeof(Type), typeof(string)
                            );
                    }

                    return getWebResourceUrl_MethodDelegate;
                }
            }
        }



        private static readonly object getWebResourceUrlInternal_lockingObject = new object();

        private static Func<Assembly, string, bool, bool, ScriptManager, bool, string> getWebResourceUrlInternal_MethodDelegate;

        public static Func<Assembly, string, bool, bool, ScriptManager, bool, string> GetWebResourceUrlInternal
        {
            get
            {
                if (getWebResourceUrlInternal_MethodDelegate != null)
                {
                    return getWebResourceUrlInternal_MethodDelegate;
                }

                lock (getWebResourceUrlInternal_lockingObject)
                {
                    // ReSharper disable ConvertIfStatementToNullCoalescingExpression
                    if(getWebResourceUrlInternal_MethodDelegate == null)
                    // ReSharper restore ConvertIfStatementToNullCoalescingExpression
                    {
                        getWebResourceUrlInternal_MethodDelegate = (Func<Assembly, string, bool, bool, ScriptManager, bool, string>)
                            typeof(AssemblyResourceLoader).FetchMethodDelegate(
                                BindingFlags.NonPublic | BindingFlags.Static, "GetWebResourceUrlInternal", typeof(Assembly), typeof(string), typeof(bool), typeof(bool), typeof(ScriptManager), typeof(bool)
                            );
                    }

                    return getWebResourceUrlInternal_MethodDelegate;
                }
            }
        }
    }
}