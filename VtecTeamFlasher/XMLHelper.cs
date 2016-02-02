using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace VtecTeamFlasher
{
    public static class XMLHelper
    {
        public static List<string> GetCARManufacture()
        {
            var resList = new List<string>();
            resList.Add(string.Empty);
            var doc = new XmlDocument();
            doc.Load("Resources\\CarOptions.xml"); 
            var nodes = doc.GetElementsByTagName("cartype");

            foreach (XmlNode node in nodes)
            {
                resList.Add(node.Attributes.GetNamedItem("name").Value);
            }

            return resList;
        }

        public static List<string> GetCARModel(string carManufacture)
        {
            var resList = new List<string>();
            //resList.Add(string.Empty);
            var doc = new XmlDocument();
            doc.Load("Resources\\CarOptions.xml");
            var nodes = doc.GetElementsByTagName("cartype");

            foreach (XmlNode node in nodes)
            {
                if (node.Attributes.GetNamedItem("name").Value == carManufacture)
                {
                    foreach (XmlNode modelNode in node.ChildNodes)
                    {
                        resList.Add(modelNode.Attributes.GetNamedItem("name").Value);
                    }
                    break;
                }
            }

            return resList;
        }
    }
}
