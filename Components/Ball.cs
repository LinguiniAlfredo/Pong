using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;


namespace Pong.Components
{

    internal class Ball : GameObject
    {
        readonly Pong _game;

        public override string Name { get; set; }
        public override Texture2D Texture { get; set; }
        public override Vector2 Position { get; set; }
        public override Rectangle Collision { get; set; }
        public Vector2 Direction { get; set; }
        public float Spacing { get; set; }
        public float Speed { get; set; }

        public bool _isColliding = false;


        public Ball(Pong game, string name) : base(game, name)
        {
            _game = game;

            Name = name;
            Direction = new Vector2(1, 1);
            Speed = 100f;

        }

        public override void Update(GameTime deltaTime)
        {
            var velocity = Vector2.Zero;

            if (_game.Started)
            {
                velocity.X = -1;
                velocity.Y = 1;

                // bounce off ceiling/floor 
                if (Position.Y < Texture.Height / 2 || Position.Y > _game.Height - Texture.Height / 2)
                {
                    Direction = new Vector2(Direction.X, Direction.Y * -1);
                }

                // score conditions
                if (Position.X < Texture.Width / 2)
                {
                    // increment player 2 score
                    Position = _game._centerScreen;
                    _game.Started = false;
                }

                if (Position.X > _game.Width - Texture.Width / 2)
                {
                    // increment player 1 score
                    Position = _game._centerScreen;
                    _game.Started = false;
                }

                // update ball position based on direction vector and speed;
                Position += velocity * Speed * (float)deltaTime.ElapsedGameTime.TotalSeconds * Direction;


                // update collision position and check for collisions
                Collision = new Rectangle(new Point((int)Position.X, (int)Position.Y), new Point(Texture.Width, Texture.Height));


                foreach (GameObject go in _game.gameObjects)
                {
                    if (go.Name != "ball")
                    {
                        if (go.Collision.Intersects(this.Collision))
                        {
                            Debug.WriteLine("COLLIDED");
                            Direction = new Vector2(Direction.X * -1, Direction.Y);
                        }                        
                    }
                }
            }
        }

    }
}
