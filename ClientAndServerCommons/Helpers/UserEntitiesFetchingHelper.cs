using System.Linq;
using ClientAndServerCommons.DataClasses;
using NHibernateContext.ADORepository;

namespace ClientAndServerCommons.Helpers
{
    public static class UserEntitiesFetchingHelper
    {
        public static IQueryable<AbstractUser> Users(this IADORepository source)
        {
            return source.Users<AbstractUser>();
        }

        //public static IQueryable<AbstractAreaUser> AreaUsers(this IADORepository source)
        //{
        //    return source.AreaUsers<AbstractAreaUser>();
        //}




        public static IQueryable<T> Users<T>(this IADORepository source) where T : AbstractUser
        {
            return source.Entities<T>();
        }

        //public static IQueryable<T> AreaUsers<T>(this IADORepository source) where T : AbstractAreaUser
        //{
        //    return source.Users<T>();
        //}
    }
}