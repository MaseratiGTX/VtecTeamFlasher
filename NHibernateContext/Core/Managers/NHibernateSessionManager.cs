using System;
using System.Collections.Generic;
using Commons.Logging;
using NHibernate;
using NHibernateContext.Core.Providers;

namespace NHibernateContext.Core.Managers
{
    public class NHibernateSessionManager
    {
        private readonly List<ISession> sessionRepository = new List<ISession>();

        public NHibernateSessionProvider SessionProvider { get; private set; }



        public NHibernateSessionManager(NHibernateSessionProvider sessionProvider)
        {
            SessionProvider = sessionProvider;
        }



        public ISession OpenSession()
        {
            return OpenSession(FlushMode.Auto);
        }

        public ISession OpenSession(FlushMode flushMode)
        {
            return OpenSession(FlushMode.Auto, null);
        }

        public ISession OpenSession(FlushMode flushMode, bool? defaultReadOnly)
        {
            var session = SessionProvider.OpenSession(flushMode, defaultReadOnly);

            sessionRepository.Add(session);

            return session;
        }


        public void CloseAllSessions()
        {
            foreach (var session in sessionRepository)
            {
                try
                {
                    if (session.IsOpen)
                    {
                        session.Close();
                        session.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    Log.Error("При попытке закрытии сессии произошла ошибка {0}", ex);
                }
            }

            sessionRepository.Clear();
        }
    }
}