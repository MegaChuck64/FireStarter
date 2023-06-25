
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Engine;

public class Input
{
    public static KeyboardState KeyboardState { get; private set; }
    public static KeyboardState LastKeyboardState { get; private set; }

    public static MouseState MouseState { get; private set; }
    public static MouseState LastMouseState { get; private set; }

    public static void Update()
    {
        LastKeyboardState = KeyboardState;
        KeyboardState = Keyboard.GetState();

        LastMouseState = MouseState;
        MouseState = Mouse.GetState();
    }

    public static bool WasKeyPressed(Keys key)
    {
        return KeyboardState.IsKeyDown(key) && LastKeyboardState.IsKeyUp(key);
    }

    public static bool WasKeyReleased(Keys key)
    {
        return KeyboardState.IsKeyUp(key) && LastKeyboardState.IsKeyDown(key);
    }

    public static bool IsKeyDown(Keys key)
    {
        return KeyboardState.IsKeyDown(key);
    }

    public static bool WasLeftMousePressed()
    {
        return MouseState.LeftButton == ButtonState.Pressed && LastMouseState.LeftButton == ButtonState.Released;
    }

    public static bool WasRightMousePressed()
    {
        return MouseState.RightButton == ButtonState.Pressed && LastMouseState.RightButton == ButtonState.Released;
    }

    public static bool IsLeftMouseDown()
    {
        return MouseState.LeftButton == ButtonState.Pressed;
    }

    public static bool IsRightMouseDown()
    {
        return MouseState.RightButton == ButtonState.Pressed;
    }

    public static Vector2 GetMousePosition()
    {
        return new Vector2(MouseState.X, MouseState.Y);
    }

    public static Vector2 GetMousePositionDelta()
    {
        return new Vector2(MouseState.X - LastMouseState.X, MouseState.Y - LastMouseState.Y);
    }

    
}