using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Microsoft.Xna.Framework;
using Newtonsoft.Json;

namespace Pong.Components.GameObjects
{
    internal class Player
    {
        private readonly Pong _game;

        private readonly PlayerIndex _id;
        
        public readonly Score Score;
        
        public int CurrentHiScore;
        
        public Player(Pong game, PlayerIndex id) 
        {
            _game = game;
            _id = id;
            Score = new Score("AAA", 0);
            Score.Value = 0;
            CurrentHiScore = 0;
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
                var hiscores = File.ReadAllText(Score.Filepath);
                list = JsonConvert.DeserializeObject<List<Score>>(hiscores);
            }
            catch (FileNotFoundException e)
            {
                // do stuff
            }

            CurrentHiScore = hiScore;
            Score.Value = CurrentHiScore;

            list.Add(Score);
            
            string json = System.Text.Json.JsonSerializer.Serialize(list);
            File.WriteAllText(Score.Filepath, json);
            Debug.WriteLine(json);
        }

        private static List<Score> readHiScores()
        { 
            return new List<Score>();
        }
    }
}