using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using ClientAndServerCommons;
using ClientAndServerCommons.DataClasses;

namespace VtecTeamFlasherWeb.Interfaces
{
    /// <summary>
    /// Summary description for IPrinterMonitoringService
    /// </summary>
    [ServiceContract]

    public interface IVtecTeamWebService
    {
        [OperationContract]
        AuthInfoResult Authenticate(string login, string passwordHash);
        [OperationContract]
        void SignOut();
        [OperationContract]
        string GetSoftvareVersion();
        [OperationContract]
        byte[] GetReflashFile(ReflashRequest reflashRequest);
        [OperationContract]
        bool SendRequest(ReflashRequest relashRequest);
        [OperationContract]
        List<ReflashHistory> GetReflashHistory(int userId);
        [OperationContract]
        List<ReflashHistory> GetAdminReflashHistory(int userId);
        [OperationContract]
        bool UpdateReflashHistory(ReflashHistory history);
        [OperationContract]
        List<ReflashRequest> GetReflashRequests(int userId);
        [OperationContract]
        bool UpdateUserPersonalData(User user);
        [OperationContract]
        bool SendReview(Review review);
        [OperationContract]
        SaveEntityResult SendComment(Comment comment);
        [OperationContract]
        List<News> GetNews();


    }
}