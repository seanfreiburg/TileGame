using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using TileGame.Interfaces;
using TileGame.Lib;

namespace TileGame
{
    class Map : IDrawableObject
    {
        private static int[,] tileMap = new int[4, 4] { { 1, 1, 0, 1 }, { 1, 1, 0, 0 }, { 0, 1, 0, 0 }, { 1, 0, 0, 1 } };
        private static List<int> solidTiles = new List<int> { 1 };
        private static int tileSize = 64;
        private Camera2D camera;

        public Texture2D[] TileTextures;
        public Vector2 Position;
        public List<Lib.Tile> tiles = new List<Lib.Tile>();

        public Map()
        {
            Position = new Vector2(0, 0);
        }

        public void Initialize(Camera2D camera)
        {
            this.camera = camera;
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var tile in tiles)
            {
                if (camera.IsInView(tile.Position, tile.texture))
                {
                    spriteBatch.Draw(tile.texture, tile.Position, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                } 
            }
        }

        public void Update(GameTime gameTime)
        {
            //throw new NotImplementedException();
        }

        public void LoadContent(GraphicsDevice graphicsDevice, ContentManager content)
        {
            TileTextures = new Texture2D[] { content.Load<Texture2D>("bin\\Windows\\Graphics\\tile1"), content.Load<Texture2D>("bin\\Windows\\Graphics\\tile2") };
            LoadTiles();
        }

        public void UnloadContent()
        {
            //throw new NotImplementedException();
        }

        private void LoadTiles()
        {
            for (var x = 0; x < tileMap.GetLength(0); x++)
            {
                for (var y = 0; y < tileMap.GetLength(1); y++)
                {
                    var tilePosition = new Vector2(Position.X + x * tileSize, Position.Y + y * tileSize);
                    var solid = false;
                    if (solidTiles.Contains(tileMap[x, y]))
                    {
                        solid = true;
                    }
                    tiles.Add(new Lib.Tile(TileTextures[tileMap[x, y]], tilePosition, solid));

                }
            }
        }
    }
}
