using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
    public override float Depth { get; set; }

    private const float Speed = 500f;
    
    private readonly List<Vector2> _menuPositions = new List<Vector2>();
    
    private int _currentMenuIndex;
    
    private Vector2 _targetPosition;
    
    private bool _inPosition = true;
    
    private int _direction = -1;
    
    public Cursor(Pong game, string name, List<MenuItem> menuItems) : base(game, name)
    {
        _game = game;
        Name = name;

        foreach (var item in menuItems)
        {
            _menuPositions.Add(item.Position);
        }
        _currentMenuIndex = 0;
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
                if (_currentMenuIndex == 0)
                {
                    _inPosition = false;
                    _targetPosition = _menuPositions.Last();
                    velocity.Y += 1;
                    _direction = 1;
                }
                else
                {
                    _inPosition = false;
                    _targetPosition = _menuPositions[_currentMenuIndex - 1];
                    velocity.Y -= 1;
                    _direction = -1;
                }
            }
            
            if (kstate.IsKeyDown(Keys.S))
            {
                if (_currentMenuIndex == _menuPositions.Count - 1)
                {
                    _inPosition = false;
                    _targetPosition = _menuPositions[0];
                    velocity.Y -= 1;
                    _direction = -1;
                }
                else
                {
                    _inPosition = false;
                    _targetPosition = _menuPositions[_currentMenuIndex + 1];
                    velocity.Y += 1;
                    _direction = 1;
                }
            }
        }
        
        Position += velocity * Speed * (float)deltaTime.ElapsedGameTime.TotalSeconds;

        if (_direction == 1)
        {
            if (Position.Y >= _targetPosition.Y)
            {
                _currentMenuIndex = _menuPositions.IndexOf(_targetPosition);
                _inPosition = true;
                _direction = 0;
                Debug.WriteLine("target: " + _targetPosition);
                Debug.WriteLine("actual: " + Position);
            }
        }
        else if (_direction == -1)
        {
            if (Position.Y <= _targetPosition.Y)
            {
                _currentMenuIndex = _menuPositions.IndexOf(_targetPosition);
                _inPosition = true;
                _direction = 0;
                Debug.WriteLine("target: " + _targetPosition);
                Debug.WriteLine("actual: " + Position);
            }
        }
        
        
    }
    

}