using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Slut_Project_2.Scripts;
using Slut_Project_2.Scripts.World;

namespace Slut_Project_2
{
    public class Main : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;


        public Main()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            Globals.G_Manager = new WorldManager();
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = Globals.ScreenWidth;
            _graphics.PreferredBackBufferHeight = Globals.ScreenHeight;
            _graphics.ApplyChanges();

            base.Initialize();

            // Starts the game after the textures have been loaded.
            Globals.G_Manager.Start();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            Globals.G_Manager.AddTexture("Player", Content.Load<Texture2D>("Player"));
            Globals.G_Manager.AddTexture("Bullet", Content.Load<Texture2D>("Bullet"));
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Updates the game inputs.
            Globals.G_Mouse.Update(gameTime);
            Globals.G_Keyboard.Update(gameTime);

            // Runs the update function for the game manager.
            Globals.G_Manager.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            _spriteBatch.Begin();

            // Runs the draw function for the game manager.
            Globals.G_Manager.Draw(_spriteBatch, gameTime);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
