using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;

namespace Pong.Components
{
    internal class Player
    {
        internal Pong _game;

        private readonly PlayerIndex _id;
        
        public Score Score;
        
        public int currentHiScore;
        
        public Player(Pong game, PlayerIndex id, Paddle paddle) 
        {
            _game = game;
            _id = id;
            Score = new Score("AAA", 0);
            Score.Value = 0;
            currentHiScore = 0;
        }

        public void IncrementScore()
        {
            Score.Value += 1;
        }

        public void ResetScore() { 
            Score.Value = 0;
        }

        public void UpdateHiScores(int hiScore)
        {
            var list = new List<Score>();
            try
            {
                var hiscores = File.ReadAllText(Score._filepath);
                list = JsonConvert.DeserializeObject<List<Score>>(hiscores);
            }
            catch (FileNotFoundException e)
            {
                // do stuff
            }

            currentHiScore = hiScore;
            Score.Value = currentHiScore;

            list.Add(Score);
            
            string json = System.Text.Json.JsonSerializer.Serialize(list);
            File.WriteAllText(Score._filepath, json);
            Debug.WriteLine(json);
        }

        private static List<Score> readHiScores()
        { 
            return new List<Score>();
        }
    }
}