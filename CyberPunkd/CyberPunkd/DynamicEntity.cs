using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace CyberPunkd
{
    abstract class DynamicEntity : Entity
    {
        public DynamicEntity(Texture2D texture) : base (texture)
        {
            canCollide = true;

        }



        
    }
}
