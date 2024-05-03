using System.Collections.Generic;
namespace Pong.Components;

public abstract class Scene
{
    public abstract Pong Game { get; set; }
    public abstract List<GameObject> GameObjects { get; set; }
    public abstract string Name {get; set; }
    public abstract int Index { get; set; }
    

    public Scene(Pong game, int index, string name)
    {
    }
    
    public abstract void AddGameObject(GameObject obj);
}