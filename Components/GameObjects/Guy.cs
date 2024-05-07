using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pong.Components.UI;

namespace Pong.Components.GameObjects;

public class Guy : GameObject
{
    private readonly Pong _game;
    public override string Name { get; set; }
    public override Vector2 Position { get; set; }
    public override Texture2D Texture { get; set; }
    public override Rectangle Collision { get; set; }
    public override float Depth { get; set; }

    public Guy(Pong game, string name) : base(game, name)
    {
       Position = new Vector2(game.CenterScreen.X + 100, game.CenterScreen.Y);
    }

    public override void Update(GameTime deltatime)
    {
        PlayAnimation("idle");
    }
    
    public override void AddAnimation(string name, int index)
    {
        Animations.Add(new Animation(this, name, Texture, 5, index));
    }

    public override void PlayAnimation(string name)
    {
        CurrentAnimation = Animations.Find(anim => anim.Name == name);
    }
}