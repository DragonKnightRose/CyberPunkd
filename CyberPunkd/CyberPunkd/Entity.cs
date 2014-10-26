<<<<<<< Updated upstream
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace CyberPunkd
{
    abstract class Entity : Drawable
    {
        protected Entity(Texture2D texture) : base(texture)
        {
        }
    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CyberPunkd
{
    abstract class Entity : Drawable
    {
        //autoAnimate controls whether under the default draw(), we automatically cycle through
        //the animations on a row. If you set this to true, make sure that animationSequenceLength[]
        //is set.
        //TODO: Implement this.
        protected Boolean autoAnimate = false;
        //animationSequenceLength is used to to represent how many animation frames are in each row.
        protected int[] animationSequenceLength;

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
>>>>>>> Stashed changes
