using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Pong.Components.Scenes;

public class Level1 : Scene
{
    public sealed override Pong Game { get; set; }
    public sealed override List<GameObject> GameObjects { get; set; }
    public sealed override int Index { get; set; }
    public sealed override string Name { get; set; }

    public Level1(Pong game, int index, string name) : base(game, index, name)
    {
        Game = game;
        Index = index;
        Name = name;

        GameObjects = new List<GameObject>();
        
        Ball ball = new(Game, "ball");
        ball.Position = Game.CenterScreen;
        GameObjects.Add(ball);
        
        Paddle paddle1 = new(Game, "paddle_1");
        paddle1.Position = new Vector2(paddle1.Spacing, Game.Height/2);
        GameObjects.Add(paddle1);
        
        Paddle paddle2 = new(Game, "paddle_2");
        paddle2.Position = new Vector2(Game.Width - paddle1.Spacing, Game.Height/2);
        GameObjects.Add(paddle2);
    }
    
    public override void AddGameObject(GameObject obj)
    {
        GameObjects.Add(obj);
    }
}