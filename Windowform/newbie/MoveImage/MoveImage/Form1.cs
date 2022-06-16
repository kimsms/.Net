using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoveImage
{
    public partial class Form1 : Form
    {
        Random ran = new Random();
        int a;
        bool gameout;
        int chodi = 100;
        int difficulty;
        public Form1()
        {
            InitializeComponent();
            difficulty = chodi; 
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if(gameout == true)
            {
                a = 0;
                difficulty = chodi;
                label1.Text = "TIme : " + a.ToString();
                label2.Text = "Stage : " + difficulty;
                timer1.Start();
                timer2.Start();
                gameout = false;
            }
            else
            {
                pictureBox1.Location = new Point(ran.Next(0, 380), pictureBox1.Location.Y - 150);
            }
        }

        public void Upstage()
        {
            timer1.Stop();
            timer2.Stop();
            difficulty++;
            timer1.Interval = timer1.Interval - difficulty;
            pictureBox1.Location = new Point(ran.Next(0, 380), 0);
            MessageBox.Show("Upstage");
        }
        public void Upstageed()
        {
            timer1.Start();
            timer2.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y + difficulty);
            pictureBox1.Location = new Point(ran.Next(0, 380), pictureBox1.Location.Y + difficulty);
            if (pictureBox1.Location.Y >= 370)
            {
                gameout = true;
                timer2.Stop();
                timer1.Stop();
                pictureBox1.Location = new Point(ran.Next(0, 380), 0);
                MessageBox.Show("게임오버\n" + difficulty + " stage", "GameOver");
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            a++;
            label1.Text = "TIme : " + a.ToString();
            label2.Text = "Stage : " + difficulty;
            if(a % 10 == 0)
            {
                    Upstage();
                    Upstageed();
            }
        }
    }
}
