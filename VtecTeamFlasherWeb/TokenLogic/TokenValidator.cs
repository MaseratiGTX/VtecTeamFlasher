using System;
using System.Configuration;
using ClientAndServerCommons.DataClasses;
using ClientAndServerCommons.Helpers;
using VtecTeamFlasherWeb.Interfaces;

namespace VtecTeamFlasherWeb.TokenLogic
{
    public class DatabaseTokenValidator : ITokenValidator
    {
        private readonly double DefaultSecondsUntilTokenExpires =  Convert.ToDouble(ConfigurationManager.AppSettings["DefaultSecondsUntilTokenExpires"]);



        public bool IsValid(string tokenText)
        {
            var token = new VtecTeamDBManager().GetToken(tokenText); 
            return token != null && !IsExpired(token);
        }

        private bool IsExpired(Token token)
        {
            var span = DateTime.Now - token.CreateDate;
            return span.TotalSeconds > DefaultSecondsUntilTokenExpires;
        }
    }
}