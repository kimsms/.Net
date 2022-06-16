using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace freeStudy
{
    public partial class Form1 : Form
    {
        string a = "\\";
        bool pip = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            string file_path = null;
            openFileDialog1.InitialDirectory = "C:\\";
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                file_path = openFileDialog1.FileName;
                textBox1.Text = file_path;
                textBox2.Text = file_path.Replace(a, a+a);
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            string file_path = null;
            if(folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                file_path = folderBrowserDialog1.ToString();
                textBox1.Text = file_path;
                textBox2.Text = file_path.Replace(".", a + a);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox2.Text == "")
            {
                MessageBox.Show("경로를 설정해주세요.");
            }
            else
            {
                Clipboard.SetText(textBox2.Text);
                MessageBox.Show("복사되었습니다.");
                textBox3.Text = textBox2.Text;
            }
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(pip == false)
            {
                this.TopMost = true;
                pip = true;
            }
            else
            {
                this.TopMost = false;
                pip = false;
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("경로를 설정해주세요.");
            }
            else
            {
                Clipboard.SetText(textBox1.Text);
                MessageBox.Show("복사되었습니다.");
                textBox3.Text = textBox1.Text;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                MessageBox.Show("경로를 설정해주세요.");
            }
            else
            {
                Clipboard.SetText(textBox3.Text);
                MessageBox.Show("복사되었습니다.");
            }
        }

   
    }
}
