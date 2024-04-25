using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker
{
    internal class Powerup
    {
        public String Type;

        public Powerup(String Type)
        {
            this.Type = Type;
        }

        public List<Ball> Effect(List<Ball> balls)
        {
            if (Type.Contains("BB"))
            {
                return BallBurst(balls);
            }
            else
            {
                switch (Type)
                {
                    case "SpUBX":
                        SpeedUp(balls, 0);
                        break;
                    case "SpUBY":
                        SpeedUp(balls, 1);
                        break;
                    case "SpUPX":
                        SpeedUp(balls, 2);
                        break;
                    case "SpDBX":
                        SpeedDown(balls, 0);
                        break;
                    case "SpDBY":
                        SpeedDown(balls, 1);
                        break;
                    case "SpDPX":
                        SpeedDown(balls, 2);
                        break;


                }
            }
            return balls;
        }

        List<Ball> BallBurst(List<Ball> balls)
        {
            //double splitvalue = Math.PI / 4;
            List<Ball> newBall = new List<Ball>();
            double numBurst = Convert.ToInt16(Type.Substring(2));

            if (Type.Contains("C"))
            {
                foreach (Ball b in balls)
                {
                    Random random = new Random();
                    double ang = random.Next(0, Convert.ToInt16(2 * Math.PI));
                    double angleInc = ((2 * Math.PI) / numBurst);

                    for (int i = 0; i < numBurst; i++)
                    {
                        if ((ang + (angleInc * i)) % (Math.PI * 2) < (Math.PI / 2) && (ang + (angleInc * i)) % (Math.PI * 2) > 0)
                        {

                        }
                        else if ((ang + (angleInc * i)) % (Math.PI * 2) < (Math.PI) && (ang + (angleInc * i)) % (Math.PI * 2) > 0)
                        {

                        }
                        else if ((ang + (angleInc * i)) % (Math.PI * 2) < (Math.PI / 2) && (ang + (angleInc * i)) % (Math.PI * 2) > 0)
                        {

                        }
                        else if ((ang + (angleInc * i)) % (Math.PI * 2) < (Math.PI / 2) && (ang + (angleInc * i)) % (Math.PI * 2) > 0)
                        {

                        }
                    }
                }
            }
            else
            {
                foreach (Ball b in balls)
                {
                    if (numBurst % 2 != 0)
                    {
                        newBall.Add(b);
                    }

                    //double ang = Math.Atan(b.ySpeed / b.xSpeed);
                    if (b.ySpeed > 0)
                    {
                        if (b.xSpeed > 0)
                        {
                            for (int i = 1; i < 1 + Math.Floor(numBurst / 2); i++)
                            {
                                newBall.Add(new Ball(b.x, b.y, b.defaultSpeedX - i, b.defaultSpeedY + i, b.size));
                                newBall.Add(new Ball(b.x, b.y, b.defaultSpeedX + i, b.defaultSpeedY - i, b.size));
                            }
                        }
                        else
                        {
                            for (int i = 1; i < 1 + Math.Floor(numBurst / 2); i++)
                            {
                                newBall.Add(new Ball(b.x, b.y, -b.defaultSpeedX + i, b.defaultSpeedY + i, b.size));
                                newBall.Add(new Ball(b.x, b.y, -b.defaultSpeedX - i, b.defaultSpeedY - i, b.size));
                            }
                        }
                    }
                    else
                    {
                        if (b.xSpeed > 0)
                        {
                            for (int i = 1; i < 1 + Math.Floor(numBurst / 2); i++)
                            {
                                newBall.Add(new Ball(b.x, b.y, b.defaultSpeedX - i, -b.defaultSpeedY - i, b.size));
                                newBall.Add(new Ball(b.x, b.y, b.defaultSpeedX + i, -b.defaultSpeedY + i, b.size));
                            }
                        }
                        else
                        {
                            for (int i = 1; i < 1 + Math.Floor(numBurst / 2); i++)
                            {
                                newBall.Add(new Ball(b.x, b.y, -b.defaultSpeedX + i, -b.defaultSpeedY - i, b.size));
                                newBall.Add(new Ball(b.x, b.y, -b.defaultSpeedX - i, -b.defaultSpeedY + i, b.size));
                            }
                        }
                    }
                }
            }
            return newBall;
        }

        void SpeedUp(List<Ball> balls, int type)
        {
            switch (type)
            {
                case 0:
                    GameScreen.speedModBX++;
                    break;
                case 1:
                    GameScreen.speedModBY++;
                    break;
                case 2:
                    GameScreen.speedModPX++;
                    break;
            }
        }

        void SpeedDown(List<Ball> balls, int type)
        {
            switch (type)
            {
                case 0:
                    GameScreen.speedModBX--;
                    break;
                case 1:
                    GameScreen.speedModBY--;
                    break;
                case 2:
                    GameScreen.speedModPX--;
                    break;
            }
        }
    }
}
