using System.IO;
using System.Web;

namespace WebAppCommons.Classes.Helpers
{
    public static class VirtualPathExtensions
    {
        public static bool HasExtension(this string virtualPath)
        {
            return virtualPath.Contains(".");
        }

        public static bool HasNoExtension(this string virtualPath)
        {
            return virtualPath.HasExtension() == false;
        }


        public static string MapPath(this string virtualPath)
        {
            return HttpContext.Current.Server.MapPath(virtualPath);
        }

        public static bool Exists(this string virtualPath)
        {
            return File.Exists(virtualPath.MapPath());
        }
    }
}