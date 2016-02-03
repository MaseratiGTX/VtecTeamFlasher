using System;
using System.Collections;
using System.Collections.Generic;

namespace Commons.DataCache
{
    public class EnumerationCache<T> : DataCache<IEnumerable<T>>, IEnumerationCache<T>
    {
        public EnumerationCache(Func<IEnumerable<T>> initializationAction) : base(initializationAction)
        {
        }


        public IEnumerator<T> GetEnumerator()
        {
            return Value.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}