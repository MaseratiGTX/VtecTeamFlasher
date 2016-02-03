using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using ClientAndServerCommons;
using ClientAndServerCommons.Helpers;
using Commons.Logging;
using WebAreaCommons.Classes.Security.Authentication;

namespace VtecTeamFlasherWeb.Facade
{
    public class VtecTeamServiceFacadeImpl : IVtecTeamServiceFacade
    {
        public AuthInfoResult Authenticate(string login, string passwordHash)
        {
            var user = new VtecTeamDBManager().GetUser(login);

            if (user == null)
            {
                Log.Info("Пользователь {0} не найден в базе данных");
                return new AuthInfoResult((int)AuthenticationCode.Failed, "Неверно указан логин или пароль");
            }

            if (user.PasswordHash == passwordHash)
            {
                Log.Info("Пользователь {0} успешно найден в БД и авторизован");

                //var userSessionGuid = Guid.NewGuid().ToString();
                //CustomFormsAuthentication.SetAuthCookie(user.Id.ToString(CultureInfo.InvariantCulture), true, userSessionGuid);
                
                return new AuthInfoResult
                {
                    Code = (int) AuthenticationCode.Success,
                    User = user,
                    Message = "Пользователь успешно авторизован"
                };
            }
            else
            {
                Log.Info("Пользователь {0} успешно найден в БД но пароли не совпадают");
                return new AuthInfoResult
                {
                    Code = (int)AuthenticationCode.Failed,
                    Message = "Неверно указан логин или пароль"
                };
            }

        }

        public void SignOut()
        {
            CustomFormsAuthentication.SignOut();
        }
    }
}