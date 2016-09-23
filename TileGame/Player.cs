using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TileGame
{
    class Player
    {
        // Animation representing the player

        public Texture2D PlayerTexture;
        public Vector2 Position;
        public int Width = 64;
        public int Height = 64;
        private Map Map;

        public void Initialize(Texture2D texture, Vector2 position, Map map)
        {
            PlayerTexture = texture;
            Position = position;
            this.Map = map;
        }

        public void Update()
        {
            MovePlayer();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(PlayerTexture, Position, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
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
                Position.Y = Position.Y + 2;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up) || Keyboard.GetState().IsKeyDown(Keys.W) && !isCollidingWithTiles((int)Position.X, (int)Position.Y - 2))
            {
                Position.Y = Position.Y - 2;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left) || Keyboard.GetState().IsKeyDown(Keys.A) && !isCollidingWithTiles((int)Position.X - 2, (int)Position.Y))
            {
                Position.X = Position.X - 2;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right) || Keyboard.GetState().IsKeyDown(Keys.D) && !isCollidingWithTiles((int)Position.X + 2, (int)Position.Y))
            {
                Position.X = Position.X + 2;
            }
        }
    }
}
