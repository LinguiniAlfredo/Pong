using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pong.Components
{
    public abstract class GameObject : GameComponent
    {
        public abstract string Name { get; set;}
        public abstract Vector2 Position { get; set;}
        public abstract Texture2D Texture {get; set;}
        public abstract Rectangle Collision { get; set; }

        protected GameObject(Game game, string name) : base(game)
        {
        }
    }
}
