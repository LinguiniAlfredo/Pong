﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong.Components.GameObjects
{
    internal class Paddle : GameObject
    {
        private readonly Pong _game;
        
        public sealed override string Name { get; set; }
        public override Texture2D Texture { get; set; }
        public override Vector2 Position { get; set; }
        public override Rectangle Collision { get; set; }
        public override float Depth { get; set; }
        public override bool hasTexture { get; set; }

        public float Spacing { get; set; }
        private float Speed { get; set; }


        public Paddle(Pong game, string name, bool hasTexture) : base(game, name, hasTexture)
        {
            _game = game;

            Name = name;
            Spacing = 20;
            Speed = 250f;
            this.hasTexture = hasTexture;
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
        
        public override void AddAnimation(string name, int index)
        {
            throw new System.NotImplementedException();
        }

        public override void PlayAnimation(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}
