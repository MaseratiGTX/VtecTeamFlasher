using System.Collections.Generic;
using ClientAndServerCommons;
using ClientAndServerCommons.DataClasses;

namespace VtecTeamFlasherWeb.Interfaces
{
    public interface IVtecTeamServiceFacade
    {
        AuthInfoResult Authenticate(string login, string passwordHash);
        void SignOut();
        string GetSoftvareVersion();
        byte[] GetReflashFile(ReflashRequest reflashRequest);
        bool SendRequest(ReflashRequest reflashRequest, string token);
        List<ReflashHistory> GetReflashHistory(int userId, string token);
        List<ReflashHistory> GetAdminReflashHistory(int userId);
        bool UpdateReflashHistory(ReflashHistory history, string token);
        List<ReflashRequest> GetReflashRequests(int userId, string token);
        bool UpdateUserPersonalData(User user, string token);
        bool SendReview(Review review, string token);
        SaveEntityResult SendComment(Comment comment, string token);
        List<News> GetNews(string token);
        List<ReflashInformation> GetInformationListOfReflashBinaries(string ecuBinary, string token);
    }

}