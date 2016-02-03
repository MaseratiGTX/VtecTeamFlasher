using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using Commons.Helpers.CommonObjects;
using WebAreaCommons.Classes.Helpers;
using WebAreaCommons.Classes.Security.Authorization.Configuration;

namespace WebAreaCommons.Classes.Security.Authorization
{
    public class AuthorizationRuleManager
    {
        private readonly List<Location> locations;
        private string authorizationFailedUrl;

        public string AuthorizationFailedUrl
        {
            get { return HttpContextHelper.GetUrlWithAppContext(authorizationFailedUrl); }
        }

        public Location RootDirectory { get; private set; }

        public AuthorizationRuleManager()
        {
            locations = new List<Location>();
            RootDirectory = new Location(".");
        }
      
        public Location Register(string path)
        {
            var location = new Location(path.ToLowerInvariant());
            AddLocation(location);

            return location;
        }

        private void AddLocation(Location location)
        {
            var existLocation = locations.Any(x => x.Path == location.Path);

            if (existLocation || location.Path == RootDirectory.Path)
                throw new Exception("Правило для URL: {0} уже указано.".FillWith(location.Path));

            locations.Add(location);
        }


        public void SetAuthorizationFailedUrl(string path)
        {
            Register(path.Replace("{AppContext}", "")).AddRule<UserRule>("*", CustomAuthorizationRuleAction.Allow)
                                                      .AddRule<UserRule>("?", CustomAuthorizationRuleAction.Allow);

            authorizationFailedUrl = path;
        }


        public bool IsUserAllowed(string path, IPrincipal user)
        {
            var hasUserAccessToApplication = RootDirectory.IsUserAllowed(user, true);

            var location = locations.FirstOrDefault(x => path.ToLowerInvariant().Contains(x.Path));
            
            if (location == null)
                return hasUserAccessToApplication;

            return location.IsUserAllowed(user, hasUserAccessToApplication);
        }
    }
}
