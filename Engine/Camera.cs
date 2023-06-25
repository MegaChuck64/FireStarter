using Microsoft.Xna.Framework;

namespace Engine;

public class Camera
{
    public Matrix Transform { get; private set; }

    public void Follow(Vector2 target, Vector2 offset)
    {
        var position = Matrix.CreateTranslation(
          -target.X,
          -target.Y,
          0);

        var off = Matrix.CreateTranslation(offset.X, offset.Y, 0);

        Transform = position * off;
    }
}
