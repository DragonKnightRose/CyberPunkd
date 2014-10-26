using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CyberPunkd
{
    class NPC : DynamicEntity
    {
        public NPC(Texture2D texture) : base(texture)
        {
        }

        public override void update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
