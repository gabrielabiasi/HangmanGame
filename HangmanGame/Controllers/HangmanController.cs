using Game.Domain.Commands;
using Game.Domain.Handlers;
using Game.Domain.Helpers.Constants;
using HangmanGame.HttpApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace HangmanGame.HttpApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HangmanController : ControllerBase
    {
        private readonly ILogger<HangmanController> _logger;
        private readonly GameHandler _game;
        private readonly ValidateKeyHandler _validadeKey;
        private readonly WordsHandlers _words;

        public HangmanController(
            ILogger<HangmanController> logger, 
            GameHandler game, 
            ValidateKeyHandler validadeKey,
            WordsHandlers words)
        {
            _logger = logger;
            _game = game;
            _validadeKey = validadeKey;
            _words = words;
        }

        [HttpGet("word")]
        public IActionResult GetWord()
        {
            var word = _words.ChooseWord();

            return Ok(word);
        }

        [HttpPost("key")]
        public IActionResult GetKey([FromBody] GameInputModel keyPressed)
        {
            var command = keyPressed.Create();

            if (command.IsFailure)
            {
                return BadRequest(
                    new ResponseCommand(
                        keyPressed.CorrectKeys,
                        keyPressed.WrongKeys,
                        MessagesConstants.InvalidKey
                ));
            }

            var result = _validadeKey.Validate(command.Value);

            return Ok(result);
        }
    }
}

