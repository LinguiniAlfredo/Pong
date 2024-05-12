using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Pong.Components.UI;

namespace Pong.Components.Scenes;

public class GameOver : Scene
{
    public sealed override Pong Game { get; set; }
    public sealed override List<GameObject> GameObjects { get; set; }
    public sealed override string Name { get; set; }
    public sealed override int Index { get; set; }
    
    public GameOver(Pong game, int index, string name) : base(game, index, name)
    {
        Game = game;
        Index = index;
        Name = name;
        
        GameObjects = new List<GameObject>();

        var gameOver = new GameOverObject(Game, "gameover", false);
        GameObjects.Add(gameOver);
    }

    public override void AddGameObject(GameObject obj)
    {
        throw new System.NotImplementedException();
    }
    
}