using CSharpFunctionalExtensions;
using Game.Domain.Commands;
using Game.Domain.Helpers.Constants;

namespace HangmanGame.HttpApi.Model;

public class GameInputModel
{
    public GameInputModel(
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

    public Result<GameCommand> Create()
    {
        if (KeyCode < 65 || KeyCode > 90)
            return Result.Failure<GameCommand>("Invalid key");

        return new GameCommand(
            Key,
            KeyCode,
            Word,
            CorrectKeys,
            WrongKeys

        );
    }
}
