using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CyberPunkd
{

    // TODO: Refractor frame selection code into Entity class.
    class Player : DynamicEntity
    {
        private int gender = 0;
        private int directionOffset = 0;
        private int modeOffset = 2;
        private int spriteRow = 0;

        private int SPELL_CAST = 0,
                    THRUST = 1,
                    WALK = 2,
                    SLASH =3,
                    SHOOT = 4,
                    HURT = 5,
                    SIT = 6;
        

        private Point sheetSize;
        public Player(Texture2D texture) : base(texture)
        {
            //texture = content.Load<Texture2D> (@"SpriteSheets\Female_sheet");
            
            sheetSize = new Point(texture.Width/64, texture.Height/64);
        }

       
        
       public override void draw(GameTime gameTime,  Point position)
        {
            spriteBatch.Draw(texture,Vector2.Zero,getFrameRectangle(currentFrame),Color.White);
            //throw new NotImplementedException();
        }

        public override void update(GameTime gameTime)
        {
            int oldSpriteRow = spriteRow;
            KeyboardState kb = Keyboard.GetState();
            if (kb.IsKeyDown(Keys.W) || kb.IsKeyDown(Keys.Up))
            {
                directionOffset = 0;
            }
            else if (kb.IsKeyDown(Keys.A) || kb.IsKeyDown(Keys.Left))
            {
                directionOffset = 1;
            }
            else if (kb.IsKeyDown(Keys.S) || kb.IsKeyDown(Keys.Down))
            {
                directionOffset = 2;
            }
            else if (kb.IsKeyDown(Keys.D) || kb.IsKeyDown(Keys.Right))
            {
                directionOffset = 3;
            }
            if (modeOffset != HURT)
                spriteRow = modeOffset*4 + directionOffset;
            else
                spriteRow = modeOffset*4;

            if(oldSpriteRow != spriteRow)
                setSpriteFrame(new Point(spriteRow,0));


        }
    }
}
