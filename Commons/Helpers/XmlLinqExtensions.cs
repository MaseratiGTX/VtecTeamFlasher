using System.Xml.Linq;

namespace Commons.Helpers
{
    public static class XmlLinqExtensions
    {
        public static string Value(this XElement source)
        {
            if (source == null) return null;

            return source.Value;
        }

        public static string Value(this XAttribute source)
        {
            if (source == null) return null;

            return source.Value;
        }
    }
}