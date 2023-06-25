using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine;

public class Sprite : Component
{
    public Texture2D Texture { get; set; }
    public Color Tint { get; set; }    
    public Rectangle Source { get; set; }
    
    public float Layer { get; set; }

    public Sprite(GameObject go, Texture2D texture, Color tint) : base(go)
    {
        Texture = texture;
        Tint = tint;
        Source = new Rectangle(0, 0, texture.Width, texture.Height);
    }
    public override void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(
            texture: Texture,
            position: GameObject.Transform.Position.ToVector2(),
            sourceRectangle: Source,
            color: Tint,
            rotation: GameObject.Transform.Rotation,
            origin: Vector2.Zero,
            scale: GameObject.Transform.Scale,
            effects: SpriteEffects.None,
            layerDepth: Layer
            );
    }

    public override void Update(float dt)
    {
    }
}