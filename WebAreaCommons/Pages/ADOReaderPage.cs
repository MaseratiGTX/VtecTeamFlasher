using System.Web.UI;
using NHibernateContext.ADORepository;
using NHibernateContext.Core;

namespace WebAreaCommons.Pages
{
    public class ADOReaderPage : Page
    {
        protected IADORepository ADORepository { get; set; }


        public ADOReaderPage()
        {
            ADORepository = NHibernateContextManager.CommonADORepository;
        }
    }
}