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
        int speedX = 20;
        int speedY = 20;
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

        private void instructionButton_Click(object sender, EventArgs e)
        {
            if (ricktimer.Enabled == false)
            {
                ricktimer.Enabled = true;
                mrRoll.Visible = true;
            }
            else
            {
                ricktimer.Enabled = false;
                mrRoll.Visible = false;
            }
        }

        private void ricktimer_Tick(object sender, EventArgs e)
        {
            mrRoll.Location = new Point(mrRoll.Location.X + speedX, mrRoll.Location.Y + speedY);

            if (mrRoll.Location.X + mrRoll.Width > this.Width || mrRoll.Location.X < 0)
            {
                speedX *= -1;
            }

            if (mrRoll.Location.Y + mrRoll.Height > this.Height || mrRoll.Location.Y < 0)
            {
                speedY *= -1;
            }
        }
    }
}
