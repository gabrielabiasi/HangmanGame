using Game.Domain.Commands;

namespace HangmanGame.HttpApi.Model;

public class GameResponseModel
{
    public GameResponseModel(
        string[] correctKeys,
        string[] wrongKeys,
        string message)
    {
        CorrectKeys = correctKeys;
        WrongKeys = wrongKeys;
        Message = message;
    }

    public string[] CorrectKeys { get; set; }
    public string[] WrongKeys { get; set; }
    public string Message { get; set; }

    public ResponseCommand Create()
    {
        return new ResponseCommand(
            CorrectKeys,
            WrongKeys,
            Message

        );
    }
}
