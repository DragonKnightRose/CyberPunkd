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
        private string name;

        public NPC(Texture2D texture) : base(texture)
        {
        }

        public NPC(Texture2D texture, string name) : base(texture)
        {
            this.name = name;
        }

        public override void update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
