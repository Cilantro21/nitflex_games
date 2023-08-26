using webapi.Models;

namespace webapi.Interfaces
{
    public interface IGamesService
    {
        Task<List<Game>> GetAllGames();
        Task<Game> GetGameById(int id);
        Task AddGame(Game game);
        Task UpdateGame(Game game, int id);
        Task DeleteGame(int id);
        
    }
}
