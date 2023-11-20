using Microsoft.AspNetCore.Mvc;

namespace HangmanGame.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HangmanController : ControllerBase
    {
        string words = "application";

        private readonly ILogger<HangmanController> _logger;

        public HangmanController(ILogger<HangmanController> logger)
        {
            _logger = logger;
        }

        //[HttpPost("new")]
        //public IActionResult StartNewGame()
        //{
        //    // Lógica para iniciar um novo jogo


        //}
    }
}