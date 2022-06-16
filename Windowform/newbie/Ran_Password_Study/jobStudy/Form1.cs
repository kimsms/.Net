using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Security.AccessControl;
using System.IO;



namespace jobStudy
{
    public partial class Form1 : Form
    {
        int Pword;
        int Cword;
        int ranchar;
        int late = 1;
        bool st = false;

        Random ran = new Random();



        public Form1()
        {
            InitializeComponent();

            ranchar = ran.Next(65, 91);
            Pword = (char)ranchar + ran.Next(1, 2147483647);
            password.Text = (char)ranchar + Pword.ToString();
            timer1.Stop();

        }
        public void start()
        {
            startButton.Enabled = false;
            button1.Enabled = false;
            label1.Text = "실행중...";
            if (st == true)
            {

                for (int j = 65; j < 91; j++)
                {
                    for (int i = 0; i < 2147483647; i++)
                    {
                        if ((char)j + Cword == Pword)
                        {
                            timer1.Stop();
                            nowWord.Text = (char)ranchar + Cword.ToString();
                            MessageBox.Show("Password : " + (char)ranchar + Cword);
                            i = 0;
                            Cword = 0;
                            ranchar = ran.Next(65, 91);
                            Pword = (char)ranchar + ran.Next(1, 2147483647);
                            password.Text = (char)ranchar + Pword.ToString();
                            startButton.Enabled = true;
                            button1.Enabled = true;
                            label1.Text = "";
                            st = false;
                            return;
                        }
                        Cword++;
                    }

                }
            }
            else
            {
                timer1.Start();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ranchar = ran.Next(65, 91);
            Pword = (char)ranchar + ran.Next(1, 2147483647);
            password.Text = (char)ranchar + Pword.ToString();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(late > 0)
            {
                late--;
            }
            else
            {
                st = true;
                start();
                timer1.Stop();
            }
        }


    }
}
