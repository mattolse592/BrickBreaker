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

        public StatisticScreen(int currentLevel, List<Block> currentBlocks, int sandwiches_)
        {
            level = currentLevel;
            blocks = currentBlocks;
            sandwiches = sandwiches_;
            InitializeComponent();

            XmlRw w = new XmlRw();
            w.getStatistics();

            this.label12.Text = w.totalBlocksDestoryed.ToString();
            Console.WriteLine($"sandwiches: {w.sandwichesEaten}");
            this.label11.Text = w.sandwichesEaten.ToString();
            this.Refresh();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            GameScreen gameScreen = new GameScreen();
            gameScreen.blocks = blocks;
            gameScreen.currentLevel = level;
            gameScreen.loadGame = false;
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
