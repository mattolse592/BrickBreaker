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

        System.Windows.Media.MediaPlayer menuMusic = new System.Windows.Media.MediaPlayer();
        System.Windows.Media.MediaPlayer rickRoll = new System.Windows.Media.MediaPlayer();
        bool rolling = false;
        public static Font font = new Font(new FontFamily("Antiquity Print"), 55, FontStyle.Bold, GraphicsUnit.Pixel);


        List<System.Windows.Media.MediaPlayer> winSounds = new List<System.Windows.Media.MediaPlayer>();

        int speedX = 20;
        int speedY = 20;

        int redR = 0;
        bool reddening = true;

        public MenuScreen()
        {
            InitializeComponent();

            menuMusic.Open(new Uri(Application.StartupPath + "\\Resources\\2019-01-10_-_Land_of_8_Bits_-_Stephen_Bennett_-_FesliyanStudios.com.wav"));
            menuMusic.MediaEnded += new EventHandler(menuMusicEnded);
            menuMusic.Play();

            rickRoll.Open(new Uri(Application.StartupPath + "\\Resources\\Rick Astley - Never Gonna Give You Up (Official Music Video).wav"));
            rickRoll.MediaEnded += new EventHandler(rickEnded);

            ricktimer.Start();
        }

        private void GameStart()
        {

            var startSound = new System.Windows.Media.MediaPlayer();

            startSound.Open(new Uri(Application.StartupPath + "\\Resources\\Microsoft Windows XP Startup Sound.wav"));

            winSounds.Add(startSound);

            winSounds[winSounds.Count - 1].Play();

        }
        private void menuMusicEnded(object sender, EventArgs e)
        {
            menuMusic.Stop();

            menuMusic.Play();
        }

        private void rickEnded(object sender, EventArgs e)
        {
            rickRoll.Stop();

            rickRoll.Play();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            // Goes to the game screen
            GameStart();
            rickRoll.Stop();
            menuMusic.Stop();
            Form1.ChangeScreen(this, new GameScreen());
            ricktimer.Stop();
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

            rolling = !rolling;
            if (rolling)
            {
                menuMusic.Stop();
                rickRoll.Play();
                mrRoll.Visible = true;
            }
            else
            {
                rickRoll.Stop();
                menuMusic.Play();
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

            if (redR >= 255)
            {
                redR = 255;
                reddening = false;
            }
            else if (redR <= 0)
            {
                redR = 0;
                reddening = true;
            }

            if (reddening)
            {
                redR += 5;
            }
            else
            {
                redR -= 5;
            }

            Refresh();
        }

        private void MenuScreen_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(Properties.Resources.Sign, new Rectangle(225, -75, 800, 300));
            e.Graphics.DrawString("Rick's BrickBreakin'", font, new SolidBrush(Color.FromArgb(255, redR, redR ,redR)), new Point(250,25));
            e.Graphics.DrawString("DELI", font, new SolidBrush(Color.FromArgb(255, redR, redR, redR)), new Point(500, 25 + 75));
            //Benny Bagel! (by Grady Rueffer)
            e.Graphics.DrawImage(Properties.Resources.BennyBagel__6_f, new Rectangle(25, 350, 300, 250));
            e.Graphics.DrawImage(Properties.Resources.BennyBagel__6_, new Rectangle(this.Width - 25 - 300, 350, 300, 250));
        }
    }
}