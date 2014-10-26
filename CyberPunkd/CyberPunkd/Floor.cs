using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CyberPunkd
{
    class Floor : Tile
    {
        
        public Floor(Texture2D texture) : base(texture)
        {
            canCollide = true;
        }

        public override void draw(GameTime gameTime, Point position)
        {
            throw new NotImplementedException();
        }
    }
}
