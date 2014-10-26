using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CyberPunkd
{
    abstract class Tile : Drawable
    {
        protected Tile(Texture2D texture) : base(texture)
        {
        }

        public override void draw(GameTime gameTime, Point position)
        {
            spriteBatch.Draw(texture, new Vector2(position.X, position.Y), getFrameRectangle(currentFrame),
                Color.White);
        }
    }
}
