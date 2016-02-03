using System.Web.Configuration;

namespace WebAppCommons.Classes.Configuration
{
    public class ASPNetConfiguration
    {
        public static bool IsDebuggingEnabled
        {
            get
            {
                var compilationSection = WebConfigurationManager.GetSection("system.web/compilation") as CompilationSection;

                return compilationSection != null && compilationSection.Debug;
            }
        }
    }
}