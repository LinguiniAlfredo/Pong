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

        public List<Animation> Animations { get; set; } = new List<Animation>();
        public Animation CurrentAnimation { get; set; }
        
        protected GameObject(Pong game, string name) : base(game)
        {
            _game = game;
            Name = name;

            Depth = 0f;
        }

        public abstract void AddAnimation(string name, int index);
        public abstract void PlayAnimation(string name);
    }
}
