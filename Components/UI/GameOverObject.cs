using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong.Components.UI;

public class GameOverObject : GameObject
{
    private readonly Pong _game;

    public sealed override string Name { get; set; }
    public override Vector2 Position { get; set; }
    public override Texture2D Texture { get; set; }
    public override Rectangle Collision { get; set; }
    public override float Depth { get; set; }
    public override bool hasTexture { get; set; }

    public bool _hasTexture;
    
    
    public GameOverObject(Pong game, string name, bool hasTexture) : base(game, name, hasTexture)
    {
        _game = game;
        Name = name;
        _hasTexture = hasTexture;
    }
   
    public override void AddAnimation(string name, int index)
    {
        throw new System.NotImplementedException();
    }

    public override void PlayAnimation(string name)
    {
        throw new System.NotImplementedException();
    }
    
    public override void Update(GameTime deltaTime)
    {
        var kstate = Keyboard.GetState();

        if (kstate.IsKeyDown(Keys.Enter))
        {
            _game.SetCurrentScene(_game.Scenes.Find(s => s.Name == "title"));
        }
    }
}