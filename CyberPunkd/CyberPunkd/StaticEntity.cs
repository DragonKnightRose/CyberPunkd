using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace CyberPunkd
{
    class StaticEntity : Entity
    {
        public StaticEntity(Texture2D texture) : base(texture)
        {
            canCollide = false;
        }
        
        
    }
}
