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
    public override bool hasTexture { get; set; }

    public readonly List<GameObject> GameObjects = new();
    
    public readonly List<MenuItem> MenuItems = new();

    public int currentMenuIndex = 0;

    public bool _allowInputs = false;


    public Menu(Pong game, string name, int rows, bool hasTexture) : base(game, name, hasTexture)
    {
        _game = game;
        Name = name;
        this.hasTexture = hasTexture;
        
        Position = new Vector2(_game.CenterScreen.X, _game.CenterScreen.Y + 100);
        
        for (var i = 0; i < rows; i++)
        {
            var menuItem = new MenuItem(_game, i == 0 ? "play" : "quit", true);
            menuItem.Position = new Vector2(Position.X, (Position.Y - 40)+ (MenuItem.Spacing * i));
            MenuItems.Add(menuItem);
            GameObjects.Add(menuItem);
        }

        var cursorLeft = new Cursor(_game, "ball", this, true);
        GameObjects.Add(cursorLeft);
        var cursorRight = new Cursor(_game, "ball", this, true);
        GameObjects.Add(cursorRight);

        cursorLeft.Position = new Vector2(MenuItems[0].Position.X - 100, MenuItems[0].Position.Y);
        cursorRight.Position = new Vector2(MenuItems[0].Position.X + 100, MenuItems[0].Position.Y);
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
    
    public override void AddAnimation(string name, int index)
    {
        throw new System.NotImplementedException();
    }

    public override void PlayAnimation(string name)
    {
        throw new System.NotImplementedException();
    }
}

