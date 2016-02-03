using System;
using System.Security.Principal;
using WebAreaCommons.Classes.Security.Authorization.Configuration;

namespace WebAreaCommons.Classes.Security.Authorization.CustomRules
{
    public abstract class BaseCustomRule : ICustomRule
    {
        public bool IsUserAllowed(IPrincipal user)
        {
            try
            {
                Validate();
                return true;
            }
            catch (Exception ex)
            {
                HandleException(ex);
                return false;
            }
        }


        //TODO: Возможно переделать
        protected virtual void HandleException(Exception ex)
        {
            ApplicationAuthorizationContext.AuthorizationFailureMessage = ex.Message;
        }

        protected abstract void Validate();
    }
}