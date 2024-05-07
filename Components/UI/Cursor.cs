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
    private readonly Menu _menu;

    public sealed override string Name { get; set; }
    public sealed override Vector2 Position { get; set; }
    public override Texture2D Texture { get; set; }
    public override Rectangle Collision { get; set; }
    public override float Depth { get; set; }

    private const float Speed = 1500f;
    
    private readonly List<Vector2> _menuPositions = new List<Vector2>();
    
    private Vector2 _targetPosition;
    
    private bool _inPosition = true;
    
    private int _direction = -1;
    
    
    public Cursor(Pong game, string name, Menu menu) : base(game, name)
    {
        _game = game;
        _menu = menu;
        Name = name;

        foreach (var item in _menu.MenuItems)
        {
            _menuPositions.Add(item.Position);
        }
        _menu.currentMenuIndex = 0;
    }
    
    public override void Update(GameTime deltaTime)
    {
        var kstate = Keyboard.GetState();
        var velocity = Vector2.Zero;
        
        
        switch (_inPosition)
        {
            case false:
                velocity.Y = _direction;
                break;
            case true when kstate.IsKeyUp(Keys.W) && kstate.IsKeyUp(Keys.S):
                _menu._allowInputs = true;
                break;
        }

        if (_menu._allowInputs)
        {
            if (kstate.IsKeyDown(Keys.W))
            {
                if (_menu.currentMenuIndex == 0) { return; }

                _inPosition = false;
                _menu._allowInputs = false;
                _targetPosition = _menuPositions[_menu.currentMenuIndex - 1];
                velocity.Y -= 1;
                _direction = -1;
          
            }
        
            if (kstate.IsKeyDown(Keys.S))
            {
                if (_menu.currentMenuIndex == _menuPositions.Count - 1){ return; }
                
                _inPosition = false;
                _menu._allowInputs = false;
                _targetPosition = _menuPositions[_menu.currentMenuIndex + 1];
                velocity.Y += 1;
                _direction = 1;
            }
        }
       
        
        
        Position += velocity * Speed * (float)deltaTime.ElapsedGameTime.TotalSeconds;

        switch (_direction)
        {
            case 1:
            {
                if (Position.Y >= _targetPosition.Y)
                {
                    _menu.currentMenuIndex = _menuPositions.IndexOf(_targetPosition);
                    _inPosition = true;
                    _direction = 0;
                    Debug.WriteLine("target: " + _targetPosition);
                    Debug.WriteLine("actual: " + Position);
                }

                break;
            }
            case -1:
            {
                if (Position.Y <= _targetPosition.Y)
                {
                    _menu.currentMenuIndex = _menuPositions.IndexOf(_targetPosition);
                    _inPosition = true;
                    _direction = 0;
                    Debug.WriteLine("target: " + _targetPosition);
                    Debug.WriteLine("actual: " + Position);
                }

                break;
            }
        }
        
        
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