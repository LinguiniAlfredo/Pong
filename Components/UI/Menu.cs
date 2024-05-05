using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong.Components.UI;

public class Menu : GameObject
{
    private readonly Pong _game;
    public sealed override string Name { get; set; }
    public sealed override Vector2 Position { get; set; }
    public override Texture2D Texture { get; set; }
    public override Rectangle Collision { get; set; }
    public override float Depth { get; set; }

    public readonly List<GameObject> GameObjects = new();
    
    private readonly List<MenuItem> MenuItems = new(); 

    public Menu(Pong game, string name, int rows) : base(game, name)
    {
        _game = game;
        Name = name;
        
        Position = new Vector2(_game.CenterScreen.X, _game.CenterScreen.Y + 100);
        
        for (var i = 0; i < rows; i++)
        {
            var menuItem = new MenuItem(_game, "ball");
            menuItem.Position = new Vector2(Position.X, (Position.Y - 50)+ (MenuItem.Spacing * i));
            MenuItems.Add(menuItem);
            GameObjects.Add(menuItem);
        }
        
        var cursor = new Cursor(_game, "cursor", MenuItems);
        GameObjects.Add(cursor);

        cursor.Position = new Vector2(MenuItems[0].Position.X - 160, MenuItems[0].Position.Y);
    }
}

