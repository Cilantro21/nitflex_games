using Microsoft.AspNetCore.Mvc;
using webapi.Interfaces;
using webapi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {

        private readonly IGamesService _gamesService;

        public GamesController(IGamesService gamesService)
        {
            _gamesService = gamesService;
        }

        // GET: api/<GamesController>
        [HttpGet]
        public async Task<IActionResult> GetAllGames()
        {
            var games = await _gamesService.GetAllGames();
            return Ok(games);
        }

        // GET api/<GamesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGameById(int id)
        {
            var game = await _gamesService.GetGameById(id);
            if (game == null)
            {
                return NotFound();
            }

            return Ok(game);
        }

        // POST api/<GamesController>
        [HttpPost]
        public async Task<IActionResult> AddNewGame(Game game)
        {
            await _gamesService.AddGame(game);
            return CreatedAtAction(nameof(GetGameById), new { id =  game.Id }, game);
        }

        // PUT api/<GamesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateGame(Game game, int id)
        {
            var currentGame = await _gamesService.GetGameById(id);
            if(currentGame == null) {
                return NotFound();
            }
            game.Id = id;
            await _gamesService.UpdateGame(game, id);
            return NoContent();
        }

        // DELETE api/<GamesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveGame(int id)
        {
            var currentGame = await _gamesService.GetGameById(id);
            if (currentGame == null)
            {
                return NotFound();
            }
            await _gamesService.DeleteGame(id);
            return NoContent();
        }
    }
}
