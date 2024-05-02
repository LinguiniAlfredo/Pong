using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

// Not sure if I've created this abstract class for a valid purpose.... :)
// Needed to ensure my game objects (ball, paddles) have a texture, position, and name

namespace Pong.Components
{
    internal abstract class GameObject : GameComponent
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
