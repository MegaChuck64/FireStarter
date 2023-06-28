using Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using RogueSharp;
using Point = Microsoft.Xna.Framework.Point;
using Rectangle = Microsoft.Xna.Framework.Rectangle;
using System.Linq;

namespace GameCode;

public class IslandGenerator
{
    private Tile[,] tiles;
    private MainGame game;
    private IMap map;
    private Random rand;
    public void Generate(MainGame game, Point size, int? seed = null)
    {
        rand = new Random(seed ?? Environment.TickCount);
        tiles = new Tile[size.X, size.Y];
        map = new Map(tiles.GetLength(0), tiles.GetLength(1));
        this.game = game;
        CreateGround();
        CreateRiver();
        foreach (var tile in tiles)
        {
            game.GameObjects.Add(tile);
        }
    }

    private void CreateRiver()
    {
        var start = RandomShoreTile();
        var end = RandomShoreTile();
        while (end == start)
            end = RandomShoreTile();

        var pathfinder = new PathFinder(map, 0.1);
        var path = pathfinder.ShortestPath(map.GetCell(start.X, start.Y), map.GetCell(end.X, end.Y));        
        var waterTexture = game.Content.Load<Texture2D>(@"Sprites\" + "water");
        do
        {            
            var tile = path.StepForward();
            if (tile != null)
            {
                (tiles[tile.X, tile.Y].Component.First(t => t is Sprite) as Sprite).Texture = waterTexture;
            }
        } while (path.CurrentStep != path.End);

        (tiles[start.X, start.Y].Component.First(t => t is Sprite) as Sprite).Texture = waterTexture;
        (tiles[end.X, end.Y].Component.First(t => t is Sprite) as Sprite).Texture = waterTexture;
    }

    private Point RandomShoreTile()
    {
        Point p = new();
        do
        {
            p.X = rand.Next(0, tiles.GetLength(0));
            p.Y = rand.Next(0, tiles.GetLength(1));
        } while ((p.X == 0 || p.X == tiles.GetLength(0) - 1 || p.Y == 0 || p.Y == tiles.GetLength(1) - 1) == false);
        return p;
    }
    private void CreateGround()
    {
        for (int x = 0; x < tiles.GetLength(0); x++)
        {
            for (int y = 0; y < tiles.GetLength(1); y++)
            {
                var spriteName = "grass";

                if (x == 0 && y == 0)
                {
                    spriteName = "shore_top_left";
                }
                else if (x == tiles.GetLength(0)- 1 && y == 0)
                {
                    spriteName = "shore_top_right";
                }
                else if (x == 0 && y == tiles.GetLength(1) - 1)
                {
                    spriteName = "shore_bottom_left";
                }
                else if (x == tiles.GetLength(0) - 1 && y == tiles.GetLength(1) - 1)
                {
                    spriteName = "shore_bottom_right";
                }
                else if (x == tiles.GetLength(0) - 1)
                {
                    spriteName = "shore_right";
                }
                else if (y == tiles.GetLength(0) - 1)
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
                tiles[x, y] = new Tile(game, spriteName)
                {
                    Transform = new Transform(new Point(x * 32, y * 32), Vector2.One, 0f)
                };
                
                map.SetCellProperties(x, y, false, true);
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