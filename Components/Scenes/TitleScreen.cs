using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Pong.Components.GameObjects;
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
        
        var menu = new Menu(Game, "mainmenu", 2);
        
        foreach (GameObject obj in menu.GameObjects)
        {
            obj.Depth = 1f;
            GameObjects.Add(obj);
        }
        GameObjects.Add(menu);
    }

    public override void AddGameObject(GameObject obj)
    {
        throw new System.NotImplementedException();
    }
}