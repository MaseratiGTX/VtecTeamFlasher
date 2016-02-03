using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Routing;

namespace WebAppCommons.Classes.Routes.Extensions
{
    public static class RouteValueDictionaryExtension
    {
        public static RouteValueDictionary ExcludeBy(this RouteValueDictionary source, Func<KeyValuePair<string, object>, bool> predicate)
        {
            if (source == null) return null;

            var result = new RouteValueDictionary();

            foreach (var pair in source)
            {
                if (predicate.Invoke(pair) == false)
                {
                    result.Add(pair.Key, pair.Value);
                }    
            }

            return result;
        }

        public static RouteValueDictionary ExcludeUnusedIn(this RouteValueDictionary source, string routeUrl)
        {
            return source.ExcludeBy(x => routeUrl.HasNoRouteKey(x.Key));
        }

        public static RouteValueDictionary ExcludeNull(this RouteValueDictionary source)
        {
            return source.ExcludeBy(x => x.Value == null);
        }


        public static RouteValueDictionary MergeWith(this RouteValueDictionary source, RouteValueDictionary anotherDictionary)
        {
            if (source == null) return null;
            
            if (anotherDictionary == null) return source;

            return new RouteValueDictionary(
                source
                    .Concat(anotherDictionary)
                    .ToLookup(
                        x => x.Key, 
                        x => x.Value
                    )
                    .ToDictionary(
                        x => x.Key, 
                        x => x.Last()
                    )
            ); 
        }
    }
}