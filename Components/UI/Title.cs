using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pong.Components.UI;

public class Title : GameObject     // TODO - Create UIObject class with less shit
{
    private readonly Pong _game;

    public sealed override string Name { get; set; }
    public override Vector2 Position { get; set; }
    public override Texture2D Texture { get; set; }
    public override Rectangle Collision { get; set; }
    public override float Depth { get; set; }
    public override bool hasTexture { get; set; }

    public Title(Pong game, string name, bool hasTexture) : base(game, name, hasTexture)
    {
        _game = game;
        Name = name;
        this.hasTexture = hasTexture;
    }
    
    public override void AddAnimation(string name, int index)
    {
        throw new System.NotImplementedException();
    }

    public override void PlayAnimation(string name)
    {
        throw new System.NotImplementedException();
    }

}