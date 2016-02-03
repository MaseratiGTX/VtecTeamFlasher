namespace Commons.DataCache
{
    public interface IDataCache<T>
    {
        T Value { get; }
        bool IsDirty { get; }

        IDataCache<T> SetValue(T value);
        IDataCache<T> Dirty();
    }
}