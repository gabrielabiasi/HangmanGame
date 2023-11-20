using System.Globalization;

namespace Game.Domain.Commands
{
    public class GameCommand
    {
        public GameCommand(
            string key, 
            int keyCode, 
            string word, 
            string[] correctKeys, 
            string[] wrongKeys)
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

        public static GameCommand Create(
            string key,
            int keyCode,
            string word,
            string[] correctKeys,
            string[] wrongKeys)
        {

            return new GameCommand(
                key,
                keyCode,
                word,
                correctKeys,
                wrongKeys);

        }
    }
}
