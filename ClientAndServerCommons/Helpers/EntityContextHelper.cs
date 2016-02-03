using System.Collections.Generic;
using System.Linq;
using ClientAndServerCommons.DataClasses;

namespace ClientAndServerCommons.Helpers
{
    public static class EntityContextHelper
    {
        public static string AreaAbbreviation(this string entityContextName)
        {
            if (entityContextName == typeof(AdminAreaContext).Name) return "РМАС";
            //if (entityContextName == typeof(ClientAreaContext).Name) return "РМКС";
            //if (entityContextName == typeof(TaxationAreaContext).Name) return "РМНИ";
            
            return null;
        }

        public static string AreaName(this string entityContextName)
        {
            if (entityContextName == typeof(AdminAreaContext).Name) return "Рабочее место администратора системы";
            //if (entityContextName == typeof(ClientAreaContext).Name) return "Рабочее место клиента системы";
            //if (entityContextName == typeof(TaxationAreaContext).Name) return "Рабочее место налогового инспектора";
            
            return null;
        }


        //public static List<UserRole> UserRoles(this EntityContext entityContext)
        //{
        //    var entityContextName = entityContext.GetType().Name;

        //    if (entityContextName == typeof(AdminAreaContext).Name)
        //    {
        //        return UserRole.Values.ToList();
        //    }

        //    return UserRole.Values
        //        .Where(x => x.EntityContextName == entityContextName)
        //        .ToList();
        //}
    }
}