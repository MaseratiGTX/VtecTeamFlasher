using System;
using System.Security.Authentication;
using ClientAndServerCommons.DataClasses;
using ClientAndServerCommons.Helpers;
using VtecTeamFlasherWeb.Interfaces;

namespace VtecTeamFlasherWeb.TokenLogic
{
    public class DatabaseTokenBuilder : ITokenBuilder
    {
        public string Build(string login, string passwordHash)
        {
            if (!new UserCredentialValidator().IsValid(login, passwordHash))
            {
                throw new AuthenticationException();
            }
            var token = Guid.NewGuid().ToString();
            var dbManager = new VtecTeamDBManager();
            var user = dbManager.GetUser(login);
            if (user == null)
            {
                throw new AuthenticationException();
            }
            if (!dbManager.SaveToken(new Token {TokenString = token, User = user, CreateDate = DateTime.Now}))
                throw new AuthenticationException("Проблемы с БД");
            return token;
        }
    }
}