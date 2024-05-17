using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Drawing.Drawing2D;
using System.Security.Cryptography.X509Certificates;
using System.IO;
namespace BrickBreaker
{
    public class Block
    {
        public int width = 50;
        public int height = 25;

        public int x;
        public int y; 
        public int hp;
        public int maxHp;
        public Color colour;

        public static Random rand = new Random();

        public List<Modifier> modifiers = new List<Modifier>();
        List<System.Windows.Media.MediaPlayer> ballHits = new List<System.Windows.Media.MediaPlayer>();

        const int TICSPEED = 50;
        int fireTic;

        public Block(int _x, int _y, int _hp, Color _colour)
        {
            x = _x;
            y = _y;
            hp = _hp;
            maxHp = _hp;
            colour = _colour;
            fireTic = TICSPEED;
        }

        public void StatUp(String startUp)
        {

            var sound = new System.Windows.Media.MediaPlayer();

            sound.Open(new Uri(Application.StartupPath + startUp));

            ballHits.Add(sound);

            ballHits[ballHits.Count - 1].Play();

        }

        public Ball PassCondition(Ball ball)
        {
            foreach (Modifier modifier in ball.modifiers)
            {
                if (modifier.mod.Contains("IMMINENT"))
                {
                    GameScreen.holeSong.Play();
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
                    if (modifier.mod.Contains("fire"))
                    {
                        StatUp("\\Resources\\barrel-exploding-soundbible (1).wav");
                    }
                    else
                    {
                        StatUp("Large Fireball-SoundBible.com-301502490.wav");
                    }

                    int explodeSize = 200;

                    List<Modifier> hold = new List<Modifier>();

                    foreach(Modifier mod in ball.modifiers)
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
