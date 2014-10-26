using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace CyberPunkd
{
    abstract class Actor : Drawable
    {
        public Actor(Texture2D texture) : base (texture)
        {
            
        }


    }
}
