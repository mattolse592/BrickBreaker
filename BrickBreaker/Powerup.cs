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
        public List<String> Modifiers = new List<string>();
        Random random = new Random();

        public Powerup(String Type)
        {
            this.Type = Type.ToUpper();
        }

        public Powerup(String Type, List<String> modifiers)
        {
            this.Type = Type.ToUpper();
            foreach (String modifier in modifiers)
            {
                Modifiers.Add(modifier.ToLower());
            }
        }

        public List<Ball> Effect(List<Ball> balls)
        {
            if (Type.Contains("P"))
            {
                return setSimple(balls);
            }
            if (Type.Contains("BB"))
            {
                return BallBurst(balls);
            }
            else if (Type.Contains("BF"))
            {
                return AddFlame(balls);
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

        List<String> setModifiers(Ball b)
        {
            List<String> returnModifiers = new List<String>();
            if (b.modifiers.Any())
            {
                foreach (String mod in b.modifiers)
                {
                    returnModifiers.Add(mod.ToLower());
                }
            }
            if (Modifiers.Any())
            {
                foreach (String mod in Modifiers)
                {
                    returnModifiers.Add(mod.ToLower());
                }
            }
            return returnModifiers;
        }

        public bool CheckFor(String check)
        {
            foreach (String modifier in Modifiers)
            {
                if (modifier == check)
                {
                    return true;
                }
            }
            return false;
        }

        List<Ball> setSimple(List<Ball> balls)
        {
            List<Ball> newBall = new List<Ball>();
            foreach (Ball b in balls)
            {
                newBall.Add(new Ball(b.x, b.y, b.xSpeed, b.ySpeed, b.size, setModifiers(b)));
            }
            return newBall;
        }

        List<Ball> AddFlame(List<Ball> balls)
        {
            List<Ball> newBall = new List<Ball>();
            if (Type.Contains("P"))
            {
                newBall = setSimple(balls);
            }
            return newBall;
        }

        List<Ball> BallBurst(List<Ball> balls)
        {
            //double splitvalue = Math.PI / 4;
            List<Ball> newBall = new List<Ball>();

            if (Type.Contains("C"))
            {
                double numBurst = Convert.ToInt16(Type.Substring(3));

                foreach (Ball b in balls)
                {
                    double ang = random.Next(0, Convert.ToInt16(2 * Math.PI));
                    double angleInc = ((2 * Math.PI) / numBurst);
                    double hyp = Math.Sqrt(Math.Pow(b.defaultSpeedX, 2) + Math.Pow(b.defaultSpeedY, 2));

                    for (int i = 0; i < numBurst; i++)
                    {
                        if (i == 0 && b.modifiers.Contains("temp") == false)
                        {
                            double compAng = ((ang + (angleInc * i)) % (Math.PI / 2));
                            if ((ang + (angleInc * i)) % (Math.PI * 2) < (Math.PI / 2) && (ang + (angleInc * i)) % (Math.PI * 2) > 0)
                            {
                                newBall.Add(new Ball(b.x, b.y, Convert.ToInt16(Math.Sin(compAng) * hyp), Convert.ToInt16(Math.Cos(compAng) * hyp), b.size, b.modifiers));
                            }
                            else if ((ang + (angleInc * i)) % (Math.PI * 2) < (Math.PI) && (ang + (angleInc * i)) % (Math.PI * 2) > (Math.PI / 2))
                            {
                                newBall.Add(new Ball(b.x, b.y, -Convert.ToInt16(Math.Sin(compAng) * hyp), Convert.ToInt16(Math.Cos(compAng) * hyp), b.size, b.modifiers));
                            }
                            else if ((ang + (angleInc * i)) % (Math.PI * 2) < ((3 * Math.PI) / 2) && (ang + (angleInc * i)) % (Math.PI * 2) > Math.PI)
                            {
                                newBall.Add(new Ball(b.x, b.y, -Convert.ToInt16(Math.Sin(compAng) * hyp), -Convert.ToInt16(Math.Cos(compAng) * hyp), b.size, b.modifiers));
                            }
                            else if ((ang + (angleInc * i)) % (Math.PI * 2) < (2 * Math.PI) && (ang + (angleInc * i)) % (Math.PI * 2) > ((3 * Math.PI) / 2))
                            {
                                newBall.Add(new Ball(b.x, b.y, Convert.ToInt16(Math.Sin(compAng) * hyp), -Convert.ToInt16(Math.Cos(compAng) * hyp), b.size, b.modifiers));
                            }
                        }
                        else
                        {
                            double compAng = ((ang + (angleInc * i)) % (Math.PI / 2));
                            if ((ang + (angleInc * i)) % (Math.PI * 2) < (Math.PI / 2) && (ang + (angleInc * i)) % (Math.PI * 2) > 0)
                            {
                                newBall.Add(new Ball(b.x, b.y, Convert.ToInt16(Math.Sin(compAng) * hyp), Convert.ToInt16(Math.Cos(compAng) * hyp), b.size, setModifiers(b)));
                            }
                            else if ((ang + (angleInc * i)) % (Math.PI * 2) < (Math.PI) && (ang + (angleInc * i)) % (Math.PI * 2) > (Math.PI / 2))
                            {
                                newBall.Add(new Ball(b.x, b.y, -Convert.ToInt16(Math.Sin(compAng) * hyp), Convert.ToInt16(Math.Cos(compAng) * hyp), b.size, setModifiers(b)));
                            }
                            else if ((ang + (angleInc * i)) % (Math.PI * 2) < ((3 * Math.PI) / 2) && (ang + (angleInc * i)) % (Math.PI * 2) > Math.PI)
                            {
                                newBall.Add(new Ball(b.x, b.y, -Convert.ToInt16(Math.Sin(compAng) * hyp), -Convert.ToInt16(Math.Cos(compAng) * hyp), b.size, setModifiers(b)));
                            }
                            else if ((ang + (angleInc * i)) % (Math.PI * 2) < (2 * Math.PI) && (ang + (angleInc * i)) % (Math.PI * 2) > ((3 * Math.PI) / 2))
                            {
                                newBall.Add(new Ball(b.x, b.y, Convert.ToInt16(Math.Sin(compAng) * hyp), -Convert.ToInt16(Math.Cos(compAng) * hyp), b.size, setModifiers(b)));
                            }
                        }
                    }
                }
            }
            else
            {
                double numBurst = Convert.ToInt16(Type.Substring(2));

                foreach (Ball b in balls)
                {
                    int evenOp = 0;

                    if (numBurst % 2 != 0)
                    {
                        if (b.modifiers.Contains("temp"))
                        {
                            newBall.Add(new Ball(b.x, b.y, b.xSpeed, b.ySpeed, b.size, b.modifiers));
                        }
                        else
                        {
                            newBall.Add(new Ball(b.x, b.y, b.xSpeed, b.ySpeed, b.size, setModifiers(b)));
                        }
                    }
                    else
                    {
                        if (b.modifiers.Contains("temp"))
                        {
                            evenOp = 1;

                            if (b.ySpeed > 0)
                            {
                                if (b.xSpeed > 0)
                                {
                                    if (random.Next(0, 2) == 0)
                                    {
                                        newBall.Add(new Ball(b.x, b.y, b.defaultSpeedX - 1, b.defaultSpeedY + 1, b.size, b.modifiers));
                                        newBall.Add(new Ball(b.x, b.y, b.defaultSpeedX + 1, b.defaultSpeedY - 1, b.size, setModifiers(b)));
                                    }
                                    else
                                    {
                                        newBall.Add(new Ball(b.x, b.y, b.defaultSpeedX - 1, b.defaultSpeedY + 1, b.size, setModifiers(b)));
                                        newBall.Add(new Ball(b.x, b.y, b.defaultSpeedX + 1, b.defaultSpeedY - 1, b.size, b.modifiers));
                                    }
                                }
                                else
                                {
                                    if (random.Next(0, 2) == 0)
                                    {
                                        newBall.Add(new Ball(b.x, b.y, -b.defaultSpeedX + 1, b.defaultSpeedY + 1, b.size, b.modifiers));
                                        newBall.Add(new Ball(b.x, b.y, -b.defaultSpeedX - 1, b.defaultSpeedY - 1, b.size, setModifiers(b)));
                                    }
                                    else
                                    {
                                        newBall.Add(new Ball(b.x, b.y, -b.defaultSpeedX + 1, b.defaultSpeedY + 1, b.size, setModifiers(b)));
                                        newBall.Add(new Ball(b.x, b.y, -b.defaultSpeedX - 1, b.defaultSpeedY - 1, b.size, b.modifiers));
                                    }
                                }
                            }
                            else
                            {
                                if (b.xSpeed > 0)
                                {
                                    if (random.Next(0, 2) == 0)
                                    {
                                        newBall.Add(new Ball(b.x, b.y, b.defaultSpeedX - 1, -b.defaultSpeedY - 1, b.size, b.modifiers));
                                        newBall.Add(new Ball(b.x, b.y, b.defaultSpeedX + 1, -b.defaultSpeedY + 1, b.size, setModifiers(b)));
                                    }
                                    else
                                    {
                                        newBall.Add(new Ball(b.x, b.y, b.defaultSpeedX - 1, -b.defaultSpeedY - 1, b.size, setModifiers(b)));
                                        newBall.Add(new Ball(b.x, b.y, b.defaultSpeedX + 1, -b.defaultSpeedY + 1, b.size, b.modifiers));
                                    }
                                }
                                else
                                {
                                    if (random.Next(0, 2) == 0)
                                    {
                                        newBall.Add(new Ball(b.x, b.y, -b.defaultSpeedX + 1, -b.defaultSpeedY - 1, b.size, b.modifiers));
                                        newBall.Add(new Ball(b.x, b.y, -b.defaultSpeedX - 1, -b.defaultSpeedY + 1, b.size, setModifiers(b)));
                                    }
                                    else
                                    {
                                        newBall.Add(new Ball(b.x, b.y, -b.defaultSpeedX + 1, -b.defaultSpeedY - 1, b.size, setModifiers(b)));
                                        newBall.Add(new Ball(b.x, b.y, -b.defaultSpeedX - 1, -b.defaultSpeedY + 1, b.size, b.modifiers));
                                    }
                                }
                            }
                        }
                    }


                    if (b.ySpeed > 0)
                    {
                        if (b.xSpeed > 0)
                        {
                            for (int i = 1 + evenOp; i < 1 + Math.Floor(numBurst / 2); i++)
                            {
                                newBall.Add(new Ball(b.x, b.y, b.defaultSpeedX - i, b.defaultSpeedY + i, b.size, setModifiers(b)));
                                newBall.Add(new Ball(b.x, b.y, b.defaultSpeedX + i, b.defaultSpeedY - i, b.size, setModifiers(b)));
                            }
                        }
                        else
                        {
                            for (int i = 1 + evenOp; i < 1 + Math.Floor(numBurst / 2); i++)
                            {
                                newBall.Add(new Ball(b.x, b.y, -b.defaultSpeedX + i, b.defaultSpeedY + i, b.size, setModifiers(b)));
                                newBall.Add(new Ball(b.x, b.y, -b.defaultSpeedX - i, b.defaultSpeedY - i, b.size, setModifiers(b)));
                            }
                        }
                    }
                    else
                    {
                        if (b.xSpeed > 0)
                        {
                            for (int i = 1 + evenOp; i < 1 + Math.Floor(numBurst / 2); i++)
                            {
                                newBall.Add(new Ball(b.x, b.y, b.defaultSpeedX - i, -b.defaultSpeedY - i, b.size, setModifiers(b)));
                                newBall.Add(new Ball(b.x, b.y, b.defaultSpeedX + i, -b.defaultSpeedY + i, b.size, setModifiers(b)));
                            }
                        }
                        else
                        {
                            for (int i = 1 + evenOp; i < 1 + Math.Floor(numBurst / 2); i++)
                            {
                                newBall.Add(new Ball(b.x, b.y, -b.defaultSpeedX + i, -b.defaultSpeedY - i, b.size, setModifiers(b)));
                                newBall.Add(new Ball(b.x, b.y, -b.defaultSpeedX - i, -b.defaultSpeedY + i, b.size, setModifiers(b)));
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
