using Microsoft.Xna.Framework;

namespace Engine;

public class Transform
{
    public Point Position { get; set; }

    public Vector2 Scale { get; set; }
    
    public float Rotation { get; set; }

    public Transform()
    {
        Position = Point.Zero;
        Scale = new Vector2(1,1);
        Rotation = 0f;
    }

    public Transform(Point position, Vector2 scale, float rotation)
    {
        Position = position;
        Scale = scale;
        Rotation = rotation;
    }
    
}