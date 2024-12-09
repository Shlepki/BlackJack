using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using BlackJackClient.Models;

namespace BlackJackClient.Services
{
    public class GameClient
    {
        public HubConnection _hubConnection;

        public event Action<GameState> OnGameStateUpdated;
        public GameState CurrentGameState { get; private set; }

        public GameClient(string hubUrl)
        {
            _hubConnection = new HubConnectionBuilder()
                .WithUrl(hubUrl) 
                .Build();

            _hubConnection.On<GameState>("UpdateGameState", (gameState) =>
            {
                CurrentGameState = gameState;
                OnGameStateUpdated?.Invoke(gameState);
            });
        }

        private async Task EnsureConnectedAsync()
        {
            if (_hubConnection.State == HubConnectionState.Disconnected)
            {
                try
                {
                    await _hubConnection.StartAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error starting SignalR connection: {ex.Message}");
                    throw;
                }
            }
        }

        public async Task ConnectAsync() => await _hubConnection.StartAsync();

        public async Task JoinGame(string gameId, string playerName)
        {
            await EnsureConnectedAsync(); 
            await _hubConnection.SendAsync("JoinGame", gameId, playerName);
        }

        public async Task MakeMove(string gameId, string playerName, string action)
        {
            await _hubConnection.SendAsync("MakeMove", gameId, playerName, action);
        }
    }
}
