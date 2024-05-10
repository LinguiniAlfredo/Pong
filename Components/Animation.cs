using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pong.Components;

public class Animation
{
    public readonly string Name;
    public Rectangle Stencil;
    public readonly int FrameWidth;
    private readonly int FrameHeight;
    private int FrameIndex = 0;
    private int TotalFrames;
    private Vector2 StartPosition;
    
    public Animation(GameObject go, string name, Texture2D texture, int frames, int index)
    {
        var halfWidth = texture.Width / 2;
        var halfHeight = texture.Height / 2;
        
        Name = name;
        TotalFrames = frames;
        FrameWidth = texture.Width / frames;
        FrameHeight = texture.Height / 1;
        StartPosition = new Vector2(go.Position.X , go.Position.Y);
        Stencil = new Rectangle((int)StartPosition.X, (int)StartPosition.Y, FrameWidth ,texture.Height);
    }

    public void CycleAnimation()
    {
        if (FrameIndex < TotalFrames)
        {
            Stencil.X += FrameWidth;
            FrameIndex++;
        }
        else
        {
            Stencil.X = (int)StartPosition.X;
            FrameIndex = 0;
        }
    }
}