using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using VtecTeamFlasher.VtecTeamService;

namespace VtecTeamFlasher.Helpers
{
    public class WCFServiceFactory
    {
        public static IVtecTeamWebService CreateVtecTeamService()
        {
            var serviceClient = new VtecTeamWebServiceClient();
            
            if (Session.CurrentUser != null)
            {
                using (new OperationContextScope(serviceClient.InnerChannel))
                {
                    var requestMessage = new HttpRequestMessageProperty();
                    requestMessage.Headers["Token"] = Session.CurrentUser.Token;
                    OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;
                } 
            }
            
            return serviceClient;
        }
    }
}
