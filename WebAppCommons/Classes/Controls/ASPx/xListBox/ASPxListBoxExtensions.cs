using System.Collections;
using DevExpress.Web.ASPxEditors;

namespace WebAppCommons.Classes.Controls.ASPx.xListBox
{
    public static class ASPxListBoxExtensions
    {
        public static ASPxListBox ApplyDataSource(this ASPxListBox source, IEnumerable dataSource)
        {
            source.DataSource = dataSource;
            source.DataBindItems();

            return source;
        }
    }
}