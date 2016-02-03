using System;
using System.Web;
using System.Web.UI;
using ClientAndServerCommons;
using Commons.Helpers.CommonObjects;
using Commons.Helpers.Objects;
using Commons.Localization.LocalizationContexts;
using WebAppCommons.Classes.Controls.ASPx;
using WebAppCommons.Classes.Controls.ASPx.xComboBox;
using WebAppCommons.Classes.Helpers.HttpApplicationStateExtensions;
using WebAreaCommons.Classes.Controls.ASPx.xMenu;
using WebAreaCommons.Classes.Helpers;
using WebAreaCommons.Classes.Security.Authentication;
using WebAreaCommons.Classes.Security.Authorization;

namespace VtecTeamFlasherWeb
{
    public partial class Site : MasterPage
    {
        protected EntityContext CurrentEntityContext
        {
            get { return HttpContext.Current.EntityContext(); }
        }

        public Site()
        {
        }



        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Header.DataBind();


            var user = HttpContext.Current.GetLoggedUser();

            

        }


        protected void ApplyMenuVisibility()
        {
            
        }

        protected void asplnkLogout_OnClick(object sender, EventArgs e)
        {
            CustomFormsAuthentication.SignOut();
            CustomFormsAuthentication.RedirectToLoginPage();
        } 
        protected void asplnkPersonalArea_OnClick(object sender, EventArgs e)
        {
            HttpContext.Current.Response.Redirect("~/PersonalArea");
        }
        


    }
}