using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TileGame.Lib;

namespace TileGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class TileGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Screen.Screen currentScreen;
        
        public TileGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            currentScreen = new Screen.SplashScreen(this);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            currentScreen.Initialize();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            currentScreen.LoadContent(GraphicsDevice, Content);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            currentScreen.UnloadContent();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            currentScreen.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            currentScreen.Draw(gameTime, spriteBatch);
            base.Draw(gameTime);
        }

        

        public void LoadNewScreen(Screen.Screen newScreen)
        {
            currentScreen.UnloadContent();
            currentScreen = newScreen;
            currentScreen.Initialize();
            currentScreen.LoadContent(GraphicsDevice, Content);
        }
    }
}
