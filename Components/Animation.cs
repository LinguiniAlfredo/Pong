using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pong.Components;

public class Animation
{
    public readonly string Name;
    public Rectangle Stencil;
    public readonly int FrameWidth;
    private readonly int FrameHeight;
    public Animation(GameObject go, string name, Texture2D texture, int frames, int index)
    {
        Name = name;
        FrameWidth = texture.Width / frames;
        FrameHeight = texture.Height / 1;
        Stencil = new Rectangle((int)go.Position.X, (int)go.Position.Y, FrameWidth, texture.Height);
    }
}