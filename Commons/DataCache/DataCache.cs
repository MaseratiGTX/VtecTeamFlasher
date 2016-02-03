using System;

namespace Commons.DataCache
{
    public class DataCache<T> : IDataCache<T>
    {
        private readonly Func<T> initializationAction;

        private T cachedValue;
        private bool isDirty;


        public T Value
        {
            get
            {
                if (isDirty)
                {
                    SetValue(initializationAction.Invoke());
                }

                return cachedValue;
            }
        }

        public bool IsDirty
        {
            get { return isDirty; }
        }



        public DataCache(Func<T> initializationAction)
        {
            this.initializationAction = initializationAction;

            cachedValue = default(T);

            isDirty = true;
        }



        public IDataCache<T> SetValue(T value)
        {
            isDirty = false;

            cachedValue = value;

            return this;
        }

        public IDataCache<T> Dirty()
        {
            isDirty = true;

            return this;
        }
    }
}