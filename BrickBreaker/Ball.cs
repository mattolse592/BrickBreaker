using System;
using System.Drawing;
using System.Windows.Forms;

namespace BrickBreaker
{
    public class Ball
    {
        public int x, y, xSpeed, ySpeed, size, defaultSpeedX, defaultSpeedY;
        public Color colour;

        public static Random rand = new Random();

        public Ball(int _x, int _y, int _xSpeed, int _ySpeed, int _ballSize)
        {
            x = _x;
            y = _y;
            xSpeed = _xSpeed;
            ySpeed = _ySpeed;
            defaultSpeedX = _xSpeed;
            defaultSpeedY = _ySpeed;
            size = _ballSize;

        }

        public void Move()
        {
            if (xSpeed < 0)
            {
                xSpeed = -Math.Max(0, (defaultSpeedX + GameScreen.speedModBX));
            }
            else
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

                //paddle width = 80

                if (ballRec.X + size < p.x + 10)
                {
                    defaultSpeedX = -20;
                }

                if (ballRec.X + 4 > p.x + p.width)
                {
                    xSpeed *= -1;
                    ySpeed *= -1;
                }

                //if (size / 2 + ballRec.X <= p.x + 30)
                //{
                //    defaultSpeedX = -6;
                //}
                //else if (size / 2 + ballRec.X <= p.x + 50)
                //{
                //    defaultSpeedX = -3;
                //}
                //else if (size / 2 + ballRec.X >= p.x + 70)
                //{
                //    defaultSpeedX = 6;
                //}
                //else if (size / 2 + ballRec.X >= p.x + 50)
                //{
                //    defaultSpeedX = 3;
                //}


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
            if (x >= (UC.Width - size))
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

    }
}
