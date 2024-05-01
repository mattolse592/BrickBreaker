using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BrickBreaker
{
    public class Ball
    {
        public int x, y, xSpeed, ySpeed, size, defaultSpeedX, defaultSpeedY;
        public Color colour;
        public List<Modifier> modifiers = new List<Modifier>();

        public static Random rand = new Random();

        public Ball(int _x, int _y, int _xSpeed, int _ySpeed, int _ballSize)
        {
            x = _x;
            y = _y;
            xSpeed = _xSpeed;
            ySpeed = _ySpeed;

            defaultSpeedX = Math.Abs(_xSpeed);
            defaultSpeedY = Math.Abs(_ySpeed);

           
 
            size = _ballSize;

        }

        public Ball(int _x, int _y, int _xSpeed, int _ySpeed, int _ballSize, List<Modifier> _modifiers)
        {
            x = _x;
            y = _y;
            xSpeed = _xSpeed;
            ySpeed = _ySpeed;

            defaultSpeedX = Math.Abs(_xSpeed);
            defaultSpeedY = Math.Abs(_ySpeed);

            modifiers = _modifiers;

            size = _ballSize;

        }

        public void Move()
        {

            if(xSpeed < 0 )
            {
                xSpeed = -Math.Max(0,(defaultSpeedX + GameScreen.speedModBX));
            } else

           
            {
                xSpeed = Math.Max(0, (defaultSpeedX + GameScreen.speedModBX));
            }
            if (ySpeed < 0)
            {
                ySpeed = -Math.Max(0, (defaultSpeedY + GameScreen.speedModBY));
            }
            else
            {
                ySpeed = Math.Max(0, (defaultSpeedY + GameScreen.speedModBY));
            }

            x = x + xSpeed;
            y = y + ySpeed;
        }

        public bool BlockCollision(Block b)
        {
            Rectangle blockRec = new Rectangle(b.x, b.y, b.width, b.height);
            Rectangle ballRec = new Rectangle(x, y, size, size);

            if (ballRec.IntersectsWith(blockRec))
            {
                ySpeed *= -1;

                if (ballRec.X + size < blockRec.X + 10 || ballRec.X + 4 > b.x + blockRec.Width)
                {
                    xSpeed *= -1;
                    ySpeed *= -1;
                }
            }

            return blockRec.IntersectsWith(ballRec);
        }

        public void PaddleCollision(Paddle p)
        {
            Rectangle ballRec = new Rectangle(x, y, size, size);
            Rectangle paddleRec = new Rectangle(p.x, p.y, p.width, p.height);

            if (ballRec.IntersectsWith(paddleRec))
            {
                ySpeed *= -1;


                if (x + size <= p.x + 7)
                {
                    xSpeed *= -1;
                    x -= 8;
                    defaultSpeedY = 3;
                    defaultSpeedX = 20;
                }

                if (x >= p.x + p.width - 7)
                {
                    x += 8;
                    xSpeed *= -1;
                    defaultSpeedY = 3; 
                    defaultSpeedX = 20;
                }
            }

        }

        public void WallCollision(UserControl UC)
        {
            // Collision with left wall
            if (x <= 0)
            {
                xSpeed *= -1;
            }
            // Collision with right wall

            if (x >= (950 - size)) //UC.Width

            {
                xSpeed *= -1;
            }
            // Collision with top wall
            if (y <= 2)
            {
                ySpeed *= -1;
            }
        }

        public bool BottomCollision(UserControl UC)
        {
            Boolean didCollide = false;

            if (y >= UC.Height)
            {
                didCollide = true;
            }

            return didCollide;
        }

        public bool CheckFor(String check)
        {
            foreach (Modifier modifier in modifiers)
            {
                if (modifier.mod == check)
                {
                    return true;
                }
            }
            return false;
        }

        public void CleanModifiers()
        {
            for(int i = 0; i < modifiers.Count; i++)
            {
                for (int j = 0; j < modifiers.Count; j++)
                {
                    if (modifiers[i] == modifiers[j] && i != j)
                    {
                        modifiers.RemoveAt(j);
                        j--;
                    }
                }
            }
        }

    }
}
