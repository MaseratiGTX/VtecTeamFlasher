using System;
using System.Collections.Generic;
using System.IO;
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

        public bool SaveRequest(ReflashRequest request)
        {
            try
            {
                adoPersister.ExecuteAsSingle(persister => persister.Save(adoRepository.Evict(request)));
                return true;

            }
            catch (Exception ex)
            {
                Log.Error("При сохранении сущности ReflashRequest произошла ошибка {0}",ex);
                return false;
            }
        }

        public List<ReflashRequest> GetReflashRequests(int userId)
        {
           return adoRepository.Entities<ReflashRequest>().ThatHas(x => x.UserId == userId).ToList();
        }

        public List<ReflashHistory> GetReflashHistory(int userId)
        {
            return adoRepository.Entities<ReflashHistory>().ThatHas(x => x.UserId == userId).ToList();
        }

        public bool UpdateUserPersonalData(User user)
        {
            try
            {
                adoPersister.ExecuteAsSingle(persister => persister.Save(adoRepository.Evict(user)));
                return true;

            }
            catch (Exception ex)
            {
                Log.Error("При сохранении сущности User произошла ошибка {0}", ex);
                return false;
            }
        }
       
    }
}
