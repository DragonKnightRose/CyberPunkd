using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace CyberPunkd
{
    abstract class Actor : Entity
    {
        public Actor(ContentManager content) : base (content)
        {
            
        }
    }
}
