/*  Created by: 
 *  Project: Brick Breaker
 *  Date: 
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

namespace BrickBreaker
{
    public partial class GameScreen : UserControl
    {
        #region global values

        //player1 button control keys - DO NOT CHANGE
        Boolean leftArrowDown, rightArrowDown;

        // Game values
        int currentLevel = 0;
        bool isSavedLevel = false;
        public static bool stick = false;

        // Paddle and Ball objects
        public static Paddle paddle;
        Ball ball;

        // list of all blocks for current level
        List<Block> blocks = new List<Block>();

        // Brushes
        SolidBrush paddleBrush = new SolidBrush(Color.White);
        SolidBrush ballBrush = new SolidBrush(Color.White);
        SolidBrush blockBrush = new SolidBrush(Color.Red);

        Pen sidebarPen = new Pen(Color.SaddleBrown, 3);
        SolidBrush transparentBrush = new SolidBrush(Color.Transparent);

        //Grady Stuff
        public static int speedModBX = 0, speedModBY = 0, speedModPX = 0, widthModP;

        public List<BlackHole> holes = new List<BlackHole>();

        List<Powerup> powerups = new List<Powerup>();
        List<Ball> balls = new List<Ball>();
        SolidBrush fireBrush = new SolidBrush(Color.Red);
        SolidBrush bombBrush = new SolidBrush(Color.Black);
        SolidBrush fireBallOuter = new SolidBrush(Color.OrangeRed);


        public static Font healthFont = new Font(new FontFamily("Arial"), 15, FontStyle.Bold, GraphicsUnit.Pixel);

        //currency
        int sandwiches;
        Rectangle rec1 = new Rectangle(950, 200, 300, 100);

        int score = 0;
        int blocksDestroyed = 0;

        public static int width;
        #endregion

        public GameScreen()
        {
            InitializeComponent();
            OnStart();

            //holes.Add(new BlackHole(this.Width / 2, this.Height / 2, 2, 100, true));

        }


        public void OnStart()
        {
            // For now
            if (currentLevel == 10)
            {
                currentLevel = 1;
            }
            else
            {
                currentLevel++;
            }


            sandwiches = 0;
            //sandwichLabel.Text = $"{sandwiches}";

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


            Nathan_loadLevel();


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
                        if (ball.ySpeed > 0)
                        {
                            ball.ySpeed *= -1;
                        }

                        int mag = (int)Math.Sqrt(Math.Pow(ball.y + 2, 2) + Math.Pow(ball.x - ball.throwX, 2));
                        float yScale = (((float)ball.y + 2) / mag);
                        float xScale = (((float)ball.x - ball.throwX) / mag);

                        if (xScale < 0)
                        {
                            xScale *= -1;
                        }

                        ball.xSpeed = Math.Abs(ball.xSpeed); ;

                        ball.defaultSpeedX = (int)(6 * xScale);
                        ball.defaultSpeedY = (int)(6 * yScale);

                        if (ball.x + (ball.size / 2) > ball.throwX)
                        {
                            ball.xSpeed *= -1;
                        }
                    }
                    break;
                case Keys.F:
                    powerups.Add(new Powerup("PW"));
                    //powerups.Add(new Powerup("BE", new List<Modifier> { new Modifier("explode") }));
                    //powerups.Add(new Powerup("P", new List<Modifier> { new Modifier("fire") }));
                    break;
                case Keys.G:
                    powerups.Add(new Powerup("BB4", new List<Modifier> { new Modifier("fire", 500) }));
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

            // Move ball
            ball.Move();

            // Check for collision with top and side walls

            ball.WallCollision(this);

            // Check for ball hitting bottom of screen
            if (ball.BottomCollision(this))
            {

                stick = true;


                // Moves the ball back to origin

            }

            // Check for collision of ball with paddle, (incl. paddle movement)
            ball.PaddleCollision(paddle);


            // Check if ball has collided with any blocks
            foreach (Block b in blocks)
            {
                if (ball.BlockCollision(b))
                {



                    if (b.hp <= 0)
                    {
                        blocks.Remove(b);
                    }
                    b.PassCondition(ball);

                    if (blocks.Count == 0)
                    {
                        gameTimer.Enabled = false;
                        OnEnd();
                    }

                    break;
                }
            }

            Grady();

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
                balls[i].WallCollision(this);

                // Check for collision of ball with paddle, (incl. paddle movement)
                balls[i].PaddleCollision(paddle);

                if (blocks.Count == 0)
                {
                    gameTimer.Enabled = false;
                    OnStart(); // Restart game
                    return;
                }

                // Check if ball has collided with any blocks
                for (int j = 0; j < blocks.Count; j++)
                {
                    //stinky bum
                    if (balls[i].BlockCollision(blocks[j]))
                    {
                        score += 1;
                        balls[i] = blocks[j].PassCondition(balls[i]);

                        if (blocks[j].hp <= 0)
                        {
                            blocks.RemoveAt(j);
                            j--;
                            blocksDestroyed += 1;
                        }

                        if (blocks.Count == 0)
                        {
                            gameTimer.Enabled = false;
                            OnStart(); // Restart game
                            return;
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
                    blocks = hole.Pull(blocks);
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
                        blocks.Add(block);
                    }
                    break;
                default:
                    Console.WriteLine("oops");
                    break;
            }
        }



        //Shop Controls
        private void GameScreen_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (rec1.Contains(new Point(e.X, e.Y)) && sandwiches == 30)
                {
                    sandwiches = sandwiches - 30;
                    //sandwichLabel.Text = $"{sandwiches}";
                }
            }
        }
        private void exitLabel_Click(object sender, EventArgs e)
        {
            gameTimer.Enabled = false;
            Form1.ChangeScreen(this, new MenuScreen());

        }

        private void statisticsButton_Click(object sender, EventArgs e)
        {
            Form1.ChangeScreen(this, new StatisticScreen());
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
            Form1.ChangeScreen(this, new MenuScreen());

            //TODO: save the file to xml
        }

        public void GameScreen_Paint(object sender, PaintEventArgs e)
        {

            // Draws paddle
            paddleBrush.Color = paddle.colour;
            e.Graphics.FillRectangle(paddleBrush, paddle.x, paddle.y, paddle.width, paddle.height);

            //Grady
            foreach (Ball b in balls)
            {
                if (b.CheckFor("PERM"))
                {
                    e.Graphics.FillEllipse(ballBrush, b.x, b.y, b.size, b.size);

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

            foreach (BlackHole hole in holes)
            {
                e.Graphics.FillEllipse(bombBrush, hole.schwartzchild);
                e.Graphics.DrawEllipse(sidebarPen, new Rectangle(hole.x - hole.pullField, hole.y - hole.pullField, hole.pullField * 2, hole.pullField * 2));
            }

            //draw blocks
            foreach (Block b in blocks)
            {
                SolidBrush brush = new SolidBrush(b.colour);
                e.Graphics.FillRectangle(brush, b.x, b.y, b.width, b.height);
                e.Graphics.DrawString(b.hp.ToString(), healthFont, ballBrush, b.x, b.y);
            }

            //Derick 
            if (stick)
            {
                e.Graphics.DrawLine(sidebarPen, new Point(ball.throwX, 0), new Point(ball.x + (ball.size / 2), ball.y + 2));
            }

            //Valentina
            //Shop sidebar
            e.Graphics.DrawRectangle(sidebarPen, 950, 0, 1, 700);

            e.Graphics.DrawRectangle(sidebarPen, 950, 0, 300, 100);
            e.Graphics.DrawRectangle(sidebarPen, 950, 0, 300, 200);
            e.Graphics.DrawRectangle(sidebarPen, 950, 0, 300, 300);
            e.Graphics.DrawRectangle(sidebarPen, 950, 0, 300, 400);
            e.Graphics.DrawRectangle(sidebarPen, 950, 0, 300, 500);
            e.Graphics.DrawRectangle(sidebarPen, 950, 0, 300, 600);

            e.Graphics.FillRectangle(transparentBrush, rec1);

        }

    }
}
