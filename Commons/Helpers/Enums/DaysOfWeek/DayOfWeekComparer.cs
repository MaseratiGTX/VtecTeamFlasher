using System;
using System.Collections.Generic;
using Commons.Helpers.Comparasion.Comparers;

namespace Commons.Helpers.Enums.DaysOfWeek
{
    public class DayOfWeekComparer : AbstractWeightBasedComparer<DayOfWeek>
    {
        public DayOfWeekComparer()
        {
            ItemsWeightRepository[DayOfWeek.Sunday] = 7;
        }

        public DayOfWeekComparer(Dictionary<object, int> itemsWeightRepository) : base(itemsWeightRepository)
        {
        }
    }
}