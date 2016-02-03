using NHibernateContext.ADOPersister;
using NHibernateContext.Core;

namespace WebAreaCommons.Pages
{
    public class ADOPersisterPage : ADOReaderPage
    {
        protected IADOPersister ADOPersister { get; set; }


        public ADOPersisterPage()
        {
            ADOPersister = NHibernateContextManager.CommonADOPersister;
        }
    }
}