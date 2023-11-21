using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace Game.Domain.Handlers
{
    public class XmlHandler
    {
        public T ReadXmlFile<T>(string fileName)
        {
            try
            {
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);

                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"O arquivo '{fileName}' não foi encontrado.");
                    return default(T);
                }

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(filePath);
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                T result;

                using (XmlNodeReader reader = new XmlNodeReader(xmlDoc.DocumentElement))
                {
                    result = (T)serializer.Deserialize(reader);
                }

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao ler o arquivo XML: {ex.Message}");
                return default(T);
            }
        }

        //private string ProcessAttributes(XmlNode node, object obj)
        //{
        //    string ChosenWord = "";

        //    if (node.Attributes != null)
        //    {
        //        foreach (XmlAttribute attribute in node.Attributes)
        //        {
        //            ChosenWord += attribute.Value + " ";
        //        }               
        //    }

        //    foreach (XmlNode childNode in node.ChildNodes)
        //    {
        //        ProcessAttributes(childNode, obj);
        //    }

        //    return ChosenWord.Trim();
        //}
    }
}
