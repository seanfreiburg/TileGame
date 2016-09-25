
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using TileGame.Lib;

namespace TileGame.Screen
{
    class GameScreen : Screen
    {
        Player player;
        Map map;
        Camera2D camera;

        FrameCounter frameCounter;
        SpriteFont fpsFont;

        public GameScreen(TileGame game)
        {
            camera = new Camera2D(game);
            map = new Map();
            player = new Player();
            frameCounter = new FrameCounter();
        }

        public override void Initialize()
        {
            map.Initialize(camera);
            player.Initialize(map);
            camera.Initialize(player);
        }

        public override void Update(GameTime gameTime)
        {
            player.Update(gameTime);
            map.Update(gameTime);
            camera.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            string fps = getFps(gameTime);
            
            spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, camera.Transform);
            map.Draw(spriteBatch);
            player.Draw(spriteBatch);
            
            spriteBatch.DrawString(fpsFont, fps, camera.CameraOrigin , Color.Black);
            spriteBatch.End();  
        }

        public override void LoadContent(GraphicsDevice graphicsDevice, ContentManager content)
        {
            player.LoadContent(graphicsDevice, content);
            map.LoadContent(graphicsDevice, content);
            fpsFont = content.Load<SpriteFont>("bin\\Windows\\Fonts\\Fps");
        }

        public override void UnloadContent()
        {

        }

        private string getFps(GameTime gameTime)
        {
            var deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            frameCounter.Update(deltaTime);
            var fps = string.Format("FPS: {0}", (int)frameCounter.AverageFramesPerSecond);
            return fps;
        }
    }
}
