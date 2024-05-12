namespace Pong.Components.GameObjects
{
    internal class Score
    {
        public string Player {get; set;}
        public int Value { get; set;}

        public const string Filepath = @".\scores.json";

        public Score(string player, int value) {
            Player = player;
            Value = value;
        }
    }
}
