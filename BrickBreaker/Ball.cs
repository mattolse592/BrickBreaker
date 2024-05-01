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

            if (GameScreen.stick)
            {
                x = (GameScreen.paddle.x + (GameScreen.paddle.width / 2)) - (size / 2);
                y = GameScreen.paddle.y - size - 20;
            }

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

                b.hp -= 1;

                if (ballRec.X + size < blockRec.X + 10)
                {
                    xSpeed *= -1;
                    ySpeed *= -1;
                    x = b.x - size - 3;
                }
                else if (ballRec.X + 4 > b.x + blockRec.Width)
                {
                    xSpeed *= -1;
                    ySpeed *= -1;
                    x = b.x + b.width + 3;
                }
                else if (y + size < b.y + 6)
                {
                    y = b.y - size - 3;
                }
                else
                {
                    y = b.y + b.height + 3;
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

                if (x + size <= p.x + 7 && xSpeed > 0)
                {
                    xSpeed *= -1;
                    x = p.x - size - 6;
                    defaultSpeedY = 4;
                    defaultSpeedX = 15;
                }
                else if (x >= p.x + p.width - 7 && xSpeed < 0)
                {
                    x = p.x + p.width + 6;
                    xSpeed *= -1;
                    defaultSpeedY = 4;
                    defaultSpeedX = 15;
                }
                else if (x + (size / 2) < p.x + (p.width / 4))
                {
                    defaultSpeedY = 6;
                    defaultSpeedX = 6;
                    y = p.y - size - 4;
                    if (xSpeed > 0)
                    {
                        xSpeed *= -1;
                    }

                }
                else if (x + (size / 2) < p.x + ((p.width / 4) * 2))
                {
                    defaultSpeedY = 6;
                    defaultSpeedX = 3;
                    y = p.y - size - 4;
                    if (xSpeed > 0)
                    {
                        xSpeed *= -1;
                    }

                }
                else if (x + (size / 2) < p.x + ((p.width / 4) * 3))
                {
                    defaultSpeedY = 6;
                    defaultSpeedX = 3;
                    y = p.y - size - 4;
                    if (xSpeed < 0)
                    {
                        xSpeed *= -1;
                    }

                }
                else
                {
                    defaultSpeedY = 6;
                    defaultSpeedX = 6;
                    y = p.y - size - 4;
                    if (xSpeed < 0)
                    {
                        xSpeed *= -1;
                    }
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
                x = 950 - size;
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
            for (int i = 0; i < modifiers.Count; i++)
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
