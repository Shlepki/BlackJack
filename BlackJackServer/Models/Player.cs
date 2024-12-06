using System.Collections.Generic;

namespace BlackJackServer.Models
{
    public class Player
    {
        public string Name { get; set; }
        public List<Card> Cards { get; set; } = new();
        public bool IsTurn { get; set; } = false;


        // TODO: переписать логику
        public int CalculateScore()
        {
            int score = Cards.Sum(c => c.Score);
            int aceCount = Cards.Count(c => c.Value == "A");

            // Уменьшение очков, если перебор
            while (score > 21 && aceCount > 0)
            {
                score -= 10;
                aceCount--;
            }

            return score;
        }
    }
}
