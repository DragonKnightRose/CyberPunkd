using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace CyberPunkd
{
    abstract class Entity
    {
        protected Texture2D texture;
        private Point frameSize;
        private Point currentFrame;
        private Point sheetSize;

        protected Entity(ContentManager content)
        {
            frameSize = new Point(64, 64);
            currentFrame = new Point(0, 0);
        }

        public abstract void draw(GameTime gameTime, SpriteBatch spriteBatch);

    }


}
