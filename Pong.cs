using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pong.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Pong
{
    public class Pong : Game
    {
        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SpriteFont _spriteFont;

        internal Player _player;
        internal Player _player2;

        internal List<GameObject> gameObjects = new();

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

            Ball _ball = new(this, "ball");
            _ball.Position = _centerScreen;
            gameObjects.Add(_ball);

            Paddle _paddle1 = new(this, "paddle_1");
            _paddle1.Position = new Vector2(_paddle1.Spacing, Height/2);
            gameObjects.Add(_paddle1);

            Paddle _paddle2 = new(this, "paddle_2");
            _paddle2.Position = new Vector2(this.Width - _paddle2.Spacing, Height/2);
            gameObjects.Add(_paddle2);

            _player = new Player(this, PlayerIndex.One, _paddle1);
            _player2 = new Player(this, PlayerIndex.Two, _paddle1);

            Started = false;

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _spriteFont = Content.Load<SpriteFont>("StdFont");

            foreach (GameObject go in gameObjects)
            {
                go.Texture = Content.Load<Texture2D>(go.Name);
            }
        }

        protected override void Update(GameTime gameTime)
        {
            var kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            if (kstate.IsKeyDown(Keys.Space))
            {
                Started = true;
            }

            foreach (GameObject go in gameObjects)
            {
                go.Update(gameTime);
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);

            _spriteBatch.Begin();

            foreach (GameObject go in gameObjects)
            {
                _spriteBatch.Draw(
                    go.Texture,
                    go.Position,
                    null,
                    Color.White,
                    0f,
                    new Vector2(go.Texture.Width / 2, go.Texture.Height / 2),
                    Vector2.One,
                    SpriteEffects.None,
                    0f
                );
            }

            _spriteBatch.DrawString(_spriteFont, "Score: " + _player.Score, new Vector2(100, 0), Color.Black);
            _spriteBatch.DrawString(_spriteFont, "Score: " + _player2.Score, new Vector2(Width-250, 0), Color.Black);

            _spriteBatch.DrawString(_spriteFont, "FPS: " + Math.Round(1/gameTime.ElapsedGameTime.TotalSeconds), new Vector2(0, 0), Color.Black);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
