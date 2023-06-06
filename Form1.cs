using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gamecenter
{
    public partial class Form1 : Form
    {
        public static int scoretotal = 0;
        

        public Form1()
        {
            InitializeComponent();
            pointsToolStripMenuItem.Text = scoretotal + " points";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (scoretotal >= 10)
            {
                trexrunner f2 = new trexrunner();
                f2.Show();
                Visible = false;
            }
            else
            {
                DialogResult res = MessageBox.Show("You do not have enough points!", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            rockpaperscissors f3 = new rockpaperscissors();
            f3.Show();
            Visible = false;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (scoretotal >= 20)
            {
                snakegame f5 = new snakegame();
                f5.Show();
                Visible = false;
            }
            else
            {
                DialogResult res = MessageBox.Show("You do not have enough points!", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            bilajoc f4 = new bilajoc();
            f4.Show();
            Visible = false;
        }

        private void pointsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void resetPointsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scoretotal = 0;
            pointsToolStripMenuItem.Text = scoretotal + " points";
        }
    }
}
