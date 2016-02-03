using System;
using System.Collections.Generic;
using Commons.Helpers.Collections.Generic;

namespace Commons.Helpers.Comparasion.Comparers
{
    public abstract class AbstractWeightBasedComparer<T> : IComparer<T> where T : IComparable
    {
        protected Dictionary<object, int> ItemsWeightRepository { get; set; }


        protected AbstractWeightBasedComparer()
        {
            ItemsWeightRepository = new Dictionary<object, int>();
        }

        protected AbstractWeightBasedComparer(Dictionary<object, int> itemsWeightRepository)
        {
            ItemsWeightRepository = itemsWeightRepository;
        }


        public int Compare(T x, T y)
        {
            var xItemWeight = GetItemWeight(x);
            var yItemWeight = GetItemWeight(y);

            var result = xItemWeight.CompareTo(yItemWeight);
            
            if (result == 0)
            {
                return x.CompareTo(y);
            }

            return result;
        }

        protected virtual int GetItemWeight(T item)
        {
            var itemKey = ((object)item) ?? Nothing.Value;
            
            return ItemsWeightRepository.ValueOrDefault(itemKey, int.MinValue);
        }
    }
}