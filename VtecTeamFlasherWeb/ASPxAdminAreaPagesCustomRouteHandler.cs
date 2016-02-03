using System.Web;
using System.Web.Compilation;
using System.Web.Routing;
using ClientAndServerCommons.Helpers;
using Commons.Helpers.Objects;
using NHibernateContext.ADORepository;
using NHibernateContext.Core;
using WebAppCommons.Classes.Routes.ASPxPageRoute;
using WebAreaCommons.Classes.Helpers;

namespace VtecTeamFlasherWeb
{
    public class ASPxAdminAreaPagesCustomRouteHandler : ASPxPageCustomRouteHandler
    {
        //TODO: переделать от слова совсем

        protected IADORepository ADORepository
        {
            get { return NHibernateContextManager.CommonADORepository; }
        }


        public ASPxAdminAreaPagesCustomRouteHandler(string physicalFilePathTemplate, string notFoundFilePath) : base(physicalFilePathTemplate, notFoundFilePath)
        {
        }


        public override IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            var adminAreaContext = ADORepository.AdminAreaContext();

            if (adminAreaContext.Found())
            {
                requestContext.HttpContext.EntityContext(adminAreaContext);
            }
            else
            {
                return BuildManager.CreateInstanceFromVirtualPath(NotFoundFilePath, typeof(IHttpHandler)) as IHttpHandler;
            }

            return base.GetHttpHandler(requestContext);
        }
    }
}