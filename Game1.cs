using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Pong
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Vector2 _centerScreen;

        // TODO - Put in ball class
        Texture2D _ballTexture;
        Vector2 _ballPosition;
        Vector2 _ballDirection;
        float _ballSpeed;

        // TODO - Put in two instances of a paddle class
        Texture2D _paddle1Texture;
        Vector2 _paddle1Position;
        Vector2 _paddle1Direction;

        Texture2D _paddle2Texture;
        Vector2 _paddle2Position;
        Vector2 _paddle2Direction;

        float _paddleSpeed;
        float _paddleSpacing;

        // TODO - Put in two instances of a player class

        bool _started = false;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _ballPosition = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);
            _ballDirection = new Vector2(1, 1);
            _ballSpeed = 100f;

            _paddleSpacing = 20;
            _paddleSpeed = 250f;
            _paddle1Position = new Vector2(_paddleSpacing, _graphics.PreferredBackBufferHeight/2);
            _paddle2Position = new Vector2(_graphics.PreferredBackBufferWidth - _paddleSpacing, _graphics.PreferredBackBufferHeight / 2);

            _centerScreen = _ballPosition;
        }


        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _ballTexture = Content.Load<Texture2D>("ball");
            _paddle1Texture = Content.Load<Texture2D>("paddle_1");
            _paddle2Texture = Content.Load<Texture2D>("paddle_2");
        }

        protected override void Update(GameTime gameTime)
        {
            var kstate = Keyboard.GetState();

            var ballVelocity = Vector2.Zero;

            if (kstate.IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            // Start logic
            if (kstate.IsKeyDown(Keys.Space))
            {
                _started = true;
            }

            if (_started)
            {
                // starting ball vector
                ballVelocity.X = -1;
                ballVelocity.Y = 1;
            }

            // Ball logic
            // bounce off ceiling/floor
            if (_ballPosition.Y < _ballTexture.Height/2 || _ballPosition.Y > _graphics.PreferredBackBufferHeight - _ballTexture.Height/2)
            {
                _ballDirection.Y *= -1;
            }


            // score conditions
            if (_ballPosition.X < _ballTexture.Width/2)
            {
                // increment player 2 score
                _ballPosition = _centerScreen;
                _started = false;
            }

            if (_ballPosition.X > _graphics.PreferredBackBufferWidth - _ballTexture.Width/2)
            {
                // increment player 1 score
                _ballPosition = _centerScreen;
                _started = false;
            }

            // update ball position based on direction vector and speed;
            _ballPosition += ballVelocity * _ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds * _ballDirection;

            
            // Player 1 controls
            // TODO - put in player class
            var paddleVelocity = Vector2.Zero;

            // Paddle logic
            if (kstate.IsKeyDown(Keys.Up))
            {
                paddleVelocity.Y -= 1;
            }
            if (kstate.IsKeyDown(Keys.Down))
            {
                paddleVelocity.Y += 1;
            }

            _paddle1Position += paddleVelocity * _paddleSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;


            checkPaddleCollision();
            

            base.Update(gameTime);
        }

        private void checkPaddleCollision()
        {
            
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);

            _spriteBatch.Begin();

            // Draw ball
            _spriteBatch.Draw(
                _ballTexture,
                _ballPosition,
                null,
                Color.White,
                0f,
                new Vector2(_ballTexture.Width / 2, _ballTexture.Height / 2),
                Vector2.One,
                SpriteEffects.None,
                0f
                );

            // Draw paddles
            _spriteBatch.Draw(
                _paddle1Texture,
                _paddle1Position,
                null,
                Color.White,
                0f,
                new Vector2(_paddle1Texture.Width / 2, _paddle1Texture.Height / 2),
                Vector2.One,
                SpriteEffects.None,
                0f
            );

            _spriteBatch.Draw(
                _paddle2Texture,
                _paddle2Position,
                null,
                Color.White,
                0f,
                new Vector2(_paddle2Texture.Width / 2, _paddle2Texture.Height / 2),
                Vector2.One,
                SpriteEffects.None,
                0f
            );

            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
