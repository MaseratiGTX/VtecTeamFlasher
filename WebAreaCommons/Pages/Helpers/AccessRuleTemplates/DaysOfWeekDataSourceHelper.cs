using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Commons.Helpers.Enums.DaysOfWeek;
using Commons.Helpers.Collections.Generic;
using Commons.Localization.Extensions;

namespace WebAreaCommons.Pages.Helpers.AccessRuleTemplates
{
    public static class DaysOfWeekDataSourceHelper
    {
        public static IEnumerable ToLocalizedDataSource(this IEnumerable<DayOfWeek> source)
        {
            if (source == null) return null;

            return source
                .OrderBy(new DayOfWeekComparer())
                .Select(x =>
                    new
                    {
                        Code = x,
                        Name = x.ToString().Localize()
                    }
                )
                .ToList();
        }
    }
}
