using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClientAndServerCommons;
using ClientAndServerCommons.DataClasses;

namespace VtecTeamFlasherWeb.Facade
{
    public interface IVtecTeamServiceFacade
    {
        AuthInfoResult Authenticate(string login, string passwordHash);
        void SignOut();
        string GetSoftvareVersion();
        byte[] GetReflashFile(ReflashRequest relashRequest);
        bool SendRequest(ReflashRequest relashRequest);
        List<ReflashHistory> GetReflashHistory(int userId);
        List<ReflashHistory> GetAdminReflashHistory(int userId);
        void UpdateReflashHistory(int historyId);
    }

}