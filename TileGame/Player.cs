using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using TileGame.Interfaces;
using TileGame.Lib;

namespace TileGame
{
    class Player : IDrawableObject, IFocusable
    {

        public Texture2D PlayerTexture;
        public Vector2 Position { get; set; }
        public int Width = 64;
        public int Height = 64;
        private Map Map;

        public Player()
        {
            Position = new Vector2(512, 512);
            
        }

        public void Initialize(Map map)
        {
            this.Map = map;
        }

        public void Update(GameTime gameTime)
        {
            MovePlayer();
        }

        public void LoadContent(GraphicsDevice graphicsDevice, ContentManager content)
        {
            PlayerTexture = content.Load<Texture2D>("bin\\Windows\\Graphics\\player");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(PlayerTexture, Position, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);

            // mouse cursor
            MouseState mouseState = Mouse.GetState();
            Vector2 mousePosition = mouseState.Position.ToVector2();
            spriteBatch.Draw(PlayerTexture, mousePosition, null, Color.White, 0f, Vector2.Zero, .2f, SpriteEffects.None, 0f);

        }

        public void UnloadContent()
        {

        }

        private bool isCollidingWithTiles(int playerX, int playerY)
        {
            Rectangle playerRectangle;
            Rectangle tileRectangle;
            playerRectangle = new Rectangle(playerX, playerY, this.Width, this.Height);
            foreach (var tile in Map.tiles)
            {
                if (tile.solid)
                {
                    tileRectangle = new Rectangle((int)tile.Position.X, (int)tile.Position.Y, tile.Width, tile.Height);
                    if (playerRectangle.Intersects(tileRectangle))
                    {
                        return true;
                    }
                }

            }

            return false;
        }

        private void MovePlayer()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Down) || Keyboard.GetState().IsKeyDown(Keys.S) && !isCollidingWithTiles((int)Position.X, (int)Position.Y + 2))
            {
                Position = new Vector2(Position.X, Position.Y + 2);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up) || Keyboard.GetState().IsKeyDown(Keys.W) && !isCollidingWithTiles((int)Position.X, (int)Position.Y - 2))
            {
                Position = new Vector2(Position.X, Position.Y - 2);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left) || Keyboard.GetState().IsKeyDown(Keys.A) && !isCollidingWithTiles((int)Position.X - 2, (int)Position.Y))
            {
                Position = new Vector2(Position.X -2, Position.Y);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right) || Keyboard.GetState().IsKeyDown(Keys.D) && !isCollidingWithTiles((int)Position.X + 2, (int)Position.Y))
            {
                Position = new Vector2(Position.X + 2, Position.Y);
            }
        }
    }
}
