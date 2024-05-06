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
        
        public StatisticScreen()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Form1.ChangeScreen(this, new GameScreen());
        }

        private void backButton_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine()
        }
    }
}
