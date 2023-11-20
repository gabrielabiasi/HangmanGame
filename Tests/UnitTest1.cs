using Game.Domain.Commands;
using Game.Domain.Handlers;
using Game.Domain.Helpers.Constants;
using HangmanGame.HttpApi.Controllers;
using Tests.Parsers;

namespace Tests
{
    public class UnitTest1
    {

        private readonly List<string> _jsonsLocation = new() { "..", "..", "..", "Mock", "JSON" };

        [Fact]
        public void ValidateCorrectLetter()
        {
            // arrange
            ValidateKeyHandler validateKeyHandler = new ValidateKeyHandler();
            GameCommand command = JsonParser.Parser<GameCommand>(_jsonsLocation, "newJson_1.json");

            // act
            var result = validateKeyHandler.Validate(command);

            //check
            Assert.Equal(MessagesConstants.CorrectKey, result.Message);
            Assert.Equal(new[] { "y" }, result.WrongKeys);
            Assert.Equal(new[] { "l" }, result.CorrectKeys);
        }

        [Fact]
        public void ValidateEqualLetters()
        {
            // arrange
            ValidateKeyHandler validateKeyHandler = new ValidateKeyHandler();
            GameCommand command = JsonParser.Parser<GameCommand>(_jsonsLocation, "newJson_2.json");

            // act
            var result = validateKeyHandler.Validate(command);

            //check
            Assert.Equal(MessagesConstants.KeyPressed, result.Message);
            Assert.Equal(new string[] { }, result.WrongKeys);
            Assert.Equal(new[] { "o" }, result.CorrectKeys);
        }

        [Fact]
        public void ValidateWrongLetters()
        {
            // arrange
            ValidateKeyHandler validateKeyHandler = new ValidateKeyHandler();
            GameCommand command = JsonParser.Parser<GameCommand>(_jsonsLocation, "newJson_3.json");

            // act
            var result = validateKeyHandler.Validate(command);

            //check
            Assert.Equal(MessagesConstants.WrongKey, result.Message);
            Assert.Equal(new[] { "q" }, result.WrongKeys);
            Assert.Equal(new string[] { }, result.CorrectKeys);
            
        }

        //[Fact]
        //public void teste()
        //{
        //    //Arrange
        //    var number = 10;
        //    var name = "Jeff Gordon";
        //    var inputName = nameof(name);
        //    var message = $"Field {inputName} cannot be minor than {number} caracteres";

        //    //Act
        //    var myException = Assert.Throws<ArgumentException>(() => Check.Clauses(inputName, value: name).MaxLength(number));

        //    //Assert
        //    Assert.Equals(message, myException.Message);
        //}
    }
}