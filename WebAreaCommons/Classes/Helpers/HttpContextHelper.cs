using System.Linq;
using System.Web;
using System.Web.Routing;
using ClientAndServerCommons;
using ClientAndServerCommons.DataClasses;
using ClientAndServerCommons.Helpers;
using Commons.Helpers.Objects;
using NHibernate.Linq;
using NHibernateContext.Core;

namespace WebAreaCommons.Classes.Helpers
{
    public static class HttpContextHelper
    {
        public const string LOGGED_USER_KEY = "LOGGED_USER_KEY";
        public const string ENTITY_CONTEXT_KEY = "ENTITY_CONTEXT_KEY";
        public const string ROUTE_DATA_KEY = "ROUTE_DATA_KEY";
        public const string CLIENT_CODE_KEY = "CLIENT_CODE_KEY";


        public static EntityContext EntityContext(this HttpContext source)
        {
            return source.Items[ENTITY_CONTEXT_KEY] as EntityContext;
        }

        public static void EntityContext(this HttpContextBase source, EntityContext value)
        {
            source.Items[ENTITY_CONTEXT_KEY] = value;
        }


        public static bool IsUserAuthenticated(this HttpContext source)
        {
            return source.User != null && source.User.Identity != null && source.User.Identity.IsAuthenticated;
        }


        public static AbstractUser SetLoggedUser(this HttpContext source, int id)
        {
            source.Items[LOGGED_USER_KEY] = NHibernateContextManager.CommonADORepository
                                                                    .Users()
                                                                    .FirstOrDefault(x => x.Id == id);

            return (AbstractUser)source.Items[LOGGED_USER_KEY];
        }

        public static AbstractUser GetLoggedUser(this HttpContext source)
        {
            if (source.IsUserAuthenticated() == false) return null;

            if (source.Items[LOGGED_USER_KEY] == null)
            {
                var context = HttpContext.Current;
                var userId = context.User.Identity.Name.ParseInt();

                context.SetLoggedUser(userId);
            }

            return (AbstractUser)source.Items[LOGGED_USER_KEY];
        }


        public static RouteData GetRouteData(this HttpContext source)
        {
            if (source.Items[ROUTE_DATA_KEY] == null)
            {
                source.Items[ROUTE_DATA_KEY] = source.Request.RequestContext.RouteData.Route.IsNotEmpty()
                                              ? source.Request.RequestContext.RouteData
                                              : RouteTable.Routes.GetRouteData(new HttpContextWrapper(source));
            }

            return (RouteData)source.Items[ROUTE_DATA_KEY];
        }


        public static string GetCurrentClientCode(this HttpContext source)
        {
            var routeData = source.GetRouteData();

            if (routeData == null) return null;

            var appContext = routeData.Values["appcontext"] as string;

            if (appContext == null) return null;

            //if (source.Items.Contains(CLIENT_CODE_KEY) == false)
            //{
            //    source.Items[CLIENT_CODE_KEY] = NHibernateContextManager.CommonADORepository
            //          .ClientEntities()
            //          .Select(x => x.Code)
            //          .FirstOrDefault(x => x == appContext);
            //}

            return (string)source.Items[CLIENT_CODE_KEY];
        }


        public static string GetUrlWithAppContext(string url)
        {
            if (url.IsEmpty()) return null;

            var clientCode = HttpContext.Current.GetCurrentClientCode();

            return clientCode != null
                ? url.Replace("{AppContext}", clientCode)
                : url.Replace("{AppContext}", "");
        }
    }
}