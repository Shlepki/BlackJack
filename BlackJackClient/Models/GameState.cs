namespace BlackJackClient.Models
{
    public class GameState
    {
        public List<PlayerState> Players { get; set; } = new();
        public string CurrentPlayer { get; set; }
        public bool IsGameOver { get; set; }
    }
}
