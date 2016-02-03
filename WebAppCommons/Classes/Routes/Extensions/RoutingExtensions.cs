using System.Web.Routing;

namespace WebAppCommons.Classes.Routes.Extensions
{
    public static class RoutingExtensions
    {
        public static bool HasRouteKey(this string routeUrl, string routeKey)
        {
            return 
                routeUrl.Contains("{" + routeKey + "}") 
                || 
                routeUrl.Contains("{" + "*" + routeKey + "}");
        }

        public static bool HasNoRouteKey(this string routeUrl, string routeKey)
        {
            return routeUrl.HasRouteKey(routeKey) == false;
        }


        public static Route AddRoute(this RouteCollection source, string name, Route item)
        {
            source.Add(name, item);

            return item;
        }
    }
}