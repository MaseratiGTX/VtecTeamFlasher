using System;
using System.Linq;
using System.Security.Principal;
using DevExpress.Web.ASPxMenu;
using WebAreaCommons.Classes.Security.Authorization;

namespace WebAreaCommons.Classes.Controls.ASPx.xMenu
{
    public static class ASPxMenuExtensions
    {
        public static void ApplyPermissions(this MenuItemCollection source, IPrincipal user, AuthorizationRuleManager ruleManager)
        {
            foreach (MenuItem item in source)
            {
                if (item.HasChildren)
                {
                    ApplyPermissions(item.Items, user, ruleManager);

                    if (item.Items.All(x => x.Visible == false))
                        item.Visible = false;
                }

                if (String.IsNullOrEmpty(item.NavigateUrl) == false && ruleManager.IsUserAllowed(item.NavigateUrl, user) == false)
                    item.Visible = false;
            }
        }
    }
}
