using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CyberPunkd
{
    abstract class Entity : Drawable
    {

        protected Entity(Texture2D texture) : base(texture)
        {
        }

        public override void draw(GameTime gameTime, Point position)
        {
            spriteBatch.Draw(texture, new Vector2(position.X, position.Y), 
                sourceRectangle: getFrameRectangle(currentFrame), color: Color.White);
        }

        public void update(GameTime gameTime)
        {
            
        }

        public void onCollision(Drawable drawable)
        {
            
        }

        // TODO: Question: Should the player be able to interact?
        public void onTouch()
        {
            
        }

        
    }
}
