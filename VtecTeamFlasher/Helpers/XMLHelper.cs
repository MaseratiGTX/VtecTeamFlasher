using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System;

namespace VtecTeamFlasher.Helpers
{
    public static class XMLHelper
    {
        public static List<KeyValuePair<string,int>> LoadPCMFlashModules()
        {
            var resList = new List<KeyValuePair<string, int>>();

            var doc = new XmlDocument();
            doc.Load("Resources\\CarOptions.xml");
            var cartypes = doc.GetElementsByTagName("cartype");

            
            foreach (XmlElement cartype in cartypes)
            {
                // TODO verify possible
                resList.Add(new KeyValuePair<string, int>(cartype.GetAttribute("name"), -2));
                foreach (XmlElement cars in cartype.ChildNodes)
                {
                    // TODO verify possible
                    //if (cars.HasAttribute("id"))
                    resList.Add(new KeyValuePair<string, int>(cars.GetAttribute("name"), cars.HasAttribute("id") ? Convert.ToInt16(cars.GetAttribute("id")) : -1));
                }
            }

            return resList;
        }

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


        public static bool GetCheckedStatus(this XmlDocument document, string tagName)
        {
            var result = false;
            if (document.GetElementsByTagName(tagName).Count != 0)
                bool.TryParse(document.GetElementsByTagName(tagName)[0].InnerText, out result);

            return result;
        }

        public static string GetDescription(this XmlDocument document)
        {
            var description = new StringBuilder();

            if (document.GetElementsByTagName("Author").Count != 0)
            {
                var authors = document.GetElementsByTagName("Author").Cast<object>().Aggregate("", (current, author) => current + ((XmlNode)author).InnerText + ", ").TrimEnd(new char[] { ',', ' ' });
                description.AppendLine("Автор\\ы: " + authors);

            }
            if (document.GetElementsByTagName("Price").Count !=0)
                description.AppendLine("Цена: " + document.GetElementsByTagName("Price")[0].InnerText);
            if (document.GetElementsByTagName("ReflashFileName").Count != 0) 
                description.AppendLine("Имя файла: " + document.GetElementsByTagName("ReflashFileName")[0].InnerText);
            if (document.GetElementsByTagName("DateOfLastEdit").Count != 0) 
                description.AppendLine("Дата последнего редактирования: " + document.GetElementsByTagName("DateOfLastEdit")[0].InnerText);
            if (document.GetElementsByTagName("Description").Count != 0) 
                description.AppendLine("Описание: " + document.GetElementsByTagName("Description")[0].InnerText);

            return description.ToString();
        }
    }
}
