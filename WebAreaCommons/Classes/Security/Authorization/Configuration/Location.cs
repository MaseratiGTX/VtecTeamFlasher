using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;

namespace WebAreaCommons.Classes.Security.Authorization.Configuration
{
    public class Location
    {
        public string Path { get; private set; }

        private readonly List<BaseRule> accessRules;
        private readonly List<ICustomRule> customRules;

        public Location(string path)
        {
            Path = path;
            accessRules = new List<BaseRule>();
            customRules = new List<ICustomRule>();
        }

        public Location AddRule<T>(string value, CustomAuthorizationRuleAction action) where T : BaseRule, new()
        {
            accessRules.Add(new T
            {
                Action = action,
                Value = value
            });

            return this;
        }

        public Location AddCustomRule<T>() where T : ICustomRule, new()
        {
            customRules.Add(new T());

            return this;
        }

        public bool IsUserAllowed(IPrincipal user, bool defaultValue)
        {
            foreach (var rule in accessRules)
            {
                var action = rule.IsUserAllowed(user);

                if (action != CustomAuthorizationRuleAction.NotExisted)
                {
                    return action == CustomAuthorizationRuleAction.Allow 
                                        && customRules.All(x => x.IsUserAllowed(user));
                }
            }

            return defaultValue && customRules.All(x => x.IsUserAllowed(user));
        }
    }
}
