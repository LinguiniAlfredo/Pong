using Microsoft.Xna.Framework;
using System.Diagnostics;
using System.Text.Json;

namespace Pong.Components
{
    internal class Player
    {
        internal Pong _game;

        private readonly PlayerIndex _id;
        public int Score { get; private set; }
        public int HiScore { get; private set; }

        public Player(Pong game, PlayerIndex id, Paddle paddle) 
        {
            _game = game;
            _id = id;

            Score = 0;
            HiScore = 0;
        }

        public void IncrementScore()
        {
            Score += 1;
        }
        public void ResetScore() { 
            Score = 0;
        }
        public void UpdateHiScores(string player, int hiScore)
        {
            HiScore = hiScore;
            Score score = new(player, hiScore);
            string json = JsonSerializer.Serialize(score);
            Debug.WriteLine(json);
        }
    }
}