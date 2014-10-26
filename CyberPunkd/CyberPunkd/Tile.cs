using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace CyberPunkd
{
    abstract class Tile : Drawable
    {
        protected Tile(Texture2D texture) : base(texture)
        {
        }
    }
}
