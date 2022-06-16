using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace clearTeam
{
    public partial class Form1 : Form
    {
        bool password;
        int Pnum;
        public Form1()
        {
            InitializeComponent();           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (password == true)
            {
                
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter writer_;
                    String strFilePath = saveFileDialog1.FileName;
                    writer_ = File.CreateText(strFilePath);
                    writer_.Write(textBox1.Text);
                    writer_.Close();
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (password == true)
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string file_path = openFileDialog1.FileName;
                    textBox1.Text = System.IO.File.ReadAllText(file_path);
                    label1.Text = "파일명 : " + Path.GetFileName(file_path);

                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Smessage();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Rmessage();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S && e.Shift)
            {
                if(textBox4.Visible == true)
                {
                    textBox4.Visible = false;
                }
                else
                {
                    textBox4.Visible = true;
                }
            }
            if(e.Control && e.Shift && e.KeyCode == Keys.Delete)
            {
                MessageBox.Show("타이머가 시작되었습니다.");
                timer2.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (textBox1.Text == "stupidgenius")
            //if (textBox1.Text == "1234" || textBox1.Text == 1234.ToString())
            {
                password = true;
                label1.Text = "ON";
                pictureBox2.Visible = false;
                textBox1.Clear();
                timer1.Stop();
            }
        }

        public void Smessage()
        {
            if (password == true)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    char[] a = new char[32767]; // 배열 선언
                    a = textBox1.Text.ToCharArray(); // 문자열을 char형 배열로 변환

                    string output = "";

                    for (int i = 0; i < a.Length; i++) // a의 길이만큼 반복(32767)
                    {
                        if (a[i] == '\0') // a[i]가 공백인지 검사
                            break; // 반복 종료
                        output += (char)(a[i] - Pnum);// a[i]의 아스키 값에서 -1한 문자를 output에 추가
                    }


                    StreamWriter writer_;
                    String strFilePath = saveFileDialog1.FileName;
                    writer_ = File.CreateText(strFilePath);
                    writer_.Write(output);
                    writer_.Close();

                }
            }
        }

        public void Rmessage()
        {
            if (password == true)
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string file_path = openFileDialog1.FileName;

                    char[] a = new char[32767]; // 배열 선언
                    a = System.IO.File.ReadAllText(file_path).ToCharArray(); // 문자열을 char형 배열로 변환

                    string output = "";

                    for (int i = 0; i < a.Length; i++) // a의 길이만큼 반복(32767)
                    {
                        if (a[i] == '\0') // a[i]가 공백인지 검사
                            break; // 반복 종료
                        output += (char)(a[i] + Pnum);// a[i]의 아스키 값에서 +1한 문자를 output에 추가
                    }
                    textBox1.Text = output; // ouput 출력
                    label1.Text = "파일명 : " + Path.GetFileName(file_path);

                    //textBox1.Text = System.IO.File.ReadAllText(file_path);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (password == true)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    char[] a = new char[32767]; // 배열 선언
                    a = textBox2.Text.ToCharArray(); // 문자열을 char형 배열로 변환

                    string output = "";

                    for (int i = 0; i < a.Length; i++) // a의 길이만큼 반복(32767)
                    {
                        if (a[i] == '\0') // a[i]가 공백인지 검사
                            break; // 반복 종료
                        output += (char)(a[i] - Pnum);// a[i]의 아스키 값에서 -1한 문자를 output에 추가
                    }


                    StreamWriter writer_;
                    String strFilePath = saveFileDialog1.FileName;
                    writer_ = File.CreateText(strFilePath);
                    writer_.Write(output);
                    writer_.Close();

                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                if (textBox4.Text == "")
                {
                    Pnum = 300;
                }
                else
                {
                    Pnum = int.Parse(textBox4.Text);
                }
            }catch(Exception ex)
            {
                timer2.Stop();
                MessageBox.Show(ex.ToString());
                MessageBox.Show("타이머가 정지되었습니다.");
                textBox4.Clear();
            }
            char[] a = new char[32767]; // 배열 선언
            a = textBox2.Text.ToCharArray(); // 문자열을 char형 배열로 변환

            string output = "";

            for (int i = 0; i < a.Length; i++) // a의 길이만큼 반복(32767)
            {
                if (a[i] == '\0') // a[i]가 공백인지 검사
                    break; // 반복 종료
                output += (char)(a[i] - Pnum);// a[i]의 아스키 값에서 -1한 문자를 output에 추가
            }

            textBox3.Text = output;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(pictureBox1.Visible == true)
            {
                pictureBox1.Visible = false;
                button6.Text = "숨기기";
            }
            else
            {
                pictureBox1.Visible = true;
                button6.Text = "보이기";
            }
        }

/*        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (password != true)
            {
                try
                {
                    System.Diagnostics.Process.Start("banner.bat");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }*/
    }
}
