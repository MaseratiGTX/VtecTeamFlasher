using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Activation;
using ClientAndServerCommons;
using ClientAndServerCommons.DataClasses;
using VtecTeamFlasherWeb.Facade;
using VtecTeamFlasherWeb.Interfaces;

namespace VtecTeamFlasherWeb
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "VtecTeamWebService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select VtecTeamWebService.svc or VtecTeamWebService.svc.cs at the Solution Explorer and start debugging.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(MaxItemsInObjectGraph = 2147483646, IncludeExceptionDetailInFaults = true)]
    public class VtecTeamWebService : IVtecTeamWebService
    {
        private IVtecTeamServiceFacade vtServiceFacade = new VtecTeamServiceFacadeImpl();

        
        
         string incomingUserInfo = "";
        public VtecTeamWebService()
        {
            var headerIndex = OperationContext.Current.IncomingMessageHeaders.FindHeader("UserToken", "http://vtecteam.com/");
            if (headerIndex != -1)
            {
                incomingUserInfo = OperationContext.Current.IncomingMessageHeaders.GetHeader<string>(headerIndex);
            }
        }
        
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
            return vtServiceFacade.SendRequest(reflashRequest, incomingUserInfo);
        }

        public List<ReflashHistory> GetReflashHistory(int userId)
        {
            return vtServiceFacade.GetReflashHistory(userId, incomingUserInfo);
        }

        public List<ReflashHistory> GetAdminReflashHistory(int userId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateReflashHistory(ReflashHistory history)
        {
            return vtServiceFacade.UpdateReflashHistory(history, incomingUserInfo);
        }

        public List<ReflashRequest> GetReflashRequests(int userId)
        {
            return vtServiceFacade.GetReflashRequests(userId, incomingUserInfo);
        }

        public bool UpdateUserPersonalData(User user)
        {
            return vtServiceFacade.UpdateUserPersonalData(user, incomingUserInfo);
        }

        public bool SendReview(Review review)
        {
            return vtServiceFacade.SendReview(review, incomingUserInfo);
        }

        public SaveEntityResult SendComment(Comment comment)
        {
            return vtServiceFacade.SendComment(comment, incomingUserInfo);
        }

        public List<News> GetNews()
        {
            return vtServiceFacade.GetNews(incomingUserInfo);
        }
    }
}
