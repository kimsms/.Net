using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolTabs
{
    public partial class Form1 : Form
    {
        Random ran = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://school.iamservice.net/organization/18836");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://xn--s39aj90b0nb2xw6xh.kr/");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox1.Visible == true)
            {
                textBox1.Visible = false;
                textBox2.Visible = false;
                button4.Visible = false;
                button5.Visible = false;
                button7.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
            }
            else
            {
                textBox1.Visible = true;
                textBox2.Visible = true;
                button4.Visible = true;
                button5.Visible = true;
                button7.Visible = true;
                label1.Visible = true;
                label2.Visible = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            char[] a = new char[32767]; // 배열 선언
            a = textBox1.Text.ToCharArray(); // 문자열을 char형 배열로 변환

            string output = "";

            for (int i = 0; i < a.Length; i++) // a의 길이만큼 반복(32767)
            {
                if (a[i] == '\0') // a[i]가 공백인지 검사
                    break; // 반복 종료
                output += (char)(a[i] - 500);// a[i]의 아스키 값에서 -1한 문자를 output에 추가
            }
            textBox2.Text = output;
            textBox1.Clear();
            try
            {
                Clipboard.SetText(textBox2.Text);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = Clipboard.GetText();
            char[] a = new char[32767]; // 배열 선언
            a = textBox1.Text.ToCharArray(); // 문자열을 char형 배열로 변환

            string output = "";

            for (int i = 0; i < a.Length; i++) // a의 길이만큼 반복(32767)
            {
                if (a[i] == '\0') // a[i]가 공백인지 검사
                    break; // 반복 종료
                output += (char)(a[i] + 500);// a[i]의 아스키 값에서 -1한 문자를 output에 추가
            }
            textBox2.Text = output;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(button6.Text == "심심풀이")
            {
                timer1.Start();
                label3.Visible = true;
                button6.Text = "종료";
            }
            else
            {
                timer1.Stop();
                label3.Visible = false;
                button6.Text = "심심풀이";
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Cursor.Position = new Point(ran.Next(0, 1500), ran.Next(0, 1000));
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Delete)
            {
                timer1.Stop();
                label3.Visible = false;
                button6.Text = "심심풀이";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }
    }
}
