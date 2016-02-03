using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using ClientAndServerCommons;
using ClientAndServerCommons.DataClasses;
using ClientAndServerCommons.Helpers;
using Commons.Logging;
using NHibernateContext.ADORepository;
using VtecTeamFlasherWeb.Facade;

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
    }
}
