using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CyberPunkd
{
    class Player : Actor
    {
        private int gender = 0;
        protected Player()
        {
            texture = Content.Load<Texture2D> (@"SpriteSheets\Female_sheet.png");
        }
        
        protected override void draw(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
