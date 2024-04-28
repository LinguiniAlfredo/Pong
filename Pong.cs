using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pong.Components;
using System;
using System.Collections.Generic;

namespace Pong
{
    public class Pong : Game
    {
        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private List<GameComponent> components = new List<GameComponent>();

        private Ball _ball;
        private Paddle _paddle1;
        private Paddle _paddle2;

        public readonly float Width;
        public readonly float Height;

        public Vector2 _centerScreen;

        public bool Started { get; set; }


        public Pong()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            
            Width = _graphics.PreferredBackBufferWidth;
            Height = _graphics.PreferredBackBufferHeight;
            _centerScreen = new Vector2(Width / 2, Height / 2);

            _ball = new Ball(this);
            _ball.Position = _centerScreen;
            components.Add(_ball);

            _paddle1 = new Paddle(this);
            _paddle1.Position = new Vector2(_paddle1.Spacing, Height/2);
            components.Add(_paddle1);

            _paddle2 = new Paddle(this);
            _paddle2.Position = new Vector2(this.Width - _paddle2.Spacing, Height/2);
            components.Add(_paddle2);

            //_player1 = new Player(this, _paddle1);

            Started = false;

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _ball.Texture = Content.Load<Texture2D>("ball");
            _paddle1.Texture = Content.Load<Texture2D>("paddle_1");
            _paddle2.Texture = Content.Load<Texture2D>("paddle_2");
        }

        protected override void Update(GameTime gameTime)
        {
            var kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            // Start logic
            if (kstate.IsKeyDown(Keys.Space))
            {
                Started = true;
            }


            foreach (GameComponent component in components)
            {
                component.Update(gameTime);
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);

            _spriteBatch.Begin();

            //foreach (GameComponent component in components)
            //{
            //    _spriteBatch.Draw(
            //        component.Texture,
            //        component.Position,
            //        null,
            //        Color.White,
            //        0f,
            //        new Vector2(component.Texture.Width / 2, component.Texture.Height / 2),
            //        Vector2.One,
            //        SpriteEffect.None,
            //        0f
            //    );
            //}

            // Draw ball
            _spriteBatch.Draw(
                _ball.Texture,
                _ball.Position,
                null,
                Color.White,
                0f,
                new Vector2(_ball.Texture.Width / 2, _ball.Texture.Height / 2),
                Vector2.One,
                SpriteEffects.None,
                0f
                );

            // Draw paddles
            _spriteBatch.Draw(
                _paddle1.Texture,
                _paddle1.Position,
                null,
                Color.White,
                0f,
                new Vector2(_paddle1.Texture.Width / 2, _paddle1.Texture.Height / 2),
                Vector2.One,
                SpriteEffects.None,
                0f
            );

            _spriteBatch.Draw(
                _paddle2.Texture,
                _paddle2.Position,
                null,
                Color.White,
                0f,
                new Vector2(_paddle2.Texture.Width / 2, _paddle2.Texture.Height / 2),
                Vector2.One,
                SpriteEffects.None,
                0f
            );

            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
