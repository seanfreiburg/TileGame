using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace TileGame.Screen
{
    public class Screen
    {
        public TileGame game;

        public virtual void Initialize() {

        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

        }

        public virtual void LoadContent(GraphicsDevice graphicsDevice, ContentManager content)
        {

        }

        public virtual void UnloadContent()
        {

        }

    }
}
