using NHibernate;

namespace NHibernateContext.CustomQuery.Select.LockingModes
{
    public sealed class LockingHints
    {
        public static LockingHints UpdRow { get; private set; }
        public static LockingHints UpdRowReadPast { get; private set; }


        static LockingHints()
        {
            UpdRow = new LockingHints(LockMode.Upgrade);
            UpdRowReadPast = new LockingHints(LockMode.UpgradeNoWait);
        }



        private LockMode LockingModeAnalog { get; set; }

        
        private LockingHints(LockMode lockingHintAnalog)
        {
            LockingModeAnalog = lockingHintAnalog;
        }

        
        public LockMode TransformToLockMode()
        {
            return LockingModeAnalog;
        }
    }
}