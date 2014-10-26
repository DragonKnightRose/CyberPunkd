using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace CyberPunkd
{
    abstract class Drawable
    {
        protected Texture2D texture;
        protected static SpriteBatch spriteBatch;
        //Points used in selecting a particular frame
        protected const static Point frameSize = new Point(64,64);
        protected Point currentFrame;
        protected Point sheetSize;

        public Boolean canCollide;

        protected Point currentPosition;
        protected int orientation = 0;

        protected Drawable(Texture2D texture)
        {
            this.texture = texture; 
           
            currentFrame = new Point(0, 0);
        }

        public abstract void draw(GameTime gameTime, Point position);

        public void draw(GameTime gameTime, int x, int y)
        {
            draw(gameTime, new Point(x,y));
        }

        protected Rectangle getFrameRectangle(Point select)
        {
            return new Rectangle(select.X * frameSize.X,
                select.Y * frameSize.Y,
                frameSize.X, frameSize.Y);
        }

    }


}
