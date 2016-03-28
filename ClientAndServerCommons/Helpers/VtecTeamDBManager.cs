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
            try
            {
                var resultReview = adoPersister.ExecuteAsSingle(persister => persister.Save(adoRepository.Evict(history.Review)));
                history.Review = resultReview;
                adoPersister.ExecuteAsSingle(persister => persister.Save(adoRepository.Evict(history)));
                return true;

            }
            catch (Exception ex)
            {
                Log.Error("При сохранении сущности {0} произошла ошибка {1}", ex, history.GetType());
                return false;
            }
        }

        public bool SendReview(Review review)
        {
            return SaveEntity(review);
        }

        public SaveEntityResult SendComment(Comment comment)
        {
            try
            {
                var result = adoPersister.ExecuteAsSingle(persister => persister.Save(adoRepository.Evict(comment)));
                return new SaveEntityResult{Result = true, EntityId = result.Id};

            }
            catch (Exception ex)
            {
                Log.Error("При сохранении сущности {0} произошла ошибка {1}", ex, comment.GetType());
                return new SaveEntityResult { Result = false, EntityId = -1 };
            }
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

        public List<News> GetNews()
        {
            return adoRepository.Entities<News>().OrderByDescending(news => news.Date).ToList();
        }

        public bool SaveToken(Token token)
        {
            return SaveEntity(token);
        }

        public Token GetToken(string tokenText)
        {
            return   adoRepository.Entities<Token>()
                    .ThatHas(x => x.TokenString == tokenText)
                    .FirstOrDefault();
        }

        public List<ReflashInformation> GetInformationListOfReflashBinaries(string ecuBinary)
        {
            var reflashStorages = adoRepository.Entities<ReflashStorage>().ThatHas(x => x.EcuBinaryNumber == ecuBinary || x.AltEcuCode.Contains(ecuBinary)).ToList();
            var result = reflashStorages.Select(reflashStorage => new ReflashInformation
                                                                      {
                                                                          AltEcuCode = reflashStorage.AltEcuCode, 
                                                                          Description = reflashStorage.Description, 
                                                                          EcuBinaryNumber = reflashStorage.EcuBinaryNumber, 
                                                                          Model = reflashStorage.Model, 
                                                                          ReflashFileName = reflashStorage.ReflashFileName, 
                                                                          ReflashStorageId = reflashStorage.Id, 
                                                                          TransmissionType = reflashStorage.TransmissionType
                                                                      }).ToList();
            return result;
        }
    }
}
