using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong.Components
{
    internal class Paddle : GameObject
    {
        private readonly Pong _game;
        
        public sealed override string Name { get; set; }
        public override Texture2D Texture { get; set; }
        public override Vector2 Position { get; set; }
        public override Rectangle Collision { get; set; }
        public float Spacing { get; set; }
        private float Speed { get; set; }


        public Paddle(Pong game, string name) : base(game, name)
        {
            _game = game;

            Name = name;
            Spacing = 20;
            Speed = 250f;
        }

        public override void Update(GameTime gameTime)
        {
            // TODO - Move controls of paddle to player class ? 

            var kstate = Keyboard.GetState();

            var velocity = Vector2.Zero;
            
            if ((kstate.IsKeyDown(Keys.W) || kstate.IsKeyDown(Keys.Up)) && Position.Y > 0 + Texture.Height/2f)
            {
                velocity.Y -= 1;
            }
            if ((kstate.IsKeyDown(Keys.S) || kstate.IsKeyDown(Keys.Down)) && Position.Y < _game.Height - Texture.Height/2f)
            {
                velocity.Y += 1;
            }

            // update collision position and check for collisions
            Collision = new Rectangle(new Point((int)Position.X, (int)Position.Y), new Point(Texture.Width, Texture.Height));

            Position += velocity * Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}
