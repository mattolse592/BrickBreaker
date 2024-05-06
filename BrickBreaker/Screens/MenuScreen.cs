using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrickBreaker
{
    public partial class MenuScreen : UserControl
    {
        public MenuScreen()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            // Goes to the game screen
            Form1.ChangeScreen(this, new GameScreen());
        }

        private void resetButton_Click(object sender, EventArgs e)
        {

            yesButton.Visible = true;
            noButton.Visible = true;
            arsBackgroundLabel.Visible = true;
        }

        private void noButton_Click(object sender, EventArgs e)
        {
            arsBackgroundLabel.Visible = false;
            yesButton.Visible = false;
            noButton.Visible = false;
        }

        private void yesButton_Click(object sender, EventArgs e)
        {
            //reset the xml file
            //don't totatlly delete it, just create another one and then put that in place if possible
        }
    }
}
