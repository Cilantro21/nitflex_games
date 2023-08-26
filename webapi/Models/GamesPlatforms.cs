namespace webapi.Models
{
    public class GamesPlatforms
    {
        public int GameId { get; set; }
        public Game? Game { get; set; }

        public int PlatformId { get; set; }
        public Platform? Platform { get; set; }

    }
}
