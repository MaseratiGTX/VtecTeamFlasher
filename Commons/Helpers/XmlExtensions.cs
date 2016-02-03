using System.IO;
using System.Xml;

namespace Commons.Helpers
{
    public static class XmlExtensions
    {
        public static XmlDocument ToXmlDocument(this string source)
        {
            var result = new XmlDocument { PreserveWhitespace = true };

            result.LoadXml(source);


            return result;
        }


        public static string ConvertToString(this XmlDocument source)
        {
            var stringWriter = new StringWriter();

            var xmlTextWriter = XmlWriter.Create(stringWriter);


            source.WriteTo(xmlTextWriter);

            xmlTextWriter.Flush();


            return stringWriter.GetStringBuilder().ToString();
        }
    }
}