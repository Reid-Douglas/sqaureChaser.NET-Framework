using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Media;

namespace sqaureChaser.NET_Framework
{
    public partial class squareChaserForm : Form
    {
        Rectangle player1 = new Rectangle(50, 195, 20, 20);
        Rectangle player2 = new Rectangle(330, 195, 20, 20);
        Rectangle ball = new Rectangle(195, 200, 10, 10);

        int player1Score = 0;
        int player2Score = 0;

        int player1Speed = 3;
        int player2Speed = 3;

        bool wDown = false;
        bool sDown = false;
        bool upArrowDown = false;
        bool downArrowDown = false;

        SolidBrush blueBrush = new SolidBrush(Color.DodgerBlue);
        SolidBrush orangeBrush = new SolidBrush(Color.Orange);
        SolidBrush yellowBrush = new SolidBrush(Color.Yellow);
        Pen drawPen = new Pen(Color.Teal, 5);


        bool aDown = false;
        bool dDown = false;
        bool leftArrowDown = false;
        bool rightArrowDown = false;
        

        public squareChaserForm()
        {
            InitializeComponent();
        }

        private void squareChaserForm_Load(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            drawPen.Color = Color.Teal;
        }

        private void squareChaserForm_KeyDown(object sender, KeyEventArgs e)
            
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.A:
                    aDown = true;
                    break;
                case Keys.D:
                    dDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                case Keys.Left:
                    leftArrowDown = true;
                    break;
            }
        }

        private void squareChaserForm_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
                case Keys.A:
                    aDown = false;
                    break;
                case Keys.D:
                    dDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
                case Keys.Left:
                    leftArrowDown = false;
                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            Random randGen = new Random();

            //move player 1 
            if (wDown == true && player1.Y > 50)
            {
                player1.Y -= player1Speed;
            }

            if (sDown == true && player1.Y < 330)
            {
                player1.Y += player1Speed;
            }
            if (aDown == true && player1.X > 50)
            {
                player1.X -= player1Speed;
            }
            if (dDown == true && player1.X < 330)
            {
                player1.X += player1Speed;
            }

            //move player 2 
            if (upArrowDown == true && player2.Y > 50)
            {
                player2.Y -= player2Speed;
            }

            if (downArrowDown == true && player2.Y < 330)
            {
                player2.Y += player2Speed;
            }
            if (leftArrowDown == true && player2.X > 50)
            {
                player2.X -= player2Speed;
            }
            if (rightArrowDown == true && player2.X < 330)
            {
                player2.X += player2Speed;
            }

            // if playe react to point

            if (player1.IntersectsWith(ball))
            {
                player1Score ++;
                player1Speed ++;
                p1ScoreLabel.Text = $"{player1Score}";

                ball.X = randGen.Next(60,320);
                ball.Y = randGen.Next(60,320);

                SoundPlayer player = new SoundPlayer(Properties.Resources.sound1);
                player.Play();
            }
           
            if (player2.IntersectsWith(ball))
            {
                player2Score ++;
                player2Speed ++;
                p2ScoreLabel.Text = $"{player2Score}";

                ball.X = randGen.Next(60, 320);
                ball.Y = randGen.Next(60, 320);

                SoundPlayer player = new SoundPlayer(Properties.Resources.sound1);
                player.Play();
            }
            
        
            // check score and stop game if either player is at 3 
            if (player1Score == 5)
            {
                gameTimer.Enabled = false;
                winLabel.Visible = true;
                winLabel.Text = "Player 1 Wins!!";
            }
            else if (player2Score == 5)
            {
                gameTimer.Enabled = false;
                winLabel.Visible = true;
                winLabel.Text = "Player 2 Wins!!";
            }
           
            Refresh();

        }

        private void squareChaserForm_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(drawPen, 50, 50, 300, 300);
            
            e.Graphics.FillRectangle(blueBrush, player1);
            e.Graphics.FillRectangle(orangeBrush, player2);
            e.Graphics.FillRectangle(yellowBrush, ball);
        }

        private void winLabel_Click(object sender, EventArgs e)
        {
            //sound
        }
    }
    
}
