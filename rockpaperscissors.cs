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
    public partial class rockpaperscissors : Form
    {
        int rounds = 3;
        int timerPerRound = 6;

        bool gameover = false;

        string[] AIchoiceList = { "rock", "paper", "scissor", "paper", "scissor", "rock" };

        int randomNumber = 0;

        Random rnd = new Random();

        string AIchoice;

        string playerChoice;

        int playerwins;
        int AIwins;


        public rockpaperscissors()
        {
            InitializeComponent();
            countDownTimer.Enabled = true;
            playerChoice = "none";
            txtTime.Text = "5";
        }

        private void btnRock_Click(object sender, EventArgs e)
        {
            picPlayer.Image = Properties.Resources.rock;
            playerChoice = "rock";
        }

        private void btnPaper_Click(object sender, EventArgs e)
        {
            picPlayer.Image = Properties.Resources.paper;
            playerChoice = "paper";
        }

        private void btnScissors_Click(object sender, EventArgs e)
        {
            picPlayer.Image = Properties.Resources.scissors;
            playerChoice = "scissor";
        }

        private void countDownTimer_Tick(object sender, EventArgs e)
        {
            timerPerRound -= 1;

            txtTime.Text = timerPerRound.ToString();
            roundsText.Text = "Rounds: " + rounds;

            if (timerPerRound < 1)
            {
                countDownTimer.Enabled = false;
                timerPerRound = 6;

                randomNumber = rnd.Next(0, AIchoiceList.Length);

                AIchoice = AIchoiceList[randomNumber];

                switch (AIchoice)
                {
                    case "rock":
                        picAI.Image = Properties.Resources.rock;
                        break;
                    case "paper":
                        picAI.Image = Properties.Resources.paper;
                        break;
                    case "scissor":
                        picAI.Image = Properties.Resources.scissors;
                        break;
                }


                if (rounds > 0)
                {
                    checkGame();
                }
                else
                {
                    if (playerwins > AIwins)
                    {
                        MessageBox.Show("Player Wins This Game");
                    }
                    else
                    {
                        MessageBox.Show("AI Wins This Game");
                    }

                    gameover = true;
                }


            }
        }


        private void checkGame()
        {
            if (playerChoice == "rock" && AIchoice == "paper")
            {

                AIwins += 1;

                rounds -= 1;

                MessageBox.Show("AI Wins, Paper Covers Rocks");

            }
            else if (playerChoice == "scissor" && AIchoice == "rock")
            {
                AIwins += 1;

                rounds -= 1;

                MessageBox.Show("AI Wins, Rock Breaks Scissors");
            }
            else if (playerChoice == "paper" && AIchoice == "scissor")
            {

                AIwins += 1;

                rounds -= 1;

                MessageBox.Show("AI Wins, Scissor cuts paper");

            }
            else if (playerChoice == "rock" && AIchoice == "scissor")
            {

                playerwins += 1;

                rounds -= 1;

                MessageBox.Show("Player Wins, Rock Breaks Scissors");

            }
            else if (playerChoice == "paper" && AIchoice == "rock")
            {

                playerwins += 1;

                rounds -= 1;

                MessageBox.Show("Player Wins, Paper Covers Rocks");

            }
            else if (playerChoice == "scissor" && AIchoice == "paper")
            {
                playerwins += 1;

                rounds -= 1;

                MessageBox.Show("Player Wins, Scissor cuts paper");

            }
            else if (playerChoice == "none")
            {
                MessageBox.Show("Make your Choice");
            }
            else
            {
                MessageBox.Show("Draw");

            }

            startNextRound();
        }

        public void startNextRound()
        {

            if (gameover)
            {

                return;
            }

            txtMessage.Text = "Player: " + playerwins + " - " + "AI: " + AIwins;

            playerChoice = "none";

            countDownTimer.Enabled = true;

            picPlayer.Image = Properties.Resources.qq;
            picAI.Image = Properties.Resources.qq;
        }

        private void restartGame(object sender, EventArgs e)
        {
            playerwins = 0;
            AIwins = 0;
            rounds = 3;
            txtMessage.Text = "Player: " + playerwins + " - " + "AI: " + AIwins;

            playerChoice = "none";
            txtTime.Text = "5";

            countDownTimer.Enabled = true;

            picPlayer.Image = Properties.Resources.qq;
            picAI.Image = Properties.Resources.qq;

            gameover = false;

            Form1.scoretotal = Form1.scoretotal + 10;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure you want to exit?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            this.Close();
            Form1 back = new Form1();
            back.Show();
        }

        private void rockpaperscissors_Load(object sender, EventArgs e)
        {

        }
    }
}
