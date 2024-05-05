using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pong.Components.GameObjects
{

    internal class Ball : GameObject
    {
        private readonly Pong _game;

        public sealed override string Name { get; set; }
        public override Texture2D Texture { get; set; }
        public override Vector2 Position { get; set; }
        public override Rectangle Collision { get; set; }
        public override float Depth { get; set; }
        private Vector2 Direction { get; set; }        
        private float Speed { get; set; }

        private const float DefaultSpeed = 100f;


        public Ball(Pong game, string name) : base(game, name)
        {
            _game = game;

            Name = name;
            Direction = new Vector2(1, 1);
            Speed = DefaultSpeed;

        }

        public override void Update(GameTime deltaTime)
        {
            var velocity = Vector2.Zero;

            if (!_game.Started) return;
            velocity.X = -1;
            velocity.Y = 1;

            // bounce off ceiling/floor 
            if (Position.Y < Texture.Height / 2f || Position.Y > _game.Height - Texture.Height / 2f)
            {
                Direction = new Vector2(Direction.X, Direction.Y * -1);
            }

            // score conditions
            if (Position.X > _game.Width - Texture.Width / 2f)
            {
                Position = _game.CenterScreen;
                Speed = DefaultSpeed;
                _game.Started = false;
            }

            if (Position.X < Texture.Width / 2f)
            {
                Position = _game.CenterScreen;
                Speed = DefaultSpeed;
                _game.SetCurrentScene(_game.Scenes.Find(e => e.Name == "gameover"));
                _game.Started = false;
            }

            // update ball position based on direction vector and speed;
            Position += velocity * Speed * (float)deltaTime.ElapsedGameTime.TotalSeconds * Direction;

            // update collision position and check for collisions, increase speed and reverse direction
            Collision = new Rectangle(new Point((int)Position.X, (int)Position.Y), new Point(Texture.Width, Texture.Height));

            foreach (GameObject go in _game.CurrentScene.GameObjects)
            {
                if (go.Name != "ball")
                {
                    if (go.Collision.Intersects(this.Collision))
                    {
                        Direction = new Vector2(Direction.X * -1, Direction.Y);
                        Speed += 25f;
                        _game.Player.IncrementScore();
                    }                        
                }
            }
        }

    }
}
