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
            canCollide = false;
        }

     
    }
}
