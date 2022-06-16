using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
    public partial class Form1 : Form
    {
        bool LoadPicture;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //pictureBox1.ImageLocation = textBox1.Text;
            //LoadPicture = true;
            
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Load(openFileDialog1.FileName);
                LoadPicture = true;
            }
            
        }

       public void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && LoadPicture == true)
            {
                Bitmap bmp = (Bitmap)pictureBox1.Image;
                bmp.Save(textBox1.Text + ".png");
                bmp.Save(textBox1.Text + ".jpg");
                MessageBox.Show("저장되었습니다.");
            }
            else if(LoadPicture == false)
            {
                MessageBox.Show("이미지를 불러오세요.");
            }
            else
            {
                MessageBox.Show("이름을 입력하세요");
            }
               
            
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string a = System.Windows.Forms.Application.StartupPath;
            System.Diagnostics.Process.Start(a);
            
        }
    }
}
