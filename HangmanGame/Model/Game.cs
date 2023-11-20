using System.Diagnostics.Metrics;
using System.Xml;

namespace HangmanGame.Model
{
    public class Game
    {
        public static void Play(string letter)
        {
           


        }
        public string ChooseWord(string ChosenWord)
        {
            string xml = "./Data/words.xml";
            int WordIndex;

            XmlDocument xmlDoc = new XmlDocument();

            try
            { 
                // Carregar o arquivo XML
                xmlDoc.Load(xml);

                // Encontrar todos os elementos 'word' dentro de 'word_list'
                XmlNodeList? wordNodes = xmlDoc.SelectNodes("//hangman/word_list/word");

                // Verificar se há palavras
                if (wordNodes != null && wordNodes.Count > 0)
                {
                    // Escolher aleatoriamente uma palavra
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
