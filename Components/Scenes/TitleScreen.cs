using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Pong.Components.UI;

namespace Pong.Components.Scenes;

public class TitleScreen : Scene
{
    public sealed override Pong Game { get; set; }
    public sealed override List<GameObject> GameObjects { get; set; }
    public sealed override string Name { get; set; }   
    public sealed override int Index { get; set; }
    
    
    public TitleScreen(Pong game, int index, string name) : base(game, index, name)
    {
        Game = game;
        Index = index;
        Name = name;
        
        GameObjects = new List<GameObject>();

        var title = new Title(Game, "title");
        title.Position = new Vector2(Game.CenterScreen.X, Game.CenterScreen.Y - 100);
        GameObjects.Add(title);
        
        var cursor = new Cursor(Game, "cursor");
        GameObjects.Add(cursor);

        // MenuItem menuItem = new MenuItem(Game, "title");
        
    }

    public override void AddGameObject(GameObject obj)
    {
        throw new System.NotImplementedException();
    }
}