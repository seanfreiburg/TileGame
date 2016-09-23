using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TileGame
{
    class Tile
    {
        public Texture2D texture;
        public Vector2 Position;
        public int Width = 64;
        public int Height = 64;
        public bool solid;

        public Tile(Texture2D texture, Vector2 position, bool solid)
        {
            this.texture = texture;
            Position = position;
            this.solid = solid;
        }
    }

    class Map
    {
        private static int[,] tileMap = new int[4, 4] { { 1, 1, 0, 1 }, { 1, 1, 0, 0 }, { 0, 1, 0, 0 }, { 1, 0, 0, 1 } };
        private static List<int> solidTiles = new List<int> {1 }; 
        private static int tileSize = 64;

        public Texture2D[] TileTextures;
        public Vector2 Position;
        public List<Tile> tiles = new List<Tile>();

        public void Initialize(Texture2D[] textures, Vector2 position)
        {
            TileTextures = textures;
            Position = position;

            for (var x = 0; x < tileMap.GetLength(0); x++)
            {
                for (var y = 0; y < tileMap.GetLength(1); y++)
                {
                    var tilePosition = new Vector2(Position.X + x * tileSize, Position.Y + y * tileSize);
                    var solid = false;
                    if (solidTiles.Contains(tileMap[x, y])){
                        solid = true;
                    }
                    tiles.Add(new Tile(TileTextures[tileMap[x, y]], tilePosition, solid ));

                }
            }
        }



        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
                foreach (var tile in tiles)
                {
                    spriteBatch.Draw(tile.texture,tile.Position, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                }
        }

    }
}
