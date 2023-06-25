using Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameCode
{
    public class MainGame : BaseGame
    {
        public MainGame()
        {            
        }
        public override void Load()
        {
            var island = new IslandGenerator();
            island.Generate(this, new Vector2(10, 10));
        }
        
        public override void Update(float dt)
        {
            var mouse = Input.GetMousePosition();
            Camera.Follow(mouse, new Vector2(400, 240));        
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            
        }

    }
}