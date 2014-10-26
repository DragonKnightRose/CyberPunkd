using System;
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
