using System.Web.Routing;
using WebAppCommons.Classes.Routes.ASPxPageRoute;

namespace VtecTeamFlasherWeb
{
    public class ASPxAdminAreaPagesRouteHelper : ASPxPagesRouteHelper
    {
        //TODO: переделать от слова совсем

        public ASPxAdminAreaPagesRouteHelper(RouteCollection routeCollection) : base(routeCollection)
        {
        }

        protected override ASPxPageCustomRouteHandler CreateRouteHandler(string physicalFile, string notFoundFile)
        {
            return new ASPxAdminAreaPagesCustomRouteHandler(physicalFile, notFoundFile);
        }
    }
}