namespace BlackJackServer.Models
{
    public class Card
    {
        public string Suit { get; set; } // Масть (червы, пики и т.д.)
        public string Value { get; set; } // Значение (2–10, J, Q, K, A)
        public int Score { get; set; } // Очки за карту
        public string ImageUrl { get; set; } // URL изображения карты
    }
}
