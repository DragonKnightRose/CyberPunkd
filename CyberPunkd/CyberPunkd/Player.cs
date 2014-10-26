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
        
        private Point animationFrame;
        public enum States
        {
            WalkDown,
            WalkUp,
            WalkRight,
            WalkLeft,
            Idle
        }
        private States state;

        private TimeSpan lastAnimate;
        private TimeSpan timeSinceLastAnimate;
        private TimeSpan tickTime;

        

        private int SPELL_CAST = 0,
                    THRUST = 1,
                    WALK = 2,
                    SLASH =3,
                    SHOOT = 4,
                    HURT = 5,
                    SIT = 6;
        

        private Point sheetSize;
        public Player(Texture2D texture, TimeSpan tickLength) : base(texture)
        {
            //texture = content.Load<Texture2D> (@"SpriteSheets\Female_sheet");
            
            sheetSize = new Point(texture.Width/64, texture.Height/64);
            location = new[] {10, 6};
            state = States.Idle;
            lastAnimate = new TimeSpan(0);
            animationFrame = new Point(0,11);
            tickTime = tickLength;
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

        public States getState()
        {
            return state;
        }
        public void setState(States s)
        {
            state = s;
           
        }

        public void walkUp()
        {
            if (state != States.WalkUp)
            {
                state = States.WalkUp;
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
                animationFrame = new Point(x, 8);
            }
        }
        public void walkDown()
        {
            if (state != States.WalkDown)
            {
                state = States.WalkDown;
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
                animationFrame = new Point(x, 10);
            }
        }
        public void walkRight()
        {
            if (state != States.WalkRight)
            {
                state = States.WalkRight;
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
                animationFrame = new Point(x, 11);
            }
        }
        public void walkLeft()
        {
            if (state != States.WalkLeft)
            {
                state = States.WalkLeft;
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
                animationFrame = new Point(x, 9);
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
            if (timeSinceLastAnimate > new TimeSpan(5 * tickTime.Ticks))
            {
                lastAnimate = gameTime.TotalGameTime;
                Animate(gameTime);
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

        public void ParseInput(KeyboardState keys)
        {
            States movement = States.Idle;
            //player pressing up
            if (keys.IsKeyDown(Keys.W) || keys.IsKeyDown(Keys.Up))
            {
                movement = States.WalkUp;
            }
            //player pressing down
            if (keys.IsKeyDown(Keys.S) || keys.IsKeyDown(Keys.Down))
            {
                movement = States.WalkDown;
            }
            //player pressing left
            if (keys.IsKeyDown(Keys.A) || keys.IsKeyDown(Keys.Left))
            {
                movement = States.WalkLeft;
            }
            //player pressing right
            if (keys.IsKeyDown(Keys.D) || keys.IsKeyDown(Keys.Right))
            {
                movement = States.WalkRight;
            }

            state = movement;


        }

        private void Animate(GameTime gameTime)
        {
            if (state == States.WalkUp)
                walkUp();
            if (state == States.WalkDown)
                walkDown();
            if (state == States.WalkRight)
                walkRight();
            if (state == States.WalkLeft)
                walkLeft();
        }
    }
}
