using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lucky_game
{
    public partial class Form1 : Form
    {
        Random ran = new Random();
        int a;
        char code;
        string answer;
        int b;
        int count = 1;
        public Form1()
        {
            InitializeComponent();
            textBox2.Text = count.ToString();
            timer1.Start();
            test();
        }

        public string randomchange()
        {
            char[] c = new char[count];
            for(int i = 0; i<count; i++)
            {
                a = ran.Next(97, 123);
                code = Convert.ToChar(a);
                c[i] = code;
            }

            string re = "";
            for(int j =0; j<c.Length; j++)
            {
                re += c[j];
            }

            return re;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("초기화!", "defult");
            count = 1;
            textBox2.Text = count.ToString();
            textBox1.Clear();
            timer1.Start();
        }
        public void Changepassword()
        {
            label1.Text = test();
            label2.Text = test();
            label3.Text = test();
            label4.Text = test();
            label5.Text = test();
            label6.Text = test();
            label7.Text = test();
            label8.Text = test();
            label9.Text = test();
            label10.Text = test();
            label11.Text = test();
            label12.Text = test();
            label13.Text = test();
            label14.Text = test();
            label15.Text = test();
            label16.Text = test();
            label17.Text = test();
            label18.Text = test();
            label19.Text = test();
            label20.Text = test();
            rananswer();
        }
        public void rananswer()
        {
            int an = ran.Next(1, 21);
            if(an == 1)
            {
                answer = label1.Text;
            }
            if(an == 2)
            {
                answer = label2.Text;
            }
            if (an == 3)
            {
                answer = label3.Text;
            }
            if (an == 4)
            {
                answer = label4.Text;
            }
            if (an == 5)
            {
                answer = label5.Text;
            }
            if (an == 6)
            {
                answer = label6.Text;
            }
            if (an == 7)
            {
                answer = label7.Text;
            }
            if (an == 8)
            {
                answer = label8.Text;
            }
            if (an == 9)
            {
                answer = label9.Text;
            }
            if (an == 10)
            {
                answer = label10.Text;
            }
            if (an == 11)
            {
                answer = label11.Text;
            }
            if (an == 12)
            {
                answer = label12.Text;
            }
            if (an == 13)
            {
                answer = label13.Text;
            }
            if (an == 14)
            {
                answer = label14.Text;
            }
            if (an == 15)
            {
                answer = label15.Text;
            }
            if (an == 16)
            {
                answer = label16.Text;
            }
            if (an == 17)
            {
                answer = label17.Text;
            }
            if (an == 18)
            {
                answer = label18.Text;
            }
            if (an == 19)
            {
                answer = label19.Text;
            }
            if (an == 20)
            {
                answer = label10.Text;
            }
            //label21.Text = answer;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(b > 50)
            {
                Changepassword();
                if (label21.Visible == true)
                    Clipboard.SetText(answer);
                b = 0;
                timer1.Stop();
            }
            else
            {
                Changepassword();
                b++;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Control && e.KeyCode == Keys.N)
            {
                if(label21.Visible == false)
                {
                    label21.Visible = true;
                }
                else
                {
                    label21.Visible = false;
                }
                
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                button2_Click(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
            {
                checkanswer();
                timer1.Start();
            }
            

        }
        public void checkanswer()
        {
            if(textBox1.Text == answer)
            {
                MessageBox.Show("정답!","true");
                count++;
                textBox2.Text = count.ToString();
                textBox1.Clear();
                timer1.Start();
            }
            else
            {
                MessageBox.Show("오답!","false");
                count = 1;
                textBox2.Text = count.ToString();
                textBox1.Clear();
                timer1.Start();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.Text = count.ToString();
        }

        public string test()
        {
            char[] c = new char[count];
            for (int i = 0; i < count; i++)
            {
                int t1 = ran.Next(0, 3);
                if (t1 == 0)
                {
                    c[i] = (char)ran.Next(48, 58); //숫자
                }
                else if(t1 == 1)
                {
                    c[i] = (char)ran.Next(65, 91);  //대문자
                }
                else
                {
                    c[i] = (char)ran.Next(97, 123);  //소문자
                }
            }
            string re = "";
            for (int j = 0; j < c.Length; j++)
            {
                re += c[j];
            }
            return re;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            textBox1.Text = label1.Text;
            checkanswer();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            textBox1.Text = label2.Text;
            checkanswer();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            textBox1.Text = label3.Text;
            checkanswer();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            textBox1.Text = label4.Text;
            checkanswer();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            textBox1.Text = label5.Text;
            checkanswer();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            textBox1.Text = label6.Text;
            checkanswer();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            textBox1.Text = label7.Text;
            checkanswer();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            textBox1.Text = label8.Text;
            checkanswer();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            textBox1.Text = label9.Text;
            checkanswer();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            textBox1.Text = label10.Text;
            checkanswer();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            textBox1.Text = label11.Text;
            checkanswer();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            textBox1.Text = label12.Text;
            checkanswer();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            textBox1.Text = label13.Text;
            checkanswer();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            textBox1.Text = label14.Text;
            checkanswer();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            textBox1.Text = label5.Text;
            checkanswer();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            textBox1.Text = label16.Text;
            checkanswer();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            textBox1.Text = label17.Text;
            checkanswer();
        }

        private void label18_Click(object sender, EventArgs e)
        {
            textBox1.Text = label18.Text;
            checkanswer();
        }

        private void label19_Click(object sender, EventArgs e)
        {
            textBox1.Text = label19.Text;
            checkanswer();
        }

        private void label20_Click(object sender, EventArgs e)
        {
            textBox1.Text = label20.Text;
            checkanswer();
        }
        
    }
}
