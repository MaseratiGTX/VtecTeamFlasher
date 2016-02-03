using System.Collections.Generic;
using NHibernateContext.CustomQuery.Select;

namespace NHibernateContext.CustomQuery.Helpers
{
    public static class NamedParameterCollectionExtensions
    {
         public static NamedParameter AddParameter(this List<NamedParameter> source, object parameterValue)
         {
             var parameter = new NamedParameter();
                 parameter.Name = "parameter" + source.Count;
                 parameter.Value = parameterValue;

             source.Add(parameter);

             return parameter;
         }
    }
}