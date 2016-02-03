using DevExpress.Web.ASPxClasses;

namespace WebAppCommons.Classes.Controls.ASPx.xWebControlBase
{
    public static class ASPxWebControlBaseExtensions
    {
        public static void _ResetControlHierarchy(this ASPxWebControlBase source)
        {
            ASPxWebControlBaseMembersRepository.ResetControlHierarchy.Invoke(source);
        }
    }
}