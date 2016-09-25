using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace TileGame.Screen
{
    class SplashScreen: Screen
    {
        private int gameTimeDisplayed = 0;
        private int gameTimeToShow = 2000;
        private Texture2D logoTexture;
        public Vector2 Position;


        public SplashScreen(TileGame game)
        {
            this.game = game;
        }

        public override void Initialize()
        {

        }

        public override void Update(GameTime gameTime)
        {
            gameTimeDisplayed += gameTime.ElapsedGameTime.Milliseconds;
            if (gameTimeDisplayed > gameTimeToShow)
            {
                game.LoadNewScreen(new GameScreen(game));
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(logoTexture, Position, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            spriteBatch.End();
        }

        public override void LoadContent(GraphicsDevice graphicsDevice, ContentManager content)
        {
            logoTexture = content.Load<Texture2D>("bin\\Windows\\Graphics\\logo");
            Position = new Vector2(graphicsDevice.Viewport.TitleSafeArea.X + graphicsDevice.Viewport.TitleSafeArea.Width / 2, graphicsDevice.Viewport.TitleSafeArea.Y + graphicsDevice.Viewport.TitleSafeArea.Height / 2);
        }

        public override void UnloadContent()
        {

        }
    }
}
