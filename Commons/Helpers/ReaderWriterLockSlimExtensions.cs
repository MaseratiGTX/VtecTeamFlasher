using System;
using System.Threading;

namespace Commons.Helpers
{
    public static class ReaderWriterLockSlimExtensions
    {
        public static T ProvideReadLock<T>(this ReaderWriterLockSlim source, Func<ReaderWriterLockSlim, T> codeBlock)
        {
            source.EnterReadLock();

            try
            {
                return codeBlock.Invoke(source);
            }
            finally
            {
                source.ExitReadLock();
            }
        }

        public static void ProvideReadLock(this ReaderWriterLockSlim source, Action<ReaderWriterLockSlim> codeBlock)
        {
            source.ProvideReadLock<object>(x =>
                {
                    codeBlock.Invoke(x);
                    
                    return null;
                }
            );
        }

        
        public static T ProvideWriteLock<T>(this ReaderWriterLockSlim source, Func<ReaderWriterLockSlim, T> codeBlock)
        {
            source.EnterWriteLock();

            try
            {
                return codeBlock.Invoke(source);
            }
            finally
            {
                source.ExitWriteLock();
            }
        }

        public static void ProvideWriteLock(this ReaderWriterLockSlim source, Action<ReaderWriterLockSlim> codeBlock)
        {
            source.ProvideWriteLock<object>(x =>
                {
                    codeBlock.Invoke(x);
                    
                    return null;
                }
            );
        }
    }
}