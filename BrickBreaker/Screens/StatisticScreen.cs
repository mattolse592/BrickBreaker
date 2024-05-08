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
        public StatisticScreen()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Form1.ChangeScreen(this, new GameScreen());
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
