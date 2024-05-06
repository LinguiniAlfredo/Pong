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
    
    public readonly List<MenuItem> MenuItems = new();

    public int currentMenuIndex = 0;

    public bool _allowInputs = false;


    public Menu(Pong game, string name, int rows) : base(game, name)
    {
        _game = game;
        Name = name;
        
        Position = new Vector2(_game.CenterScreen.X, _game.CenterScreen.Y + 100);
        
        for (var i = 0; i < rows; i++)
        {
            var menuItem = new MenuItem(_game, "");
            menuItem.Position = new Vector2(Position.X, (Position.Y - 40)+ (MenuItem.Spacing * i));
            MenuItems.Add(menuItem);
            // GameObjects.Add(menuItem);
        }
        
        var cursor = new Cursor(_game, "ball", this);
        GameObjects.Add(cursor);

        cursor.Position = new Vector2(MenuItems[0].Position.X - 160, MenuItems[0].Position.Y);
    }

    public override void Update(GameTime deltaTime)
    {
        var kstate = Keyboard.GetState();

        if (kstate.IsKeyDown(Keys.Enter) && currentMenuIndex == 0)
        {
            _game.SetCurrentScene(_game.Scenes.Find(s => s.Name == "level1"));
            _game.Started = true;
        }       
        if (kstate.IsKeyDown(Keys.Enter) && currentMenuIndex == 1)
        {
            _game.Exit();
        }
        
    }
}

