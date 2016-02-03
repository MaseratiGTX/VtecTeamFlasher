using System;
using System.Web;
using NHibernateContext.Core;

namespace NHibernateContext.HttpModules
{
    public class NHibernateHttpModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.EndRequest += context_EndRequest;
        }

        public void Dispose()
        {
        }


        private void context_EndRequest(object sender, EventArgs e)
        {
            NHibernateContextManager.NHibernateSessionManager.CloseAllSessions();
        }
    }
}