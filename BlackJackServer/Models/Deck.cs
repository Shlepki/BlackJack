using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJackServer.Models
{
    public class Deck
    {
        private readonly List<Card> _cards;

        public Deck()
        {
            _cards = GenerateDeck();
            Shuffle();
        }

        private List<Card> GenerateDeck()
        {
            var suits = new[] { "Черви", "Бубны", "Пики", "Крести" };
            var values = new[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            var scores = new Dictionary<string, int>
            {
                { "2", 2 }, { "3", 3 }, { "4", 4 }, { "5", 5 }, { "6", 6 },
                { "7", 7 }, { "8", 8 }, { "9", 9 }, { "10", 10 },
                { "J", 10 }, { "Q", 10 }, { "K", 10 }, { "A", 11 }
            };

            return suits
                .SelectMany(suit => values.Select(value => new Card
                {
                    Suit = suit,
                    Value = value,
                    Score = scores[value],
                    ImageUrl = $"/images/{value}_of_{suit.ToLower()}.png"
                }))
                .ToList();
        }

        public void Shuffle()
        {
            var random = new Random();
            _cards.Sort((x, y) => random.Next(-1, 2));
        }

        public Card Draw() => _cards.Count > 0 ? _cards.Pop() : null;
    }

    public static class ListExtensions
    {
        public static T Pop<T>(this List<T> list)
        {
            var item = list.LastOrDefault();
            if (item != null) list.RemoveAt(list.Count - 1);
            return item;
        }
    }
}
