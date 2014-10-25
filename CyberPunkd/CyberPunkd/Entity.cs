using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CyberPunkd
{
    abstract class Entity
    {
        protected Texture2D texture;
        protected abstract void draw(GameTime gameTime);

    }


}
