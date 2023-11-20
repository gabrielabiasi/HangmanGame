using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Game.Domain.Handlers
{
    public class WordsHandlers
    {
        public string ChooseWord()
        {
            string xml = "../Game/Data/words.xml";
            int WordIndex;
            string ChosenWord = "";

            XmlDocument xmlDoc = new XmlDocument();

            try
            {

                xmlDoc.Load(xml);
                XmlNodeList? wordNodes = xmlDoc.SelectNodes("//hangman/word_list/word");
                if (wordNodes != null && wordNodes.Count > 0)
                {
                    Random random = new Random();
                    WordIndex = random.Next(wordNodes.Count);
                    ChosenWord = wordNodes[WordIndex].InnerText;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while reading the XML file: " + ex.Message);
            }

            return ChosenWord;
        }

    }
}
