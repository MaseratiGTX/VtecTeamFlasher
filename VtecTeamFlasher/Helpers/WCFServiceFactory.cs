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
            serviceClient.Endpoint.Behaviors.Add(new CustomEndpointBehavior());
            
            return serviceClient;
        }
    }
}
