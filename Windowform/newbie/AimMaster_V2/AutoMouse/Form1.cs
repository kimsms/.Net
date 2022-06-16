using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoMouse
{
    public partial class Form1 : Form
    {
        Random ran = new Random();
        int mode;
        int timelate;
        int pin;
        bool hardmode;

        public Form1()
        {
            InitializeComponent();
            
        }

        public void gamestart()
        {
            if (hardmode == true)
            {
                timer1.Interval = 100;
            }
            else
            {
                timer1.Interval = 1000;
            }

            pin = timer1.Interval;
            timer2.Interval = pin / 2;
            button1.Location = new Point(ran.Next(12, 370), ran.Next(12, 330));
            mode1.Visible = false;
            mode2.Visible = false;
            mode3.Visible = false;
            mode4.Visible = false;
            button1.Visible = true;
            checkBox1.Visible = false;
            timer1.Start();
            timer3.Start();
        }

        public void gameend()
        {
            timer1.Stop();
            timer2.Stop();
            timer3.Stop();
            timer1.Interval = pin;
            timer2.Interval = pin;
            mode1.Visible = true;
            mode2.Visible = true;
            mode3.Visible = true;
            mode4.Visible = true;
            button1.Visible = false;
            checkBox1.Visible = true;
            mode = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(mode == 1)
            {
                button1.Location = new Point(ran.Next(12, 370), ran.Next(12, 330));
            }
            else if(mode == 2)
            {
                Cursor.Position = new Point(ran.Next(0, 1500), ran.Next(0, 800));
            }
            else if(mode == 3)
            {
                Cursor.Position = new Point(ran.Next(0, 1500), ran.Next(0, 800));
                button1.Location = new Point(ran.Next(12, 370), ran.Next(12, 330));
            }
            else if(mode == 4)
            {
                Cursor.Position = new Point(ran.Next(0, 1500), ran.Next(0, 800));
            }
            
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            button1.Location = new Point(ran.Next(12, 370), ran.Next(12, 330));
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S && e.Shift) 
            {
                gameend();
                MessageBox.Show("포기하셨습니다.\n걸린시간 : " + timelate);
                timelate = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gameend();
            MessageBox.Show("걸린시간 : " + timelate);
            timelate = 0;

        }

        private void mode1_Click(object sender, EventArgs e)
        {
            mode = 1;
            gamestart();
        }

        private void mode2_Click(object sender, EventArgs e)
        {
            mode = 2;
            gamestart();
        }

        private void mode3_Click(object sender, EventArgs e)
        {
            mode = 3;
            gamestart();
        }

        private void mode4_Click(object sender, EventArgs e)
        {
            mode = 4;
            timer2.Start();
            gamestart();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            timelate++;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                modelabel.Visible = true;
                hardmode = true;
            }
            else
            {
                modelabel.Visible = false;
                hardmode = false;
            }
        }

    }
}
