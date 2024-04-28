using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong.Components
{
    internal class Paddle : GameObject
    {
        readonly Pong _game;

        public override Texture2D Texture { get; set; }
        public override Vector2 Position { get; set; }
        public override string Name { get; set; }
        public Vector2 Direction { get; set; }
        public float Spacing { get; set; }
        public float Speed { get; set; }

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

            if (kstate.IsKeyDown(Keys.Up))
            {
                velocity.Y -= 1;
            }
            if (kstate.IsKeyDown(Keys.Down))
            {
                velocity.Y += 1;
            }

            Position += velocity * Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

        }
    }
}
