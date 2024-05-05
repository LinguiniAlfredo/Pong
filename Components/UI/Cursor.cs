using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong.Components.UI;

public class Cursor : GameObject
{
    private readonly Pong _game;

    public sealed override string Name { get; set; }
    public sealed override Vector2 Position { get; set; }
    public override Texture2D Texture { get; set; }
    public override Rectangle Collision { get; set; }

    private const float Speed = 600f;

    private readonly List<Vector2> _positions = new List<Vector2>();
    private bool _inPosition = true;
    private int _direction = -1;
    
    public Cursor(Pong game, string name) : base(game, name)
    {
        _game = game;
        Name = name;
        Position = new Vector2(_game.CenterScreen.X - 200, _game.CenterScreen.Y + 50);
        
        _positions.Add(Position);
        _positions.Add(new Vector2(_positions[0].Y + 100));
    }

    public override void Update(GameTime deltaTime)
    {
        var kstate = Keyboard.GetState();

        var velocity = Vector2.Zero;

        if (!_inPosition)
        {
            velocity.Y = _direction;
        }
        else
        {
            if (kstate.IsKeyDown(Keys.W))
            {
                velocity.Y -= 1;
                _direction = -1;
                _inPosition = false;
            }
            
            if (kstate.IsKeyDown(Keys.S))
            {
                velocity.Y += 1;
                _direction = 1;
                _inPosition = false;
            }
        }
        
        Position += velocity * Speed * (float)deltaTime.ElapsedGameTime.TotalSeconds;

        foreach (var position in _positions)
        {
            if (Position.Y >= position.Y)
            {
                _inPosition = true;
            }   
        }
    }

}