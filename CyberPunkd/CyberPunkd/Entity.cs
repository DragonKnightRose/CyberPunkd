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
        protected Point frameSize;
        protected Point currentFrame;
        protected Point sheetSize;
        protected Point currentPosition;
        protected int orientation = 0;

        protected Entity(Texture2D texture)
        {
            this.texture = texture; 
            frameSize = new Point(64, 64);
            currentFrame = new Point(0, 0);
        }

        public abstract void draw(GameTime gameTime, SpriteBatch spriteBatch, Point position);

        protected Rectangle getFrameRectangle(Point select)
        {
            return new Rectangle(select.X * frameSize.X,
                select.Y * frameSize.Y,
                frameSize.X, frameSize.Y);
        }

    }


}
