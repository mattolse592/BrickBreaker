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
        public Color colour;

        public static Random rand = new Random();

        public List<Modifier> modifiers = new List<Modifier>();
        

        const int TICSPEED = 50;
        int fireTic;

        public Block(int _x, int _y, int _hp, Color _colour)
        {
            x = _x;
            y = _y;
            hp = _hp;
            colour = _colour;
            fireTic = TICSPEED;
        }

        public void PassCondition(Ball ball)
        {
            foreach (Modifier modifier in ball.modifiers)
            {
                if (modifier.mod.Contains("fire"))
                {
                    modifiers.Add(new Modifier("ONFIRE", modifier.effCount));
                }
            }
        }

        public void setCurrent()
        {
            foreach (Modifier modifier in modifiers)
            {
                if (modifier.mod ==("ONFIRE"))
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
