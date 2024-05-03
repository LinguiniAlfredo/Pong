using System.Collections.Generic;
using System.Diagnostics;

namespace Pong.Components.Scenes;

public class Title : Scene
{
    public sealed override Pong Game { get; set; }
    public sealed override List<GameObject> GameObjects { get; set; }
    public sealed override string Name { get; set; }   
    public sealed override int Index { get; set; }
    
    public Title(Pong game, int index, string name) : base(game, index, name)
    {
        Game = game;
        Index = index;
        Name = name;
        
        GameObjects = new List<GameObject>();
        Debug.WriteLine("title screen");
    }

    public override void AddGameObject(GameObject obj)
    {
        throw new System.NotImplementedException();
    }
}