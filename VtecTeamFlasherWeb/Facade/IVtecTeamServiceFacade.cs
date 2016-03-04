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
        byte[] GetReflashFile(ReflashRequest reflashRequest);
        bool SendRequest(ReflashRequest reflashRequest);
        List<ReflashHistory> GetReflashHistory(int userId);
        List<ReflashHistory> GetAdminReflashHistory(int userId);
        bool UpdateReflashHistory(ReflashHistory history);
        List<ReflashRequest> GetReflashRequests(int userId);
        bool UpdateUserPersonalData(User user);
        bool SendReview(Review review);
        bool SendComment(Comment comment);
        List<News> GetNews();
    }

}