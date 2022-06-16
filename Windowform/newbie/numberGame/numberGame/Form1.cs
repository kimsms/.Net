using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace numberGame
{
    public partial class Form1 : Form
    {

        Random ran = new Random();

        bool clear;

        int timeCount;
        int timeUpCount;

        int a;
        int b;
        int c;
        int d;
        int a1;
        int b1;
        int c1;

        int val = 1;
        int vala;

        int val1;
        int val2;
        int val3;
        int val4;
        int val5;
        int val6;
        int val7;
        int val8;
        int val9;
        int val10;
        int val11;
        int val12;
        int val13;
        int val14;
        int val15;
        int val16;
        int val17;
        int val18;
        int val19;
        int val20;

        /*
         * val1 = a + b + c + d;
            val2 = a + b + c - d;
            val3 = a + b - c + d;
            val4 = a + b - c - d;

            val5 = a - b + c + d;
            val6 = a - b + c - d;
            val7 = a - b - c + d;
            val8 = a - b - c - d;

            val9 = a * b + c + d;
            val10 = a * b + c - d;
            val11 = a * b - c + d;
            val12 = a * b - c - d;

            val13 = a + b * c + d;
            val14 = a + b * c - d;
            val15 = a - b * c + d;
            val16 = a - b * c - d;

            val17 = a + b + c * d;
            val18 = a + b - c * d;
            val19 = a - b + c * d;
            val20 = a - b - c * d;
        */


        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                val = int.Parse(textBox4.Text);

                timer1.Interval = int.Parse(textBox5.Text);

                vala = int.Parse(textBox6.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
            label6.Text = "0초";
            timeCount = 0;
            timer2.Start();
            label5.Text = val + "을 만드시오";

            clear = false;

            test.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

            timer1.Start();
            button1.Enabled = false;
            button2.Enabled = false;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = a.ToString();
            label2.Text = b.ToString();
            label3.Text = c.ToString();
            label4.Text = d.ToString();

            a = ran.Next(0, (val + vala));
            b = ran.Next(0, (val + vala));
            c = ran.Next(0, (val + vala));
            d = ran.Next(0, (val + vala));

            val1 = a + b + c + d;
            val2 = a + b + c - d;
            val3 = a + b - c + d;
            val4 = a + b - c - d;

            val5 = a - b + c + d;
            val6 = a - b + c - d;
            val7 = a - b - c + d;
            val8 = a - b - c - d;

            val9 = a * b + c + d;
            val10 = a * b + c - d;
            val11 = a * b - c + d;
            val12 = a * b - c - d;

            val13 = a + b * c + d;
            val14 = a + b * c - d;
            val15 = a - b * c + d;
            val16 = a - b * c - d;

            val17 = a + b + c * d;
            val18 = a + b - c * d;
            val19 = a - b + c * d;
            val20 = a - b - c * d;



            jo();

        }


        public void jo()
        {
            if (val1 == val)
            {
                test.Text = "+ + +";
                jo1();
            }
            else if (val2 == val)
            {
                test.Text = "+ + -";
                jo1();
            }
            else if (val3 == val)
            {
                test.Text = "+ - +";
                jo1();
            }
            else if (val4 == val)
            {
                test.Text = "+ - -";
                jo1();
            }
            else if (val5 == val)
            {
                test.Text = "- + +";
                jo1();
            }
            else if (val6 == val)
            {
                test.Text = "- + -";
                jo1();
            }
            else if (val7 == val)
            {
                test.Text = "- - +";
                jo1();
            }
            else if (val8 == val)
            {
                test.Text = "- - -";
                jo1();
            }
            else if (val9 == val)
            {
                test.Text = "* + +";
                jo1();
            }
            else if (val10 == val)
            {
                test.Text = "* + -";
                jo1();
            }
            else if (val11 == val)
            {
                test.Text = "* - +";
                jo1();
            }
            else if (val12 == val)
            {
                test.Text = "* - -";
                jo1();
            }
            else if (val13 == val)
            {
                test.Text = "+ * +";
                jo1();
            }
            else if (val14 == val)
            {
                test.Text = "+ * -";
                jo1();
            }
            else if (val15 == val)
            {
                test.Text = "- * +";
                jo1();
            }
            else if (val16 == val)
            {
                test.Text = "- * -";
                jo1();
            }
            else if (val17 == val)
            {
                test.Text = "+ + *";
                jo1();
            }
            else if (val18 == val)
            {
                test.Text = "+ - *";
                jo1();
            }
            else if (val19 == val)
            {
                test.Text = "- + *";
                jo1();
            }
            else if (val20 == val)
            {
                test.Text = "- - *";
                jo1();
            }
        }

        public void jo1()
        {
            label1.Text = "[" + a.ToString() + "]";
            label2.Text = "[" + b.ToString() + "]";
            label3.Text = "[" + c.ToString() + "]";
            label4.Text = "[" + d.ToString() + "]";
            timer1.Stop();
            timer2.Stop();
            button1.Enabled = true;
            button2.Enabled = true;
        }


        public void reading()
        {
            if (textBox1.Text == "+")
            {
                a1 = +1;

            }
            else if (textBox1.Text == "-")
            {
                a1 = -1;
            }
            if (textBox2.Text == "+")
            {
                b1 = +1;
            }
            else if (textBox2.Text == "-")
            {
                b1 = -1;
            }
            if (textBox3.Text == "+")
            {
                c1 = +1;
            }
            else if (textBox3.Text == "-")
            {
                c1 = -1;
            }

            else if (textBox1.Text == "*" || textBox2.Text == "+" || textBox3.Text == "+")
            {
                if (a * b + c + d == val)
                {
                    clear = true;
                }
            }
            else if (textBox1.Text == "*" || textBox2.Text == "+" || textBox3.Text == "-")
            {
                if (a * b + c - d == val)
                {
                    clear = true;
                }
            }
            else if (textBox1.Text == "*" || textBox2.Text == "-" || textBox3.Text == "+")
            {
                if (a * b - c + d == val)
                {
                    clear = true;
                }
            }
            else if (textBox1.Text == "*" || textBox2.Text == "-" || textBox3.Text == "-")
            {
                if (a * b - c - d == val)
                {
                    clear = true;
                }
            }
            else if (textBox1.Text == "+" || textBox2.Text == "*" || textBox3.Text == "+")
            {
                if (a + b * c + d == val)
                {
                    clear = true;
                }
            }
            else if (textBox1.Text == "+" || textBox2.Text == "*" || textBox3.Text == "-")
            {
                if (a + b * c - d == val)
                {
                    clear = true;
                }
            }
            else if (textBox1.Text == "-" || textBox2.Text == "*" || textBox3.Text == "+")
            {
                if (a - b * c + d == val)
                {
                    clear = true;
                }
            }
            else if (textBox1.Text == "-" || textBox2.Text == "*" || textBox3.Text == "-")
            {
                if (a - b * c - d == val)
                {
                    clear = true;
                }
            }
            else if (textBox1.Text == "+" || textBox2.Text == "+" || textBox3.Text == "*")
            {
                if (a + b + c * d == val)
                {
                    clear = true;
                }
            }
            else if (textBox1.Text == "+" || textBox2.Text == "-" || textBox3.Text == "*")
            {
                if (a + b - c * d == val)
                {
                    clear = true;
                }
            }
            else if (textBox1.Text == "-" || textBox2.Text == "+" || textBox3.Text == "*")
            {
                if (a - b + c * d == val)
                {
                    clear = true;
                }
            }
            else if (textBox1.Text == "-" || textBox2.Text == "-" || textBox3.Text == "*")
            {
                if (a - b - c * d == val)
                {
                    clear = true;
                }
            }


            if (a + (a1 * b) + (b1 * c) + (c1 * d) == val)
            {
                clear = true;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            reading();
            if (clear == true)
            {
                MessageBox.Show("성공");

            }
            else
            {
                MessageBox.Show("실패");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
            timer1.Interval = int.Parse(textBox5.Text);
            timeCount = 1;
            label6.Text = "";
            button1.Enabled = true;
            button2.Enabled = true;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Delete)
            {
                if (button4.Visible == false)
                {
                    textBox4.Visible = true;
                    textBox5.Visible = true;
                    textBox6.Visible = true;
                    textBox7.Visible = true;
                    button3.Visible = true;
                    button4.Visible = true;
                    button5.Visible = true;
                }
                else
                {
                    textBox4.Visible = false;
                    textBox5.Visible = false;
                    textBox6.Visible = false;
                    textBox7.Visible = false;
                    button3.Visible = false;
                    button4.Visible = false;
                    button5.Visible = false;
                }



            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (test.Visible == false)
            {
                test.Visible = true;
            }
            else
            {
                test.Visible = false;
            }

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timeCount++;
            if(timeUpCount >= 1)
            {
                label6.Text = timeUpCount + "분" + timeCount + "초";
            }
            else
            {
                label6.Text = timeCount + "초";
            }
            
            try
            {
                if (timeCount == int.Parse(textBox7.Text))
                {
                    timer1.Stop();
                    timer1.Interval = 1;
                    timer1.Start();
                }
            }
            catch (Exception ex)
            {
                timer1.Stop();
                timer2.Stop();
                MessageBox.Show(ex.ToString());
            }
            if(timeCount == 60)
            {
                timeCount = 0;
                timeUpCount++;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox4.Text = "100";
            textBox5.Text = "50";
            textBox6.Text = "200";
            textBox7.Text = "60";
        }
    }
}
