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
        int a;
        int b;
        int c;
        int d;
        int kap;
        int bu;
        int val;
        int arrayCount = 0;
        string[] array = new string[3];


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            val = int.Parse(textBox4.Text);
            subtest();
        }
        public void subtest()
        {
            a = val - ran.Next(1, val);
            b = val - ran.Next(1, val);
            kap = Fun(a, b);
            su();
            arrayCount++;
            c = val - ran.Next(1, val);
            kap = Fun(kap, c);
            su();
            arrayCount++;
            d = val - ran.Next(1, val);
            kap = Fun(kap, d);
            su();

            label5.Text = kap + "을 만드시오";
            test.Text = array[0] + " " + array[1] + " " + array[2];
            arrayCount = 0;
            label1.Text = a.ToString();
            label2.Text = b.ToString();
            label3.Text = c.ToString();
            label4.Text = d.ToString();

        }

        public void su()
        {
            try
            {
                if (bu == 1)
                {
                    array[arrayCount] = "+";

                }
                else if (bu == 2)
                {
                    array[arrayCount] = "-";

                }
                else if (bu == 3)
                {
                    array[arrayCount] = "*";

                }
                else if (bu == 4)
                {
                    array[arrayCount] = "/";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public int Fun(int a1, int b1)
        {
            bu = ran.Next(1, 4);
            if (bu == 1)
            {
                return a1 + b1;

            }
            else if (bu == 2)
            {
                return a1 - b1;

            }
            else if (bu == 3)
            {
                return a1 * b1;

            }
            else if (bu == 4)
            {
                if (b1 == 0)
                {
                    return a1 / 1;

                }
                else
                {
                    return a1 / b1;

                }

            }
            else
            {
                return 0;
            }
        }



        private void button2_Click_1(object sender, EventArgs e)
        {
            if (test.Visible == true)
            {
                test.Visible = false;
            }
            else
            {
                test.Visible = true;
            }
        }
        public void inter(int a, int b, int c)
        {
            if(int.Parse(label1.Text) + a + int.Parse(label2.Text) + b + int.Parse(label3.Text) + c + int.Parse(label4.Text)  == val)
            {
                MessageBox.Show("정답");
            }
            else
            {
                MessageBox.Show("오답");
            }
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Delete)
            {
                if (textBox4.Visible == false)
                {
                    textBox4.Visible = true;
                }
                else
                {
                    textBox4.Visible = false;
                }


            }
        }


    }
}
