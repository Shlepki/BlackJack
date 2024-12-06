using System.Collections.Concurrent;
using System.Threading.Tasks;
using BlackJackServer.Models;
using BlackJackServer.Services;
using Microsoft.AspNetCore.SignalR;

namespace BlackJackServer.Hubs
{
    public interface IGameClient
    {
        Task UpdateGameState(GameState state);
    }

    public class GameHub : Hub<IGameClient>
    {
        private static readonly ConcurrentDictionary<string, BlackJackGame> Games = new();

        public async Task JoinGame(string gameId, string playerName)
        {
            if (!Games.ContainsKey(gameId))
            {
                Games[gameId] = new BlackJackGame(gameId);
            }

            var game = Games[gameId];
            game.AddPlayer(playerName);

            await Groups.AddToGroupAsync(Context.ConnectionId, gameId);
            await Clients.Group(gameId).UpdateGameState(game.GetState());
        }

        public async Task MakeMove(string gameId, string playerName, string action)
        {
            if (!Games.TryGetValue(gameId, out var game)) return;

            if (action == "Hit") game.DealCard(playerName);

            game.NextTurn();
            await Clients.Group(gameId).UpdateGameState(game.GetState());
        }
    }
}
