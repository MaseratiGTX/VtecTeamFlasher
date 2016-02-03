using System;
using System.ServiceModel;
using ClientAndServerCommons;
using ClientAndServerCommons.DataClasses;

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
    }
}