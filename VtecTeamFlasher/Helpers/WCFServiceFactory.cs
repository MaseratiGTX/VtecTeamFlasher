using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VtecTeamFlasher.VtecTeamService;

namespace VtecTeamFlasher.Helpers
{
    public class WCFServiceFactory
    {
        public static IVtecTeamWebService CreateVtecTeamService()
        {
            return new VtecTeamWebServiceClient();
        }
    }
}
