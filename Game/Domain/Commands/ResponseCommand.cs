namespace Game.Domain.Commands
{
    public class ResponseCommand
    {
        public ResponseCommand(
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

        public static ResponseCommand Create(
            string[] correctKeys,
            string[] wrongKeys,
            string message)
        {

            return new ResponseCommand(
                correctKeys,
                wrongKeys,
                message);

        }
    }
}
