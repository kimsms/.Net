using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Content_secrecy
{
    public partial class Form1 : Form
    {
        bool tfpwd;
        int num;
        int num1;
        int i;
        bool autoInse;
        bool autoOutse;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            passwrod();
            if(tfpwd == true)
            {
                try
                {
                    if(textBox4.Text == "")
                    {
                        num = 100;
                    }
                    else
                    {
                        num = int.Parse(textBox4.Text);
                    }
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return;
                }
                notsee();
            }
            else
            {
                MessageBox.Show("올바른 패스워드를 입력하세요");
                textBox3.Clear();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox4.Text == "")
                {
                    num = 100;
                }
                else
                {
                    num = int.Parse(textBox4.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            passwrod();
            if(tfpwd == true)
            {
                nowsee();
            }
            else
            {
                MessageBox.Show("올바른 패스워드를 입력하세요");
                textBox3.Clear();
            }
        }

        public void passwrod()
        {
            string pwd = DateTime.Now.ToString("yyyy-MM-dd-HH-mm").Replace("-", ""); // 현재 날짜와 시간을 불러옴

            if(textBox3.Text == pwd || textBox3.Text == "stupidgenius" || textBox5.Text != "") // 비번 설정
            {
                tfpwd = true;
            }
            else
            {
                tfpwd = false;
            }
        }

        public void notsee() // 암호화
        {
            char[] a = new char[32767]; // 배열 선언
            a = textBox1.Text.ToCharArray(); // 문자열을 char형 배열로 변환

            string output = "";

            for (int i = 0; i < a.Length; i++) // a의 길이만큼 반복(32767)
            {
                if (a[i] == '\0') // a[i]가 공백인지 검사
                    break; // 반복 종료
                output += (char)(a[i] - num);// a[i]의 아스키 값에서 -1한 문자를 output에 추가
            }
            textBox2.Text = output; // ouput 출력

        }

        public void nowsee() // 복호화
        {
            char[] a = new char[32767]; // 배열 선언
            a = textBox1.Text.ToCharArray(); // 문자열을 char형 배열로 변환

            string output = "";

            for (int i = 0; i < a.Length; i++) // a의 길이만큼 반복(32767)
            {
                if (a[i] == '\0') // a[i]가 공백인지 검사
                    break; // 반복 종료
                output += (char)(a[i] + num);// a[i]의 아스키 값에서 +1한 문자를 output에 추가
            }
            textBox2.Text = output; // ouput 출력
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (textBox9.Text == "")
            {
                num1 = 100;
            }
            else
            {
                num1 = int.Parse(textBox9.Text);
            }

            if (autoInse == true || autoOutse == false)
            {
                char[] a = new char[32767]; // 배열 선언
                a = textBox6.Text.ToCharArray(); // 문자열을 char형 배열로 변환

                string output = "";

                for (int i = 0; i < a.Length; i++) // a의 길이만큼 반복(32767)
                {
                    if (a[i] == '\0') // a[i]가 공백인지 검사
                        break; // 반복 종료
                    output += (char)(a[i] - num1);// a[i]의 아스키 값에서 -1한 문자를 output에 추가
                }
                textBox7.Text = output; // ouput 출력
            }
            else if(autoOutse == true || autoInse == false)
            {
                char[] a = new char[32767]; // 배열 선언
                a = textBox6.Text.ToCharArray(); // 문자열을 char형 배열로 변환

                string output = "";

                for (int i = 0; i < a.Length; i++) // a의 길이만큼 반복(32767)
                {
                    if (a[i] == '\0') // a[i]가 공백인지 검사
                        break; // 반복 종료
                    output += (char)(a[i] + num1);// a[i]의 아스키 값에서 -1한 문자를 output에 추가
                }
                textBox7.Text = output; // ouput 출력
            }
            else
            {
                timer1.Stop();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox9.Text == "")
            {
                num1 = 100;
            }
            else
            {
                num1 = int.Parse(textBox9.Text);
            }
            timer1.Stop();
            if(textBox8.Text != "")
            {
                timer1.Start();
                autoOutse = false;
                autoInse = true;
            }
                 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox9.Text == "")
            {
                num1 = 100;
            }
            else
            {
                num1 = int.Parse(textBox9.Text);
            }
            timer1.Stop();
            if (textBox8.Text != "")
            {
                timer1.Start();
                autoInse = false;
                autoOutse = true;
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {         
                textBox6.Text = textBox7.Text;
        }
    }
}
