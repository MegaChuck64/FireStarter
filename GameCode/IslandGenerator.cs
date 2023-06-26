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
                var spriteName = "grass";


                if (x == 0 && y == 0)
                {
                    spriteName = "shore_top_left";
                }
                else if (x == size.X - 1 && y == 0)
                {
                    spriteName = "shore_top_right";
                }
                else if (x == 0 && y == size.Y - 1)
                {
                    spriteName = "shore_bottom_left";
                }
                else if (x == size.X - 1 && y == size.Y - 1)
                {
                    spriteName = "shore_bottom_right";
                }
                else if (x == size.X - 1)
                {
                    spriteName = "shore_right";
                }
                else if (y == size.X - 1)
                {
                    spriteName = "shore_bottom";
                }
                else if (y == 0)
                {
                    spriteName = "shore_top";
                }
                else if (x == 0)
                {
                    spriteName = "shore_left";
                }

                game.GameObjects.Add(new Tile(game, spriteName)
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

    public Tile(MainGame game, string sprite) : base(game)
    {
        var txt = game.Content.Load<Texture2D>(@"Sprites\" + sprite);
        Component.Add(new Sprite(this, txt, Color.White));
        
    }

    public override void Draw(SpriteBatch spriteBatch)
    {

    }

    public override void Update(float dt)
    {

    } 
}