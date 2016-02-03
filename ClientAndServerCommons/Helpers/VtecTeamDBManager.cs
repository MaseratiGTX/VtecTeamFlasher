using System;
using System.Collections.Generic;
using System.Linq;
using ClientAndServerCommons.DataClasses;
using Commons.Logging;
using NHibernateContext.ADOPersister;
using NHibernateContext.ADORepository;
using NHibernateContext.Core;

namespace ClientAndServerCommons.Helpers
{
    public class VtecTeamDBManager
    {
        private IADORepository adoRepository;
        private IADOPersister adoPersister;
        public VtecTeamDBManager()
        {
            adoRepository = NHibernateContextManager.CommonADORepository;
            adoPersister = NHibernateContextManager.CommonADOPersister;
        }

        public User GetUser(string login)
        {
            var user = adoRepository.Entities<User>()
                    .ThatHas(x => x.Login == login)
                    .FirstOrDefault();
            return user;
        }
       
    }
}
