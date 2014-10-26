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
        private int[] location;
        private string state;
        private Point animationFrame;
        private TimeSpan lastAnimate;
        private TimeSpan timeSinceLastAnimate;

        private int SPELL_CAST = 0,
                    THRUST = 1,
                    WALK = 2,
                    SLASH =3,
                    SHOOT = 4,
                    HURT = 5,
                    SIT = 6;
        

        private Point sheetSize;
        public Player(Texture2D texture, int initX, int initY) : base(texture)
        {
            //texture = content.Load<Texture2D> (@"SpriteSheets\Female_sheet");
            
            sheetSize = new Point(texture.Width/64, texture.Height/64);
            location = new[] {10, 6};
            state = "idle";
            lastAnimate = new TimeSpan(0);
            animationFrame = new Point(0,11);
        }

        public int getXCoord()
        {
            return location[0];
        }
        public int getYCoord()
        {
            return location[1];
        }

        public void setXCoord(int x)
        {
            location[0] = x;

        }
        public void setYCoord(int y)
        {
            location[1] = y;
        }

        public string getState()
        {
            return state;
        }

        public void walkUp()
        {
            if (state != "walkUp")
            {
                state = "walkUp";
                animationFrame = new Point(0,8);
            }
            else
            {
                int x = animationFrame.X;
                if (x == 8)
                {
                    x = 0;
                }
                else
                {
                    x++;
                }
                animationFrame = new Point(x, animationFrame.Y);
            }
        }
        public void walkDown()
        {
            if (state != "walkDown")
            {
                state = "walkDown";
                animationFrame = new Point(0, 10);
            }
            else
            {
                int x = animationFrame.X;
                if (x == 8)
                {
                    x = 0;
                }
                else
                {
                    x++;
                }
                animationFrame = new Point(x, animationFrame.Y);
            }
        }
        public void walkRight()
        {
            if (state != "walkRight")
            {
                state = "walkRight";
                animationFrame = new Point(0, 11);
            }
            else
            {
                int x = animationFrame.X;
                if (x == 8)
                {
                    x = 0;
                }
                else
                {
                    x++;
                }
                animationFrame = new Point(x, animationFrame.Y);
            }
        }
        public void walkLeft()
        {
            if (state != "walkLeft")
            {
                state = "walkLeft";
                animationFrame = new Point(0, 9);
            }
            else
            {
                int x = animationFrame.X;
                if (x == 8)
                {
                    x = 0;
                }
                else
                {
                    x++;
                }
                animationFrame = new Point(x, animationFrame.Y);
            }
        }
       
        
       public override void draw(GameTime gameTime,  Point position)
        {
           setSpriteFrame(animationFrame);
           spriteBatch.Draw(texture, new Vector2(position.X, position.Y), getFrameRectangle(currentFrame),
               Color.White);
            //throw new NotImplementedException();
        }

        public override void update(GameTime gameTime)
        {
            timeSinceLastAnimate = gameTime.TotalGameTime - lastAnimate;
            if (timeSinceLastAnimate > new TimeSpan(0, 0, 0, 0, 60))
            {
                lastAnimate = gameTime.TotalGameTime;
                animate(gameTime);
            }
                
            
            /*int oldSpriteRow = spriteRow;
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
                setSpriteFrame(new Point(spriteRow,0));*/


        }

        private void animate(GameTime gameTime)
        {
            if (state == "walkUp")
                walkUp();
            if (state == "walkDown")
                walkDown();
            if (state == "walkRight")
                walkRight();
            if (state == "walkLeft")
                walkLeft();
        }
    }
}
