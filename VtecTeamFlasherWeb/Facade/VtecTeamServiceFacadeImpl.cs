using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Authentication;
using System.ServiceModel;
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

        public bool SendRequest(ReflashRequest reflashRequest, string token)
        {
            ITokenValidator validator = new DatabaseTokenValidator();
            if (validator.IsValid(token))
                return new VtecTeamDBManager().SaveRequest(reflashRequest);
            throw new FaultException("Срок рабочей сессии истек, преезапустите программу");
        }

        public List<ReflashHistory> GetReflashHistory(int userId, string token)
        {
            ITokenValidator validator = new DatabaseTokenValidator();
            if (validator.IsValid(token))
                return new VtecTeamDBManager().GetReflashHistory(userId);
            throw new FaultException("Срок рабочей сессии истек, преезапустите программу");
        }

        public List<ReflashHistory> GetAdminReflashHistory(int userId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateReflashHistory(ReflashHistory history, string token)
        {
            ITokenValidator validator = new DatabaseTokenValidator();
            if (validator.IsValid(token))
                return new VtecTeamDBManager().UpdateReflashHistory(history);
            throw new FaultException("Срок рабочей сессии истек, преезапустите программу");
        }

        public List<ReflashRequest> GetReflashRequests(int userId, string token)
        {
            ITokenValidator validator = new DatabaseTokenValidator();
            if (validator.IsValid(token))
                return new VtecTeamDBManager().GetReflashRequests(userId);
            throw new FaultException("Срок рабочей сессии истек, преезапустите программу");
        }

        public bool UpdateUserPersonalData(User user, string token)
        {
            ITokenValidator validator = new DatabaseTokenValidator();
            if (validator.IsValid(token))
                return new VtecTeamDBManager().UpdateUserPersonalData(user);
            throw new FaultException("Срок рабочей сессии истек, преезапустите программу");
        }

        public bool SendReview(Review review, string token)
        {
            ITokenValidator validator = new DatabaseTokenValidator();
            if (validator.IsValid(token))
                return new VtecTeamDBManager().SendReview(review);
            throw new FaultException("Срок рабочей сессии истек, преезапустите программу");
        }

        public SaveEntityResult SendComment(Comment comment, string token)
        {
            ITokenValidator validator = new DatabaseTokenValidator();
            if (validator.IsValid(token))
                return new VtecTeamDBManager().SendComment(comment);
            throw new FaultException("Срок рабочей сессии истек, преезапустите программу");
        }

        public List<News> GetNews(string token)
        {
            ITokenValidator validator = new DatabaseTokenValidator();
            if(validator.IsValid(token))
                return new VtecTeamDBManager().GetNews();
            throw new FaultException("Срок рабочей сессии истек, преезапустите программу");
        }

        public List<ReflashInformation> GetInformationListOfReflashBinaries(string ecuBinary, string token)
        {
            ITokenValidator validator = new DatabaseTokenValidator();
            if (validator.IsValid(token))
                return new VtecTeamDBManager().GetInformationListOfReflashBinaries(ecuBinary);
            throw new FaultException("Срок рабочей сессии истек, преезапустите программу");
        }
    }
}