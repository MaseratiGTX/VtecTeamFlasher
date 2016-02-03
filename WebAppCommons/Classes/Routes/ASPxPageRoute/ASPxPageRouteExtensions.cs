using System.Web.Routing;
using WebAppCommons.Classes.Routes.Extensions;

namespace WebAppCommons.Classes.Routes.ASPxPageRoute
{
    public static class ASPxPageRouteExtensions
    {
        public static RouteValueDictionary PERMANENT_DEFAULTS { get; private set; }
        public static RouteValueDictionary PERMANENT_CONSTRAINTS { get; private set; }


        static ASPxPageRouteExtensions()
        {
            PERMANENT_DEFAULTS = new RouteValueDictionary();
            PERMANENT_CONSTRAINTS = new RouteValueDictionary
            {
                {RouteKeys.PAGEPATH, @"[\w/]+(\.aspx)?"}
            };
        }


        public static Route MapASPxPageRoute(this RouteCollection source, string routeName, string routeUrl, string physicalFile)
        {
            return source.MapASPxPageRoute(routeName, routeUrl, physicalFile, null, null, null);
        }

        public static Route MapASPxPageRoute(this RouteCollection source, string routeName, string routeUrl, string physicalFile, string notFoundFile)
        {
            return source.MapASPxPageRoute(routeName, routeUrl, physicalFile, notFoundFile, null, null);
        }

        public static Route MapASPxPageRoute(this RouteCollection source, string routeName, string routeUrl, string physicalFile, string notFoundFile, RouteValueDictionary defaults)
        {
            return source.MapASPxPageRoute(routeName, routeUrl, physicalFile, notFoundFile, defaults, null);
        }

        public static Route MapASPxPageRoute(this RouteCollection source, string routeName, string routeUrl, string physicalFile, string notFoundFile, RouteValueDictionary defaults, RouteValueDictionary constraints)
        {
            var actualRouteUrl = routeUrl;
            var actualDefaults = PERMANENT_DEFAULTS.ExcludeUnusedIn(actualRouteUrl).MergeWith(defaults).ExcludeNull();
            var actualConstraints = PERMANENT_CONSTRAINTS.ExcludeUnusedIn(actualRouteUrl).MergeWith(constraints).ExcludeNull();
            var actualRouteHandler = new ASPxPageCustomRouteHandler(physicalFile, notFoundFile);

            return source.AddRoute(
                routeName, 
                new Route(
                    actualRouteUrl, 
                    actualDefaults,
                    actualConstraints, 
                    actualRouteHandler
                )
            );
        }
    }
}