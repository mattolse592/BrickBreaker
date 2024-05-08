using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker
{
    public class BlackHole
    {
        public int x, y, pullField, schwartzchildRadius;
        double intensity;
        public Rectangle schwartzchild = new Rectangle();
        public bool spin;
        private double scale;
        public bool interWBlocks;
        public bool consumeBall, consumeBlock;
        public bool grow;
        int xInc = 0;
        public List<PointF> points = new List<PointF>();
        public BlackHole(int x, int y, double intensity, int pullField, bool spin, bool interWBlocks, bool consumeBall, bool consumeBlock, bool growing)
        {
            this.x = x; this.y = y; this.intensity = intensity * 150; this.pullField = pullField;
            schwartzchildRadius = (int)Math.Max(1, intensity);
            schwartzchild = new Rectangle(Convert.ToInt16(x - (schwartzchildRadius / 2)), Convert.ToInt16(y - (schwartzchildRadius / 2)), schwartzchildRadius * 2, schwartzchildRadius * 2);
            this.spin = spin;
            scale = pullField / intensity;
            this.interWBlocks = interWBlocks;
            this.consumeBall = consumeBall;
            this.consumeBlock = consumeBlock;
            this.grow = growing;
        }

        public void SetSchwartz()
        {
            schwartzchild = new Rectangle(Convert.ToInt16(x - (schwartzchildRadius / 2)), Convert.ToInt16(y - (schwartzchildRadius / 2)), schwartzchildRadius, schwartzchildRadius);
        }

        public List<Ball> Pull(List<Ball> balls)
        {
            List<Ball> newBall = new List<Ball>();

            foreach (Ball b in balls)
            {
                double rad = Math.Sqrt(Math.Pow(x - b.x, 2) + Math.Pow(y - b.y, 2));
                if (pullField >= Math.Abs(rad))
                {
                    double diffX = x - (b.x + (b.size / 2));
                    double diffY = y - (b.y + (b.size / 2));
                    double total = Math.Abs(diffX) + Math.Abs(diffY);
                    double xScale = ((Math.Abs(diffX) / (total + 1)));
                    double yScale = ((Math.Abs(diffY) / (total + 1)));

                    Int32 suggest = Convert.ToInt32(Math.Pow(Math.Max(1, intensity / (Math.Max(0, Math.Abs(rad) - schwartzchildRadius) + 1)), 2));

                    if (diffX > 0)
                    {
                        if (Math.Abs(diffX) < suggest * xScale)
                        {
                            b.x += (int)Math.Abs(diffX);
                        }
                        else
                        {
                            b.x += Convert.ToInt32(Math.Max(1, suggest * xScale));
                        }
                    }
                    else
                    {
                        if (Math.Abs(diffX) < suggest * xScale)
                        {
                            b.x -= (int)Math.Abs(diffX);
                        }
                        else
                        {
                            b.x -= Convert.ToInt32(Math.Max(1, suggest * xScale));
                        }
                    }

                    if (diffY > 0)
                    {
                        if (Math.Abs(diffY) < suggest * yScale)
                        {
                            b.y += (int)Math.Abs(diffY);
                        }
                        else
                        {
                            b.y += Convert.ToInt32(Math.Max(1, suggest * yScale));
                        }
                    }
                    else
                    {
                        if (Math.Abs(diffY) < suggest * yScale)
                        {
                            b.y -= (int)Math.Abs(diffY);
                        }
                        else
                        {
                            b.y -= Convert.ToInt32(Math.Max(1, suggest * yScale));
                        }
                    }
                }
                newBall.Add(b);

            }

            return newBall;
        }
        public List<Block> Pull(List<Block> blocks)
        {
            List<Block> newBlock = new List<Block>();

            foreach (Block b in blocks)
            {
                double rad = Math.Sqrt(Math.Pow(x - b.x, 2) + Math.Pow(y - b.y, 2));
                if (pullField >= Math.Abs(rad))
                {
                    double diffX = x - (b.x + (b.width / 2));
                    double diffY = y - (b.y + (b.height / 2));
                    double total = Math.Abs(diffX) + Math.Abs(diffY);
                    double xScale = ((Math.Abs(diffX) / (total + 1)));
                    double yScale = ((Math.Abs(diffY) / (total + 1)));

                    Int32 suggest = Convert.ToInt32(Math.Pow(Math.Max(1, intensity / (Math.Max(0, Math.Abs(rad) - schwartzchildRadius) + 1)), 2));

                    if (diffX > 0)
                    {
                        if (Math.Abs(diffX) < suggest * xScale)
                        {
                            b.x += (int)Math.Abs(diffX);
                        }
                        else
                        {
                            b.x += Convert.ToInt32(Math.Max(1, suggest * xScale));
                        }
                    }
                    else
                    {
                        if (Math.Abs(diffX) < suggest * xScale)
                        {
                            b.x -= (int)Math.Abs(diffX);
                        }
                        else
                        {
                            b.x -= Convert.ToInt32(Math.Max(1, suggest * xScale));
                        }
                    }

                    if (diffY > 0)
                    {
                        if (Math.Abs(diffY) < suggest * yScale)
                        {
                            b.y += (int)Math.Abs(diffY);
                        }
                        else
                        {
                            b.y += Convert.ToInt32(Math.Max(1, suggest * yScale));
                        }
                    }
                    else
                    {
                        if (Math.Abs(diffY) < suggest * yScale)
                        {
                            b.y -= (int)Math.Abs(diffY);
                        }
                        else
                        {
                            b.y -= Convert.ToInt32(Math.Max(1, suggest * yScale));
                        }
                    }
                }
                newBlock.Add(b);

            }

            return newBlock;
        }

        public List<Block> BeyondHorizon(List<Block> blocks)
        {
            List<Block> newBlock = new List<Block>();

            foreach (Block b in blocks)
            {
                Rectangle block = new Rectangle(b.x, b.y, b.width, b.height);
                if (block.IntersectsWith(schwartzchild))
                {
                    b.hp -= (int)Math.Max(1, intensity);
                    if (b.hp <= 0)
                    {
                        if (grow)
                        {
                            schwartzchildRadius++;
                            pullField += (int)scale;

                            if (schwartzchildRadius > 1525)
                            {
                                schwartzchildRadius = 1525;
                            }

                            if (pullField > 55555)
                            {
                                pullField = 55555;
                            }

                            intensity = Math.Max(1, schwartzchildRadius / 5) * 150;
                            SetSchwartz();
                        }
                    }
                    else
                    {
                        newBlock.Add(b);
                    }
                }
                else
                {
                    newBlock.Add(b);
                }
            }

            return newBlock;
        }

        public List<Ball> BeyondHorizon(List<Ball> balls)
        {
            List<Ball> newBall = new List<Ball>();

            foreach (Ball b in balls)
            {
                Rectangle ball = new Rectangle(b.x, b.y, b.size, b.size);
                if (ball.IntersectsWith(schwartzchild))
                {
                    if (b.CheckFor("PERM"))
                    {
                        newBall.Add(b);
                        GameScreen.stick = true;
                    }

                    if (grow)
                    {
                        schwartzchildRadius++;
                        pullField += (int)scale;

                        if (schwartzchildRadius > 1525)
                        {
                            schwartzchildRadius = 1525;
                        }

                        if (pullField > 55555)
                        {
                            pullField = 55555;
                        }

                        intensity = Math.Max(1, schwartzchildRadius / 5) * 150;
                        SetSchwartz();
                    }
                }
                else
                {
                    newBall.Add(b);
                }
            }

            return newBall;
        }

        public void DrawPoints()
        {
            int numPoints = 50;
            points.Clear();

            if (xInc > (2 * pullField / (numPoints / 2))) {
                xInc = 0;
            }
            if (xInc < 0)
            {
                xInc = (2 * pullField / (numPoints / 2));
            }

            for (int i = 0; i < numPoints; i++)
            {
                float tX = xInc + (i * (2 * pullField / (numPoints / 2)));
                if (tX < 2 * pullField)
                {
                    points.Add(new PointF(x + tX - pullField, y + Convert.ToSingle(Math.Sqrt(Math.Pow(pullField, 2) - Math.Pow(tX - pullField, 2)))));
                }
                else
                {
                    float nTX = (pullField * 2) - (tX - (2 * pullField));
                    points.Add(new PointF(x + nTX - pullField, y - Convert.ToSingle(Math.Sqrt(Math.Pow(pullField, 2) - Math.Pow(nTX - pullField, 2)))));
                }
            }

            if (spin)
            {
                xInc++;
            }
            else
            {
                xInc--;
            }
        }
    }


}
