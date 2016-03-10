using ClientAndServerCommons.DataClasses;

namespace VtecTeamFlasherWeb.Interfaces
{
    public interface IUserCredentialsValidator
    {
        bool IsValid(string login, string passwordHash);
    }
}