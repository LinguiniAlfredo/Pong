using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pong.Components.UI;

public class MenuItem : GameObject
{
    private readonly Pong _game;

    public sealed override string Name { get; set; }
    public override Vector2 Position { get; set; }
    public override Texture2D Texture { get; set; }
    public override Rectangle Collision { get; set; }
    public override float Depth { get; set; }

    public const float Spacing = 50f;
    
    public MenuItem(Pong game, string name) : base(game, name)
    {
        _game = game;
        Name = name;
    }

}