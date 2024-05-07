using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pong.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Pong.Components.GameObjects;
using Pong.Components.Scenes;

namespace Pong
{
    public class Pong : Game
    {
        private SpriteBatch _spriteBatch;
        private SpriteFont _spriteFont;

        internal readonly Player Player;

        internal readonly List<Scene> Scenes = new();
        internal Scene CurrentScene;

        public readonly float Width;
        public readonly float Height;

        public Vector2 CenterScreen;
        
        public bool Started { get; set; }


        public Pong()
        {
            var graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            
            Width = graphics.PreferredBackBufferWidth;
            Height = graphics.PreferredBackBufferHeight;
            CenterScreen = new Vector2(Width / 2, Height / 2);

            // TODO - Put scene construction in a function/helper thing
            Scenes.Add(new TitleScreen(this, 0, "title"));
            Scenes.Add(new Level1(this, 1, "level1"));
            // Scenes.Add(new Level2(this, 2, "level2"));
            // Scenes.Add(new Level3(this, 3, "level3"));
            // Scenes.Add(new Level4(this, 4, "level4"));
            Scenes.Add(new GameOver(this, 9, "gameover"));
            
            SetCurrentScene(Scenes.Find(e => e.Name == "title"));

            Player = new Player(this, PlayerIndex.One);

            Started = false;

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _spriteFont = Content.Load<SpriteFont>("StdFont");

            Debug.WriteLine("loading content....");
            foreach (var go in Scenes.SelectMany(scene => scene.GameObjects))
            {
                go.Texture = Content.Load<Texture2D>(go.Name);
                
                if (go.Name == "guy_forward_left")
                {
                    go.AddAnimation(go.Texture, "idle", 5, 0);
                }
            }
        }

        protected override void Update(GameTime gameTime)
        {
            var kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(Keys.Escape))
            {
                // TODO - Pause scene
            }

            if (!Started && Player.Score.Value > Player.CurrentHiScore)
            {
                // TODO - Get player initials
                Player.UpdateHiScores(Player.Score.Value);
                Player.ResetScore();
            }
            
            foreach (GameObject go in CurrentScene.GameObjects)
            {
                go.Update(gameTime);
            }
            
            base.Update(gameTime);

        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);

            _spriteBatch.Begin(SpriteSortMode.FrontToBack);
            
            foreach (var go in CurrentScene.GameObjects)
            {
                if (go.Name == "guy_forward_left")
                {
                    go.Animation.stencil.X += go.Animation.offset;
                    _spriteBatch.Draw(
                        go.Texture,
                        go.Position,
                        go.Animation.stencil,
                        Color.White,
                        0f,
                        new Vector2(go.Texture.Width / 2f, go.Texture.Height / 2f),
                        Vector2.One,
                        SpriteEffects.None,
                        go.Depth
                    );
                }
                else
                {
                    _spriteBatch.Draw(
                        go.Texture,
                        go.Position,
                        null,
                        Color.White,
                        0f,
                        new Vector2(go.Texture.Width / 2f, go.Texture.Height / 2f),
                        Vector2.One,
                        SpriteEffects.None,
                        go.Depth
                    );
                }
            }
            
            // TODO - Add UI class to render these with actual pixel art
            
            _spriteBatch.DrawString(_spriteFont, "Score: " + Player.Score.Value, 
                                    new Vector2(100, 0), Color.Black);
            
            _spriteBatch.DrawString(_spriteFont, "Hi Score: " + Player.CurrentHiScore, 
                                    new Vector2(200, 0), Color.Black);
            
            _spriteBatch.DrawString(_spriteFont, "Level: " + 
                                    (CurrentScene.Index is > 0 and < 9 
                                        ? CurrentScene.Index
                                        : "0"), new Vector2(400, 0), Color.Black);

            _spriteBatch.DrawString(_spriteFont, "FPS: " + Math.Round(1/gameTime.ElapsedGameTime.TotalSeconds),
                                    new Vector2(0, 0), Color.Black);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public void SetCurrentScene(Scene scene)
        {
            CurrentScene = scene;
        }
    }
}
