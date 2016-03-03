using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ClientAndServerCommons.DataClasses;
using Commons.Logging;
using NHibernate.SqlCommand;
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
            return SaveEntity(request);
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
            return SaveEntity(user);
        }


        public bool UpdateReflashHistory(ReflashHistory history)
        {
            return SaveEntity(history);
        }

        public bool SendReview(Review review)
        {
            return SaveEntity(review);
        }

        public bool SendComment(Comment comment)
        {
            return SaveEntity(comment);
        }


        private bool SaveEntity<T>(T entity) where T : class
        {
            try
            {
                adoPersister.ExecuteAsSingle(persister => persister.Save(adoRepository.Evict(entity)));
                return true;

            }
            catch (Exception ex)
            {
                Log.Error("При сохранении сущности {0} произошла ошибка {1}", ex, entity.GetType());
                return false;
            }
        }
    }
}
