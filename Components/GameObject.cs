using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pong.Components
{
    public abstract class GameObject : GameComponent
    {
        private readonly Pong _game;

        public abstract string Name { get; set;}
        public abstract Vector2 Position { get; set;}
        public abstract Texture2D Texture {get; set;}
        public abstract Rectangle Collision { get; set; }
        public abstract float Depth { get; set; }
        public abstract List<Animation> Animations { get; set; }
        
        protected GameObject(Pong game, string name) : base(game)
        {
            _game = game;
            Name = name;

            Depth = 0f;
        }

        public void AddAnimation(Texture2D texture, string name, int frames, int row)
        {
            Animations.Add(new Animation(this, "idle", texture, frames, row));
        }
    }
}
