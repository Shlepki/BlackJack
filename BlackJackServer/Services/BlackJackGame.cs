using BlackJackServer.Models;
using System.Collections.Generic;
using System.Linq;

namespace BlackJackServer.Services
{
    public class BlackJackGame
    {
        public string GameId { get; private set; }
        private readonly List<Player> _players = new();
        private readonly Deck _deck = new();
        private int _currentPlayerIndex = 0;

        public BlackJackGame(string gameId)
        {
            GameId = gameId;
        }

        public void AddPlayer(string playerName)
        {
            if (_players.Any(p => p.Name == playerName)) return;
            _players.Add(new Player { Name = playerName });
        }

        public void DealCard(string playerName)
        {
            var player = _players.FirstOrDefault(p => p.Name == playerName);
            if (player == null) return;

            player.Cards.Add(_deck.Draw());
        }

        public GameState GetState()
        {
            return new GameState
            {
                Players = _players.Select(p => new PlayerState
                {
                    Name = p.Name,
                    Cards = p.Cards,
                    Score = p.CalculateScore()
                }).ToList(),
                CurrentPlayer = _players[_currentPlayerIndex].Name,
                IsGameOver = _players.Any(p => p.CalculateScore() >= 21)
            };
        }

        public void NextTurn()
        {
            _currentPlayerIndex = (_currentPlayerIndex + 1) % _players.Count;
        }
    }
}
