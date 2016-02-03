using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClientAndServerCommons;

namespace VtecTeamFlasherWeb.Facade
{
    public interface IVtecTeamServiceFacade
    {
        AuthInfoResult Authenticate(string login, string passwordHash);
        void SignOut();
    }

}