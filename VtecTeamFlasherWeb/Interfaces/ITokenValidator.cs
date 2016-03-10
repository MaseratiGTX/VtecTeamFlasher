namespace VtecTeamFlasherWeb.Interfaces
{
    public interface ITokenValidator
    {
        bool IsValid(string token);
    }
}