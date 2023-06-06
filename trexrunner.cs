using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gamecenter
{

    public partial class trexrunner : Form
    {
        bool jumping = false;
        int jumpSpeed;
        int force = 12;
        int score = 0;
        int hshs = 0;
        int obstacleSpeed = 10;
        Random rand = new Random();
        int position;
        bool isGameOver = false;
        public trexrunner()
        {
            InitializeComponent();

            resetGame();
        }

        private void gameEvent(object sender, EventArgs e)
        {
            trex.Top += jumpSpeed;

            score2.Text = "000000" + score;
            this.BackColor = Color.White;
            if (jumping && force < 0)
            {
                jumping = false;
            }

            if (jumping)
            {
                jumpSpeed = -12;
                force -= 1;
            }
            else
            {
                jumpSpeed = 12;
            }

            if (trex.Top > 366 && jumping == false)
            {
                force = 12;
                trex.Top = 367;
                jumpSpeed = 0;
            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "obstacle")
                {
                    x.Left -= obstacleSpeed;

                    if (x.Left < -100)
                    {
                        x.Left = this.ClientSize.Width + rand.Next(200, 500) + (x.Width * 15);
                        score++;
                    }

                    if (trex.Bounds.IntersectsWith(x.Bounds))
                    {
                        gameTimer.Stop();
                        trex.Image = Properties.Resources.dead;
                        scoreText.Text += "Press R to restart";
                        isGameOver = true;
                    }
                }
            }

            if (score >= 5)
            {
                obstacleSpeed = 15;
                this.BackColor = Color.SandyBrown;
            }

            if (score >= 15)
            {
                obstacleSpeed = 18;
                this.BackColor = Color.Peru;
            }

            if (score >= 30)
            {
                obstacleSpeed = 20;
            }

            if (score >=10)
            {
                score2.Text = "00000" + score;
            }
            if (score >= 100)
            {
                score2.Text = "0000" + score;
            }
            if (score >= 1000)
            {
                score2.Text = "000" + score;
            }
            if(score>hshs)
            {
                hshs = score;
                Form1.scoretotal = Form1.scoretotal + 10;
            }
        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space && !jumping)
            {
                jumping = true;
            }
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (jumping)
            {
                jumping = false;
            }

            if (e.KeyCode == Keys.R && isGameOver == true)
            {
                resetGame();
            }
        }

        public void resetGame()
        {
            force = 12;
            trex.Top = 367;
            jumpSpeed = 0;
            jumping = false;
            score = 0;
            obstacleSpeed = 10;
            scoreText.Text = " ";
            score2.Text = "000000" + score;
            hstext.Text = "000000" + hshs;
            trex.Image = Properties.Resources.running;
            isGameOver = false;
            
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "obstacle")
                {
                    position = this.ClientSize.Width + rand.Next(500, 800) + (x.Width * 10);
                    x.Left = position;
                }
            }
            gameTimer.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure you want to exit?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            this.Close();
            Form1 back = new Form1();
            back.Show();
        }

        private void highscore_Click(object sender, EventArgs e)
        {

        }
    }
}
