using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace CyberPunkd
{
    class Door : StaticEntity
    {
        public Door(Texture2D texture) : base(texture)
        {
        }
        public Door(Texture2D texture, int x, int y)
            : base(texture)
        {
            setCoords(x,y);
        }
    }
}
