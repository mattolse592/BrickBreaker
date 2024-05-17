using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrickBreaker
{
    public partial class StatisticScreen : UserControl
    {
        Pen whiteBrush = new Pen(Color.White);
        int level = 0;
        int sandwiches = 0;
        List<Block> blocks = new List<Block>();
        System.Windows.Media.MediaPlayer bonusSong = new System.Windows.Media.MediaPlayer();

        public StatisticScreen(int currentLevel, List<Block> currentBlocks, int sandwiches_)
        {
            level = currentLevel;
            blocks = currentBlocks;
            sandwiches = sandwiches_;
            InitializeComponent();

            bonusSong.Open(new Uri(Application.StartupPath + "\\Resources\\2019-08-25_-_8bit-Smooth_Presentation_-_David_Fesliyan.wav"));
            bonusSong.MediaEnded += new EventHandler(bonusEnded);

            bonusSong.Play();

            XmlRw w = new XmlRw();
            w.getStatistics();

            this.label12.Text = w.totalBlocksDestoryed.ToString();
            Console.WriteLine($"sandwiches: {w.sandwichesEaten}");
            this.label11.Text = w.sandwichesEaten.ToString();
            this.Refresh();
        }

        private void bonusEnded(object sender, EventArgs e)
        {
            bonusSong.Stop();


            bonusSong.Play();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            GameScreen gameScreen = new GameScreen();
            gameScreen.blocks = blocks;
            gameScreen.currentLevel = level;
            gameScreen.loadGame = false;

            bonusSong.Stop();

            gameScreen.sandwiches = sandwiches;

            Form1.ChangeScreen(this, gameScreen);
        }

        private void StatisticScreen_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(whiteBrush, 25, 0, 25, 700);
            e.Graphics.DrawLine(whiteBrush, 1225, 0, 1225, 700);
            e.Graphics.DrawLine(whiteBrush, 225, 0, 225, 700);
            e.Graphics.DrawLine(whiteBrush, 425, 0, 425, 700);
            e.Graphics.DrawLine(whiteBrush, 625, 0, 625, 700);
            e.Graphics.DrawLine(whiteBrush, 825, 0, 825, 700);
            e.Graphics.DrawLine(whiteBrush, 1025, 0, 1025, 700);
        }
    }
}
