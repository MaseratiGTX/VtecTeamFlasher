using System.Collections.Generic;
using System.Linq;
using ClientAndServerCommons;

namespace WebAreaCommons.Classes.ItemRepositories.Helpers
{
    public static class ItemsExtensions
    {
        public static T DropID<T>(this T source) where T : AbstractDataObject
        {
            source.Id = 0;

            return source;
        }

        public static IEnumerable<T> DropIDs<T>(this IEnumerable<T> source) where T : AbstractDataObject
        {
            return source.Select(DropID);
        }
    }
}