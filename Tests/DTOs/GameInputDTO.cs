using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.DTOs
{
    public class GameInputDTO
    {
        public GameInputDTO(string key, int keyCode, string word, string[] correctKeys, string[] wrongKeys)
        {
            Key = key;
            KeyCode = keyCode;
            Word = word;
            CorrectKeys = correctKeys;
            WrongKeys = wrongKeys;
        }

        public string Key { get; set; }
        public int KeyCode { get; set; }
        public string Word { get; set; }
        public string[] CorrectKeys { get; set; }
        public string[] WrongKeys { get; set; }
    }
}
