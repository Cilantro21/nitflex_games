using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using webapi.Interfaces;
using webapi.Models;

namespace webapi.Services
{
    public class GamesService : IGamesService
    {
        private readonly AppDbContext _context;

        public GamesService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Game>> GetAllGames()
        {
            return await _context.Games.ToListAsync();
        }

        public async Task<Game> GetGameById(int id)
        {
            var game = await _context.Games.FirstOrDefaultAsync(g => g.Id == id);
            return game;

        }

        public async Task AddGame(Game game)
        {
            await _context.Games.AddAsync(game);
            _context.SaveChanges();
        }

        public async Task UpdateGame(Game game, int id)
        {
            var currentGame = await _context.Games.FindAsync(id);
            if (currentGame != null)
            {
                currentGame.Title = game.Title;
                currentGame.Category = game.Category;
                currentGame.ReleaseDate = game.ReleaseDate;
                currentGame.Description = game.Description;
                currentGame.VendorId = game.VendorId;
                currentGame.Score = game.Score;
                currentGame.PlatformId = game.PlatformId;
            }
            _context.SaveChanges();
        }

        public async Task DeleteGame(int id)
        {
            var currentGame = await _context.Games.FindAsync(id);
            if (currentGame != null)
            {
                _context.Games.Remove(currentGame);
            }
        }
    }
}
