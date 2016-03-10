using ClientAndServerCommons.DataClasses;
using ClientAndServerCommons.Helpers;
using VtecTeamFlasherWeb.Interfaces;

namespace VtecTeamFlasherWeb.TokenLogic
{
    public class UserCredentialValidator : IUserCredentialsValidator
    {
        public User User { get; set; }

        public bool IsValid(string login, string passwordHash)
        {
            var user = new VtecTeamDBManager().GetUser(login);
            var result = user != null && user.PasswordHash == passwordHash;
            if (result)
                User = user;
            return result;
        }
    }
}