using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CyberPunkd
{
    class Wall : Tile
    {
        public Wall(Texture2D texture) : base(texture)
        {
            canCollide = true;
        }


    }
}
