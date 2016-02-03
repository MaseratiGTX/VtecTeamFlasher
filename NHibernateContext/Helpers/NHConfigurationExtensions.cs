using NHibernate.Cfg;

namespace NHibernateContext.Helpers
{
    public static class NHConfigurationExtensions
    {
        public static Configuration SetCommandTimeout(this Configuration source, string value)
        {
            source.SetProperty(Environment.CommandTimeout, value);
            
            return source;
        }
    }
}