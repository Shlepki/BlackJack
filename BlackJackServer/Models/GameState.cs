using System.Collections.Generic;

namespace BlackJackServer.Models
{
    public class GameState
    {
        public List<PlayerState> Players { get; set; }
        public string CurrentPlayer { get; set; }
        public bool IsGameOver { get; set; }
    }

   
}
