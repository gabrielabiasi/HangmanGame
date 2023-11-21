using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Game.Domain
{
    [XmlRoot(ElementName = "word_list")]
    public class WordList
    {

        [XmlElement(ElementName = "word")]
        public List<string> Word { get; set; }
    }

    [XmlRoot(ElementName = "hangman")]
    public class Hangman
    {

        [XmlElement(ElementName = "word_list")]
        public WordList WordList { get; set; }
    }

}
