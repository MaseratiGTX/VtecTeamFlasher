using System.Collections.Generic;

namespace Commons.DataCache
{
    public interface IEnumerationCache<T> : IDataCache<IEnumerable<T>>, IEnumerable<T>
    {
    }
}