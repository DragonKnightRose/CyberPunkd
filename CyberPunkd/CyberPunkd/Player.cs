using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace CyberPunkd
{

    // TODO: Refractor frame selection code into Entity class.
    class Player : Actor
    {
        private int gender = 0;

        private Point sheetSize;
        public Player(ContentManager content) : base(content)
        {
            texture = content.Load<Texture2D> (@"SpriteSheets\Female_sheet");
            
            sheetSize = new Point(texture.Width/64, texture.Height/64);
        }

       
        
       public override void draw(GameTime gameTime,  Point position)
        {
            spriteBatch.Draw(texture,Vector2.Zero,getFrameRectangle(currentFrame),Color.White);
            //throw new NotImplementedException();
        }
    }
}
