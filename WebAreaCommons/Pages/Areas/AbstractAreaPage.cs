using System;
using System.Web;
using ClientAndServerCommons;
using ClientAndServerCommons.DataClasses;
using Commons.Localization.Extensions;
using WebAppCommons.Classes.Helpers;
using WebAreaCommons.Classes.Helpers;

namespace WebAreaCommons.Pages.Areas
{
    public abstract class AbstractAreaPage : ADOPersisterPage
    {
        protected string PageGuid { get; private set; }


        protected EntityContext CurrentEntityContext
        {
            get { return HttpContext.Current.EntityContext(); }
        }

        protected AbstractUser CurrentUser
        {
            get { return HttpContext.Current.GetLoggedUser(); }
        }


        private string has_no_value;

        protected string HAS_NO_VALUE
        {
            get { return has_no_value ?? (has_no_value = "значение не указано".Localize()); }
        }


        protected override void OnInit(EventArgs e)
        {
            if (this.IS_FIRST_TIME_LOAD())
            {
                PageGuid = Guid.NewGuid().ToString();

                ClientScript.RegisterHiddenField("__PAGEGUID", PageGuid);
            }
            else
            {
                PageGuid = Request.Form["__PAGEGUID"];
            }

            base.OnInit(e);
        }
    }
}