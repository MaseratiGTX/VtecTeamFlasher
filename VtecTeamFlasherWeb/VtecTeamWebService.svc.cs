using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Web;
using ClientAndServerCommons;
using ClientAndServerCommons.DataClasses;
using ClientAndServerCommons.Helpers;
using Commons.Logging;
using NHibernateContext.ADORepository;
using VtecTeamFlasherWeb.Facade;
using VtecTeamFlasherWeb.Interfaces;
using VtecTeamFlasherWeb.TokenLogic;

namespace VtecTeamFlasherWeb
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "VtecTeamWebService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select VtecTeamWebService.svc or VtecTeamWebService.svc.cs at the Solution Explorer and start debugging.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(MaxItemsInObjectGraph = 2147483646, IncludeExceptionDetailInFaults = true)]
    public class VtecTeamWebService : IVtecTeamWebService
    {
        private IVtecTeamServiceFacade vtServiceFacade = new VtecTeamServiceFacadeImpl();
        public AuthInfoResult Authenticate(string login, string passwordHash)
        {
            return vtServiceFacade.Authenticate(login, passwordHash);
        }

        public void SignOut()
        {
            vtServiceFacade.SignOut();
        }

        public string GetSoftvareVersion()
        {
            throw new NotImplementedException();
        }

        public byte[] GetReflashFile(ReflashRequest reflashRequest)
        {
            //TODO: here we'll implement logic to get reflash file from BLOB
            return new byte[0];
        }

        public bool SendRequest(ReflashRequest reflashRequest)
        {
            return vtServiceFacade.SendRequest(reflashRequest);
        }

        public List<ReflashHistory> GetReflashHistory(int userId)
        {
            return vtServiceFacade.GetReflashHistory(userId);
        }

        public List<ReflashHistory> GetAdminReflashHistory(int userId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateReflashHistory(ReflashHistory history)
        {
            return vtServiceFacade.UpdateReflashHistory(history);
        }

        public List<ReflashRequest> GetReflashRequests(int userId)
        {
            return vtServiceFacade.GetReflashRequests(userId);
        }

        public bool UpdateUserPersonalData(User user)
        {
            return vtServiceFacade.UpdateUserPersonalData(user);
        }

        public bool SendReview(Review review)
        {
            return vtServiceFacade.SendReview(review);
        }

        public SaveEntityResult SendComment(Comment comment)
        {
            return vtServiceFacade.SendComment(comment);
        }

        public List<News> GetNews()
        {
            return vtServiceFacade.GetNews(HttpContext.Current.Request.Headers["Token"]);
        }
    }
}
