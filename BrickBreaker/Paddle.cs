using System;
using System.Drawing;

namespace BrickBreaker
{
    public class Paddle
    {
        public int x, y, sWidth, width, height, speed;
        public Color colour;

        public Paddle(int _x, int _y, int _width, int _height, int _speed, Color _colour)
        {
            x = _x;
            y = _y;
            sWidth = _width;
            width = _width;
            height = _height;
            speed = _speed;
            colour = _colour;
        }

        public void CalibrateWidth()
        {
            int currentWidth = width;
            width = sWidth + (2 * GameScreen.widthModP);
            x -= (width - currentWidth) / 2;
        }

        public void Move(string direction)
        {
            if (direction == "left")
            {

                x -= Math.Max(0,(speed + GameScreen.speedModPX));

            }
            if (direction == "right")
            {
                x += Math.Max(0, (speed + GameScreen.speedModPX));
            }
        }
    }
}

