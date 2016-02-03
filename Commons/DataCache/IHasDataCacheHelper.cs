namespace Commons.DataCache
{
    public static class IHasDataCacheHelper
    {
        public static void Dirty(this object source)
        {
            var hasDataCacheObject = source as IHasDataCache;

            if (hasDataCacheObject != null)
            {
                hasDataCacheObject.Dirty();
            }
        }
    }
}