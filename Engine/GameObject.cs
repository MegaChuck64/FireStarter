using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Engine;

public abstract class GameObject
{
    public abstract Rectangle Bounds { get; }    
    
    public Transform Transform { get; set; }
    
    public List<Component> Component { get; set; }

    public BaseGame Game { get; set; }
    public GameObject(BaseGame game)
    {
        Game = game;
        Transform = new Transform();
        Component = new List<Component>();
    }
    
    public void OnUpdate(float dt)
    {
        foreach (var component in Component)
        {
            component.Update(dt);
        }

        Update(dt);
    }

    public void OnDraw(SpriteBatch spriteBatch)
    {
        foreach (var component in Component)
        {
            component.Draw(spriteBatch);
        }

        Draw(spriteBatch);
    }
    
    public abstract void Update(float dt);
    public abstract void Draw(SpriteBatch spriteBatch);

    public bool IsColliding(GameObject other)
    {
        return Bounds.Intersects(other.Bounds);
    }

    public bool IsColliding(Rectangle other)
    {
        return Bounds.Intersects(other);
    }

    public bool IsColliding(Vector2 point)
    {
        return Bounds.Contains(point);
    }

    public bool IsColliding(Point point)
    {
        return Bounds.Contains(point);
    }
            
}

public abstract class Component
{
    public GameObject GameObject { get; set; }

    public Component(GameObject gameObject)
    {
        GameObject = gameObject;
    }
    public abstract void Update(float dt);
    public abstract void Draw(SpriteBatch spriteBatch);
}
