using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using ClientAndServerCommons;
using ClientAndServerCommons.DataClasses;
using ClientAndServerCommons.Helpers;
using Commons.Logging;
using VtecTeamFlasherWeb.Interfaces;
using VtecTeamFlasherWeb.TokenLogic;
using WebAreaCommons.Classes.Security.Authentication;

namespace VtecTeamFlasherWeb.Facade
{
    public class VtecTeamServiceFacadeImpl : IVtecTeamServiceFacade
    {
        public AuthInfoResult Authenticate(string login, string passwordHash)
        {
            var userCredintialsValidator = new UserCredentialValidator();

            if (userCredintialsValidator.IsValid(login, passwordHash))
            {
                Log.Info("Пользователь {0} успешно найден в БД и авторизован", userCredintialsValidator.User.FirstName);
                userCredintialsValidator.User.Token = new DatabaseTokenBuilder().Build(login, passwordHash);
                return new AuthInfoResult
                {
                    Code = (int)AuthenticationCode.Success,
                    User = userCredintialsValidator.User,
                    Message = "Пользователь успешно авторизован"
                };
            }

            Log.Info("Неверно указан логин или пароль");
            return new AuthInfoResult((int)AuthenticationCode.Failed, "Неверно указан логин или пароль");
        }

        public void SignOut()
        {
            CustomFormsAuthentication.SignOut();
        }

        public string GetSoftvareVersion()
        {
            return "1.0";
        }

        public byte[] GetReflashFile(ReflashRequest reflashRequest)
        {
            //Here I'll implement downloaing file from azure blob
            throw new NotImplementedException();
        }

        public bool SendRequest(ReflashRequest reflashRequest)
        {
            return new VtecTeamDBManager().SaveRequest(reflashRequest);
        }

        public List<ReflashHistory> GetReflashHistory(int userId)
        {
            return new VtecTeamDBManager().GetReflashHistory(userId);
        }

        public List<ReflashHistory> GetAdminReflashHistory(int userId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateReflashHistory(ReflashHistory history)
        {
            return new VtecTeamDBManager().UpdateReflashHistory(history);
        }

        public List<ReflashRequest> GetReflashRequests(int userId)
        {
            return new VtecTeamDBManager().GetReflashRequests(userId);
        }

        public bool UpdateUserPersonalData(User user)
        {
            return new VtecTeamDBManager().UpdateUserPersonalData(user);
        }

        public bool SendReview(Review review)
        {
            return new VtecTeamDBManager().SendReview(review);
        }

        public SaveEntityResult SendComment(Comment comment)
        {
            return new VtecTeamDBManager().SendComment(comment);
        }

        public List<News> GetNews(string token)
        {
            ITokenValidator validator = new DatabaseTokenValidator();
            if(validator.IsValid(token))
                return new VtecTeamDBManager().GetNews();
            throw new InvalidDataException("Need reautorise");
        }
    }
}