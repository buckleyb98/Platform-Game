using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_Platform_Game
{
    public partial class Form1 : Form
    {
        // booleans 
        bool goLeft, goRight, jumping, IsGameOver;

        // integars for player
        int jumpSpeed;
        int force;
        int score = 0;
        int playerSpeed = 7;

        // platform speed
        int horizontalSpeed = 5;
        int verticalSpeed = 3;

        // enemy speed
        int enemyOneSpeed = 5;
        int enemyTwoSpeed = 3;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void MainGameTimerEvent(object sender, EventArgs e)
        {
            txtScore.Text = "Score: " + score;

            player.Top += jumpSpeed;

            if (goLeft == true)
            {
                player.Left -= playerSpeed;
            }
            if (goRight == true)
            {
                player.Left += playerSpeed;
            }

            if (jumping == true && force < 0)
            {
                jumping = false;
            }

            if (jumping == true)
            {
                jumpSpeed = -8;
                force = -1;
            }
            else
            {
                jumpSpeed = 10;
            }

            foreach(Control x in this.Controls)
            {
                if (x is PictureBox)
                {


                    if ((string)x.Tag == "platform")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            force = 8;
                            player.Top = x.Top - player.Height;
                        }

                        x.BringToFront();
                    }
                }
            }
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = true;
            }
            if (e.KeyCode == Keys.Space && jumping == false)
            {
                jumping = true;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
            if (jumping == true)
            {
                jumping = false;
            }

            if (e.KeyCode == Keys.Enter && IsGameOver == true)
            {
                RestartGame();
            }
        }

        private void RestartGame()
        {
            jumping = false;
            goLeft = false;
            goRight = false;
            IsGameOver = false;
            score = 0;

            txtScore.Text = "Score: " + score;

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Visible == false)
                {
                    x.Visible = true;
                }
            }


            // reset position of player, platforms and enemies

            player.Left = 72;
            player.Top = 676;

            enemyOne.Left = 556;
            enemyTwo.Left = 381;

            horizontalPlatform.Left = 257;
            verticalPlatform.Top = 403;

            gameTimer.Start();

           // enemyOne.Top = 584;
            // enemyTwo.Top = 260;
        }            

    }
}
