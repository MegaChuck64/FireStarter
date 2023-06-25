using Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameCode;

public class IslandGenerator
{
    public void Generate(MainGame game, Vector2 size)
    {
        for (int x = 0; x < size.X; x++)
        {
            for (int y = 0; y < size.Y; y++)
            {
                game.GameObjects.Add(new Tile(game)
                {
                    Transform = new Transform(new Point(x * 32,y * 32), Vector2.One, 0f)
                });                
            }
        }
    }
}

public class Tile : GameObject
{
    public override Rectangle Bounds =>
        new(Transform.Position, new Point(32, 32));

    public Tile(MainGame game) : base(game)
    {
        var txt = game.Content.Load<Texture2D>(@"Sprites\grass");
        Component.Add(new Sprite(this, txt, Color.White));
        
    }

    public override void Draw(SpriteBatch spriteBatch)
    {

    }

    public override void Update(float dt)
    {

    } 
}