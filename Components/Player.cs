using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if (Score > HiScore)
            {
                HiScore = Score;
            }
            Score = 0;
        }
    }
}
