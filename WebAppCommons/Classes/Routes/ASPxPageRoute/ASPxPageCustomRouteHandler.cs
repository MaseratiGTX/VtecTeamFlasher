using System.Web;
using System.Web.Compilation;
using System.Web.Routing;
using WebAppCommons.Classes.Helpers;

namespace WebAppCommons.Classes.Routes.ASPxPageRoute
{
    public class ASPxPageCustomRouteHandler : IRouteHandler
    {
        public string PhysicalFilePathTemplate { get; private set; }
        public string NotFoundFilePath { get; private set; }



        public ASPxPageCustomRouteHandler(string physicalFilePathTemplate) : this(physicalFilePathTemplate, null)
        {
        }

        public ASPxPageCustomRouteHandler(string physicalFilePathTemplate, string notFoundFilePath)
        {
            PhysicalFilePathTemplate = Normalize(physicalFilePathTemplate);
            NotFoundFilePath = notFoundFilePath;
        }



        public virtual IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            var routeData = requestContext.RouteData;

            var physicalFilePath = PhysicalFilePathTemplate;

            foreach (var pair in routeData.Values)
            {
                physicalFilePath = physicalFilePath.Replace("{" + pair.Key + "}", (string) pair.Value);
            }

            if (physicalFilePath.HasNoExtension())
            {
                physicalFilePath = physicalFilePath + ".aspx";
            }


            var actualHandlerPath = NotFoundFilePath == null || physicalFilePath.Exists() ? physicalFilePath : NotFoundFilePath;
            

            return BuildManager.CreateInstanceFromVirtualPath(actualHandlerPath, typeof (IHttpHandler)) as IHttpHandler;
        }


        private string Normalize(string filePathTemplate)
        {
            return filePathTemplate.Replace("*", "");
        }
    }
}