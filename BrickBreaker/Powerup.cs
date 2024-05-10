using Microsoft.Win32;
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
        public List<Modifier> Modifiers = new List<Modifier>();
        Random random = new Random();
        int time = 0;

        public Powerup(String Type)
        {
            this.Type = Type.ToUpper();
        }

        public Powerup(String Type, List<Modifier> modifiers)
        {
            this.Type = Type.ToUpper();
            foreach (Modifier modifier in modifiers)
            {
                Modifiers.Add(new Modifier(modifier.mod.ToLower(), modifier.effCount));
            }
        }

        public Powerup(String Type, int time)
        {
            this.Type = Type.ToUpper();
            this.time = time;
        }

        public Powerup(String Type, List<Modifier> modifiers, int time)
        {
            this.Type = Type.ToUpper();
            foreach (Modifier modifier in modifiers)
            {
                Modifiers.Add(new Modifier(modifier.mod.ToLower(), modifier.effCount));
            }
        }

        public List<Ball> PermCheck(List<Ball> balls)
        {
            foreach (Ball b in balls)
            {
                if (b.CheckFor("PERM"))
                {
                    return new List<Ball> { b };
                }
            }
            return new List<Ball>();
        }

        public List<Ball> Effect(List<Ball> balls)
        {
            List<Ball> result = PermCheck(balls);
            if (Type.Substring(0, 1) == "P" && !Type.Contains("PW"))
            {
                return setSimple(balls);
            }
            else if (Type.Contains("BH"))
            {
                result.Clear();
                List<Modifier> modifiers = new List<Modifier> { new Modifier("PERM"), new Modifier("IMMINENT") };
                result.Add(new Ball(balls[0].x, balls[0].y, balls[0].xSpeed, balls[0].ySpeed, balls[0].size, modifiers));
                Modifiers.Add(new Modifier("remove"));
                GameScreen.stick = true;
                return result;
            }
            else if (Type.Contains("BE") || Type.Contains("BF"))
            {
                result = AddType(balls);
                Modifiers.Add(new Modifier("remove"));
                return result;
            }
            else if (Type.Contains("BB"))
            {
                result = BallBurst(balls);
                Modifiers.Add(new Modifier("remove"));
                return result;
            }
            else
            {
                switch (Type)
                {
                    case "SPUBX":
                        SpeedUp(balls, 0);
                        break;
                    case "SPUBY":
                        SpeedUp(balls, 1);
                        break;
                    case "SPUPX":
                        SpeedUp(balls, 2);
                        break;
                    case "SPDBX":
                        SpeedDown(balls, 0);
                        break;
                    case "SPDBY":
                        SpeedDown(balls, 1);
                        break;
                    case "SPDPX":
                        SpeedDown(balls, 2);
                        break;
                    case "PW":
                        if (time != 0)
                        {
                            GameScreen.widthModP += time;
                        }
                        else
                        {
                            GameScreen.widthModP++;
                        }
                        Modifiers.Add(new Modifier("remove"));
                        break;

                }
            }
            return balls;
        }

        int returnSize(Ball b)
        {
            if (b.CheckFor("fade"))
            {
                return b.defaultSize;
            }
            return b.size;
        }

        List<Modifier> setModifiers(Ball b)
        {
            List<Modifier> returnModifiers = new List<Modifier>();
            if (b.modifiers.Any())
            {
                foreach (Modifier mod in b.modifiers)
                {
                    returnModifiers.Add(new Modifier(mod.mod.ToLower(), mod.effCount));
                }
            }
            if (Modifiers.Any())
            {
                foreach (Modifier mod in Modifiers)
                {
                    returnModifiers.Add(new Modifier(mod.mod.ToLower(), mod.effCount));
                }
            }
            return returnModifiers;
        }

        List<Modifier> setWithoutTemp(Ball b)
        {
            List<Modifier> returnModifiers = new List<Modifier>();
            if (b.modifiers.Any())
            {
                foreach (Modifier mod in b.modifiers)
                {
                    returnModifiers.Add(new Modifier(mod.mod.ToLower(), mod.effCount));
                }
            }
            if (Modifiers.Any())
            {
                foreach (Modifier mod in Modifiers)
                {
                    returnModifiers.Add(new Modifier(mod.mod.ToLower(), mod.effCount));
                }
            }

            List<Modifier> returnerModifiers = new List<Modifier>();
            foreach (Modifier mod in returnModifiers)
            {
                if (mod.mod.Contains("temp") == false)
                {
                    returnModifiers.Add(mod);
                }
            }
            return returnerModifiers;
        }

        public bool CheckFor(String check)
        {
            foreach (Modifier modifier in Modifiers)
            {
                if (modifier.mod == check)
                {
                    return true;
                }
            }
            return false;
        }

        List<Ball> setSimple(List<Ball> balls)
        {
            List<Ball> newBall = PermCheck(balls);
            foreach (Ball b in balls)
            {
                newBall.Add(new Ball(b.x, b.y, b.xSpeed, b.ySpeed, returnSize(b), setModifiers(b)));
            }
            return newBall;
        }

        List<Ball> AddType(List<Ball> balls)
        {
            List<Ball> newBall = PermCheck(balls);
            if (Type.Contains("P"))
            {
                newBall = setSimple(balls);
            }
            else
            {
                foreach (Ball b in balls)
                {
                    newBall.Add(new Ball(b.x, b.y, b.xSpeed, b.ySpeed, returnSize(b), setModifiers(b)));
                }
            }
            return newBall;
        }

        List<Ball> BallBurst(List<Ball> balls)
        {
            //double splitvalue = Math.PI / 4;
            List<Ball> newBall = PermCheck(balls);

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
                        if (i == 0 && CheckFor("temp"))
                        {
                            double compAng = ((ang + (angleInc * i)) % (Math.PI / 2));
                            if ((ang + (angleInc * i)) % (Math.PI * 2) < (Math.PI / 2) && (ang + (angleInc * i)) % (Math.PI * 2) > 0)
                            {
                                newBall.Add(new Ball(b.x, b.y, Convert.ToInt16(Math.Sin(compAng) * hyp), Convert.ToInt16(Math.Cos(compAng) * hyp), returnSize(b), setWithoutTemp(b)));
                            }
                            else if ((ang + (angleInc * i)) % (Math.PI * 2) < (Math.PI) && (ang + (angleInc * i)) % (Math.PI * 2) > (Math.PI / 2))
                            {
                                newBall.Add(new Ball(b.x, b.y, -Convert.ToInt16(Math.Sin(compAng) * hyp), Convert.ToInt16(Math.Cos(compAng) * hyp), returnSize(b), setWithoutTemp(b)));
                            }
                            else if ((ang + (angleInc * i)) % (Math.PI * 2) < ((3 * Math.PI) / 2) && (ang + (angleInc * i)) % (Math.PI * 2) > Math.PI)
                            {
                                newBall.Add(new Ball(b.x, b.y, -Convert.ToInt16(Math.Sin(compAng) * hyp), -Convert.ToInt16(Math.Cos(compAng) * hyp), returnSize(b), setWithoutTemp(b)));
                            }
                            else if ((ang + (angleInc * i)) % (Math.PI * 2) < (2 * Math.PI) && (ang + (angleInc * i)) % (Math.PI * 2) > ((3 * Math.PI) / 2))
                            {
                                newBall.Add(new Ball(b.x, b.y, Convert.ToInt16(Math.Sin(compAng) * hyp), -Convert.ToInt16(Math.Cos(compAng) * hyp), returnSize(b), setWithoutTemp(b)));
                            }
                        }
                        else
                        {
                            double compAng = ((ang + (angleInc * i)) % (Math.PI / 2));
                            if ((ang + (angleInc * i)) % (Math.PI * 2) < (Math.PI / 2) && (ang + (angleInc * i)) % (Math.PI * 2) > 0)
                            {
                                newBall.Add(new Ball(b.x, b.y, Convert.ToInt16(Math.Sin(compAng) * hyp), Convert.ToInt16(Math.Cos(compAng) * hyp), returnSize(b), setModifiers(b)));
                            }
                            else if ((ang + (angleInc * i)) % (Math.PI * 2) < (Math.PI) && (ang + (angleInc * i)) % (Math.PI * 2) > (Math.PI / 2))
                            {
                                newBall.Add(new Ball(b.x, b.y, -Convert.ToInt16(Math.Sin(compAng) * hyp), Convert.ToInt16(Math.Cos(compAng) * hyp), returnSize(b), setModifiers(b)));
                            }
                            else if ((ang + (angleInc * i)) % (Math.PI * 2) < ((3 * Math.PI) / 2) && (ang + (angleInc * i)) % (Math.PI * 2) > Math.PI)
                            {
                                newBall.Add(new Ball(b.x, b.y, -Convert.ToInt16(Math.Sin(compAng) * hyp), -Convert.ToInt16(Math.Cos(compAng) * hyp), returnSize(b), setModifiers(b)));
                            }
                            else if ((ang + (angleInc * i)) % (Math.PI * 2) < (2 * Math.PI) && (ang + (angleInc * i)) % (Math.PI * 2) > ((3 * Math.PI) / 2))
                            {
                                newBall.Add(new Ball(b.x, b.y, Convert.ToInt16(Math.Sin(compAng) * hyp), -Convert.ToInt16(Math.Cos(compAng) * hyp), returnSize(b), setModifiers(b)));
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
                        if (CheckFor("temp"))
                        {
                            newBall.Add(new Ball(b.x, b.y, b.xSpeed, b.ySpeed, returnSize(b), setWithoutTemp(b)));
                        }
                        else
                        {
                            newBall.Add(new Ball(b.x, b.y, b.xSpeed, b.ySpeed, returnSize(b), setModifiers(b)));
                        }
                    }
                    else
                    {
                        if (CheckFor("temp"))
                        {
                            evenOp = 1;

                            if (b.ySpeed > 0)
                            {
                                if (b.xSpeed > 0)
                                {
                                    if (random.Next(0, 2) == 0)
                                    {
                                        newBall.Add(new Ball(b.x, b.y, b.defaultSpeedX - 1, b.defaultSpeedY + 1, returnSize(b), setWithoutTemp(b)));
                                        newBall.Add(new Ball(b.x, b.y, b.defaultSpeedX + 1, b.defaultSpeedY - 1, returnSize(b), setModifiers(b)));
                                    }
                                    else
                                    {
                                        newBall.Add(new Ball(b.x, b.y, b.defaultSpeedX - 1, b.defaultSpeedY + 1, returnSize(b), setModifiers(b)));
                                        newBall.Add(new Ball(b.x, b.y, b.defaultSpeedX + 1, b.defaultSpeedY - 1, returnSize(b), setWithoutTemp(b)));
                                    }
                                }
                                else
                                {
                                    if (random.Next(0, 2) == 0)
                                    {
                                        newBall.Add(new Ball(b.x, b.y, -b.defaultSpeedX + 1, b.defaultSpeedY + 1, returnSize(b), setWithoutTemp(b)));
                                        newBall.Add(new Ball(b.x, b.y, -b.defaultSpeedX - 1, b.defaultSpeedY - 1, returnSize(b), setModifiers(b)));
                                    }
                                    else
                                    {
                                        newBall.Add(new Ball(b.x, b.y, -b.defaultSpeedX + 1, b.defaultSpeedY + 1, returnSize(b), setModifiers(b)));
                                        newBall.Add(new Ball(b.x, b.y, -b.defaultSpeedX - 1, b.defaultSpeedY - 1, returnSize(b), setWithoutTemp(b)));
                                    }
                                }
                            }
                            else
                            {
                                if (b.xSpeed > 0)
                                {
                                    if (random.Next(0, 2) == 0)
                                    {
                                        newBall.Add(new Ball(b.x, b.y, b.defaultSpeedX - 1, -b.defaultSpeedY - 1, returnSize(b), setWithoutTemp(b)));
                                        newBall.Add(new Ball(b.x, b.y, b.defaultSpeedX + 1, -b.defaultSpeedY + 1, returnSize(b), setModifiers(b)));
                                    }
                                    else
                                    {
                                        newBall.Add(new Ball(b.x, b.y, b.defaultSpeedX - 1, -b.defaultSpeedY - 1, returnSize(b), setModifiers(b)));
                                        newBall.Add(new Ball(b.x, b.y, b.defaultSpeedX + 1, -b.defaultSpeedY + 1, returnSize(b), setWithoutTemp(b)));
                                    }
                                }
                                else
                                {
                                    if (random.Next(0, 2) == 0)
                                    {
                                        newBall.Add(new Ball(b.x, b.y, -b.defaultSpeedX + 1, -b.defaultSpeedY - 1, returnSize(b), setWithoutTemp(b)));
                                        newBall.Add(new Ball(b.x, b.y, -b.defaultSpeedX - 1, -b.defaultSpeedY + 1, returnSize(b), setModifiers(b)));
                                    }
                                    else
                                    {
                                        newBall.Add(new Ball(b.x, b.y, -b.defaultSpeedX + 1, -b.defaultSpeedY - 1, returnSize(b), setModifiers(b)));
                                        newBall.Add(new Ball(b.x, b.y, -b.defaultSpeedX - 1, -b.defaultSpeedY + 1, returnSize(b), setWithoutTemp(b)));
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
                                newBall.Add(new Ball(b.x, b.y, b.defaultSpeedX - i, b.defaultSpeedY + i, returnSize(b), setModifiers(b)));
                                newBall.Add(new Ball(b.x, b.y, b.defaultSpeedX + i, b.defaultSpeedY - i, returnSize(b), setModifiers(b)));
                            }
                        }
                        else
                        {
                            for (int i = 1 + evenOp; i < 1 + Math.Floor(numBurst / 2); i++)
                            {
                                newBall.Add(new Ball(b.x, b.y, -b.defaultSpeedX + i, b.defaultSpeedY + i, returnSize(b), setModifiers(b)));
                                newBall.Add(new Ball(b.x, b.y, -b.defaultSpeedX - i, b.defaultSpeedY - i, returnSize(b), setModifiers(b)));
                            }
                        }
                    }
                    else
                    {
                        if (b.xSpeed > 0)
                        {
                            for (int i = 1 + evenOp; i < 1 + Math.Floor(numBurst / 2); i++)
                            {
                                newBall.Add(new Ball(b.x, b.y, b.defaultSpeedX - i, -b.defaultSpeedY - i, returnSize(b), setModifiers(b)));
                                newBall.Add(new Ball(b.x, b.y, b.defaultSpeedX + i, -b.defaultSpeedY + i, returnSize(b), setModifiers(b)));
                            }
                        }
                        else
                        {
                            for (int i = 1 + evenOp; i < 1 + Math.Floor(numBurst / 2); i++)
                            {
                                newBall.Add(new Ball(b.x, b.y, -b.defaultSpeedX + i, -b.defaultSpeedY - i, returnSize(b), setModifiers(b)));
                                newBall.Add(new Ball(b.x, b.y, -b.defaultSpeedX - i, -b.defaultSpeedY + i, returnSize(b), setModifiers(b)));
                            }
                        }
                    }
                }

            }

            return newBall;
        }

        void SpeedUp(List<Ball> balls, int type)
        {
            Modifiers.Add(new Modifier("remove"));
            switch (type)
            {
                case 0:
                    if (time != 0)
                    {
                        GameScreen.speedModBX += time;
                    }
                    else
                    {
                        GameScreen.speedModBX++;
                    }
                    break;
                case 1:
                    if (time != 0)
                    {
                        GameScreen.speedModBY += time;
                    }
                    else
                    {
                        GameScreen.speedModBY++;
                    }
                    break;
                case 2:
                    if (time != 0)
                    {
                        GameScreen.speedModPX += time;
                    }
                    else
                    {
                        GameScreen.speedModPX++;
                    }
                    break;
            }
        }

        void SpeedDown(List<Ball> balls, int type)
        {
            Modifiers.Add(new Modifier("remove"));
            switch (type)
            {
                case 0:
                    if (time != 0)
                    {
                        GameScreen.speedModBX -= time;
                    }
                    else
                    {
                        GameScreen.speedModBX--;
                    }
                    break;
                case 1:
                    if (time != 0)
                    {
                        GameScreen.speedModBY -= time;
                    }
                    else
                    {
                        GameScreen.speedModBY--;
                    }
                    break;
                case 2:
                    if (time != 0)
                    {
                        GameScreen.speedModPX -= time;
                    }
                    else
                    {
                        GameScreen.speedModPX--;
                    }
                    break;
            }
        }
    }
}
