using System;
using System.Globalization;
using System.Linq;
using System.Web;
using ClientAndServerCommons.Helpers;
using ClientAndServerCommons.Validators;
using Commons.Helpers.CommonObjects;
using Commons.Helpers.Objects;
using Commons.Localization.LocalizationContexts;
using Commons.Validation.Exceptions;
using DevExpress.Web.ASPxClasses;
using WebAppCommons.Classes.Controls;
using WebAppCommons.Classes.Controls.ASPx;
using WebAppCommons.Classes.Controls.ASPx.xFormLayout;
using WebAppCommons.Classes.Helpers;
using WebAreaCommons.Classes.Helpers;
using WebAreaCommons.Classes.Providers.Configurations;
using WebAreaCommons.Classes.Security.Authentication;
using WebAreaCommons.Pages.Areas;

namespace VtecTeamFlasherWeb.Pages
{
    public partial class Login : AdminAreaPage
    {
        private const string EVENT_GUID = "EVENT_GUID";


        
        #region PAGE EVENTS

        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (this.IS_FIRST_TIME_LOAD() && HttpContext.Current.GetLoggedUser() != null)
            {
                Response.RedirectToRoute("RESOLVE EMPTY URL");
            }
        }

        
        protected void Page_Init(object sender, EventArgs e)
        {
            if (this.IS_FIRST_TIME_LOAD())
            {
                aspxtbLogin.Focus();
            }

            Master.FindControlSmart(x => x.ID == "MainMenu").Visible = false;
            Master.FindControlSmart(x => x.ID == "tblUserInfo").Visible = false;
        }



        protected void aspxbtnAuthorize_OnClick(object sender, EventArgs e)
        {
            try
            {
                var user = ADORepository.Users().FirstOrDefault(x => x.Login == aspxtbLogin.GetValue<string>());
          
                new AuthorizationUserValidator().Validate(user, aspxtbPassword.GetValue<string>());

            

                var userSessionGuid = Guid.NewGuid().ToString();

                CustomFormsAuthentication.SetAuthCookie(user.Id.ToString(CultureInfo.InvariantCulture), true, userSessionGuid);
             
                Response.Redirect("~/");
            }
            catch (Exception exception)
            {
                ShowError(exception);
            }
        }


        #endregion


        #region CALLBACK PANEL EVENTS

        protected void aspxcpSourceXML_Callback(object sender, CallbackEventArgsBase e)
        {
            //aspxhfAuthorizationXMLData["Content"] = PrepareAuthorizationXML();
            //aspxhfAuthorizationXMLData["SignedContent"] = "";
            //aspxhfAuthorizationXMLData["ExpirationDateTime"] = PrepareAuthorizationXMLExpirationDateTime();
        }

        #endregion


        #region VALIDATION

        private void ShowError(Exception exception)
        {
            loginFormErrors.InnerHtml = exception.Message;

            MainFormLayout.FindItemOrGroupByName("ItemErrorMessage").ClientVisible = true;


            var validationException = exception as ValidationException;

            if (validationException != null && validationException.FieldName.IsNotEmpty())
            {
                MainFormLayout.SetFocusByID(validationException.FieldName);
            }
        }

        #endregion
        
      
        public string CurrentLanguage()
        {
            switch (ApplicationLocalizationContext.CurrentLanguageName())
            {
                case "RUS": 
                default: 
                    return "ru";
            }
        }


    }
}