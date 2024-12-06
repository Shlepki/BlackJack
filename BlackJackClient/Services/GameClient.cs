using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using BlackJackClient.Models;

namespace BlackJackClient.Services
{
    public class GameClient
    {
        private readonly HubConnection _hubConnection;

        public event Action<GameState> OnGameStateUpdated;
        public GameState CurrentGameState { get; private set; }

        public GameClient(string hubUrl)
        {
            _hubConnection = new HubConnectionBuilder()
                .WithUrl(hubUrl) // Убедитесь, что этот метод доступен
                .Build();

            _hubConnection.On<GameState>("UpdateGameState", (gameState) =>
            {
                CurrentGameState = gameState;
                OnGameStateUpdated?.Invoke(gameState);
            });
        }

        public async Task ConnectAsync() => await _hubConnection.StartAsync();

        public async Task JoinGame(string gameId, string playerName)
        {
            await _hubConnection.SendAsync("JoinGame", gameId, playerName);
        }

        public async Task MakeMove(string gameId, string playerName, string action)
        {
            await _hubConnection.SendAsync("MakeMove", gameId, playerName, action);
        }
    }
}
