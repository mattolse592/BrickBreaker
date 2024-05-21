using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace BrickBreaker
{
    public class Ball
    {
        public int x, y, xSpeed, ySpeed, size, defaultSpeedX, defaultSpeedY, defaultSize;
        public int lineSpeed = 25;
        public int throwX = 0;
        public Color colour;
        public List<Modifier> modifiers = new List<Modifier>();
        public Rectangle ballRec = new Rectangle();

        public static Random rand = new Random();

        public Ball(int _x, int _y, int _xSpeed, int _ySpeed, int _ballSize)
        {
            x = _x;
            y = _y;
            xSpeed = _xSpeed;
            ySpeed = _ySpeed;

            defaultSpeedX = Math.Abs(_xSpeed);
            defaultSpeedY = Math.Abs(_ySpeed);

            defaultSize = size;

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
                if (throwX >= 950 || throwX < 0)
                {
                    lineSpeed *= -1;
                }
                throwX += lineSpeed;
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
            ballRec = new Rectangle(x, y, size, size);
            bool shouldMove = true;

            shouldMove = !CheckFor("explode");

            if (CheckFor("fade"))
            {
                foreach(Modifier m in modifiers)
                {
                    if (m.mod == "fade")
                    {
                        ballRec = new Rectangle(x + ((size / 2) - ((size / (m.effCount+ 1))/2)), y + ((size / 2) - ((size / (m.effCount + 1)) / 2)), size / (m.effCount + 1), size / (m.effCount + 1));
                    }
                }
            }

            if (ballRec.IntersectsWith(blockRec) && shouldMove)
            {
                

                b.hp -= 1;

                if (x + size < b.x + 10 && xSpeed > 0)
                {
                    x = b.x - size - 2;
                    xSpeed *= -1;

                }

                else if (x > b.x + b.width  - 10 && xSpeed < 0)
                {
                    x = b.x + b.width + 2;
                    xSpeed *= -1;
                }

                if (y + size < b.y + 10 && ySpeed > 0)
                {
                    ySpeed *= -1;

                    y = b.y - size - 2;
                }

                else if (y > b.y + b.height - 10 && ySpeed < 0)
                {
                    ySpeed *= -1;

                    y = b.y + b.height + 2;
                }
            }
            else if (ballRec.IntersectsWith(blockRec))
            {
                b.hp -= 1;
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

                if (x + size <= p.x + 7 && xSpeed >= -1)
                {
                    if (xSpeed == 0)
                    {
                        xSpeed *= -1;
                    }
                    xSpeed *= -1;
                    x = p.x - size - 6;
                    defaultSpeedY = 4;
                    defaultSpeedX = 10;
                }
                else if (x >= p.x + p.width - 7 && xSpeed <= -1)
                {
                    if (xSpeed == 0)
                    {
                        xSpeed *= -1;
                    }
                    x = p.x + p.width + 6;
                    xSpeed *= -1;
                    defaultSpeedY = 4;
                    defaultSpeedX = 10;
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
                //GameScreen.StatUp("")
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

        public void SetCurrent()
        {
            List<Modifier> hold = new List<Modifier>();
            foreach (Modifier m in modifiers)
            {
                if(m.effCount != -55555)
                {
                    m.effCount--;
                    if (m.effCount >= 0)
                    {
                        hold.Add(m);
                    }
                    else if (m.effCount < 0 && m.mod == "fade")
                    {
                        hold.Add(new Modifier("remove"));
                    }
                }
                else
                {
                    hold.Add(m);
                }
            }
            modifiers = hold;
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

        public void MakeBallRec()
        {
            foreach (Modifier m in modifiers)
            {
                if (m.mod == "fade")
                {
                    ballRec = new Rectangle(x + ((size / 2) - ((size / (m.effCount + 1)) / 2)), y + ((size / 2) - ((size / (m.effCount + 1)) / 2)), size / (m.effCount + 1), size / (m.effCount + 1));
                }
            }
        }
    }
}
