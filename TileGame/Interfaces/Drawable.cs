using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TileGame.Interfaces
{
    interface IDrawableObject
    {

        void Update(GameTime gameTime);

        void Draw(SpriteBatch spriteBatch);

        void LoadContent(GraphicsDevice graphicsDevice, ContentManager content);

        void UnloadContent();
    }
}
