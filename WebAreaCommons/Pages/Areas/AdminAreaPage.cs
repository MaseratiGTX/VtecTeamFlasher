using ClientAndServerCommons;

namespace WebAreaCommons.Pages.Areas
{
    public abstract class AdminAreaPage : AbstractAreaPage
    {
        protected new AdminAreaContext CurrentEntityContext
        {
            get { return (AdminAreaContext) base.CurrentEntityContext; }
        }
    }
}