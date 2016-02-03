using System;
using System.Collections.Generic;
using System.Linq;
using Commons.Helpers.Comparasion;

namespace Commons.DataRanges
{
    public static class DataRangesHelper
    {
        public static IEnumerable<DataRange<T>> FetchNotPresentIn<T>(this IEnumerable<DataRange<T>> source, T minPossibleData, T maxPossibleData) where T : IComparable<T>
        {
            return source.NotPresentIn(minPossibleData, maxPossibleData);
        }

        public static IEnumerable<DataRange<T>> NotPresentIn<T>(this IEnumerable<DataRange<T>> source, T minPossibleData, T maxPossibleData) where T : IComparable<T>
        {
            return source.OrderBy(x => x.DataFrom).CalculateNotPresentSummRanges(minPossibleData, maxPossibleData);
        }

        private static IEnumerable<DataRange<T>> CalculateNotPresentSummRanges<T>(this IEnumerable<DataRange<T>> source, T minPossibleSumm, T maxPossibleSumm) where T : IComparable<T>
        {
            var currentMinPossibleSum = default(T);
            var currentMaxPossibleSumm = default(T);


            var sourceEnumerator = source.GetEnumerator();

            currentMinPossibleSum = minPossibleSumm;

            while (sourceEnumerator.MoveNext())
            {
                var current = sourceEnumerator.Current;

                if (current == null) continue;

                currentMaxPossibleSumm = current.DataFrom;

                if (currentMinPossibleSum.IsLowerThan(currentMaxPossibleSumm))
                {
                    yield return new DataRange<T>(currentMinPossibleSum, currentMaxPossibleSumm);
                }

                currentMinPossibleSum = current.DataTo;
            }

            currentMaxPossibleSumm = maxPossibleSumm;

            if (currentMinPossibleSum.IsLowerThan(currentMaxPossibleSumm))
            {
                yield return new DataRange<T>(currentMinPossibleSum, currentMaxPossibleSumm);
            }
        }
    }
}