using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImageClass;

namespace ImageSaveDllTester
{
    public partial class Form1 : Form
    {
        ImageTools it = new ImageTools();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            it.Save(pictureBox1.Image);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < numericUpDown1.Value; i++)
            {
                it.Save(pictureBox1.Image);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            it.SetPath();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            it.Stop();
        }
    }
}
