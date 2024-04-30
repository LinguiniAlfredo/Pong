using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong.Components
{
    internal class Score
    {
        public string _player;
        public int _score;
        public Score(string player, int score) {
            _player = player;
            _score = score;
        }
    }
}
