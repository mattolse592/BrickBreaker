﻿/*  Created by: Matthew, Nathan, Grady, Valentina, and Duhrick
 *  Project: Brick Breaker Team Porject
 *  Date: May 13, 2024
 */
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
    public partial class GameScreen : UserControl
    {
        #region global values

        //player1 button control keys - DO NOT CHANGE
        Boolean leftArrowDown, rightArrowDown;

        // Game values
        public int currentLevel = 0;
        public bool loadGame = true;
        bool isSavedLevel = false;
        public static bool stick = true;

        // Level 10
        int maxN = 10;
        int minN = 4;

        // Paddle and Ball objects
        public static Paddle paddle;
        Ball ball;

        //upgrade varuables
        int widthCounter, paddleSpeedCounter = 0;
        // list of all blocks for current level
        public List<Block> blocks = new List<Block>();

        // Brushes
        SolidBrush paddleBrush = new SolidBrush(Color.White);
        SolidBrush ballBrush = new SolidBrush(Color.White);
        SolidBrush blockBrush = new SolidBrush(Color.Red);

        Pen sidebarPen = new Pen(Color.SaddleBrown, 3);
        SolidBrush transparentBrush = new SolidBrush(Color.Transparent);

        //Grady Stuff
        public static int speedModBX = 0, speedModBY = 0, speedModPX = 0, widthModP;

        List<System.Windows.Media.MediaPlayer> ballHits = new List<System.Windows.Media.MediaPlayer> ();

        List<System.Windows.Media.MediaPlayer> winSounds = new List<System.Windows.Media.MediaPlayer>();

        public static List<BlackHole> holes = new List<BlackHole>();
        int numHole = 0;

        List<Powerup> powerups = new List<Powerup>();
        List<Ball> balls = new List<Ball>();
        SolidBrush fireBrush = new SolidBrush(Color.Red);
        SolidBrush bombBrush = new SolidBrush(Color.Black);
        SolidBrush fireBallOuter = new SolidBrush(Color.OrangeRed);
        SolidBrush permBrush = new SolidBrush(Color.Purple);
        SolidBrush tagBrush = new SolidBrush(Color.BurlyWood);
        Pen blackHoleAcc = new Pen(Color.RoyalBlue);
        SolidBrush[] fadeBrush = {
            new SolidBrush(Color.FromArgb(25,0,0,0)),
            new SolidBrush(Color.FromArgb(50,0,0,0)),
            new SolidBrush(Color.FromArgb(75,0,0,0)),
            new SolidBrush(Color.FromArgb(100,0,0,0)),
            new SolidBrush(Color.FromArgb(125,0,0,0)),
            new SolidBrush(Color.FromArgb(150,0,0,0)),
            new SolidBrush(Color.FromArgb(175,0,0,0)),
            new SolidBrush(Color.FromArgb(200,0,0,0)),
            new SolidBrush(Color.FromArgb(225,0,0,0)),
            new SolidBrush(Color.FromArgb(250,0,0,0)),
        };
        System.Windows.Media.MediaPlayer[] music =
        {
            new System.Windows.Media.MediaPlayer(),
            new System.Windows.Media.MediaPlayer(),
            new System.Windows.Media.MediaPlayer(),
            new System.Windows.Media.MediaPlayer(),
            new System.Windows.Media.MediaPlayer()
        };

        public static System.Windows.Media.MediaPlayer holeSong = new System.Windows.Media.MediaPlayer();
        System.Windows.Media.MediaPlayer bonusSong = new System.Windows.Media.MediaPlayer();
        bool bonus = false;

        public static Font healthFont = new Font(new FontFamily("Arial"), 15, FontStyle.Bold, GraphicsUnit.Pixel);
        public static Font font = new Font(new FontFamily("Antiquity Print"), 30, FontStyle.Bold, GraphicsUnit.Pixel);
        public static Font mascot = new Font(new FontFamily("Antiquity Print"), 7, FontStyle.Bold, GraphicsUnit.Pixel);


        Random rnd = new Random();

        Image[] sandwichImages = new Image[7];
        Image[] bennyBagel = 
        { 
            Properties.Resources.BennyBagel__1_,
            Properties.Resources.BennyBagel__2_,
            Properties.Resources.BennyBagel__3_,
            Properties.Resources.BennyBagel__4_,
            Properties.Resources.BennyBagel__5_,
            Properties.Resources.BennyBagel__6_f,
            Properties.Resources.BennyBagel__7_,
            Properties.Resources.BennyBagel__8_,
            Properties.Resources.BennyBagel__9_
        };

        Image plate = Properties.Resources.Plate;
        Image deli = Properties.Resources.Deli;
        Image SandwichIcon = Properties.Resources.sandwich1;
        
        //currency
        public int sandwiches;

        int multiplier = 1;

        int upgrade1Cost = 5;
        int upgrade2Cost = 20;
        int upgrade3Cost = 50;
        int upgrade4Cost = 30;
        int upgrade5Cost = 200;
        int upgrade6Cost = 500;

        int score = 0;
        int blocksDestroyed = 0;

        public static int width;
        #endregion

        public GameScreen()
        {
            InitializeComponent();

            sandwichImages[0] = Properties.Resources.Sandwich__1_;
            sandwichImages[1] = Properties.Resources.Sandwich__2_;
            sandwichImages[2] = Properties.Resources.Sandwich__3_;
            sandwichImages[3] = Properties.Resources.Sandwich__7_;
            sandwichImages[4] = Properties.Resources.Sandwich__6_;
            sandwichImages[5] = Properties.Resources.Sandwich__5_;
            sandwichImages[6] = Properties.Resources.Sandwich__4_;


            music[0].Open(new Uri(Application.StartupPath + "\\Resources\\2021-08-30_-_Boss_Time_-_www.FesliyanStudios.com.wav"));
            music[1].Open(new Uri(Application.StartupPath + "\\Resources\\2021-10-19_-_Funny_Bit_-_www.FesliyanStudios.com (1).wav"));
            music[2].Open(new Uri(Application.StartupPath + "\\Resources\\2019-12-11_-_Retro_Platforming_-_David_Fesliyan.wav"));
            music[3].Open(new Uri(Application.StartupPath + "\\Resources\\2020-03-22_-_8_Bit_Surf_-_FesliyanStudios.com_-_David_Renda.wav"));
            music[4].Open(new Uri(Application.StartupPath + "\\Resources\\2021-08-16_-_8_Bit_Adventure_-_www.FesliyanStudios.com.wav"));
            holeSong.Open(new Uri(Application.StartupPath + "\\Resources\\BlackHole.wav"));
            bonusSong.Open(new Uri(Application.StartupPath + "\\Resources\\2020-04-24_-_Arcade_Kid_-_FesliyanStudios.com_-_David_Renda.wav"));

            music[0].MediaEnded += new EventHandler(music0Ended);
            music[1].MediaEnded += new EventHandler(music1Ended);
            music[2].MediaEnded += new EventHandler(music2Ended);
            music[3].MediaEnded += new EventHandler(music3Ended);
            music[4].MediaEnded += new EventHandler(music4Ended);
            holeSong.MediaEnded += new EventHandler(holeEnded);
            bonusSong.MediaEnded += new EventHandler(bonusEnded);

            OnStart();
        }

        #region sound plyaers

        private void holeEnded(object sender, EventArgs e)
        {
            holeSong.Stop();


            holeSong.Play();
        }

        private void bonusEnded(object sender, EventArgs e)
        {
            bonusSong.Stop();


            bonusSong.Play();
        }


        private void music0Ended(object sender, EventArgs e)
        {
            music[0].Stop();


            music[0].Play();
        }
        private void music1Ended(object sender, EventArgs e)
        {
            music[1].Stop();

            music[1].Play();
        }
        private void music2Ended(object sender, EventArgs e)
        {
            music[2].Stop();

            music[2].Play();
        }
        private void music3Ended(object sender, EventArgs e)
        {
            music[3].Stop();

            music[3].Play();
        }
        private void music4Ended(object sender, EventArgs e)
        {
            music[4].Stop();

            music[4].Play();
        }
        

        private void BallHit()
        {

            var ballSound = new System.Windows.Media.MediaPlayer();

            ballSound.Open(new Uri(Application.StartupPath + "\\Resources\\Dodge.wav"));

            ballHits.Add(ballSound);

            ballHits[ballHits.Count - 1].Play();

        }

        private void PlayFireball()
        {

            var sound = new System.Windows.Media.MediaPlayer();

            sound.Open(new Uri(Application.StartupPath + "\\Resources\\audiomass-output.wav"));

            ballHits.Add(sound);

            ballHits[ballHits.Count - 1].Play();

        }

        private void PlayBomb()
        {

            var sound = new System.Windows.Media.MediaPlayer();

            sound.Open(new Uri(Application.StartupPath + "\\Resources\\bomb-has-been-planted-sound-effect-cs-go.wav"));

            ballHits.Add(sound);

            ballHits[ballHits.Count - 1].Play();

        }

        private void Death()
        {

            var sound = new System.Windows.Media.MediaPlayer();

            sound.Open(new Uri(Application.StartupPath + "\\Resources\\i-am-become-death-youtube.wav"));

            ballHits.Add(sound);

            ballHits[ballHits.Count - 1].Play();

        }

        public void StatUp(String startUp)
        {

            var sound = new System.Windows.Media.MediaPlayer();

            sound.Open(new Uri(Application.StartupPath + startUp));

            ballHits.Add(sound);

            ballHits[ballHits.Count - 1].Play();

        }

        private void GameWin()
        {

            var winSound = new System.Windows.Media.MediaPlayer();

            winSound.Open(new Uri(Application.StartupPath + "\\Resources\\level-up-enhancement-8-bit-retro-sound-effect-153002.wav"));

            winSounds.Add(winSound);

            winSounds[winSounds.Count - 1].Play();

        }

        public void PlayMusic()
        {
            TurnMusicOff();
            int indexer = currentLevel % 5;
            music[indexer].Play();
        }

        void TurnMusicOff()
        {
            for (int i = 0; i < 5; i++)
            {
                music[i].Stop();
            }
        }
        #endregion

        void generateRandomStuff()
        {
            if (minN == 0 || currentLevel != 10)
            {
                return;
            }

            Random rand = new Random();

            if (minN != 4 && maxN != 10 && rand.Next(0, 1000) > 5)
            {
                return;
            }

            XmlRw w = new XmlRw();
            for (int i = 0; i < rand.Next(minN, maxN); i++)
            {
                int shape = rand.Next(0, 4);

                switch (shape)
                {
                    case 0:
                        w.bigBlock(rand.Next(2, 5), rand.Next(1, 14), rand.Next(14));
                        break;
                    case 1:
                        w.line(rand.Next(0, 2) == 0, rand.Next(2, 7), rand.Next(1, 14), rand.Next(14));
                        break;
                    case 2:
                        w.triangleBlocks(true, rand.Next(1, 6), rand.Next(1, 14), rand.Next(1, 14));
                        break;
                    default:
                        break;
                }
            }

            for (int i = 0; i < w.blocks.Count; i++)
            {
                w.blocks[i].hp = rand.Next(11, 199);
                w.blocks[i].x += w.blocks[i].x * 57;
                w.blocks[i].y += w.blocks[i].y * 32;
                blocks.Add(w.blocks[i]);
            }

            minN -= 1;
            maxN -= 3;
        }

        public void nextLevel()
        {
            if (currentLevel >= 10)
            {
                currentLevel = 1;
            }
            else if (currentLevel == 9)
            {
                generateRandomStuff();
                currentLevel += 1;
                return;
            }
            else
            {
                currentLevel++;
            }


            stick = true;

            Nathan_loadLevel();
        }
        /*
        public void PlayMusic()
        {
            TurnMusicOff();
            int indexer = currentLevel % 5;
            music[indexer].Play();
        }

        void TurnMusicOff()
        {
            for (int i = 0; i < music.Length; i++)
            {
                music[i].Stop();
            }
        }
        */
       public void OnStart()
        {
            // if the black hole was purchased less than 5 times, clear it
            if (numHole < 5)
            {
                holes.Clear();
                holeSong.Stop();
            }

            //set all button presses to false.
            leftArrowDown = rightArrowDown = false;

            // setup starting paddle values and create paddle object
            int paddleWidth = 80;
            int paddleHeight = 20;
            int paddleX = ((this.Width / 2) - (paddleWidth / 2));
            int paddleY = (this.Height - paddleHeight) - 60;
            int paddleSpeed = 8;
            paddle = new Paddle(paddleX, paddleY, paddleWidth, paddleHeight, paddleSpeed, Color.White);

            balls.Clear();

            // setup starting ball values
            int ballX = this.Width / 2 - 10;
            int ballY = this.Height - paddle.height - 80;

            // Creates a new ball
            int xSpeed = 6;
            int ySpeed = 6;
            int ballSize = 20;
            ball = new Ball(ballX, ballY, xSpeed, ySpeed, ballSize);

            //Grady Code
            balls.Add(new Ball(ball.x, ball.y, ball.xSpeed, ball.ySpeed, ball.size, new List<Modifier> { new Modifier("PERM") }));

            #region Creates blocks for generic level. Need to replace with code that loads levels.

            //TODO - replace all the code in this region eventually with code that loads levels from xml files

            blocks.Clear();


            //Nathan_loadLevel();
            if (loadGame == true)
            {
                nextLevel();
                PlayMusic();
                if (bonus)
                {
                    bonusSong.Stop();
                    bonus = false;
                }
                ballHits.Clear();
            }

            #endregion

            //derick 
            width = this.Width;


            // start the game engine loop
            gameTimer.Enabled = true;
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //player 1 button presses
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Up:
                    if (stick)
                    {
                        stick = false;
                        if (balls[0].ySpeed > 0)
                        {
                            balls[0].ySpeed *= -1;
                        }

                        int mag = (int)Math.Sqrt(Math.Pow(ball.y + 2, 2) + Math.Pow(ball.x - ball.throwX, 2));
                        float yScale = (((float)balls[0].y + 2) / mag);
                        float xScale = (((float)balls[0].x - balls[0].throwX) / mag);

                        if (xScale < 0)
                        {
                            xScale *= -1;
                        }


                        balls[0].xSpeed = Math.Abs(ball.xSpeed);

                        balls[0].defaultSpeedX = (int)(16 * xScale);
                        balls[0].defaultSpeedY = (int)(16 * yScale);

                        if (balls[0].x + (balls[0].size / 2) > balls[0].throwX)
                        {
                            balls[0].xSpeed *= -1;
                        }
                    }
                    break;
                case Keys.F:
                    powerups.Add(new Powerup("PW", 5));
                    powerups.Add(new Powerup("BE", new List<Modifier> { new Modifier("explode") }));
                    //powerups.Add(new Powerup("P", new List<Modifier> { new Modifier("fire") }));
                    break;
                case Keys.G:
                    PlayFireball();
                    powerups.Add(new Powerup("BB4", new List<Modifier> { new Modifier("fire", 500) }));
                    break;
                case Keys.H:
                    powerups.Add(new Powerup("BH"));
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                default:
                    break;
            }
        }
        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            //player 1 button releases
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = false;
                    //powerups.Add(new Powerup("BB4", new List<Modifier> { new Modifier("fire", 5)}));
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    //powerups.Add(new Powerup("P", new List<Modifier> { new Modifier("fire") }));
                    break;
                default:
                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            // Move the paddle
            if (leftArrowDown == true && paddle.x > 0)
            {
                paddle.Move("left");
            }
            if (rightArrowDown == true && paddle.x + paddle.width < 950)
            {
                paddle.Move("right");
            }

            //shop feature
            ShopBackColor();

            Grady();
            generateRandomStuff();

            //redraw the screen
            Refresh();
        }

        void Grady()
        {
            speedModPX = 0;
            speedModBY = 0;
            speedModBX = 0;

            for (int i = 0; i < balls.Count; i++)
            {
                Ball tempBall = new Ball(balls[i].x, balls[i].y, balls[i].xSpeed, balls[i].ySpeed, balls[i].size, balls[i].modifiers);
                balls[i].Move();

                // Check for collision with top and side walls
                String hold = balls[i].WallCollision(this);

                if (hold != "")
                {
                    StatUp(hold);
                }

                // Check for collision of ball with paddle, (incl. paddle movement)
                String pad = balls[i].PaddleCollision(paddle);
                if (pad != "")
                {
                    StatUp(pad);
                }

                if (blocks.Count == 0)
                {
                    gameTimer.Enabled = false;
                    GameWin(); // play sounds
                    OnStart();
                    return;
                }

                // Check if ball has collided with any blocks
                for (int j = 0; j < blocks.Count; j++)
                {
                    if (balls[i].BlockCollision(blocks[j]))
                    {
                        BallHit();
                        score += 1;
                        balls[i] = blocks[j].PassCondition(balls[i]);
                        //add points to the player
                        sandwiches = sandwiches + multiplier;
                        if (blocks[j].hp <= 0)
                        {
                            blocks.RemoveAt(j);
                            j--;
                            blocksDestroyed++;
                        }
                    }

                    if (j >= 0)
                    {
                        blocks[j].CleanModifiers();
                    }
                }

                balls[i].CleanModifiers();
                balls[i].SetCurrent();

                if (balls[i].modifiers.Any())
                {
                    if (balls[i].modifiers[balls[i].modifiers.Count - 1].mod == "remove")
                    {
                        if (balls[i].CheckFor("PERM"))
                        {
                            stick = true;
                        }
                        else
                        {
                            balls.Remove(balls[i]);
                            i--;
                        }
                    }
                    else if (balls[i].BottomCollision(this) || (balls[i].CheckFor("temp") && (tempBall.xSpeed != balls[i].xSpeed || tempBall.ySpeed != balls[i].ySpeed)))
                    {
                        if (balls[i].BottomCollision(this))
                        {
                            sandwiches -= 5;
                            StatUp("\\Resources\\mixkit-8-bit-lose-2031.wav");
                        }

                        if (balls[i].CheckFor("PERM"))
                        {
                            stick = true;
                        }
                        else
                        {
                            balls.Remove(balls[i]);
                            i--;
                        }
                    }
                }


                // Check for ball hitting bottom of screen
                else if (balls[i].BottomCollision(this) || (balls[i].CheckFor("temp") && (tempBall.xSpeed != balls[i].xSpeed || tempBall.ySpeed != balls[i].ySpeed)))
                {
                    sandwiches -= 5;
                    if (balls[i].CheckFor("PERM"))
                    {
                        stick = true;
                    }
                    else
                    {
                        balls.Remove(balls[i]);
                        i--;
                    }
                }
            }

            for (int j = 0; j < blocks.Count; j++)
            {
                blocks[j].CleanModifiers();
                blocks[j].setCurrent();
                if (blocks[j].hp <= 0)
                {
                    blocks.RemoveAt(j);
                    j--;
                }
            }

            for (int i = 0; i < powerups.Count; i++)
            {
                balls = powerups[i].Effect(balls);
                if (powerups[i].CheckFor("remove"))
                {
                    powerups.RemoveAt(i);
                    i--;
                }
            }

            paddle.CalibrateWidth();

            if (holes.Count > 0)
            {
                foreach (BlackHole hole in holes)
                {
                    balls = hole.Pull(balls);
                    if (hole.interWBlocks)
                    {
                        blocks = hole.Pull(blocks);
                    }

                    if (hole.consumeBall)
                    {
                        balls = hole.BeyondHorizon(balls);
                    }

                    if (hole.consumeBlock)
                    {
                        if (hole.interWBlocks)
                        {
                            blocks = hole.BeyondHorizon(blocks);
                        }
                    }


                    hole.DrawPoints();
                }
            }
        }

        void CleanPowerups()
        {
            for (int i = 0; i < powerups.Count; i++)
            {
                for (int j = 0; j < powerups.Count; j++)
                {
                    if (powerups[i] == powerups[j] && i != j)
                    {
                        powerups.RemoveAt(j);
                        j--;
                    }
                }
            }
        }

        // Level loading
        void Nathan_loadLevel()
        {
            string file;

            if (isSavedLevel)
            {
                file = $"level_save{currentLevel}.xml";
            }
            else
            {
                file = $"level{currentLevel}.xml";
            }

            XmlRw xmlRw = new XmlRw();
            int ret = xmlRw.loadLevel(file);

            switch (ret)
            {
                // ``loadLevel`` will return ``XML_READ_ERR`` until powerups are implemented for XmlRw
                case XmlRw.SUCCESS | XmlRw.XML_READ_ERR:
                    foreach (Block block in xmlRw.blocks)
                    {
                        // Add spacing between blocks
                        block.x += 57 * block.x;
                        block.y += 32 * block.y;
                        if (currentLevel == 9)
                        {
                            block.width = 200;
                            block.height = 150;
                        }
                        block.maxHp = block.hp;
                        blocks.Add(block);
                    }
                    break;
                default:
                    Console.WriteLine("oops");
                    break;
            }
        }

        //shop
        #region upgrade panel click events
        private void upgrade1Panel_Click(object sender, EventArgs e)
        {
            if (sandwiches >= upgrade1Cost)
            {
                sandwiches = sandwiches - upgrade1Cost;
                powerups.Add(new Powerup("PW"));
                widthCounter++;
                upgrade1Quantity.Text = $"{widthCounter}";
                StatUp("\\Resources\\world-of-warcraft-lvl-up.wav");
            }
        }

        private void upgrade2Panel_Click(object sender, EventArgs e)
        {
            if (sandwiches >= upgrade2Cost)
            {
                sandwiches = sandwiches - upgrade2Cost;
                paddle.speed = paddle.speed + 1 % 6;
                paddleSpeedCounter++;
                upgrade2Quantity.Text = $"{paddleSpeedCounter}";
                StatUp("\\Resources\\33174986-ed27-49fb-b3e7-dac93a3def3f.wav");
            }
        }

        private void upgrade3Panel_Click(object sender, EventArgs e)
        {
            if (sandwiches >= upgrade3Cost)
            {
                sandwiches = sandwiches - upgrade3Cost;
                multiplier++;
                upgrade3Quantity.Text = multiplier + "x";
                StatUp("\\Resources\\ffxiv_level_up.wav");
            }
        }

        private void upgrade4Quantity_Click(object sender, EventArgs e)
        {
            if (sandwiches >= upgrade4Cost)
            {
                sandwiches = sandwiches - upgrade4Cost;
                Random rnd = new Random();
                if (rnd.Next(0, 2) == 0)
                {
                    powerups.Add(new Powerup("BB" + rnd.Next(2, 10).ToString(), new List<Modifier> { new Modifier("fire", 500) }));
                }
                else
                {
                    powerups.Add(new Powerup("BBC" + rnd.Next(2, 10).ToString(), new List<Modifier> { new Modifier("fire", 500) }));
                }
                PlayFireball();
            }
        }
        //black hole upgrade 
        private void upgrade5Panel_Click(object sender, EventArgs e)
        {
            if (sandwiches >= upgrade5Cost)
            {
                sandwiches = sandwiches - upgrade5Cost;
                Death();
                numHole++;
                powerups.Add(new Powerup("BH"));
                upgrade5Description.Font = new Font(upgrade5Description.Font.FontFamily, 5);
                switch (numHole)
                {
                    case 1:
                        upgrade5Description.Text = "They say the real importance of atomic energy does not lie in the weapons that have been made; the real importance lies in all the great benefits which atomic energy, which the various radiations, will bring to mankind.";
                        break;
                    case 2:
                        upgrade5Description.Text = "I am sure that there is truth in it, because there has never in the past been a new field opened up where the real fruits of it have not been invisible at the beginning.";
                        break;
                    case 3:
                        upgrade5Description.Text = "There are others who try to escape the immediacy of this situation by saying that, after all, war has always been very terrible; after all, weapons have always gotten worse and worse;";
                        break;
                    case 4:
                        upgrade5Description.Text = "I think it is for us to accept it as a very grave crisis, to realize that these atomic weapons which we have started to make are very terrible, that they involve a change, that they are not just a slight modification.";
                        break;
                    case 5:
                        upgrade5Description.Text = "“When I came to you with those calculations, we thought we might start a chain reaction that would destroy the world.”\n“What of it?”\n“I believe we did.”";
                        break;
                }
            }
        }
        //purchase randomized level
        private void upgrade6Panel_Click(object sender, EventArgs e)
        {
            if (sandwiches >= upgrade6Cost)
            {
                sandwiches = sandwiches - upgrade6Cost;
                currentLevel = 10;

                TurnMusicOff();
                bonus = true;
                bonusSong.Play();

                generateRandomStuff();

            }
        }
        #endregion
        void ShopBackColor()
        {
            if (sandwiches >= 20)
            {
                htpButton.BackColor = Color.Tan;
            }
            else
            {
                htpButton.BackColor = Color.Peru;
            }

            if (sandwiches >= upgrade1Cost)
            {
                upgrade1Panel.BackColor = Color.Tan;
            }
            else
            {
                upgrade1Panel.BackColor = Color.Peru;
            }

            if (sandwiches >= upgrade2Cost)
            {
                upgrade2Panel.BackColor = Color.Tan;
            }
            else
            {
                upgrade2Panel.BackColor = Color.Peru;
            }

            if (sandwiches >= upgrade3Cost)
            {
                upgrade3Panel.BackColor = Color.Tan;
            }
            else
            {
                upgrade3Panel.BackColor = Color.Peru;
            }

            if (sandwiches >= upgrade4Cost)
            {
                upgrade4Panel.BackColor = Color.Tan;
            }
            else
            {
                upgrade4Panel.BackColor = Color.Peru;
            }

            if (sandwiches >= upgrade5Cost)
            {
                upgrade5Panel.BackColor = Color.Tan;
            }
            else
            {
                upgrade5Panel.BackColor = Color.Peru;
            }

            if (sandwiches >= upgrade6Cost)
            {
                upgrade6Panel.BackColor = Color.Tan;
            }
            else
            {
                upgrade6Panel.BackColor = Color.Peru;
            }

        }

        private void htpButton_Click(object sender, EventArgs e)
        {
            if (sandwiches >= 20)
            {
                PlayBomb();
                sandwiches = sandwiches - 20;
                powerups.Add(new Powerup("BE", new List<Modifier> { new Modifier("explode") }));
            }
        }

        private void exitLabel_Click(object sender, EventArgs e)
        {
            XmlRw w = new XmlRw();
            w.writeStatistics(blocksDestroyed, score, currentLevel, sandwiches);


            TurnMusicOff();
            gameTimer.Enabled = false;
            Form1.ChangeScreen(this, new MenuScreen());

        }

        private void statisticsButton_Click(object sender, EventArgs e)
        {
            TurnMusicOff();
            gameTimer.Enabled = false;
            Form1.ChangeScreen(this, new StatisticScreen(currentLevel, blocks, sandwiches));
        }

        // Save level
        void Nathan_saveLevel()
        {
            XmlRw saver = new XmlRw();
            saver.saveLevel($"level_save{currentLevel}.xml", blocks);
        }

        public void OnEnd()
        {
            // Goes to the game over screen
            gameTimer.Enabled = false;
            Form1.ChangeScreen(this, new MenuScreen());

            //TODO: save the file to xml
        }

        public void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(deli, 0, 0, 950, this.Height);

            foreach (BlackHole hole in holes)
            {
                e.Graphics.FillEllipse(bombBrush, hole.schwartzchild);
                for (int i = 9; i >= 0; i--)
                {
                    e.Graphics.FillEllipse(fadeBrush[9 - i], new Rectangle(hole.x - ((i + 1) * (hole.pullField / 10)), hole.y - ((i + 1) * (hole.pullField / 10)), 2 * (i + 1) * (hole.pullField / 10), 2 * (i + 1) * (hole.pullField / 10)));
                }

                foreach (PointF point in hole.points)
                {
                    e.Graphics.DrawEllipse(blackHoleAcc, new RectangleF(hole.x, hole.y, point.X - hole.x, point.Y - hole.y));
                }
            }

            // Draws paddle
            e.Graphics.DrawImage(plate, paddle.x, paddle.y, paddle.width, paddle.height);

            //Grady
            foreach (Ball b in balls)
            {
                if (b.CheckFor("PERM"))
                {
                    e.Graphics.FillEllipse(permBrush, b.x, b.y, b.size, b.size);

                    if (b.CheckFor("fade"))
                    {
                        b.MakeBallRec();
                        e.Graphics.FillEllipse(fireBallOuter, b.ballRec.X + 5, b.ballRec.Y + 5, b.ballRec.Width - 10, b.ballRec.Height - 10);
                    }
                    else if (b.CheckFor("fire"))
                    {
                        e.Graphics.FillEllipse(fireBrush, b.ballRec.X + 5, b.ballRec.Y + 5, b.ballRec.Width - 10, b.ballRec.Height - 10);
                    }
                    else if (b.CheckFor("explode"))
                    {
                        e.Graphics.FillEllipse(bombBrush, b.ballRec.X + 5, b.ballRec.Y + 5, b.ballRec.Width - 10, b.ballRec.Height - 10);
                    }
                    else
                    {
                        e.Graphics.FillEllipse(ballBrush, b.ballRec.X + 5, b.ballRec.Y + 5, b.ballRec.Width - 10, b.ballRec.Height - 10);
                    }
                }
                else
                {
                    if (b.CheckFor("fade"))
                    {
                        b.MakeBallRec();
                        e.Graphics.FillEllipse(fireBallOuter, b.ballRec.X, b.ballRec.Y, b.ballRec.Width, b.ballRec.Height);
                    }
                    else if (b.CheckFor("fire"))
                    {
                        e.Graphics.FillEllipse(fireBrush, b.x, b.y, b.size, b.size);
                    }
                    else if (b.CheckFor("explode"))
                    {
                        e.Graphics.FillEllipse(bombBrush, b.x, b.y, b.size, b.size);
                    }
                    else
                    {
                        e.Graphics.FillEllipse(ballBrush, b.x, b.y, b.size, b.size);
                    }
                }
            }

            //draw blocks
            foreach (Block b in blocks)
            {

                SolidBrush brush = new SolidBrush(b.colour);
            
                e.Graphics.FillRectangle(brush, b.x, b.y, b.width, b.height);

                e.Graphics.FillRectangle(bombBrush, b.x, b.y, b.width, b.height);

                if (b.hp >= b.maxHp)
                {
                    e.Graphics.DrawImage(sandwichImages[0], b.x, b.y, b.width, b.height);
                }
                else if (b.hp >= (float)6 * ((float)b.maxHp / 7))
                {
                    e.Graphics.DrawImage(sandwichImages[1], b.x, b.y, b.width, b.height);
                }
                else if (b.hp >= (float)5 * ((float)b.maxHp / 7))
                {
                    e.Graphics.DrawImage(sandwichImages[2], b.x, b.y, b.width, b.height);
                }
                else if (b.hp >= (float)4 * ((float)b.maxHp / 7))
                {
                    e.Graphics.DrawImage(sandwichImages[3], b.x, b.y, b.width, b.height);
                }
                else if (b.hp >= (float)3 * ((float)b.maxHp / 7))
                {
                    e.Graphics.DrawImage(sandwichImages[4], b.x, b.y, b.width, b.height);
                }
                else if (b.hp >= (float)2 * ((float)b.maxHp / 7))
                {
                    e.Graphics.DrawImage(sandwichImages[5], b.x, b.y, b.width, b.height);
                }
                else 
                {
                    e.Graphics.DrawImage(sandwichImages[6], b.x, b.y, b.width, b.height);
                }

                e.Graphics.DrawString(b.hp.ToString(), healthFont, ballBrush, b.x, b.y);
            }

            //Derick 
            if (stick)
            {
                e.Graphics.DrawLine(sidebarPen, new Point(balls[0].throwX, 0), new Point(balls[0].x + (balls[0].size / 2), balls[0].y + 2));
            }

            e.Graphics.FillRectangle(tagBrush, 950, 0, this.Width - 950, this.Height);
            //Valentina
            //Shop sidebar
            e.Graphics.DrawRectangle(sidebarPen, 950, 0, 1, 700);

            e.Graphics.DrawRectangle(sidebarPen, 950, 0, 300, 100);
            e.Graphics.DrawRectangle(sidebarPen, 950, 0, 300, 200);
            e.Graphics.DrawRectangle(sidebarPen, 950, 0, 300, 300);
            e.Graphics.DrawRectangle(sidebarPen, 950, 0, 300, 400);
            e.Graphics.DrawRectangle(sidebarPen, 950, 0, 300, 500);
            e.Graphics.DrawRectangle(sidebarPen, 950, 0, 300, 600);

            e.Graphics.DrawImage(SandwichIcon, 0, this.Height - 75, 100, 75);
            e.Graphics.DrawString(sandwiches.ToString(), font, new SolidBrush(Color.LightGreen), 5, this.Height - 62);

            //Benny Bagel!
            e.Graphics.DrawImage(bennyBagel[rnd.Next(0, 9)], this.Width - 95, 10, 75, 75);
            e.Graphics.DrawString("Benny Bagel", mascot, paddleBrush, this.Width - 85, 87);
        }

    }
}
