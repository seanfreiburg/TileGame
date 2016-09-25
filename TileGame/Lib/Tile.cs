using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TileGame.Lib
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
}
