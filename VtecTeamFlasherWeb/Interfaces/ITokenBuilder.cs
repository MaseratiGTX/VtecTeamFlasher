using ClientAndServerCommons.DataClasses;

namespace VtecTeamFlasherWeb.Interfaces
{
    interface ITokenBuilder
    {
        string Build(string login, string passwordHash);
    }
}
