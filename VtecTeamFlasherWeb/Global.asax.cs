using System;
using System.Reflection;
using System.Web;
using System.Web.Routing;
using Commons.Localization.LocalizationContexts;
using Commons.Logging;
using Commons.Reflections.Assemblies;
using WebAppCommons.Classes.Helpers.HttpApplicationStateExtensions;
using WebAppCommons.Classes.Localization;
using WebAreaCommons.Classes.Security.Authorization;

namespace VtecTeamFlasherWeb
{
    public class Global : HttpApplication
    {
        //MORE INFORMATION ABOUT HttpApplication EVENTS: http://msdn.microsoft.com/en-us/library/system.web.httpapplication_events.aspx

        protected void Application_Start(object sender, EventArgs e)
        {
            Application.InitializeVersionDescription(
                Assembly.GetExecutingAssembly().FetchVersionDescription()
            );

            ApplicationLocalizationConfiguration.Configure(
                ApplicationLocalizationContext.LocalizationManager
            );

            ApplicationRoutesConfiguration.Configure(
                RouteTable.Routes
            );

            ApplicationAuthorizationConfiguration.Configure(
                ApplicationAuthorizationContext.AuthorizationRuleManager
            );
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Log.Error(((HttpApplication) sender).Context.Error);
        }
    }
}