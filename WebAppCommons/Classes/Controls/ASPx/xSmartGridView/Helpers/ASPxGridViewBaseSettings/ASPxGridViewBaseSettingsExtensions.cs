using System.Web.UI;
using DevExpress.Web.ASPxGridView;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Helpers.ASPxGridViewBaseSettings
{
    public static class ASPxGridViewBaseSettingsExtensions
    {
        public static ASPxGridView _Grid(this DevExpress.Web.ASPxGridView.ASPxGridViewBaseSettings source)
        {
            return ASPxGridViewBaseSettingsMembersRepository.GridGetter.Invoke(source);
        }

        public static IStateManager[] _GetStateManagedObjects(this DevExpress.Web.ASPxGridView.ASPxGridViewBaseSettings source)
        {
            return ASPxGridViewBaseSettingsMembersRepository.GetStateManagedObjects.Invoke(source);
        }
    }
}