using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BrickBreaker
{
    public class Block
    {
        public int width = 50;
        public int height = 25;

        public int x;
        public int y;
        public int hp;
        public int maxHP;
        public Color colour;
        public Image image;

        public static Random rand = new Random();

        public List<Modifier> modifiers = new List<Modifier>();


        const int TICSPEED = 50;
        int fireTic;

        public Block(int _x, int _y, int _hp, Color _colour)
        {
            x = _x;
            y = _y;
            hp = _hp;
            maxHP = _hp;
            colour = _colour;
            image = Properties.Resources.samsmich_full_health;
            fireTic = TICSPEED;
        }

        public Ball PassCondition(Ball ball)
        {
            foreach (Modifier modifier in ball.modifiers)
            {
                if (modifier.mod.Contains("IMMINENT"))
                {
                    GameScreen.holes.Add(new BlackHole(ball.x, ball.y, 0.5, 200, true, true, true, true, true));
                    ball.modifiers.Clear();
                    ball.modifiers.Add(new Modifier("PERM"));
                    return (ball);
                }

                if (modifier.mod.Contains("fire"))
                {
                    modifiers.Add(new Modifier("ONFIRE", modifier.effCount));
                }

                if (modifier.mod.Contains("explode") && !ball.CheckFor("fade"))
                {
                    int explodeSize = 200;

                    List<Modifier> hold = new List<Modifier>();

                    foreach (Modifier mod in ball.modifiers)
                    {
                        hold.Add(mod);
                    }
                    hold.Add(new Modifier("fade", 25));

                    return new Ball(ball.x + (ball.size / 2) - (explodeSize / 2), ball.y + (ball.size / 2) - (explodeSize / 2), 0, 0, explodeSize, hold);
                }
            }
            return ball;
        }

        public void setCurrent()
        {
            foreach (Modifier modifier in modifiers)
            {
                if (modifier.mod == ("ONFIRE"))
                {
                    fireTic--;
                }

                if (fireTic <= 0)
                {
                    fireTic = TICSPEED;
                    hp--;
                    modifier.effCount--;
                }
            }

            for (int i = 0; i < modifiers.Count; i++)
            {
                if (modifiers[i].effCount <= 0)
                {
                    modifiers.RemoveAt(i);
                    i--;
                }
            }
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
