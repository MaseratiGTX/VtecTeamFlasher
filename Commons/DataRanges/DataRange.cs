using System;

namespace Commons.DataRanges
{
    public class DataRange<T> where T : IComparable<T>
    {
        public T DataFrom { get; set; }
        public T DataTo { get; set; }


        public DataRange()
        {
        }

        public DataRange(T dataFrom, T dataTo)
        {
            DataFrom = dataFrom;
            DataTo = dataTo;
        }
    }
}