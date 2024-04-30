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

namespace BrickBreaker
{
    public partial class GameScreen : UserControl
    {
        #region global values

        //player1 button control keys - DO NOT CHANGE
        Boolean leftArrowDown, rightArrowDown;

        // Game values
        int lives;
        int currentLevel;
        bool isSavedLevel = false;

        // Paddle and Ball objects
        Paddle paddle;
        Ball ball;

        // list of all blocks for current level
        List<Block> blocks = new List<Block>();

        // Brushes
        SolidBrush paddleBrush = new SolidBrush(Color.White);
        SolidBrush ballBrush = new SolidBrush(Color.White);
        SolidBrush blockBrush = new SolidBrush(Color.Red);

        Pen sidebarPen = new Pen(Color.SaddleBrown, 3);

        //Grady Stuff
        public static int speedModBX = 0, speedModBY = 0, speedModPX = 0;

        List<Powerup> powerups = new List<Powerup>();
        List<Ball> balls = new List<Ball>();
        SolidBrush fireBrush = new SolidBrush(Color.Red);


        public static Font healthFont = new Font(new FontFamily("Arial"), 15, FontStyle.Bold, GraphicsUnit.Pixel);



        #endregion

        public GameScreen()
        {
            InitializeComponent();
            OnStart();
        }


        public void OnStart()
        {
            //set life counter
            lives = 3;
            // For now
            currentLevel = 1;

            //set all button presses to false.
            leftArrowDown = rightArrowDown = false;

            // setup starting paddle values and create paddle object
            int paddleWidth = 80;
            int paddleHeight = 20;
            int paddleX = ((this.Width / 2) - (paddleWidth / 2));
            int paddleY = (this.Height - paddleHeight) - 60;
            int paddleSpeed = 8;
            paddle = new Paddle(paddleX, paddleY, paddleWidth, paddleHeight, paddleSpeed, Color.White);

            // setup starting ball values
            int ballX = this.Width / 2 - 10;
            int ballY = this.Height - paddle.height - 80;

            // Creates a new ball
            int xSpeed = 6;
            int ySpeed = 6;
            int ballSize = 20;
            ball = new Ball(ballX, ballY, xSpeed, ySpeed, ballSize);

            //Grady Code
            balls.Add(ball);

            #region Creates blocks for generic level. Need to replace with code that loads levels.

            //TODO - replace all the code in this region eventually with code that loads levels from xml files

            blocks.Clear();


            Nathan_loadLevel();


            #endregion

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
                    powerups.Add(new Powerup("BB5", new List<string> { "fire" }));
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    powerups.Add(new Powerup("P", new List<string> { "fire" }));
                    break;
                default:
                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            // Move the paddle
            if (leftArrowDown && paddle.x > 0)
            {
                paddle.Move("left");
            }
            if (rightArrowDown && paddle.x < (this.Width - paddle.width))
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
                lives--;

                // Moves the ball back to origin
                ball.x = ((paddle.x - (ball.size / 2)) + (paddle.width / 2));
                ball.y = (this.Height - paddle.height) - 85;

                if (lives == 0)
                {
                    gameTimer.Enabled = false;
                    OnEnd();
                }
            }

            // Check for collision of ball with paddle, (incl. paddle movement)
            ball.PaddleCollision(paddle);

            // Check if ball has collided with any blocks
            foreach (Block b in blocks)
            {
                if (ball.BlockCollision(b))
                {
                    blocks.Remove(b);

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

                for(int j = 0; j < blocks.Count; j++)
                {
                    blocks[j].setCurrent();
                    if (blocks[j].hp <= 0)
                    {
                        blocks.RemoveAt(j);
                        j--;
                    }
                }

                // Check if ball has collided with any blocks
                foreach (Block b in blocks)
                {
                    if (balls[i].BlockCollision(b))
                    {
                        b.hp--;
                        if (b.hp <= 0)
                        {
                            blocks.Remove(b);
                        }
                        b.PassCondition(balls[i]);

                        if (blocks.Count == 0)
                        {
                            gameTimer.Enabled = false;
                            OnEnd();
                        }

                        break;
                    }
                }

                balls[i].CleanModifiers();

                // Check for ball hitting bottom of screen
                if (balls[i].BottomCollision(this) || (balls[i].CheckFor("temp") && (tempBall.xSpeed != balls[i].xSpeed || tempBall.ySpeed != balls[i].ySpeed)))
                {
                    balls.Remove(balls[i]);
                    i--;
                }
            }

            for (int i = 0; i < powerups.Count; i++)
            {
                balls = powerups[i].Effect(balls);
                if (powerups[i].Type.Contains("BB"))
                {
                    powerups.RemoveAt(i);
                    i--;
                }
            }

            if (lives == 0)
            {
                gameTimer.Enabled = false;
                OnEnd();
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
            } else
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

        // Save level
        void Nathan_saveLevel()
        {
            XmlRw saver = new XmlRw();
            saver.saveLevel($"level_save{currentLevel}.xml", blocks);
        }

        public void OnEnd()
        {
            // Goes to the game over screen
            Form form = this.FindForm();
            MenuScreen ps = new MenuScreen();

            ps.Location = new Point((form.Width - ps.Width) / 2, (form.Height - ps.Height) / 2);

            form.Controls.Add(ps);
            form.Controls.Remove(this);
        }

        public void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            // Draws paddle
            paddleBrush.Color = paddle.colour;
            e.Graphics.FillRectangle(paddleBrush, paddle.x, paddle.y, paddle.width, paddle.height);

            // Draws blocks
            foreach (Block b in blocks)
            {
                e.Graphics.FillRectangle(blockBrush, b.x, b.y, b.width, b.height);
            }

            // Draws ball
            e.Graphics.FillRectangle(ballBrush, ball.x, ball.y, ball.size, ball.size);

            //Grady
            foreach (Ball b in balls)
            {
                if (b.modifiers.Contains("fire"))
                {
                    e.Graphics.FillRectangle(fireBrush, b.x, b.y, b.size, b.size);
                }
                else
                {
                    e.Graphics.FillRectangle(ballBrush, b.x, b.y, b.size, b.size);
                }
            }

            foreach (Block b in blocks)
            {
                e.Graphics.DrawString(b.hp.ToString(), healthFont, ballBrush, b.x, b.y);
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
        }
    }
}
