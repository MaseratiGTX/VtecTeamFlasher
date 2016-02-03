using System.Web;
using Commons.Reflections.Assemblies;

namespace WebAppCommons.Classes.Helpers.HttpApplicationStateExtensions
{
    public static class VersionDescriptionExtensions
    {
        private const string VERSION_DESCRIPTION_OBJECT_KEY = "VERSION_DESCRIPTION_OBJECT_KEY";
        private const string VERSION_DESCRIPTION_STRING_KEY = "VERSION_DESCRIPTION_STRING_KEY";


        public static void InitializeVersionDescription(this HttpApplicationState source, AssemblyVersionDescription value)
        {
            // ====================================================================================================================
            // ВНИМАНИЕ! Данный метод сознательно оставлен НЕ БЕЗОПАСНЫМ для выполнения в МУЛЬТИПОТОЧНОЙ СРЕДЕ. 
            // ====================================================================================================================
            // Планируется, что вызов данного метода будет происходить только в БЕЗОПАСНОМ в отношении мультипоточности окружении - 
            // например, в обработчике HttpApplication.Application_Start*.
            // --------------------------------------------------------------------------------------------------------------------
            // * Примечание: обычно HttpApplication является Global.asax.
            // ====================================================================================================================

            source.Add(VERSION_DESCRIPTION_OBJECT_KEY, value);
            source.Add(VERSION_DESCRIPTION_STRING_KEY, value.ToString());
        }


        public static AssemblyVersionDescription VersionDescriptionObject(this HttpApplicationState source)
        {
            return source[VERSION_DESCRIPTION_OBJECT_KEY] as AssemblyVersionDescription;
        }

        public static string VersionDescriptionString(this HttpApplicationState source)
        {
            return source[VERSION_DESCRIPTION_STRING_KEY] as string;
        }
    }
}