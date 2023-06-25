using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Engine
{
    public abstract class BaseGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public Camera Camera { get; set; }
        public Input Input { get; set; }
        
        public List<GameObject> GameObjects { get; set; }
        
        public BaseGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            Camera = new Camera();
            GameObjects = new List<GameObject>();
            Input = new Input();
            
            Load();

        }

        protected override void Update(GameTime gameTime)
        {
            Input.Update();

            if (Input.WasKeyPressed(Keys.Escape))
                Exit();

            foreach (var go in GameObjects)
            {
                go.OnUpdate((float)gameTime.ElapsedGameTime.TotalSeconds);
            }

            Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(transformMatrix: Camera.Transform);


            foreach (var go in GameObjects)
            {
                go.OnDraw(_spriteBatch);
            }

            Draw(_spriteBatch);
            
            _spriteBatch.End();
            
            base.Draw(gameTime);
        }

        public abstract void Load();

        public abstract void Update(float dt);

        public abstract void Draw(SpriteBatch spriteBatch);

        
    }
}
