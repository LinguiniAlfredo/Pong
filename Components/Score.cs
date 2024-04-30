using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong.Components
{
    internal class Score
    {
        public string Player {get; set;}
        public int Value { get; set;}

        public Score(string player, int value) {
            Player = player;
            Value = value;
        }
    }
}
