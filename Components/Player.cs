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
        public int Score { get; private set; }
        public int HiScore { get; private set; }

        private readonly string _filepath = "C:\\vs_projects\\Pong\\Pong\\scores.json";

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
            var list = new List<Score>();
            try
            {
                var hiscores = File.ReadAllText(_filepath);
                list = JsonConvert.DeserializeObject<List<Score>>(hiscores);
            }
            catch (FileNotFoundException e)
            {
                // do stuff
            }

            HiScore = hiScore;
            Score newScore = new(player, hiScore);

            list.Add(newScore);
            
            string json = System.Text.Json.JsonSerializer.Serialize(list);
            File.WriteAllText(_filepath, json);
            Debug.WriteLine(json);
        }

        private static List<Score> readHiScores()
        { 
            return new List<Score>();
        }
    }
}