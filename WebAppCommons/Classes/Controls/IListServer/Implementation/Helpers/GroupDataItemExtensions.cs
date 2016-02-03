using Commons.Helpers.Collections.Generic;

namespace WebAppCommons.Classes.Controls.IListServer.Implementation.Helpers
{
    public static class GroupDataItemExtensions
    {
        public static string CalculateKey(this object[] source)
        {
            return source.ToString(x => x != null ? x.ToString() : "[NULL]", "|");
        }
    }
}