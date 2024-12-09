namespace BlackJackClient.Models
{
    public class PlayerState
    {
        public string Name { get; set; }
        public List<Card> Cards { get; set; } = new();
        public int Score { get; set; }
        public bool isPlayerMove = false;
    }
}
