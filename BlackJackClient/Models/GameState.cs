namespace BlackJackClient.Models
{
    public class GameState
    {
        public List<PlayerState> Players { get; set; } = new();
        public string CurrentPlayer { get; set; }
        public bool IsGameOver { get; set; }
        public List<Card> cards { get; set; }

        public GameState()
        {
            List<Card> cards = new();
            cards.Add(new Card());
        }
    }
}
