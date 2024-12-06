namespace BlackJackServer.Models
{
    public class PlayerState
    {
        public string Name { get; set; }
        public List<Card> Cards { get; set; }
        public int Score { get; set; }
    }
}
