using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace VtecTeamFlasherWeb
{
    public static class ApplicationRoutesConfiguration
    {
        public static void Configure(RouteCollection routeCollection)
        {
            var notExistedPagePath = "~/Pages/NotExisted.aspx";

            var routes = new ASPxAdminAreaPagesRouteHelper(routeCollection);

            routes.RouteExistingFiles = true;

            routes.Ignore("{*jar}", new {jar=@".*\.jar"});
            routes.Ignore("{*jnlp}", new {jnlp=@".*\.jnlp"});

            routes.Ignore("favicon.ico");

            routes.Ignore("{resource}.axd/{*pathInfo}");
            routes.Ignore("{service}.svc");

            routes.MapASPxPageRoute("RESOLVE EMPTY URL", "", "~/Pages/Default.aspx");

            routes.MapASPxPageRoute("BREAK DEFAULT PAGE DIRECT URL", "Default", notExistedPagePath);
            
            routes.MapASPxPageRoute("RESOLVE AUTHORIZATION FAILED URL", "AuthorizationFailed/{errorContext}", "~/Pages/AuthorizationFailed.aspx", notExistedPagePath);

            routes.MapASPxPageRoute("RESOLVE ALL ASPX PAGE URLs", "{*PAGEPATH}", "~/Pages/{*PAGEPATH}", notExistedPagePath);
            
            routes.MapPageRoute("RESOLVE OTHER URLs", "{*others}", notExistedPagePath);


            routes.EnableFriendlyUrls(
                new FriendlyUrlSettings
                {
                    AutoRedirectMode = RedirectMode.Permanent,
                    ResolverCachingMode = ResolverCachingMode.Static
                }
            );
        }
    }
}