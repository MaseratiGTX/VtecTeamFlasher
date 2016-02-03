using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;
using Microsoft.AspNet.FriendlyUrls.Resolvers;
using WebAppCommons.Classes.Routes.Extensions;

namespace WebAppCommons.Classes.Routes.ASPxPageRoute
{
    public class ASPxPagesRouteHelper
    {
        protected RouteCollection Source { get; set; }

        public RouteValueDictionary PERMANENT_DEFAULTS { get; private set; }
        public RouteValueDictionary PERMANENT_CONSTRAINTS { get; private set; }

        public bool RouteExistingFiles
        {
            get { return Source.RouteExistingFiles; }
            set { Source.RouteExistingFiles = value; }
        }



        public ASPxPagesRouteHelper(RouteCollection routeCollection)
        {
            PERMANENT_DEFAULTS = new RouteValueDictionary();
            PERMANENT_CONSTRAINTS = new RouteValueDictionary
            {
                {RouteKeys.PAGEPATH, @"[\w/]+(\.aspx)?"}
            };

            Source = routeCollection;
        }



        public void Ignore(string url)
        {
            Source.Ignore(url);
        }

        public void Ignore(string url, object constraints)
        {
            Source.Ignore(url, constraints);
        }


        public Route MapPageRoute(string routeName, string routeUrl, string physicalFile)
        {
            return Source.MapPageRoute(routeName, routeUrl, physicalFile);
        }

        public Route MapPageRoute(string routeName, string routeUrl, string physicalFile, bool checkPhysicalUrlAccess)
        {
            return Source.MapPageRoute(routeName, routeUrl, physicalFile, checkPhysicalUrlAccess);
        }

        public Route MapPageRoute(string routeName, string routeUrl, string physicalFile, bool checkPhysicalUrlAccess, RouteValueDictionary defaults)
        {
            return Source.MapPageRoute(routeName, routeUrl, physicalFile, checkPhysicalUrlAccess, defaults);
        }

        public Route MapPageRoute(string routeName, string routeUrl, string physicalFile, bool checkPhysicalUrlAccess, RouteValueDictionary defaults, RouteValueDictionary constraints)
        {
            return Source.MapPageRoute(routeName, routeUrl, physicalFile, checkPhysicalUrlAccess, defaults, constraints);
        }

        public Route MapPageRoute(string routeName, string routeUrl, string physicalFile, bool checkPhysicalUrlAccess, RouteValueDictionary defaults, RouteValueDictionary constraints, RouteValueDictionary dataTokens)
        {
            return Source.MapPageRoute(routeName, routeUrl, physicalFile, checkPhysicalUrlAccess, defaults, constraints, dataTokens);
        }


        public Route MapASPxPageRoute(string routeName, string routeUrl, string physicalFile)
        {
            return MapASPxPageRoute(routeName, routeUrl, physicalFile, null, null, null);
        }

        public Route MapASPxPageRoute(string routeName, string routeUrl, string physicalFile, string notFoundFile)
        {
            return MapASPxPageRoute(routeName, routeUrl, physicalFile, notFoundFile, null, null);
        }

        public Route MapASPxPageRoute(string routeName, string routeUrl, string physicalFile, string notFoundFile, RouteValueDictionary defaults)
        {
            return MapASPxPageRoute(routeName, routeUrl, physicalFile, notFoundFile, defaults, null);
        }

        public Route MapASPxPageRoute(string routeName, string routeUrl, string physicalFile, string notFoundFile, RouteValueDictionary defaults, RouteValueDictionary constraints)
        {
            var actualRouteUrl = routeUrl;
            var actualDefaults = PERMANENT_DEFAULTS.ExcludeUnusedIn(actualRouteUrl).MergeWith(defaults).ExcludeNull();
            var actualConstraints = PERMANENT_CONSTRAINTS.ExcludeUnusedIn(actualRouteUrl).MergeWith(constraints).ExcludeNull();
            var actualRouteHandler = CreateRouteHandler(physicalFile, notFoundFile);

            return Source.AddRoute(
                routeName,
                new Route(
                    actualRouteUrl,
                    actualDefaults,
                    actualConstraints,
                    actualRouteHandler
                )
            );
        }


        protected virtual ASPxPageCustomRouteHandler CreateRouteHandler(string physicalFile, string notFoundFile)
        {
            return new ASPxPageCustomRouteHandler(physicalFile, notFoundFile);
        }


        public void EnableFriendlyUrls()
        {
            Source.EnableFriendlyUrls();
        }

        public void EnableFriendlyUrls(FriendlyUrlSettings settings)
        {
            Source.EnableFriendlyUrls(settings);
        }

        public void EnableFriendlyUrls(params IFriendlyUrlResolver[] resolvers)
        {
            Source.EnableFriendlyUrls(resolvers);
        }

        public void EnableFriendlyUrls(FriendlyUrlSettings settings, params IFriendlyUrlResolver[] resolvers)
        {
            Source.EnableFriendlyUrls(settings, resolvers);
        }
    }
}