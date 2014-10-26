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
        private const int INVINCIBLE = 10000;
        protected int health = INVINCIBLE;
        private string state = "idle";

        protected DynamicEntity(Texture2D texture) : base (texture)
        {
            canCollide = true;

        }

        public abstract void update(GameTime gameTime);


    }
}
