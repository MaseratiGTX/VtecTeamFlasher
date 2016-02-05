using System;
using System.Collections.Generic;
using System.ServiceModel;
using ClientAndServerCommons;
using ClientAndServerCommons.DataClasses;
using NHibernate.Mapping;

namespace VtecTeamFlasherWeb
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
        byte[] GetReflashFile(ReflashRequest relashRequest);
        [OperationContract]
        bool SendRequest(ReflashRequest relashRequest);
        [OperationContract]
        List<ReflashHistory> GetReflashHistory(int userId);
        [OperationContract]
        List<ReflashHistory> GetAdminReflashHistory(int userId);
        [OperationContract]
        void UpdateReflashHistory(int historyId);

    }
}