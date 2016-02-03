using System.Security.Principal;

namespace WebAreaCommons.Classes.Security.Authorization.Configuration
{
    public interface ICustomRule
    {
        bool IsUserAllowed(IPrincipal user);
    }
}