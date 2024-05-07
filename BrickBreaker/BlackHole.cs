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
        public int x, y, intensity, pullField, schwartzchildRadius;
        public Rectangle schwartzchild = new Rectangle();
        public bool spin;

        public BlackHole(int x, int y, int intensity, int pullField, bool spin)
        {
            this.x = x; this.y = y; this.intensity = intensity * 100; this.pullField = pullField;
            schwartzchildRadius = intensity;
            schwartzchild = new Rectangle(Convert.ToInt16(x - (schwartzchildRadius / 2)), Convert.ToInt16(y - (schwartzchildRadius / 2)), schwartzchildRadius * 2, schwartzchildRadius * 2);
            this.spin = spin;
        }

        public void SetSchwartz()
        {
            schwartzchild = new Rectangle(Convert.ToInt16(x - (schwartzchildRadius / 2)), Convert.ToInt16(y - (schwartzchildRadius / 2)), schwartzchildRadius * 2, schwartzchildRadius * 2);
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
                    if (diffX > 0)
                    {
                        b.x += Convert.ToInt16(Math.Max(1, intensity / (Math.Max(0, Math.Abs(diffX) - schwartzchildRadius) + 1)));
                    }
                    else
                    {
                        b.x -= Convert.ToInt16(intensity / (Math.Max(0,Math.Abs(diffX) - schwartzchildRadius) + 1));
                    }
                    if (diffY > 0)
                    {
                        b.y += Convert.ToInt16(intensity / (Math.Max(0, Math.Abs(diffY) - schwartzchildRadius) + 1));
                    }
                    else
                    {
                        b.y -= Convert.ToInt16(intensity / (Math.Max(0, Math.Abs(diffY) - schwartzchildRadius) + 1));

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
                    double diffX = x - (b.x + (b.width/2));
                    double diffY = y - (b.y + (b.height / 2));

                    b.x += Convert.ToInt16(intensity / (Math.Abs(diffX - schwartzchildRadius) + 1));
                    b.y += Convert.ToInt16(intensity / (Math.Abs(diffY - schwartzchildRadius) + 1));
                }
                newBlock.Add(b);

            }

            return newBlock;
        }
    }
}
