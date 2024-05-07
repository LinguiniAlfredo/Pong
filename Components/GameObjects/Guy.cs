using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pong.Components.GameObjects;

public class Guy : GameObject
{
    public override string Name { get; set; }
    public override Vector2 Position { get; set; }
    public override Texture2D Texture { get; set; }
    public override Rectangle Collision { get; set; }
    public override float Depth { get; set; }
    public override List<Animation> Animations { get; set; }
    public Animation CurrentAnimation { get; set; }
    public Guy(Pong game, string name) : base(game, name)
    {
        
    }
    public void PlayAnimation(string name)
    {
        CurrentAnimation = Animations.Find(anim => anim.Name == name);
    }

}