using System;
using System.Collections;
using System.Linq;
using Commons.Helpers.Collections.Generic;
using Commons.Helpers.CommonObjects;
using Commons.Helpers.Enums;
using Commons.Helpers.Enums.DaysOfWeek;
using NHibernate;
using NHibernate.Dialect.Function;
using NHibernate.Engine;
using NHibernate.SqlCommand;
using NHibernate.Type;

namespace NHibernateContext.CustomDialects.Functions
{
    public class DAY_OF_WEEK_TO_INT_SMARTFunction : StandardSQLFunction
    {
        public DAY_OF_WEEK_TO_INT_SMARTFunction() : base(null)
        {
        }


        public override IType ReturnType(IType columnType, IMapping mapping)
        {
            return NHibernateUtil.Int32;
        }

        public override SqlString Render(IList args, ISessionFactoryImplementor factory)
        {
            var selectorName = args[0].ToString();
            
            var orderedDaysOfWeek = EnumHelper.GetValues<DayOfWeek>().OrderBy(new DayOfWeekComparer());

            return SqlString.Parse(
                "CASE " + 
                    orderedDaysOfWeek
                        .Select(
                            (dayOfWeek, position) => 
                                "WHEN {0} = '{1}' THEN {2} ".FillWith(selectorName, dayOfWeek, position)
                        )
                        .ToString(
                            x => x, " "
                        ) 
                + "END"
            );
        }
    }
}